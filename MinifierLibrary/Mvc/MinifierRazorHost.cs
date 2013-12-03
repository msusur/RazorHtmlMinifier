﻿using System.Web.Razor.Generator;
using System.Web.WebPages.Razor;

namespace MinifierLibrary.Mvc
{
    public class MinifierRazorHost : WebPageRazorHost
    {
        public MinifierRazorHost(string virtualPath, string physicalPath)
            : base(virtualPath, physicalPath)
        { }

        public override RazorCodeGenerator DecorateCodeGenerator(RazorCodeGenerator incomingCodeGenerator)
        {
            var minifier = MinifierFactory.GetMinifier(incomingCodeGenerator);
            return minifier.GetMinifierCodeGenerator();
        }
    }
}