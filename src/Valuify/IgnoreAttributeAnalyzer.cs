namespace Valuify;

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Valuify.Semantics;
using Valuify.Syntax;
using static Valuify.IgnoreAttributeAnalyzer_Resources;

/// <summary>
/// Analyzes usage of the IgnoreAttribute when applied to a property, ensuring the property adheres to the known constraints.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class IgnoreAttributeAnalyzer
    : AttributeAnalyzer<IgnoreAttributeAnalyzer_Resources>
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(MissingValuifyRule);

    /// <summary>
    /// Gets the descriptor associated with the missing valuify rule (VALFY04).
    /// </summary>
    /// <value>
    /// The descriptor associated with the missing valuify rule (VALFY04).
    /// </value>
    internal static DiagnosticDescriptor MissingValuifyRule { get; } = new(
        "VALFY04",
        GetResourceString(ResourceManager, nameof(MissingValuifyRuleTitle)),
        GetResourceString(ResourceManager, nameof(MissingValuifyRuleMessageFormat)),
        "Usage",
        DiagnosticSeverity.Info,
        isEnabledByDefault: true,
        description: GetResourceString(ResourceManager, nameof(MissingValuifyRuleDescription)),
        helpLinkUri: GetHelpLinkUri("VALFY04"));

    /// <inheritdoc/>
    protected override void Analyze(AttributeSyntax attribute, SyntaxNodeAnalysisContext context, Location location)
    {
        if (IsViolatingMissingValuifyRule(attribute, context, out string @class))
        {
            Raise(context, MissingValuifyRule, location, @class);
        }
    }

    /// <inheritdoc/>
    protected override bool IsMatch(IMethodSymbol symbol)
    {
        return symbol.ContainingType is not null
            && symbol.ContainingType.IsIgnore();
    }

    private static bool IsViolatingMissingValuifyRule(AttributeSyntax attribute, SyntaxNodeAnalysisContext context, out string @class)
    {
        if (attribute is null)
        {
            throw new ArgumentNullException(nameof(attribute));
        }

        ISymbol? parent = attribute.GetParent<TypeDeclarationSyntax>(context);

        if (parent is not INamedTypeSymbol type || type.HasValuify())
        {
            @class = string.Empty;

            return false;
        }

        @class = type.Name;

        return true;
    }
}