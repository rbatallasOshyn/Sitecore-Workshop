using System.Web.Mvc;
using Workshop.Feature.Navigation.Repositories;

namespace Workshop.Feature.Navigation.Controllers
{
    public class NavigationController : Controller
    {
        private readonly INavigationRepository _navigationRepository;

        public NavigationController(INavigationRepository navigationRepository)
        {
            _navigationRepository = navigationRepository;
        }


        
        public ActionResult MenuItems()
        {
            var menuItems = _navigationRepository.GetMenuItems();

            return View(Constants.NavigationMenuView, menuItems);
        }
    }
}