using System;
using System.Collections.Generic;
using System.Web.Razor.Generator;

namespace MinifierLibrary
{
    internal class MinifierFactory
    {
        private static readonly Dictionary<string, Type> Minifiers = new Dictionary<string, Type>
                                                                         {
                                                                             { "defaultminifier", typeof(DefaultMinifier) },
                                                                         };

        public static IMinifier GetMinifier(RazorCodeGenerator codeGenerator)
        {

        }

        public static void AddMinifier<TMinifier>(string key, TMinifier minifier)
            where TMinifier : IMinifier
        {
            Minifiers[key.ToLowerInvariant()] = minifier.GetType();
        }
    }
}