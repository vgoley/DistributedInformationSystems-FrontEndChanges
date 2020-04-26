using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
namespace DistributedInformationSystems.Models
{
    /// <summary>
    /// Represents enrollment information for a given school year and term
    /// </summary>
    public class EnrollmentInfo
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("School Year")]
        public string Yeasr { get; set; }
        public SemesterEnum Semester;
        [DisplayName("Asian")]
        public string Institution { get; set; }
        [DisplayName("Asian")]
        [JsonProperty("name")]
        public int Asian { get; set; }
        [DisplayName("Anerican Indian")]
        [JsonProperty("name")]
        public int AmericanIndian { get; set; }
        [DisplayName("Hawaiian/Pacific Islander")]
        [JsonProperty("name")]
        public int HawaiianPacificIslander { get; set; }
        [JsonProperty("name")]
        [DisplayName("White")]
        public int White { get; set; }
        [JsonProperty("name")]
        [DisplayName("African American")]
        public int AfricanAmerican { get; set; }
        [JsonProperty("name")]
        [DisplayName("Hispanic")]
        public int Hispanic { get; set; }
        [JsonProperty("nhip")]
        [DisplayName("Hispanic")]
        public int NonHispanic { get; set; }
        [JsonProperty("name")]
        [DisplayName("Gender")]
        public GenderEnum Gender { get; set; }
        [JsonProperty("name")]
        [DisplayName("Student Level")]
        public StudentLevelEnum StudentLevel { get; set; }
        [DisplayName("Asian")]
        public int TotalEnrollment
        {
            get
            {
                return Asian + AmericanIndian + HawaiianPacificIslander + White + AfricanAmerican + Hispanic;
            }
        }
    }
    public enum StudentLevelEnum
    {
        Graduate = 1,
        Undergraduate
    }
    public enum GenderEnum
    {
        Male = 1,
        Female
    }
    public enum SemesterEnum
    {
        [Description("Fall 2010")]
        Fall2010 = 1,
        [Description("Spring 2010")]
        Spring2010,
        [Description("Fall 2011")]
        Fall2011,
        [Description("Spring 2011")]
        Spring2011,
        [Description("Fall 2012")]
        Fall2012,
        [Description("Spring 2012")]
        Spring2012,
        [Description("Fall 2013")]
        Fall2013,
        [Description("Spring 2013")]
        Spring2013,
        [Description("Fall 2014")]
        Fall2014,
        [Description("Spring 2014")]
        Spring2014,
        [Description("Fall 2015")]
        Fall2015,
        [Description("Spring 2016")]
        Spring2015,
        [Description("Fall 2017")]
        Fall2016,
        [Description("Spring 2017")]
        Spring2016,
    }
    /// <summary>
    /// Helps with displaying the history of enrollment information
    /// </summary>
    public class EnrollmentInfoList : List<EnrollmentInfo>
    {

    }
    public class results
    {
        public student myStudents;
        [DisplayName("Non Hispanic")]
        public float? nhpi { get; set; }
        [DisplayName("Hispanic")]
        public float? hispanic { get; set; }
        [DisplayName("Asian")]
        public float? asian { get; set; }
        [DisplayName("African American")]
        public float? black { get; set; }
        [DisplayName("Unknown")]
        public float? unknown { get; set; }
        [DisplayName("Hawaiian/Pacific Islander")]
        public object asian_pacific_islander { get; set; }
        [DisplayName("White")]
        public float? white { get; set; }
        [DisplayName("Multi-Racial")]
        public float? two_or_more { get; set; }
    }
    public class student
    {
        public demographics demographics { get; set; }
    }
    public class demographics
    {
        [JsonProperty("race_ethnicity")]
        public race_ethnicity race_ethnicity { get; set; }

    }
    public class race_ethnicity
    {

        public int Id;
        public int SchoolYearId;
        public string SchoolYear;
        [DisplayName("Non Hispanic")]
        public float? nhpi { get; set; }
        [DisplayName("Hispanic")]
        public float? hispanic { get; set; }
        [DisplayName("Asian")]
        public float? asian { get; set; }
        [DisplayName("African American")]
        public float? black { get; set; }
        [DisplayName("Unknown")]
        public float? unknown { get; set; }
        [DisplayName("Hawaiian/Pacific Islander")]
        public object asian_pacific_islander { get; set; }
        [DisplayName("White")]
        public float? white { get; set; }
        [DisplayName("Multi-Racial")]
        public float? two_or_more { get; set; }


    }
    public class SchoolYear
    {
        public int Id;
        public string Year;
    }
    public class StudentComposition
    {
        public int Id { get; set; }
        public int SchoolYearId { get; set; }
        public string SchoolYear
        {
            get
            {
                switch (SchoolYearId)
                {
                    case 1:
                        return "2012";
                    case 2:
                        return "2013";
                    case 3:
                        return "2014";
                    case 4:
                        return "2015";
                    case 5:
                        return "2016";
                    case 6:
                        return "2017";
                    case 7:
                        return "2018";
                    case 8:
                        return "2019";
                    case 9:
                        return "2020";
                    default:
                        return string.Empty;

                }
                
            }
        }
        public decimal Hispanic { get; set; }
        public decimal NonHispanic { get; set; }
        public decimal White { get; set; }
        public decimal AfricanAmerican { get; set; }
        public decimal Asian { get; set; }
        public decimal Hawaiian { get; set; }
        public decimal MultiRacial { get; set; }
        public decimal Unknown { get; set; }
        public string SchoolName { get; set; }

    }


}