using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DistributedInformationSystems.Business
{
    public class SchoolYear
    {
        public List<DistributedInformationSystems.Models.SchoolYear> GetSchoolYears()
        {
            EnrollmentsEntities1 _enrollmentsdb = new EnrollmentsEntities1();
            var vDbSchoolYears = _enrollmentsdb.SchoolYears.ToList();
            List<DistributedInformationSystems.Models.SchoolYear> vSchoolYears = new List<Models.SchoolYear>();
            foreach (DistributedInformationSystems.SchoolYear schYr in vDbSchoolYears)
            {
                DistributedInformationSystems.Models.SchoolYear pSchYr = new Models.SchoolYear();
                pSchYr.Id = schYr.Id;
                pSchYr.Year = schYr.Year;
                vSchoolYears.Add(pSchYr);
            }
            return vSchoolYears;
        }
    }

}