namespace Valuify.Snippets;

using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp;
using Arrangements = Valuify.Snippets.Extensions;

[DebuggerDisplay("{Name,nq}")]
public sealed record Snippets(Content[] Body, Content Declaration, Generated[] Expected, Extension[] Extensions, string Name)
{
    public const string BodyTag = "__BODY__";

    public IEnumerable<Expectations> Render(Arrangements target)
    {
        IEnumerable<Content> declarations = Compose();

        for (Arrangements arrangement = Arrangements.None; arrangement <= target; arrangement++)
        {
            foreach (Expectations expectation in Expect(arrangement, declarations))
            {
                yield return expectation;
            }
        }
    }

    private IEnumerable<Content> Compose()
    {
        if (Body.Length == 0)
        {
            yield return Declaration;
        }
        else
        {
            foreach (Content body in Body)
            {
                string declaration = Declaration.Body.Replace(BodyTag, body.Body);
                LanguageVersion minimum = Highest(body.Minimum, Declaration.Minimum);

                yield return new(declaration, minimum);
            }
        }
    }

    private IEnumerable<Expectations> Expect(Arrangements arrangements, IEnumerable<Content> declarations)
    {
        Generated[] expectations = Expected
            .Where(extension => !arrangements.HasFlag(extension.Extensions))
            .ToArray();

        string[] extensions = Extensions
            .Where(extension => arrangements.HasFlag(extension.Extensions))
            .Select(extension => extension.Body)
            .ToArray();

        foreach (Content declaration in declarations)
        {
            string[] contents = [declaration.Body, .. extensions];

            yield return new Expectations(contents, expectations, declaration.Minimum);
        }
    }

    private static LanguageVersion Highest(LanguageVersion first, LanguageVersion second)
    {
        return first > second
            ? first
            : second;
    }
}