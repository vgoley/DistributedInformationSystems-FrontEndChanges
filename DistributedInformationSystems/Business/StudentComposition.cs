using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistributedInformationSystems.Models;
using System.Data.Entity;

namespace DistributedInformationSystems.Business
{
    public class StudentComposition
    {
        public EnrollmentsEntities1 _enrollmentsdb;
        public StudentComposition()
        {
            _enrollmentsdb = new EnrollmentsEntities1();
        }
        public results GetStudentCompostionByYearFromApi(Models.SchoolYear pSchYr)
        {
            DistributedInformationSystems.Service.ApiHandler pApiHandler = new Service.ApiHandler();
            DistributedInformationSystems.Models.results pResults = pApiHandler.GetStudentComposition(GetSearchFieldBySchoolYear(pSchYr.Id), pSchYr.Year);
            return pResults;
        }
        public void AddStudentCompositionToDb(StudetnCompositionByYear pStudentCompostion)
        {
            _enrollmentsdb.StudetnCompositionByYears.Add(pStudentCompostion);
            _enrollmentsdb.SaveChanges();
        }
        public void UpdateStudentComposition(Models.StudentComposition pStudentCompostion)
        {

            var vRecordToBeUpdated = _enrollmentsdb.StudetnCompositionByYears.Where(c => c.Id == pStudentCompostion.Id).FirstOrDefault();
            vRecordToBeUpdated.SchoolName = pStudentCompostion.SchoolName;
            vRecordToBeUpdated.Asian = pStudentCompostion.Asian;
            vRecordToBeUpdated.AfricanAmerican = pStudentCompostion.AfricanAmerican;
            vRecordToBeUpdated.White = pStudentCompostion.White;
            vRecordToBeUpdated.Hispanic = pStudentCompostion.Hispanic;
            vRecordToBeUpdated.NonHispanic = pStudentCompostion.NonHispanic;
            vRecordToBeUpdated.MultiRacial = pStudentCompostion.MultiRacial;
            vRecordToBeUpdated.Unknown = pStudentCompostion.Unknown;
            _enrollmentsdb.SaveChanges();
        }
        public void DeleteStudentCompositionByYr(int pId)
        {
            var vRecordToBeDeleted = _enrollmentsdb.StudetnCompositionByYears.Where(c => c.Id == pId).FirstOrDefault();
            _enrollmentsdb.Entry(vRecordToBeDeleted).State = EntityState.Deleted;
            _enrollmentsdb.SaveChanges();
        }
        public Models.StudentComposition GetStudentCompositionByYrFromDb(int pId)
        {
            var pSearch = _enrollmentsdb.StudetnCompositionByYears.Where(c => c.Id == pId).FirstOrDefault();
            Models.StudentComposition pStuComp = new Models.StudentComposition();
            pStuComp.Id = pSearch.Id;
            pStuComp.SchoolYearId = pSearch.SchoolYearId;
            pStuComp.Hispanic = pSearch.Hispanic;
            pStuComp.NonHispanic = pSearch.NonHispanic;
            pStuComp.Asian = pSearch.Asian;
            pStuComp.AfricanAmerican = pSearch.AfricanAmerican;
            pStuComp.White = pSearch.White;
            pStuComp.Unknown = pSearch.Unknown;
            pStuComp.MultiRacial = pSearch.MultiRacial;
            pStuComp.Hawaiian = pSearch.Hawaiian;
            pStuComp.SchoolName = pSearch.SchoolName;
            return pStuComp;
        }
        public Models.StudentComposition GetStudentCompositionBySchYrFromDb(int pId)
        {
            var pSearch = _enrollmentsdb.StudetnCompositionByYears.Where(c => c.SchoolYearId == pId).FirstOrDefault();
            Models.StudentComposition pStuComp = new Models.StudentComposition();
            pStuComp.Id = pSearch.Id;
            pStuComp.SchoolYearId = pSearch.SchoolYearId;
            pStuComp.Hispanic = pSearch.Hispanic;
            pStuComp.NonHispanic = pSearch.NonHispanic;
            pStuComp.Asian = pSearch.Asian;
            pStuComp.AfricanAmerican = pSearch.AfricanAmerican;
            pStuComp.White = pSearch.White;
            pStuComp.Unknown = pSearch.Unknown;
            pStuComp.MultiRacial = pSearch.MultiRacial;
            pStuComp.Hawaiian = pSearch.Hawaiian;
            pStuComp.SchoolName = pSearch.SchoolName;
            return pStuComp;
        }
        /// <summary>
        /// returns a list of all the student compositions available in the database.
        /// </summary>
        /// <returns></returns>
        public List<Models.StudentComposition> GetStudentCompositionByYrAll()
        {
            var vStudentCompositionAll = _enrollmentsdb.StudetnCompositionByYears.ToList();
            List<Models.StudentComposition> pAvailableLists = new List<Models.StudentComposition>();
            foreach (DistributedInformationSystems.StudetnCompositionByYear pStuComp in vStudentCompositionAll)
            {
                Models.StudentComposition pStudentCompostion = new Models.StudentComposition();
                pStudentCompostion.Hispanic = pStuComp.Hispanic; ;
                pStudentCompostion.NonHispanic = pStuComp.NonHispanic;
                pStudentCompostion.White = pStuComp.White;
                pStudentCompostion.AfricanAmerican = pStuComp.AfricanAmerican;
                pStudentCompostion.Asian = pStuComp.Asian;
                pStudentCompostion.Hawaiian = pStuComp.Hawaiian;
                pStudentCompostion.MultiRacial = pStuComp.MultiRacial;
                pStudentCompostion.Unknown = pStuComp.Unknown;
                pStudentCompostion.Id = pStuComp.Id;
                pStudentCompostion.SchoolYearId = pStuComp.SchoolYearId;
                pStudentCompostion.SchoolName = pStuComp.SchoolName;
                pAvailableLists.Add(pStudentCompostion);

            }
            return pAvailableLists;
        }
        private string GetSearchFieldBySchoolYear(int selectedSchoolYear)
        {
            switch (selectedSchoolYear)
            {
                case 1:
                    return "2012.student.demographics.race_ethnicity";
                case 2:
                    return "2013.student.demographics.race_ethnicity";
                case 3:
                    return "2014.student.demographics.race_ethnicity";
                case 4:
                    return "2015.student.demographics.race_ethnicity";
                case 5:
                    return "2016.student.demographics.race_ethnicity";
                case 6:
                    return "2017.student.demographics.race_ethnicity";
                case 7:
                    return "2018.student.demographics.race_ethnicity";
                case 8:
                    return "2019.student.demographics.race_ethnicity";
                case 9:
                    return "2020.student.demographics.race_ethnicity";
                default:
                    throw new NotImplementedException("Not a valid school year! Please verify.");

            }
        }
    }

}