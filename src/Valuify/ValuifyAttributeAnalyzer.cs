namespace Valuify
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Threading;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Diagnostics;
    using Valuify.Semantics;
    using Valuify.Syntax;
    using static Valuify.ValuifyAttributeAnalyzer_Resources;

    /// <summary>
    /// Analyzes usage of the ValuifyAttribute when applied to a class, ensuring the class adheres to the known constraints.
    /// </summary>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class ValuifyAttributeAnalyzer
        : AttributeAnalyzer<ValuifyAttributeAnalyzer_Resources>
    {
        /// <inheritdoc/>
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(
            CompatibleTargetTypeRule,
            PartialTypeRule,
            DefinesPropertiesRule,
            EqualityGuarenteeRule);

        /// <summary>
        /// Gets the descriptor associated with the compatible target type rule (VALFY01).
        /// </summary>
        /// <value>
        /// The descriptor associated with the compatible target type rule (VALFY01).
        /// </value>
        internal static DiagnosticDescriptor CompatibleTargetTypeRule { get; } = new DiagnosticDescriptor(
            "VALFY01",
            GetResourceString(ResourceManager, nameof(CompatibleTargetTypeRuleTitle)),
            GetResourceString(ResourceManager, nameof(CompatibleTargetTypeRuleMessageFormat)),
            "Usage",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: GetResourceString(ResourceManager, nameof(CompatibleTargetTypeRuleDescription)),
            helpLinkUri: GetHelpLinkUri("VALFY01"));

        /// <summary>
        /// Gets the descriptor associated with the partial type rule (VALFY02).
        /// </summary>
        /// <value>
        /// The descriptor associated with the partial type rule (VALFY02).
        /// </value>
        internal static DiagnosticDescriptor PartialTypeRule { get; } = new DiagnosticDescriptor(
            "VALFY02",
            GetResourceString(ResourceManager, nameof(PartialTypeRuleTitle)),
            GetResourceString(ResourceManager, nameof(PartialTypeRuleMessageFormat)),
            "Usage",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: GetResourceString(ResourceManager, nameof(PartialTypeRuleDescription)),
            helpLinkUri: GetHelpLinkUri("VALFY02"));

        /// <summary>
        /// Gets the descriptor associated with the defines properties rule (VALFY03).
        /// </summary>
        /// <value>
        /// The descriptor associated with the defines properties rule (VALFY03).
        /// </value>
        internal static DiagnosticDescriptor DefinesPropertiesRule { get; } = new DiagnosticDescriptor(
            "VALFY03",
            GetResourceString(ResourceManager, nameof(DefinesPropertiesTitle)),
            GetResourceString(ResourceManager, nameof(DefinesPropertiesMessageFormat)),
            "Design",
            DiagnosticSeverity.Info,
            isEnabledByDefault: true,
            description: GetResourceString(ResourceManager, nameof(DefinesPropertiesRuleDescription)),
            helpLinkUri: GetHelpLinkUri("VALFY03"));

        /// <summary>
        /// Gets the descriptor associated with the equality guarentee rule (VALFY05).
        /// </summary>
        /// <value>
        /// The descriptor associated with the equality guarentee rule (VALFY05).
        /// </value>
        internal static DiagnosticDescriptor EqualityGuarenteeRule { get; } = new DiagnosticDescriptor(
            "VALFY05",
            GetResourceString(ResourceManager, nameof(EqualityGuarenteeTitle)),
            GetResourceString(ResourceManager, nameof(EqualityGuarenteeMessageFormat)),
            "Design",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: GetResourceString(ResourceManager, nameof(EqualityGuarenteeRuleDescription)),
            helpLinkUri: GetHelpLinkUri("VALFY05"));

        /// <inheritdoc/>
        protected override void Analyze(AttributeSyntax attribute, SyntaxNodeAnalysisContext context, Location location)
        {
            if (IsViolatingCompatibleTargetTypeRule(attribute, out ClassDeclarationSyntax @class))
            {
                Raise(context, CompatibleTargetTypeRule, location);

                return;
            }

            if (IsViolatingPartialTypeRule(@class, out string identifier))
            {
                Raise(context, PartialTypeRule, location, identifier);

                return;
            }

            if (IsViolatingDefinesPropertiesRule(context, @class, out identifier, out INamedTypeSymbol symbol))
            {
                Raise(context, DefinesPropertiesRule, location, identifier);
            }

            if (IsViolatingEqualityGuarenteeRule(symbol, type => type.InheritsSealedEquals()))
            {
                Raise(context, EqualityGuarenteeRule, location, identifier, nameof(Equals));
            }

            if (IsViolatingEqualityGuarenteeRule(symbol, type => type.InheritsSealedGetHashCode()))
            {
                Raise(context, EqualityGuarenteeRule, location, identifier, nameof(GetHashCode));
            }
        }

        /// <inheritdoc/>
        protected override bool IsMatch(IMethodSymbol symbol)
        {
            return !(symbol.ContainingType is null)
                && symbol.ContainingType.IsValuify();
        }

        private static bool IsViolatingDefinesPropertiesRule(
            SyntaxNodeAnalysisContext context,
            ClassDeclarationSyntax @class,
            out string identifier,
            out INamedTypeSymbol symbol)
        {
            identifier = default;
            symbol = default;

            if (@class is null)
            {
                return true;
            }

            identifier = @class.Identifier.Text;
            symbol = context.SemanticModel.GetDeclaredSymbol(@class, cancellationToken: context.CancellationToken);

            return symbol is null || !symbol.HasProperties(context.Compilation, property => !property.IsIgnored);
        }

        private static bool IsViolatingCompatibleTargetTypeRule(AttributeSyntax attribute, out ClassDeclarationSyntax @class)
        {
            @class = attribute.Parent?.Parent as ClassDeclarationSyntax;

            return @class is null;
        }

        private static bool IsViolatingPartialTypeRule(TypeDeclarationSyntax parent, out string identifier)
        {
            identifier = default;

            while (!(parent is null))
            {
                if (!parent.IsPartial())
                {
                    identifier = parent.Identifier.Text;

                    return true;
                }

                parent = parent.Parent as TypeDeclarationSyntax;
            }

            return false;
        }

        private static bool IsViolatingEqualityGuarenteeRule(INamedTypeSymbol @class, Predicate<INamedTypeSymbol> predicate)
        {
            return !(@class is null) && predicate(@class);
        }
    }
}