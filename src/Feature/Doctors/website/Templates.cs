using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workshop.Feature.Doctors
{
    public static class Templates
    {
        public struct Doctor
        {
            public static ID Id = new ID("{D8F6E045-B2E7-45D5-9858-FD7109117913}");

            public struct Fields
            {
                public static ID Name = new ID("{91BF8EFE-4FE5-47F7-ADDE-B970078F7D51}");
                public static ID Specialty = new ID("{F7D1FD1C-83D0-45A2-9E85-3962C08296E1}");
                public static ID OpeningHours = new ID("{B1A76AE2-3234-4E37-9D06-C3587C253E1B}");
                public static ID CTA = new ID("{561280F9-17FF-489E-B614-352678DF3C4A}");
                public static ID Photo = new ID("{B2FD076D-9F15-4F4C-A30E-D1CE8950B9B0}");
            }
        }

        public struct Specialty
        {
            public static ID Id = new ID("{1766AF60-4402-439E-8115-74A7E651B286}");

            public struct Fields
            {
                public static ID Name = new ID("{AA74FFD3-9CF4-478C-80D1-C162ABB0F090}");
            }
        }
    }
}