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
         var nullOrderer = new NullOrderer();

         var commonStylesBundle = new Bundle("~/Bundles/CommonStyles");
         commonStylesBundle.Include(
             "~/Content/less/bootstrap.css");
         commonStylesBundle.Transforms.Add(cssTransformer);
         commonStylesBundle.Orderer = nullOrderer;

         bundles.Add(commonStylesBundle);

         var modernizrBundle = new Bundle("~/Bundles/Modernizr");
         modernizrBundle.Include("~/Scripts/modernizr-2.*");
         modernizrBundle.Transforms.Add(jsTransformer);
         modernizrBundle.Orderer = nullOrderer;

         bundles.Add(modernizrBundle);

         var commonScriptsBundle = new Bundle("~/Bundles/CommonScripts");
         commonScriptsBundle.Include(
            "~/Scripts/bootstrap.js",
            "~/Scripts/jquery-{version}.js",
            "~/Scripts/jquery.validate.js",
            "~/Scripts/jquery.validate.unobtrusive.js",
            "~/Scripts/jquery.unobtrusive-ajax.js");
         commonScriptsBundle.Transforms.Add(jsTransformer);
         commonScriptsBundle.Orderer = nullOrderer;

         bundles.Add(commonScriptsBundle);
      }

    }
}