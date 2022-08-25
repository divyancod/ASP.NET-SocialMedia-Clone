using System.Web;
using System.Web.Optimization;

namespace BiasedSocialMedia.Web
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
                      "~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/login").Include("~/Scripts/login-script.js"));
            bundles.Add(new ScriptBundle("~/bundles/Dashboard").Include("~/Scripts/main-home.js"));
            bundles.Add(new ScriptBundle("~/bundles/Profile").Include("~/Scripts/profilefiles.js"));
            bundles.Add(new ScriptBundle("~/bundles/Notifications").Include("~/Scripts/notifications.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/myCss").Include("~/Content/login-styles.css").Include("~/Content/dashboard-styles.css"));

            bundles.UseCdn = true;
            var JQueyCDN = "https://code.jquery.com/jquery-3.6.0.js";
            bundles.Add(new ScriptBundle("~/Scripts",JQueyCDN).Include("~/Scripts/jquery-3.6.0.js"));
            var fontAwesome = "https://kit.fontawesome.com/fe400c9505.js";
            bundles.Add(new ScriptBundle("~/Scripts", fontAwesome).Include("~/Script/fe400c9505.js"));
            ////"https://kit.fontawesome.com/fe400c9505.js"))
        }
    }
}
