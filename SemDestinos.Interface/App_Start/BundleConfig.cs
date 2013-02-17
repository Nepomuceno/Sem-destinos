using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Transformers;

namespace SemDestinos.Interface.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
      {
         var cssTransformer = new CssTransformer();
         var jsTransformer = new JsTransformer();

         var commonStylesBundle = new Bundle("~/css");
         commonStylesBundle.Include(
             "~/Content/less/bootstrap.less");
         commonStylesBundle.Transforms.Add(cssTransformer);

         bundles.Add(commonStylesBundle);

         var modernizrBundle = new Bundle("~/modernizr");
         modernizrBundle.Include("~/Scripts/modernizr-2.*");
         modernizrBundle.Transforms.Add(jsTransformer);

         bundles.Add(modernizrBundle);

         var commonScriptsBundle = new Bundle("~/jquery");
         commonScriptsBundle.Include(
            "~/Scripts/jquery-{version}.js",
            "~/Scripts/jquery-migrate-{version}.js"
            );
         commonScriptsBundle.Transforms.Add(jsTransformer);
         bundles.Add(commonScriptsBundle);
         
        var jqueryDependentScriptsBundle = new Bundle("~/js");
            jqueryDependentScriptsBundle.Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js"
                , "~/Scripts/jquery.unobtrusive-ajax.js");
            jqueryDependentScriptsBundle.Transforms.Add(jsTransformer);
            bundles.Add(jqueryDependentScriptsBundle);


         
      }

    }
}