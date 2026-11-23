namespace Valuify.Visitors
{
    using System.Collections.Generic;
    using System.Linq;
    using Graphify;
    using MooVC.Syntax.CSharp;
    using Valuify.Model;
    using Valuify.Syntax;

    using static Valuify.Visitors.GenerateGetHashCodeOverrideWhenSubjectVisited_Resources;
    using Property = Valuify.Model.Property;

    /// <summary>
    /// Generates the source needed to support <see cref="object.GetHashCode()"/>.
    /// </summary>
    internal sealed class GenerateGetHashCodeOverrideWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph instance)
        {
            Subject subject = ((IGraph<Subject>)instance).Root;

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
            string format = property.UsesSequenceEquality ? SequenceHashCode : ValueHashCode;

            return string.Format(format, property.Name);
        }
    }
}