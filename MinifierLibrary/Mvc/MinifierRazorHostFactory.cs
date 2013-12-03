using System.Web.Mvc;
using System.Web.WebPages.Razor;
using MinifierLibrary.Helpers;

namespace MinifierLibrary.Mvc
{
    public class MinifierRazorHostFactory : MvcWebRazorHostFactory
    {
        public override WebPageRazorHost CreateHost(string virtualPath, string physicalPath)
        {
            var notMinifiedHost = base.CreateHost(virtualPath, physicalPath);
            if (MinifierConfiguration.MinifyPages && (notMinifiedHost.DesignTimeMode || notMinifiedHost.IsSpecialPage))
            {
                return notMinifiedHost;
            }
            return new MinifierRazorHost(virtualPath, physicalPath);
        }
    }
}
