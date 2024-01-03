using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workshop.Feature.Navigation
{
    public static class Templates
    {
        public struct RootItem
        {
            public static ID Id = new ID("{0E8E20EF-F7B2-4953-8BB2-4248B31D1D50}");
        }
    }

    public static class Constants 
    {
        public static string NavigationMenuView = "~/Views/Navigation/Menu.cshtml";
    }
}