namespace Valuify.Strategies
{
    using System.Collections.Generic;
    using Valuify.Model;
    using static Valuify.Strategies.EqualsStrategy_Resources;

    /// <summary>
    /// Generates the source needed to support <see cref="object.Equals(object)"/>.
    /// </summary>
    internal sealed class EqualsStrategy
        : IStrategy
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Generate(Subject subject)
        {
            if (!subject.CanOverrideEquals)
            {
                yield break;
            }

            string code = string.Format(Source, subject.Qualification);

            yield return new Source(code, nameof(Equals));
        }
    }
}