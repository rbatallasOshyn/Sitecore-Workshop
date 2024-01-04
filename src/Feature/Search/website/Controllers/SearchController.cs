using Sitecore.Layouts;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workshop.Feature.Search.Repositories;

namespace Workshop.Feature.Search.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchRepository _searchRepository;

        public SearchController(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }
        // GET: Search
        public ActionResult Search()
        {
            var model = (RenderingModel)RenderingContext.Current.Rendering.Model;
            return View("~/Views/Search/SearchComponent.cshtml", model);
        }
    }
}