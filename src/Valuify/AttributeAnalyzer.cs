namespace Valuify;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using static Valuify.ValuifyAttributeAnalyzer_Resources;

/// <summary>
/// Serves as a base for analyzers.
/// </summary>
/// <typeparam name="TResource">
/// The type associated with the resources for the analyzer.
/// </typeparam>
public abstract class AttributeAnalyzer<TResource>
    : DiagnosticAnalyzer
{
    private const string Branch = "master";

    /// <inheritdoc/>
    public sealed override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.Attribute);
    }

    /// <summary>
    /// Reports a diagnostic message associated with the <paramref name="descriptor"/> at the specified <paramref name="location"/>.
    /// </summary>
    /// <param name="context">
    /// The context to which the report will be issued.
    /// </param>
    /// <param name="descriptor">
    /// The diagnostic descriptor to report.
    /// </param>
    /// <param name="location">
    /// The location at which the issue was identified.
    /// </param>
    /// <param name="messageArgs">
    /// Any parameters associated with the descriptor.
    /// </param>
    protected static void Raise(SyntaxNodeAnalysisContext context, DiagnosticDescriptor descriptor, Location location, params object?[] messageArgs)
    {
        var diagnostic = Diagnostic.Create(descriptor, location, messageArgs);

        context.ReportDiagnostic(diagnostic);
    }

    /// <summary>
    /// Gets the fully qualified URL for the documentation associated with the rule denoted by <paramref name="ruleId"/>.
    /// </summary>
    /// <param name="ruleId">
    /// The unique id of the rule.
    /// </param>
    /// <returns>
    /// The fully qualified URL for the documentation associated with the rule denoted by <paramref name="ruleId"/>.
    /// </returns>
    protected static string GetHelpLinkUri(string ruleId)
    {
        return $"https://github.com/MooVC/Valuify/blob/{Branch}/docs/rules/{ruleId}.md";
    }

    /// <summary>
    /// Gets the localzed resource string associated with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="name">
    /// The name of the resource string to retrieve.
    /// </param>
    /// <returns>
    /// The localzed resource string associated with the specified <paramref name="name"/>.
    /// </returns>
    protected static LocalizableResourceString GetResourceString(string name)
    {
        return new(name, ResourceManager, typeof(TResource));
    }

    /// <summary>
    /// Gets the <see cref="IMethodSymbol"/> associated with the <paramref name="syntax"/>.
    /// </summary>
    /// <param name="context">
    /// The analysis context from which the semantic model is obtained.
    /// </param>
    /// <param name="syntax">
    /// The attribute for which the symbol is to be retrieved.
    /// </param>
    /// <returns>
    /// The <see cref="IMethodSymbol"/> associated with the <paramref name="syntax"/>.
    /// </returns>
    protected static IMethodSymbol? GetSymbol(SyntaxNodeAnalysisContext context, AttributeSyntax syntax)
    {
        return context
            .SemanticModel
            .GetSymbolInfo(syntax, cancellationToken: context.CancellationToken)
            .Symbol as IMethodSymbol;
    }

    /// <summary>
    /// Analyses the location at which the matching attribute has been detected.
    /// </summary>
    /// <param name="attribute">
    /// The syntax for the detected attribute.
    /// </param>
    /// <param name="context">
    /// The analysis context, providing access to the semantic model and facilitating reporting.
    /// </param>
    /// <param name="location">
    /// The location at which the attribute was identified.
    /// </param>
    protected abstract void Analyze(AttributeSyntax attribute, SyntaxNodeAnalysisContext context, Location location);

    /// <summary>
    /// Determines whether or not the <paramref name="symbol"/> is a match for the required attribute.
    /// </summary>
    /// <param name="symbol">
    /// The symbol to check.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the <paramref name="symbol"/> is a match, otherwise <see langword="false"/>.
    /// </returns>
    protected abstract bool IsMatch(IMethodSymbol symbol);

    private void AnalyzeNode(SyntaxNodeAnalysisContext context)
    {
        if (context.Node is not AttributeSyntax attribute)
        {
            return;
        }

        IMethodSymbol? symbol = GetSymbol(context, attribute);

        if (symbol is null || !IsMatch(symbol))
        {
            return;
        }

        Location location = attribute.GetLocation();

        Analyze(attribute, context, location);
    }
}