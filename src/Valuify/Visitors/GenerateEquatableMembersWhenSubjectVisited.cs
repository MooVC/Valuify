namespace Valuify.Visitors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MooVC.Syntax;
    using MooVC.Syntax.CSharp;
    using Valuify.Model;
    using Valuify.Syntax;

    using static Valuify.Strategies.EquatableStrategy_Resources;
    using Property = Valuify.Model.Property;

    /// <summary>
    /// Generates the source needed to support <see cref="IEquatable{T}"/>.
    /// </summary>
    internal sealed class GenerateEquatableMembersWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph.Self, Source>
    {
        private const string Conditional = "\n    && ";

        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Self instance)
        {
            Subject subject = instance._Value;

            if (!subject.IsEquatable)
            {
                Symbol contract = MakeGeneric(typeof(IEquatable<>), subject.Type);

                yield return subject.ToSource("IEquatable", contract);
            }

            if (!subject.HasEquatable)
            {
                yield return GenerateImplementation(subject);
            }
        }

        private static Source GenerateImplementation(Subject subject)
        {
            IEnumerable<string> comparisons = subject.Properties
                .Where(property => !property.IsIgnored)
                .Select(property => string.Format(PropertyCondition, GetComparer(property), property.Name));

            string conditions = string.Join(Conditional, comparisons.DefaultIfEmpty("true"));
            Snippet body = Snippet.From(Configuration.Options, string.Format(Body, conditions));
            Symbol parameterType = (Qualification)(Moniker)subject.Type;
            const string Hint = "IEquatable.Equals";

            if (!PreservesSpelling(parameterType, subject.Type))
            {
                string declaration = $"public bool {nameof(Equals)}({subject.Type} other)";

                return subject.ToSource(Hint, body.Block(Configuration.Options, declaration));
            }

            Method method = Method.Undefined
                .Named(nameof(Equals))
                .Accepts(parameter => parameter.Named("Other").OfType(parameterType))
                .Returns(Result.Void.OfType(typeof(bool)))
                .WithBody(body);

            return subject.ToSource(Hint, method);
        }

        private static string GetComparer(Property property)
        {
            Symbol comparer = ShouldUseSequenceComparer(property)
                ? (Symbol)(Name: "SequenceEqualityComparer", Qualifier: "Valuify.Internal")
                : MakeGeneric(typeof(EqualityComparer<>), property.Type);

            return comparer.ToSnippet(Configuration.Options);
        }

        private static Symbol MakeGeneric(System.Type definition, string argument)
        {
            Symbol type = (Qualification)(Moniker)argument;

            // MooVC can shorten a type name ending in Attribute. Keep Roslyn's spelling in that case.
            if (PreservesSpelling(type, argument))
            {
                return type.As(definition);
            }

            Symbol generic = definition;
            return (Qualification)(Moniker)$"{generic.ToSnippet(Configuration.Options)}<{argument}>";
        }

        private static bool PreservesSpelling(Symbol type, string spelling)
        {
            return string.Equals(type.ToSnippet(Configuration.Options), spelling, StringComparison.Ordinal);
        }

        private static bool ShouldUseSequenceComparer(Property property)
        {
            return property.IsSequence && (property.IsImmutableArray || !(property.IsEquatable || property.HasValuify));
        }
    }
}