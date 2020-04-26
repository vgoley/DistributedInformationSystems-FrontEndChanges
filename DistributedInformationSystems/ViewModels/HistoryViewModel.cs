using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistributedInformationSystems.Models;

namespace DistributedInformationSystems.ViewModels
{
    /// <summary>
    /// Model specific to history view
    /// </summary>
    public class HistoryViewModel
    {
        public List<Models.StudentComposition> StudentCompHistory { get; set; }
        public List<Models.SchoolYear> pAvailableSchoolYears { get; set;}
        public EnrollmentInfoList History { get; set; }
        public SemesterEnum AvailableSemesters { get; set; }
        public GenderEnum Genders { get; set; }
        public StudentLevelEnum StudentLevel { get; set; }
        public int SelectedSem { get; set; }
        public int SelectedGender { get; set; }
    }
}