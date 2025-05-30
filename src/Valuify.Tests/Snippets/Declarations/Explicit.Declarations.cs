﻿namespace Valuify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class Explicit
{
    public static class Declarations
    {
        public static readonly Content CSharp1Body = new(
            """
                {
                    private int age;
                    private string name;

                    public int Age
                    {
                        get { return age; }
                        set { age = value; }
                    }
        
                    public bool IsAdult
                    {
                        get { return Age >= 18; }
                    }
        
                    public string Name
                    {
                        get { return name; }
                        set { name = value; }
                    }

                    string INamed.Name
                    {
                        get { return Name; }
                    }
                }
            """,
            LanguageVersion.CSharp1);

        public static readonly Content CSharp3Body = new(
            """
                {
                    public int Age { get; set; }
        
                    public bool IsAdult
                    {
                        get { return Age >= 18; }
                    }
        
                    public string Name { get; set; }
            
                    string INamed.Name
                    {
                        get { return Name; }
                    }
                }
            """,
            LanguageVersion.CSharp3);

        public static readonly Content CSharp6Body = new(
            """
                {
                    public int Age { get; }
        
                    public bool IsAdult => Age >= 18;
        
                    public string Name { get; }

                    string INamed.Name => Name;
                }
            """,
            LanguageVersion.CSharp6);

        public static readonly Content CSharp9Body = new(
            """
                {
                    public int Age { get; init; }
        
                    public bool IsAdult => Age >= 18;
        
                    public string Name { get; init; }

                    string INamed.Name => Name; 
                }
            """,
            LanguageVersion.CSharp9);

        public static readonly Content Main = new(
            """
            namespace Valuify.Classes.Testing
            {
                public interface INamed
                {
                    string Name { get; }
                }

                [Valuify]
                public sealed partial class Explicit : INamed
            __BODY__
            }
            """,
            LanguageVersion.CSharp2);
    }
}