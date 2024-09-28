namespace Valuify.Snippets;

internal static partial class Classes
{
    public const string SimpleWithEqualityOperatorTemplate = """
        namespace Valuify.Classes.Testing
        {
            using System.Collections.Generic;

            [Valuify]
            public sealed partial class Simple
        __BODY__

            partial class Simple
            {
                public static bool operator ==(Simple left, Simple right)
                {
                    return EqualityComparer<Simple>.Default.Equals(left, right);
                }
            }
        }
        """;

    public static readonly Declared SimpleWithEqualityOperator;
}