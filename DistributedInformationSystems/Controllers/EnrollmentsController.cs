using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DistributedInformationSystems.Models;
using DistributedInformationSystems.ViewModels;
using System.Web.Routing;


namespace DistributedInformationSystems.Controllers
{
    public class EnrollmentsController : Controller
    {
        public EnrollmentsEntities1 _enrollmentsdb;

        public EnrollmentsController()
        {

            _enrollmentsdb = new EnrollmentsEntities1();
        }
        [HttpGet]
        public ActionResult GenerateData()
        {
            GenerateDataViewModel generateData = new GenerateDataViewModel();
            Business.StudentComposition stuComp = new Business.StudentComposition();
            List<Models.StudentComposition> pAvailableStudentCompostions = new List<Models.StudentComposition>();
            pAvailableStudentCompostions = stuComp.GetStudentCompositionByYrAll();
            if (pAvailableStudentCompostions.Count > 0) { generateData.RecordsAvailable = true; }
            return View(generateData);
        }
        [HttpPost]
        public ActionResult Generate()
        {
            try
            {
                DistributedInformationSystems.Business.SchoolYear pSchYr = new Business.SchoolYear();
                List<Models.SchoolYear> AvailableSchoolYears = pSchYr.GetSchoolYears();
                foreach (Models.SchoolYear pSchoolYr in AvailableSchoolYears)
                {
                    DistributedInformationSystems.Business.StudentComposition vStudentComposition = new Business.StudentComposition();
                    DistributedInformationSystems.Models.results pResults = vStudentComposition.GetStudentCompostionByYearFromApi(pSchoolYr);
                    var studentComposition = new StudetnCompositionByYear
                    {
                        Asian = 100 * Convert.ToDecimal(pResults.asian),
                        AfricanAmerican = 100 * Convert.ToDecimal(pResults.black),
                        Hispanic = 100 * Convert.ToDecimal(pResults.hispanic),
                        NonHispanic = 100 * Convert.ToDecimal(pResults.nhpi),
                        White = 100 * Convert.ToDecimal(pResults.white),
                        Unknown = 100 * Convert.ToDecimal(pResults.unknown),
                        MultiRacial = 100 * Convert.ToDecimal(pResults.two_or_more),
                        Hawaiian = 100 * 0,
                        SchoolYearId = pSchoolYr.Id,
                        SchoolName = "University of South Florida (Main Campus)"
                    };

                    Business.StudentComposition pStuComposition = new Business.StudentComposition();
                    pStuComposition.AddStudentCompositionToDb(studentComposition);
                }
                return RedirectToAction("History");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // GET: Enrollments
        public ActionResult Welcome()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int Id)
        {
            try
            {
                Business.StudentComposition stuComp = new Business.StudentComposition();
                Models.StudentComposition vStudentCompositionByYr = new Models.StudentComposition();
                vStudentCompositionByYr = stuComp.GetStudentCompositionByYrFromDb(Id);
                return View(vStudentCompositionByYr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult Update(Models.StudentComposition myObject)
        {
            try
            {
                Business.StudentComposition vStuComp = new Business.StudentComposition();
                vStuComp.UpdateStudentComposition(myObject);
                return RedirectToAction("History");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //todo: bug with the search which has to be fixed.
        public ActionResult Filter(HistoryViewModel myObject)
        {

            DistributedInformationSystems.Business.SchoolYear pSchYr = new Business.SchoolYear();
            List<Models.SchoolYear> AvailableSchoolYears = pSchYr.GetSchoolYears();
            HistoryViewModel hvm = new HistoryViewModel();
            hvm.pAvailableSchoolYears = AvailableSchoolYears;

            return RedirectToAction("History", "Enrollments", new { id = myObject.SelectedSem });
        }

        public ActionResult Delete(Models.StudentComposition myObject)
        {
            try
            {
                Business.StudentComposition stuComp = new Business.StudentComposition();
                stuComp.DeleteStudentCompositionByYr(myObject.Id);
                return RedirectToAction("History");
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        /// <summary>
        /// Helps display the summary of student compositions for all school years at usf
        /// </summary>
        /// <returns></returns>
        public ActionResult History(int id = 0)
        {

            Business.StudentComposition stuComp = new Business.StudentComposition();
            List<Models.StudentComposition> pAvailableStudentCompostions = new List<Models.StudentComposition>();
            if (id > 0)
            {
                Models.StudentComposition vStudentCompositionByYr = new Models.StudentComposition();
                vStudentCompositionByYr = stuComp.GetStudentCompositionBySchYrFromDb(id);
                pAvailableStudentCompostions.Add(vStudentCompositionByYr);
            }
            else
            {
                pAvailableStudentCompostions = stuComp.GetStudentCompositionByYrAll();
            }

            DistributedInformationSystems.Business.SchoolYear pSchYr = new Business.SchoolYear();
            List<Models.SchoolYear> AvailableSchoolYears = pSchYr.GetSchoolYears();

            HistoryViewModel demoHistory = new HistoryViewModel();
            demoHistory.StudentCompHistory = pAvailableStudentCompostions;
            demoHistory.pAvailableSchoolYears = AvailableSchoolYears;

            return View(demoHistory);
        }
    }
}