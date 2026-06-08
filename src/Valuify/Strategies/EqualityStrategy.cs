namespace Valuify.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Valuify.Model;
    using static Valuify.Strategies.EqualityStrategy_Resources;

    /// <summary>
    /// Generates the source needed to support the equality operator.
    /// </summary>
    internal sealed class EqualityStrategy
        : IStrategy
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Generate(Subject subject)
        {
            if (subject.HasEqualityOperator)
            {
                yield break;
            }

            string code = string.Format(Source, subject.Qualification);

            yield return new Source(code, "Equality");
        }
    }
}