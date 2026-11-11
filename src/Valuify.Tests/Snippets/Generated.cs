namespace Valuify.Snippets;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;

[DebuggerDisplay("{Hint,nq}")]
public sealed record Generated(string Content, Extensions Extensions, string Hint, Type? Generator = default)
{
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1316:Tuple element names should use correct casing", Justification = "Casing matches declaration.")]
    public void IsExpectedIn(SolutionState state)
    {
        Type generator = Generator ?? typeof(ClassGenerator);
        SourceHashAlgorithm checksumAlgorithm = generator == typeof(ClassGenerator) ? SourceHashAlgorithm.Sha256 : SourceHashAlgorithm.Sha1;
        var content = SourceText.From(Content, Encoding.UTF8, checksumAlgorithm);

        state.GeneratedSources.Add((sourceGeneratorType: generator, filename: $"{Hint}.g.cs", content));
    }
}