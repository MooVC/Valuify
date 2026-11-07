namespace Valuify.Snippets;

using System.Diagnostics;
using System.Text;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;

[DebuggerDisplay("{Hint,nq}")]
public sealed record Generated(string Content, Extensions Extensions, string Hint, Type? Generator = default)
{
    public void IsExpectedIn(SolutionState state)
    {
        Type generator = Generator ?? typeof(ClassGenerator);
        SourceHashAlgorithm checksumAlgorithm = generator == typeof(ClassGenerator) ? SourceHashAlgorithm.Sha256 : SourceHashAlgorithm.Sha1;
        var content = SourceText.From(Content, Encoding.UTF8, checksumAlgorithm);

        state.GeneratedSources.Add((sourceGeneratorType: generator, filename: $"{Hint}.g.cs", content: content));
    }
}