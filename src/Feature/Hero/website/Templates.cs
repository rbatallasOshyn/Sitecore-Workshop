using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workshop.Feature.Hero
{
    public static class Templates
    {
        public struct HeroBanner
        {
            public static ID Id = new ID("{6B0481DE-745C-4779-9318-53739A91A4E4}");

            public struct Fields
            {
                public static ID Image = new ID("{A0F6B77E-0DB7-4C33-A9FD-957296A6CD15}");
            }
        }


    }
}