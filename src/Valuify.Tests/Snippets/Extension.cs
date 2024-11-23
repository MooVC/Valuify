namespace Valuify.Snippets;

using System.Diagnostics;

[DebuggerDisplay("{Extensions,nq}")]
public sealed record Extension(string Body, Extensions Extensions);