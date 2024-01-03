using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Links.UrlBuilders;
using System.Collections.Generic;
using Workshop.Feature.Navigation.Models;

namespace Workshop.Feature.Navigation.Repositories
{
    public class NavigationRepository : INavigationRepository
    {
        public List<NavigationModel> GetMenuItems()
        {
            var childPages = new List<NavigationModel>();
            var rootItem = Sitecore.Context.Database.GetItem(Templates.RootItem.Id);

            var childItems = rootItem.GetChildren();

            foreach (Item childItem in childItems)
            {
                var itemUrl = LinkManager.GetItemUrl(childItem, new ItemUrlBuilderOptions { LowercaseUrls = true, AlwaysIncludeServerUrl = false });

                childPages.Add(new NavigationModel
                {
                    Text = childItem.Name,
                    Url = itemUrl
                });
            }

            return childPages;
        }
    }
}