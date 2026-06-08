namespace Valuify.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Valuify.Model;
    using static Valuify.Strategies.ToStringStrategy_Resources;

    /// <summary>
    /// Generates the source needed to support <see cref="object.ToString()"/>.
    /// </summary>
    internal sealed class ToStringStrategy
        : IStrategy
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Generate(Subject subject)
        {
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

            string code = string.Format(Source, subject.Qualification, value);

            yield return new Source(code, nameof(ToString));
        }
    }
}