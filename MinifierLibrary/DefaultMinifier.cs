using System;
using System.Web.Razor.Generator;

namespace MinifierLibrary
{
    internal class DefaultMinifier : IMinifier
    {
        public RazorCodeGenerator GetMinifierCodeGenerator()
        {
            throw new NotImplementedException();
        }
    }
}