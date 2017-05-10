using System.Web;
using System.Web.Optimization;

namespace rotelearn
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/customjavascripts").Include(
                        "~/Scripts/owl.carousel.js",
                        "~/Scripts/script.js",
                        "~/Scripts/nouislider.min.js",
                        //"~/Scripts/stickUp.min.js",
                        "~/Scripts/jquery.corner.js",
                        "~/Scripts/wow.min.js",
                        "~/Scripts/classie.js",
                        "~/Scripts/jquery.magnific-popup.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.js"));

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
                    "~/Content/bootstrap.min.css",
                    "~/Content/general.css",
                    "~/Content/custom.css",
                    "~/Content/owl.carousel.css",
                    "~/Content/owl.theme.css",
                    "~/Content/style.css",
                    "~/Content/animate.css",
                    "~/Content/magnific-popup.css",
                    "~/Content/nouislider.min.css",
                    "~/Content/font-awesome.min.css"));
        }
    }
}
