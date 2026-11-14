namespace Valuify.Visitors
{
    using System.Collections.Generic;
    using Graphify;
    using MooVC.Syntax.CSharp;
    using Valuify.Model;
    using Valuify.Syntax;

    using static Valuify.Visitors.GenerateInequalityOperatorWhenSubjectVisited_Resources;

    /// <summary>
    /// Generates the source needed to support the inequality operator.
    /// </summary>
    internal sealed class GenerateInequalityOperatorWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph instance)
        {
            Subject subject = ((IGraph<Subject>)instance).Root;

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