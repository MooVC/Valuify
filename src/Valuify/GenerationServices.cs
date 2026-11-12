namespace Valuify
{
    using System;
    using System.Collections.Generic;
    using Valuify.Model;
    using Valuify.Visitors;

    /// <summary>
    /// Provides the source generation visitors to the model navigator.
    /// </summary>
    internal sealed class GenerationServices
        : IServiceProvider
    {
        private static readonly ISubjectVisitor<Subject.Graph.Self, Source>[] _visitors =
        {
            new GenerateEqualityOperatorWhenSubjectVisited(),
            new GenerateEqualsOverrideWhenSubjectVisited(),
            new GenerateEquatableMembersWhenSubjectVisited(),
            new GenerateGetHashCodeOverrideWhenSubjectVisited(),
            new GenerateInequalityOperatorWhenSubjectVisited(),
            new GenerateToStringOverrideWhenSubjectVisited(),
        };

        /// <inheritdoc/>
        public object GetService(Type serviceType)
        {
            return serviceType == typeof(IEnumerable<ISubjectVisitor<Subject.Graph.Self, Source>>) ? _visitors : null;
        }
    }
}