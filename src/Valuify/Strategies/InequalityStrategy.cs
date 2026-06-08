namespace Valuify.Strategies
{
    using System.Collections.Generic;
    using Valuify.Model;
    using static Valuify.Strategies.InequalityStrategy_Resources;

    /// <summary>
    /// Generates the source needed to support the inequality operator.
    /// </summary>
    internal sealed class InequalityStrategy
        : IStrategy
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Generate(Subject subject)
        {
            if (subject.HasInequalityOperator)
            {
                yield break;
            }

            string code = string.Format(Source, subject.Qualification);

            yield return new Source(code, "Inequality");
        }
    }
}