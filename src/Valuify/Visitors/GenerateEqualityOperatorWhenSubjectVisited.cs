namespace Valuify.Visitors
{
    using System.Collections.Generic;
    using MooVC.Syntax;
    using MooVC.Syntax.CSharp;
    using Valuify.Model;
    using Valuify.Syntax;

    using static Valuify.Strategies.EqualityStrategy_Resources;

    /// <summary>
    /// Generates the source needed to support the equality operator.
    /// </summary>
    internal sealed class GenerateEqualityOperatorWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph.Self, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Self instance)
        {
            Subject subject = instance._Value;

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