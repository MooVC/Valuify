namespace Valuify.Snippets;

using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

[DebuggerDisplay("{Name,nq}")]
public sealed record Declared(string Content, LanguageVersion Minimum, LanguageVersion Maximum, string Name, params Generated[] Expected)
{
    public Declared(string[] content, LanguageVersion minimum, LanguageVersion maximum, string name, params Generated[] expected)
        : this(string.Join(Environment.NewLine, content), minimum, maximum, name, expected)
    {
    }

    public void IsDeclaredIn(SolutionState state)
    {
        state.Sources.Add(Content);

        foreach (Generated expected in Expected)
        {
            expected.IsExpectedIn(state);
        }
    }
}