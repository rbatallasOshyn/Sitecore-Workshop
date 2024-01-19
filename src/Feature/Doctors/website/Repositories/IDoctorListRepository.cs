using System.Collections.Generic;
using Workshop.Feature.Doctors.Models;

namespace Workshop.Feature.Doctors.Repositories
{
    public interface IDoctorListRepository
    {
        List<DoctorListItemModel> GetDoctorList();

        SpecialtyModel SpecialtyDetails();
    }
}
