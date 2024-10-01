namespace Valuify.Snippets;

using System.Diagnostics;
using Microsoft.CodeAnalysis.Testing;

[DebuggerDisplay("{Hint,nq}")]
public sealed record Generated(string Content, Extensions Extensions, string Hint, Type? Generator = default)
{
    public void IsExpectedIn(SolutionState state)
    {
        Type generator = Generator ?? typeof(ClassGenerator);

        state.GeneratedSources.Add((sourceGeneratorType: generator, filename: $"{Hint}.g.cs", content: Content));
    }
}