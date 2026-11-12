namespace Valuify.Visitors
{
    using System.Collections.Generic;
    using MooVC.Syntax.CSharp;
    using Valuify.Model;
    using Valuify.Syntax;

    using static Valuify.Strategies.EqualsStrategy_Resources;

    /// <summary>
    /// Generates the source needed to support <see cref="object.Equals(object)"/>.
    /// </summary>
    internal sealed class GenerateEqualsOverrideWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph.Self, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Self instance)
        {
            Subject subject = instance._Value;

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