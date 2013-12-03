using System.Web.Razor.Generator;

namespace MinifierLibrary
{
    internal interface IMinifier
    {
        RazorCodeGenerator GetMinifierCodeGenerator();
    }
}