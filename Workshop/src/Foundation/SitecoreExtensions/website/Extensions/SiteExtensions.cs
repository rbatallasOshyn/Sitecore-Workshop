using System;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Sites;
using System.Linq;
using Sitecore.StringExtensions;

namespace Workshop.Foundation.SitecoreExtensions.Extensions
{
    public static class SiteExtensions
    {
        public static Item GetContextItem(this SiteContext site, ID derivedFromTemplateID)
        {
            if (site == null)
                throw new ArgumentNullException(nameof(site));

            var startItem = site.GetStartItem();
            return startItem?.GetAncestorOrSelfOfTemplate(derivedFromTemplateID);
        }

        public static Item GetRootItem(this SiteContext site)
        {
            if (site == null)
                throw new ArgumentNullException(nameof(site));

            return site.Database.GetItem(Context.Site.RootPath);
        }

        public static Item GetStartItem(this SiteContext site)
        {
            if (site == null)
                throw new ArgumentNullException(nameof(site));

            return site.Database.GetItem(Context.Site.StartPath);
        }

        public static SiteContext GetSiteContext(this Item item)
        {
            foreach (var siteInfo in SiteContextFactory.Sites.Where(site => site.Database.ToLowerInvariant() == item.Database.Name.ToLowerInvariant() && !string.IsNullOrWhiteSpace(string.Concat(site.RootPath, site.StartItem)) && item.Paths.FullPath.StartsWith(string.Concat(site.RootPath, site.StartItem), true)))
            {
                return SiteContextFactory.GetSiteContext(siteInfo.Name);
            }
            if (SiteContextFactory.GetSiteContext("website") == null)
            {
                return Sitecore.Context.Site;
            }
            return SiteContextFactory.GetSiteContext("website");
        }
    }
}