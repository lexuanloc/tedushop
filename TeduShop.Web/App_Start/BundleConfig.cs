using System.Web;
using System.Web.Optimization;

namespace TeduShop.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Sẽ gom nhóm tất cả các file đã Include thành 1 file duy nhất với tên file random
            // VD: <script src="/js/jquery?v=iAfF7w_9xk3YMliaOVPqpx8pALBmF-FTbrao0RIgp_U1"></script>
            // Khi có thay đổi thì tên file include đó cũng thay đổi theo nên không lo bị cache
            bundles.Add(new ScriptBundle("~/js/jquery").Include(
                    "~/Assets/client/js/jquery.min.js"
                ));

            bundles.Add(new ScriptBundle("~/js/plugins").Include(
                    "~/Assets/admin/libs/jquery-ui/jquery-ui.min.js",
                    "~/node_modules/mustache/mustache.js",
                    "~/node_modules/numeral/numeral.js",
                    "~/node_modules/jquery-validation/dist/jquery.validate.js",
                    "~/node_modules/jquery-validation/dist/additional-methods.js",
                    "~/Assets/client/js/common.js"
                ));

            // Cần khai báo CssRewriteUrlTransform để một số resource gán theo đường dẫn cũ sẽ không bị lỗi
            bundles.Add(new StyleBundle("~/css/base")
                .Include("~/Assets/client/css/bootstrap.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/font-awesome-4.6.3/css/font-awesome.css", new CssRewriteUrlTransform())
                .Include("~/Assets/admin/libs/jquery-ui/themes/smoothness/jquery-ui.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/style.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/custom.css", new CssRewriteUrlTransform())
                );

            BundleTable.EnableOptimizations = true;
        }
    }
}
