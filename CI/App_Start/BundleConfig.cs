using System.Web.Optimization;

namespace CI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            //custom css bundle
            var customCssBundle = new StyleBundle("~/Content/css").Include("~/Content/styles.css");
            bundles.Add(customCssBundle);

             //bootstrap css bundle
            var bootstrapCssBundle = new StyleBundle("~/Content/bootstrap/css").Include("~/Content/bootstrap/bootstrap.min.css").Include("~/Content/bootstrap/bootstrap-theme.min.css");
            bundles.Add(bootstrapCssBundle);

            //bootstrap jquery bundle
            var bootstrapJQueryBundle = new ScriptBundle("~/Scripts/js").Include("~/Scripts/bootstrap.min.js");
            bundles.Add(bootstrapJQueryBundle);

            //jquery bundle
            var jqueryBundle = new ScriptBundle("~/Scripts/js").Include("~/Scripts/jquery-1.9.1.min.js");
            bundles.Add(jqueryBundle);

            var jqueryPlayerBundle = new ScriptBundle("~/Scripts/player/js").Include("~/Scripts/player/jquery.iwish.js");
            bundles.Add(jqueryPlayerBundle);
        }
    }
}