using System.Web;
using System.Web.Optimization;

namespace Apresentacao.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.1.1.min.js",
                        "~/Scripts/jquery.validate.min.js",
                         "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/jquery-ui.min.js",
                        "~/Scripts/jquery-ui-timepicker-addon.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/wait").Include(
                       "~/Scripts/WaitModal.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/mask").Include(
                      "~/Scripts/Mask/jquery.mask.js"
                       ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery-ui.min.css",
                      "~/Contentjquery-ui-timepicker-addon.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/sidebar").Include(
                      "~/Content/sidebar.css"));
        }
    }
}
