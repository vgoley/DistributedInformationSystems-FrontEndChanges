using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistributedInformationSystems.Models;

namespace DistributedInformationSystems.ViewModels
{
    public class GenerateDataViewModel
    {
        public string SelectedSchoolYear;
        public List<DistributedInformationSystems.Models.SchoolYear> AvailableSchoolYears;
        public bool RecordsAvailable { get; set; }
    }
}