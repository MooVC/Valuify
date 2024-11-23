namespace Valuify;

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Valuify.Semantics;
using Valuify.Syntax;
using static Valuify.AttributeAnalyzer_Resources;

/// <summary>
/// Analyzes usage of the ValuifyAttribute when applied to a class, ensuring the class adheres to the known constraints.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class AttributeAnalyzer
    : DiagnosticAnalyzer
{
    private const string Branch = "master";

    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
    [
        CompatibleTargetTypeRule,
        PartialTypeRule,
        DefinesPropertiesRule,
    ];

    /// <summary>
    /// Gets the descriptor associated with the compatible target type rule (VALFY01).
    /// </summary>
    /// <value>
    /// The descriptor associated with the compatible target type rule (VALFY01).
    /// </value>
    internal static DiagnosticDescriptor CompatibleTargetTypeRule { get; } = new(
        "VALFY01",
        GetResourceString(nameof(CompatibleTargetTypeRuleTitle)),
        GetResourceString(nameof(CompatibleTargetTypeRuleMessageFormat)),
        "Usage",
        DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: GetResourceString(nameof(CompatibleTargetTypeRuleDescription)),
        helpLinkUri: GetHelpLinkUri("VALFY01"));

    /// <summary>
    /// Gets the descriptor associated with the partial type rule (VALFY02).
    /// </summary>
    /// <value>
    /// The descriptor associated with the partial type rule (VALFY02).
    /// </value>
    internal static DiagnosticDescriptor PartialTypeRule { get; } = new(
        "VALFY02",
        GetResourceString(nameof(PartialTypeRuleTitle)),
        GetResourceString(nameof(PartialTypeRuleMessageFormat)),
        "Usage",
        DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: GetResourceString(nameof(PartialTypeRuleDescription)),
        helpLinkUri: GetHelpLinkUri("VALFY02"));

    /// <summary>
    /// Gets the descriptor associated with the defines properties rule (VALFY03).
    /// </summary>
    /// <value>
    /// The descriptor associated with the defines properties rule (VALFY03).
    /// </value>
    internal static DiagnosticDescriptor DefinesPropertiesRule { get; } = new(
        "VALFY03",
        GetResourceString(nameof(DefinesPropertiesTitle)),
        GetResourceString(nameof(DefinesPropertiesMessageFormat)),
        "Design",
        DiagnosticSeverity.Info,
        isEnabledByDefault: true,
        description: GetResourceString(nameof(DefinesPropertiesRuleDescription)),
        helpLinkUri: GetHelpLinkUri("VALFY03"));

    /// <inheritdoc/>
    public sealed override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.Attribute);
    }

    private static void Raise(SyntaxNodeAnalysisContext context, DiagnosticDescriptor descriptor, Location location, params object?[] messageArgs)
    {
        var diagnostic = Diagnostic.Create(descriptor, location, messageArgs);

        context.ReportDiagnostic(diagnostic);
    }

    private static void Analyze(AttributeSyntax attribute, SyntaxNodeAnalysisContext context, Location location)
    {
        if (IsViolatingCompatibleTargetTypeRule(attribute, out ClassDeclarationSyntax? @class))
        {
            Raise(context, CompatibleTargetTypeRule, location);

            return;
        }

        if (IsViolatingPartialTypeRule(@class, out string? identifier))
        {
            Raise(context, PartialTypeRule, location, identifier);

            return;
        }

        if (IsViolatingDefinesPropertiesRule(context, @class, out identifier))
        {
            Raise(context, DefinesPropertiesRule, location, identifier);
        }
    }

    private static bool IsViolatingDefinesPropertiesRule(SyntaxNodeAnalysisContext context, ClassDeclarationSyntax? @class, out string? identifier)
    {
        identifier = default;

        if (@class is null)
        {
            return true;
        }

        identifier = @class.Identifier.Text;
        INamedTypeSymbol? symbol = context.SemanticModel.GetDeclaredSymbol(@class, cancellationToken: context.CancellationToken);

        return symbol is null || !symbol.HasProperties();
    }

    private static void AnalyzeNode(SyntaxNodeAnalysisContext context)
    {
        if (context.Node is not AttributeSyntax attribute)
        {
            return;
        }

        IMethodSymbol? symbol = GetSymbol(context, attribute);

        if (symbol is null || !IsValuify(symbol))
        {
            return;
        }

        Location location = attribute.GetLocation();

        Analyze(attribute, context, location);
    }

    private static string GetHelpLinkUri(string ruleId)
    {
        return $"https://github.com/MooVC/Valuify/blob/{Branch}/docs/rules/{ruleId}.md";
    }

    private static LocalizableResourceString GetResourceString(string name)
    {
        return new(name, ResourceManager, typeof(AttributeAnalyzer_Resources));
    }

    private static IMethodSymbol? GetSymbol(SyntaxNodeAnalysisContext context, AttributeSyntax syntax)
    {
        return context
            .SemanticModel
            .GetSymbolInfo(syntax, cancellationToken: context.CancellationToken)
            .Symbol as IMethodSymbol;
    }

    private static bool IsViolatingCompatibleTargetTypeRule(AttributeSyntax attribute, out ClassDeclarationSyntax? @class)
    {
        @class = attribute.Parent?.Parent as ClassDeclarationSyntax;

        return @class is null;
    }

    private static bool IsViolatingPartialTypeRule(TypeDeclarationSyntax? parent, out string? identifier)
    {
        identifier = default;

        while (parent is not null)
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

    private static bool IsValuify(IMethodSymbol symbol)
    {
        return symbol.ContainingType is not null
            && symbol.ContainingType.IsValuify();
    }
}