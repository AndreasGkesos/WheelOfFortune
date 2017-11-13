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


            //Index View
            bundles.Add(new ScriptBundle("~/bundles/IndexView").Include(
                "~/Scripts/Controllers/IndexControllerJs.js",
                "~/Scripts/Wheel/TweenMax.min.js",
                "~/Scripts/Wheel/Draggable.min.js",
                "~/Scripts/Wheel/ThrowPropsPlugin.min.js",
                "~/Scripts/Wheel/Spin2WinWheel.min.js",
                "~/Scripts/Wheel/TextPlugin.min.js",
                "~/Scripts/Wheel/index.js",
                "~/Scripts/toastr.min.js",
                "~/Scripts/bootbox.min.js"
                ));

            //Spins View
            bundles.Add(new ScriptBundle("~/bundles/SpinsHistoryView").Include(
                "~/Scripts/Controllers/SpinsControllerJs.js",
                "~/scripts/datatables/jquery.datatables.js",
                "~/scripts/datatables/datatables.bootstrap.js"
            ));

            //Transactions View
            bundles.Add(new ScriptBundle("~/bundles/TransactionHistoryView").Include(
                "~/Scripts/Controllers/TransactionsControllerJs.js"
                //"~/scripts/datatables/jquery.datatables.js",
                //"~/scripts/datatables/datatables.bootstrap.js"
            ));

            // Custom Bundles for pages using stable bootstrap
            bundles.Add(new ScriptBundle("~/bundles/stable").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/respond.js",
                        "~/scripts/datatables/jquery.datatables.js",
                        "~/scripts/datatables/datatables.bootstrap.js",
                        "~/Scripts/scripts.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/stable/css").Include(
                "~/Content/bootstrap-lumen.css",
                "~/content/datatables/css/datatables.bootstrap.css",
                "~/Content/Index.css"
                ));


            // Custom ScriptBundle
            bundles.Add(new ScriptBundle("~/bundles/GsBundle").Include(
                "~/Scripts/Core/jquery.3.2.1.js",
                "~/Scripts/Core/popper.js",
                "~/Scripts/Core/bootstrap.js",
                "~/Scripts/bootbox.js",
                "~/Scripts/respond.js",
                "~/Scripts/datatables/jquery.datatables.js",
                "~/Scripts/datatables/datatables.bootstrap.js",
                "~/Scripts/Core/indexGs.js"));

            bundles.Add(new StyleBundle("~/Content/Core/css").Include(
                "~/Content/Core/bootstrap.css",
                "~/content/datatables/css/datatables.bootstrap.css",
                "~/Content/Core/site.css"
                ));
        }
    }
}
