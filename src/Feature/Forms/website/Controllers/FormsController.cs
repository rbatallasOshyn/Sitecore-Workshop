using System.Web.Mvc;
using Workshop.Feature.Forms.Repositories;

namespace Workshop.Feature.Forms.Controllers
{
    public class FormsController : Controller
    {

        private readonly IFormsRepository _formsRepository;

        public FormsController(IFormsRepository formsRepository)
        {
            _formsRepository = formsRepository;
        }

        public ActionResult ContactUs()
        {
            return View(Constants.Views.ContactUs);
        }
    }
}