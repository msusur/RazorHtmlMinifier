using System.Web.Razor.Generator;
using MinifierLibrary.Minifiers;

namespace MinifierLibrary.Mvc
{
    internal class CodeGeneratorFactory
    {
        public static RazorCodeGenerator GetCodeGenerator(MinifierRazorHost codeGeneratorHost, RazorCodeGenerator incomingCodeGenerator, IMinifier minifier)
        {
            if (incomingCodeGenerator is CSharpRazorCodeGenerator)
            {
                return new MinifierCSharpRazorCodeGenerator(codeGeneratorHost, incomingCodeGenerator, minifier);
            }
            return codeGeneratorHost.DecorateCodeGenerator(incomingCodeGenerator);
        }
    }
}