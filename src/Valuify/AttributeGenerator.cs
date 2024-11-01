﻿namespace Valuify;

using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

/// <summary>Generates the Valuify attribute, used to denote when a class should exhibit record-like behavior.</summary>
[Generator(LanguageNames.CSharp)]
public sealed class AttributeGenerator
    : IIncrementalGenerator
{
    /// <summary>The source code that will be output by the generator.</summary>
    internal const string Content = $$"""
        namespace Valuify
        {
            using System;
            using System.Diagnostics.CodeAnalysis;

            [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
            internal sealed class ValuifyAttribute
                : Attribute
            {
            }
        }
        """;

    /// <summary>The hint name used for the code generated by the generator.</summary>
    internal const string Hint = $"ValuifyAttribute.g.cs";

    /// <inheritdoc/>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(Generate);
    }

    private static void Generate(IncrementalGeneratorPostInitializationContext context)
    {
        var text = SourceText.From(Content, Encoding.UTF8);

        context.AddSource(Hint, text);
    }
}