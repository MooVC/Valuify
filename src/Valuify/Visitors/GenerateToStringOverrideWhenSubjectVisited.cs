namespace Valuify.Visitors
{
    using System.Collections.Generic;
    using System.Linq;
    using MooVC.Syntax.CSharp;
    using Valuify.Model;
    using Valuify.Syntax;

    using static Valuify.Strategies.ToStringStrategy_Resources;
    using Property = Valuify.Model.Property;

    /// <summary>
    /// Generates the source needed to support <see cref="object.ToString()"/>.
    /// </summary>
    internal sealed class GenerateToStringOverrideWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph.Self, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Self instance)
        {
            Subject subject = instance._Value;

            if (!subject.CanOverrideToString)
            {
                yield break;
            }

            string value = string.Format(EmptyValue, subject.Name);

            Property[] properties = subject.Properties
                .Where(property => !property.IsIgnored)
                .ToArray();

            if (properties.Length > 0)
            {
                IEnumerable<string> values = properties.Select((property, index) => string.Format(PropertyValue, property.Name, index));
                string format = string.Format(Format, subject.Name, string.Join(", ", values));
                IEnumerable<string> names = properties.Select(property => property.Name);
                string parameters = string.Join(", ", names);

                value = string.Format(Value, format, parameters);
            }

            Method method = Method.Undefined
                .Named(nameof(ToString))
                .WithExtensibility(Modifiers.Override)
                .Returns(Result.Void.OfType(typeof(string)))
                .WithBody(string.Format(Body, value));

            yield return subject.ToSource(nameof(ToString), method);
        }
    }
}