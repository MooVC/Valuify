namespace Valuify.Visitors
{
    using System.Collections.Generic;
    using MooVC.Syntax.CSharp;
    using Valuify.Model;
    using Valuify.Syntax;

    using static Valuify.Strategies.InequalityStrategy_Resources;

    /// <summary>
    /// Generates the source needed to support the inequality operator.
    /// </summary>
    internal sealed class GenerateInequalityOperatorWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph.Self, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Self instance)
        {
            Subject subject = instance._Value;

            if (subject.HasInequalityOperator)
            {
                yield break;
            }

            Comparison comparison = Comparison.Undefined
                .WithOperator(Comparison.Types.Inequality)
                .WithBody(Source);

            yield return subject.ToSource("Inequality", comparison);
        }
    }
}