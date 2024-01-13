using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Feature.Doctors.Models;
using Workshop.Foundation.SitecoreExtensions.Extensions;

namespace Workshop.Feature.Doctors.Repositories
{
    public class DoctorListRepository : IDoctorListRepository
    {
        public List<DoctorListItemModel> GetDoctorList()
        {
            var model = new List<DoctorListItemModel>();

            var currentItem = Sitecore.Context.Item;

            var doctorListItems = currentItem.GetChildren();

            foreach (Item item in doctorListItems)
            {
                var doctorItem = new DoctorListItemModel
                {
                    ItemUrl = item.Url(),
                    PhotoUrl = item.ImageUrl(Templates.Doctor.Fields.Photo),
                    DoctorName = item.Fields[Templates.Doctor.Fields.Name].Value
                };
                var specialty = item.GetSelectedItemFromDroplistField(Templates.Doctor.Fields.Specialty);
                if (specialty != null)
                {
                    doctorItem.Specialty = specialty.Fields[Templates.Specialty.Fields.Name].Value;
                }

                model.Add(doctorItem);
            }


            return model;
        }
    }
}