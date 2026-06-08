namespace Valuify.Semantics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Provides extensions relating to <see cref="ISymbol"/>.
    /// </summary>
    internal static partial class ISymbolExtensions
    {
        /// <summary>
        /// Determines whether or not the <paramref name="symbol"/> represents the attribute specified using <paramref name="name"/>.
        /// </summary>
        /// <param name="symbol">
        /// The symbol to check.
        /// </param>
        /// <param name="name">
        /// The name of the attribute (without the suffix).
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the <paramref name="symbol"/> is the Valuify attribute, otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsAttribute(this ISymbol symbol, string name)
        {
            string fullyQualifiedName = $"Valuify.{name}Attribute";
            string globalQualifiedName = $"global::{fullyQualifiedName}";

            bool IsGlobal()
            {
                return symbol.ContainingNamespace.IsGlobalNamespace && symbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat) == name;
            }

            bool IsQualified()
            {
                string qualifiedName = symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);

                return qualifiedName == fullyQualifiedName || qualifiedName == globalQualifiedName;
            }

            return !(symbol is null)
                && (IsQualified() || IsGlobal());
        }
    }
}