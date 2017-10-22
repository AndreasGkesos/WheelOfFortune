using System.Web;
using System.Web.Optimization;

namespace WheelOfFortune
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            // Custom ScriptBundle
            bundles.Add(new ScriptBundle("~/bundles/GsBundle").Include(
                      "~/Scripts/Core/jquery.3.2.1.js",
                      "~/Scripts/Core/popper.js",
                      "~/Scripts/Core/bootstrap.js",
                      "~/Scripts/Core/indexGs.js"));

            bundles.Add(new StyleBundle("~/Content/Core/css").Include(
                      "~/Content/Core/bootstrap.css",
                      "~/Content/Core/site.css"));
        }
    }
}
