using System.Web.Mvc;
using Workshop.Feature.Doctors.Repositories;

namespace Workshop.Feature.Doctors.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorListRepository _doctorListRepository;

        public DoctorsController(IDoctorListRepository doctorListRepository)
        {
            _doctorListRepository = doctorListRepository;
        }

        public ActionResult DoctorList()
        {
            var model = _doctorListRepository.GetDoctorList();
            return View(Constants.Views.DoctorList, model);
        }
    }
}