namespace Valuify.Visitors
{
    using System.Collections.Generic;
    using Graphify;
    using MooVC.Syntax.CSharp;
    using Valuify.Model;
    using Valuify.Syntax;

    using static Valuify.Visitors.GenerateEqualsOverrideWhenSubjectVisited_Resources;

    /// <summary>
    /// Generates the source needed to support <see cref="object.Equals(object)"/>.
    /// </summary>
    internal sealed class GenerateEqualsOverrideWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph instance)
        {
            Subject subject = ((IGraph<Subject>)instance).Root;

            if (!subject.CanOverrideEquals)
            {
                yield break;
            }

            Method method = Method.Undefined
                .Named(nameof(Equals))
                .WithExtensibility(Modifiers.Override)
                .Accepts(parameter => parameter.Named("Other").OfType(typeof(object)))
                .Returns(Result.Void.OfType(typeof(bool)))
                .WithBody(string.Format(Source, subject.Type));

            yield return subject.ToSource(nameof(Equals), method);
        }
    }
}