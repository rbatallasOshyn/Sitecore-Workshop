using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;
using Workshop.Feature.PageContent.Models;
using Workshop.Foundation.SitecoreExtensions.Extensions;

namespace Workshop.Feature.PageContent.Repositories
{
    public class PageContentRepository : IPageContentRepository
    {
        public List<LinkModel> GetChildLinks()
        {
            var model = new List<LinkModel>();

            var currentItem = Sitecore.Context.Item;

            var childs = currentItem.GetChildren();

            if(childs.Any() )
            {
                foreach (Item item in childs)
                {
                    model.Add(new LinkModel { Name = item.Name, Url = item.Url() });
                }
            }
            else
            {
                var parentItem = currentItem.Parent;
                var parentChilds = parentItem.GetChildren();
                model.Add(new LinkModel { Name = parentItem.Name, Url = parentItem.Url() });

                foreach (Item item in parentChilds)
                {
                    if(item.ID == currentItem.ID)                    
                        continue;
                    
                    model.Add(new LinkModel { Name = item.Name, Url = item.Url() });
                }
            }


            return model;
        }
    }
}