using System.ComponentModel.Design;
using System.Data.Entity.Infrastructure;
using System.Web.Optimization;

// This file is used for configuring bundles for JavaScript and CSS files
// Bundling is a feature in ASP.NET that helps to reduce the number of HTTP requests for JavaScript and CSS files, improving the performance of web applications

namespace OdeToFood.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) //this method is used to register different bundles in our application
                                                                     //it takes a BundleCollection object as a parameter, to which we add various types of bundles
        {
            // The jQuery bundle typically refers to a package that includes the jQuery library along with additional components
            // jQuery itself is a widely used JavaScript library designed to simplify HTML DOM tree traversal and manipulation, as well as event handling, CSS animation, and Ajax

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js")); //this creates a script bundle for jQuery
                                                                                                        //the {version} placeholder allows for matching any version of jQuery

            // The jQuery Validation Bundle is a specific package that includes the jQuery Validation plugin along with its additional components
            // This plugin is widely used in web development for client-side form validation

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*")); //this creates a script bundle for jQuery validation
                                                                                                        //the wildcard '*' includes all files that start with jquery.validate

            // Modernizr is a JavaScript library that detects HTML5 and CSS3 features in the user's browser
            // It tries to "modernize" older browsers if they are being used by the user

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*")); //this bundle includes all scripts starting with 'modernizr-'

            // This is a style bundle that includes Bootstrap's CSS and a custom site.css for your application’s styles
            // In summary, the Bootstrap bundle provides a ready-made, comprehensive solution for fast and responsive web design,
            // while a custom CSS bundle is tailored to the specific needs and branding of a particular web project.

            bundles.Add(new Bundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/site.css"));

        }
    }
}
