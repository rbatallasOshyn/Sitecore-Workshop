using System.Collections.Generic;
using Workshop.Feature.PageContent.Models;

namespace Workshop.Feature.PageContent.Repositories
{
    public interface IPageContentRepository
    {
        List<LinkModel> GetChildLinks();
    }
}
