namespace Valuify.Snippets;

using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

[DebuggerDisplay("{Minimum,nq}")]
public sealed record Expectations(string[] Declarations, Generated[] Generated, LanguageVersion Minimum)
{
    public void IsDeclaredIn(SolutionState state)
    {
        foreach (string declaration in Declarations)
        {
            state.Sources.Add(declaration);
        }

        foreach (Generated generated in Generated)
        {
            generated.IsExpectedIn(state);
        }
    }
}