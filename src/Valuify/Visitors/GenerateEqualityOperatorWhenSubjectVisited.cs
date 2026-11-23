namespace Valuify.Visitors
{
    using System.Collections.Generic;
    using Graphify;
    using MooVC.Syntax;
    using MooVC.Syntax.CSharp;
    using Valuify.Model;
    using Valuify.Syntax;

    using static Valuify.Visitors.GenerateEqualityOperatorWhenSubjectVisited_Resources;

    /// <summary>
    /// Generates the source needed to support the equality operator.
    /// </summary>
    internal sealed class GenerateEqualityOperatorWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph instance)
        {
            Subject subject = ((IGraph<Subject>)instance).Root;

            if (subject.HasEqualityOperator)
            {
                yield break;
            }

            Comparison comparison = Comparison.Undefined
                .WithOperator(Comparison.Types.Equality)
                .WithBody(Snippet.From(Configuration.Options, Source));

            yield return subject.ToSource("Equality", comparison);
        }
    }
}