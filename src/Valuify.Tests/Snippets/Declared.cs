namespace Valuify.Snippets;

using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

[DebuggerDisplay("{Name,nq}")]
public sealed record Declared(Content[] Content, Generated[] Expected, string Name, Content Template)
{
    public const string BodyTag = "__BODY__";

    public Declared(Content content, Generated[] expected, string name)
        : this([], expected, name, content)
    {
    }

    public void IsDeclaredIn(string content, SolutionState state)
    {
        state.Sources.Add(content);

        foreach (Generated expected in Expected)
        {
            expected.IsExpectedIn(state);
        }
    }

    public IEnumerable<Content> Render()
    {
        if (Content.Length == 0)
        {
            yield return Template;
        }
        else
        {
            foreach (Content content in Content)
            {
                string body = Template.Body.Replace(BodyTag, content.Body);

                LanguageVersion minimum = content.Minimum > Template.Minimum
                    ? content.Minimum
                    : Template.Minimum;

                yield return new(body, minimum);
            }
        }
    }
}