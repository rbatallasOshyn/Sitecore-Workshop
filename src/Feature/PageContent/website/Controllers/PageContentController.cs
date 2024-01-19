using System.Web.Mvc;
using Workshop.Feature.PageContent.Repositories;

namespace Workshop.Feature.PageContent.Controllers
{
    public class PageContentController : Controller
    {
        private readonly IPageContentRepository _pageContentRepository;

        public PageContentController(IPageContentRepository pageContentRepository)
        {
            _pageContentRepository = pageContentRepository;
        }


        public ActionResult GetChildLinks()
        {
            var model = _pageContentRepository.GetChildLinks();
            return View(Constants.Views.ChildLinks, model);
        }
    }
}