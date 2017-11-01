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

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/site.css"));


            //Index View
            bundles.Add(new ScriptBundle("~/bundles/IndexView").Include(
                "~/Scripts/Controllers/IndexControllerJs.js",
                "~/Scripts/Wheel/TweenMax.min.js",
                "~/Scripts/Wheel/ThrowPropsPlugin.min.js",
                "~/Scripts/Wheel/Draggable.min.js",
                "~/Scripts/Wheel/TextPlugin.min.js",
                "~/Scripts/Wheel/Spin2WinWheel.min.js",
                "~/Scripts/Wheel/index.js"
                
                
            ));

            //Spins View
            bundles.Add(new ScriptBundle("~/bundles/SpinsHistoryView").Include(
                "~/Scripts/Controllers/SpinsControllerJs.js",
                
                "~/scripts/datatables/jquery.datatables.js",
                "~/scripts/datatables/datatables.bootstrap.js"

            ));

            //Transactions View
            bundles.Add(new ScriptBundle("~/bundles/TransactionHistoryView").Include(
                "~/Scripts/Controllers/TransactionsControllerJs.js",
                
                
                "~/scripts/datatables/jquery.datatables.js",
                "~/scripts/datatables/datatables.bootstrap.js"

            ));


            // Custom ScriptBundle
            bundles.Add(new ScriptBundle("~/bundles/GsBundle").Include(
                "~/Scripts/Core/jquery.3.2.1.js",
                "~/Scripts/Core/popper.js",
                "~/Scripts/Core/bootstrap.js", 
                
                "~/scripts/bootbox.js",

                "~/Scripts/Core/indexGs.js"));

            bundles.Add(new StyleBundle("~/Content/Core/css").Include(
                "~/Content/Core/bootstrap.css",
                "~/Content/Core/site.css"));
        }
    }
}
