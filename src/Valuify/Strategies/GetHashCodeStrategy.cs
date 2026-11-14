namespace Valuify.Strategies
{
    using System.Collections.Generic;
    using System.Linq;
    using Valuify.Model;
    using static Valuify.Strategies.GetHashCodeStrategy_Resources;

    /// <summary>
    /// Generates the source needed to support <see cref="object.GetHashCode()"/>.
    /// </summary>
    internal sealed class GetHashCodeStrategy
        : IStrategy
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Generate(Subject subject)
        {
            if (!subject.CanOverrideGetHashCode)
            {
                yield break;
            }

            IEnumerable<string> properties = subject.Properties
                .Where(property => !property.IsIgnored)
                .Select(Format);

            string combine = string.Join(", ", properties);
            string code = string.Format(Source, subject.Qualification, combine);

            yield return new Source(code, nameof(GetHashCode));
        }

        private static string Format(Property property)
        {
            string format = property.UsesSequenceEquality ? SequenceHashCode : ValueHashCode;

            return string.Format(format, property.Name);
        }
    }
}