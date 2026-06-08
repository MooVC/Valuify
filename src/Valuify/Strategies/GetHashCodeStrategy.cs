namespace Valuify.Strategies
{
    using System.Collections.Generic;
    using System.Linq;
    using Valuify.Model;
    using static Valuify.Strategies.GetHashCodeStrategy_Resources;

    /// <summary>
    /// Generates the source needed to support <see cref="object.Equals(object)"/>.
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
            if (property.IsSequence && !property.IsImmutableArray && (property.IsEquatable || property.HasValuify))
            {
                return string.Format(SequenceHashCode, property.Name);
            }

            return property.Name;
        }
    }
}