namespace Valuify.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis.CSharp;
    using Valuify.Model;
    using static Valuify.Strategies.EquatableStrategy_Resources;

    /// <summary>
    /// Generates the source needed to support <see cref="IEquatable{T}"/>.
    /// </summary>
    internal sealed class EquatableStrategy
        : IStrategy
    {
        private static readonly string _conditional = string.Concat(SyntaxFactory.ElasticCarriageReturnLineFeed, "            && ");

        /// <inheritdoc/>
        public IEnumerable<Source> Generate(Subject subject)
        {
            if (!subject.IsEquatable)
            {
                yield return GenerateContract(subject);
            }

            if (!subject.HasEquatable)
            {
                yield return GenerateImplementation(subject);
            }
        }

        private static Source GenerateContract(Subject subject)
        {
            string code = string.Format(Contract, subject.Qualification);

            return new Source(code, "IEquatable");
        }

        private static Source GenerateImplementation(Subject subject)
        {
            string conditions = "true";

            if (subject.Properties.Count > 0)
            {
                IEnumerable<string> properties = subject.Properties
                    .Where(property => !property.IsIgnored)
                    .Select(property => string.Format(PropertyCondition, GetComparer(property), property.Name));

                conditions = string.Join(_conditional, properties);
            }

            string code = string.Format(Implementation, subject.Qualification, conditions);

            return new Source(code, string.Concat("IEquatable.", nameof(Equals)));
        }

        private static string GetComparer(Property property)
        {
            return ShouldUseSequenceComparer(property)
                ? SequenceComparer
                : string.Format(EqualityComparer, property.Type);
        }

        private static bool ShouldUseSequenceComparer(Property property)
        {
            return property.IsSequence && (property.IsImmutableArray || !(property.IsEquatable || property.HasValuify));
        }
    }
}