using System.Web.Razor.Generator;
using System.Web.WebPages.Razor;
using MinifierLibrary.Minifiers;

namespace MinifierLibrary.Mvc
{
    public class MinifierRazorHost : WebPageRazorHost
    {
        public MinifierRazorHost(string virtualPath, string physicalPath)
            : base(virtualPath, physicalPath)
        { }

        public override RazorCodeGenerator DecorateCodeGenerator(RazorCodeGenerator incomingCodeGenerator)
        {
            var minifier = MinifierFactory.GetMinifier();
            var codeGenerator = CodeGeneratorFactory.GetCodeGenerator(this, incomingCodeGenerator, minifier);
            return codeGenerator;
        }
    }
}