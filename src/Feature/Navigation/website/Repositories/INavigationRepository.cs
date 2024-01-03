using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Feature.Navigation.Models;

namespace Workshop.Feature.Navigation.Repositories
{
    public interface INavigationRepository
    {
        List<NavigationModel> GetMenuItems();
    }
}