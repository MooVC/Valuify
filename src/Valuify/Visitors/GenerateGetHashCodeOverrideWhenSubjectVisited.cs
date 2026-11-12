namespace Valuify.Visitors
{
    using System.Collections.Generic;
    using System.Linq;
    using MooVC.Syntax.CSharp;
    using Valuify.Model;
    using Valuify.Syntax;

    using static Valuify.Strategies.GetHashCodeStrategy_Resources;
    using Property = Valuify.Model.Property;

    /// <summary>
    /// Generates the source needed to support <see cref="object.GetHashCode()"/>.
    /// </summary>
    internal sealed class GenerateGetHashCodeOverrideWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph.Self, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Self instance)
        {
            Subject subject = instance._Value;

            if (!subject.CanOverrideGetHashCode)
            {
                yield break;
            }

            IEnumerable<string> properties = subject.Properties
                .Where(property => !property.IsIgnored)
                .Select(Format);

            string combine = string.Join(", ", properties);

            Method method = Method.Undefined
                .Named(nameof(GetHashCode))
                .WithExtensibility(Modifiers.Override)
                .Returns(Result.Void.OfType(typeof(int)))
                .WithBody(string.Format(Body, combine));

            yield return subject.ToSource(nameof(GetHashCode), method);
        }

        private static string Format(Property property)
        {
            if (property.IsSequence && !property.IsImmutableArray && (property.IsEquatable || property.HasValuify))
            {
                return string.Format(SequenceHashCode, property.Name);
            }

            return property.Name;
        }
    }
}