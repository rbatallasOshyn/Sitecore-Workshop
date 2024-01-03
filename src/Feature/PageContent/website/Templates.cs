using Sitecore.Data;

namespace Workshop.Feature.PageContent
{
    public static class Templates
    {
        public struct Footer
        {
            public static ID Id = new ID("{35ECC186-62E7-4BE1-8023-7DC6892A8724}");
            public struct Fields
            {
                public static ID Content = new ID("{D1E12D54-4C24-4283-AB9D-A7FCB4CBD605}");
            }
        }

        public struct Header
        {
            public static ID Id = new ID("{FEB45060-A9C5-4BE5-BF2F-2B423DC8FC90}");

            public struct Fields
            {
                public static ID CTA = new ID("{39E49DCD-783D-4F4C-87BE-1489697BB859}");

                public static ID CTAText = new ID("{CAD7FEED-7428-4BDD-A49C-57A0D040256F}");

                public static ID MenuButtonText = new ID("{99110813-6ADA-446F-8AFE-060197A0DB44}");


                public static string CTAString = "CTA";

                public static string CTATextString = "CTA Text";

                public static string MenuButtonTextString = "Menu Button Text";
            }
        }
    }
}