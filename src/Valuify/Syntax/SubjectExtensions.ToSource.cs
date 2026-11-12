namespace Valuify.Syntax
{
    using MooVC.Syntax;
    using MooVC.Syntax.CSharp;
    using Valuify.Model;

    /// <summary>
    /// Builds partial class declarations for the subject's generated members.
    /// </summary>
    internal static partial class SubjectExtensions
    {
        public static Source ToSource(this Subject subject, string hint, Comparison comparison)
        {
            // The comparison renderer takes its left operand from the containing type's declaration.
            Class operand = Class.Undefined.Named((Declaration)subject.Type);
            Snippet member = comparison.ToSnippet(Configuration.Options, operand);

            return subject.ToSource(hint, member);
        }

        public static Source ToSource(this Subject subject, string hint, Method method)
        {
            return new Source(Declare(subject).WithMethods(method).ToSnippet(Configuration.Options), hint);
        }

        public static Source ToSource(this Subject subject, string hint, Symbol contract)
        {
            return new Source(Declare(subject).Implements(contract).ToSnippet(Configuration.Options), hint);
        }

        public static Source ToSource(this Subject subject, string hint, Snippet member)
        {
            return new Source(member.Block(Configuration.Options, $"partial class {subject.Qualification}"), hint);
        }

        private static Class Declare(Subject subject)
        {
            return Class.Undefined
                .Named((Declaration)subject.Qualification)
                .WithExtensibility(Modifiers.Implicit)
                .WithScope(Scopes.Unspecified);
        }
    }
}