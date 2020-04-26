using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace DistributedInformationSystems.Service
{
    public class ApiHandler
    {

        static string BASE_URL = "https://api.data.gov/ed/collegescorecard/v1/schools?school.name=University%20of%20South%20Florida-Main%20Campus&fields=";
        static string API_KEY = "f53I92HKdvqaUe1bojmcKhshvYVRFaWPzdGGzRWV";
        HttpClient httpClient;

        /// <summary>
        ///  Constructor to initialize the connection to the data source
        /// </summary>
        public ApiHandler()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44388/");
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Method to receive data from API end point as a collection of objects
        /// 
        /// JsonConvert parses the JSON string into classes
        /// </summary>
        /// <returns></returns>
        public DistributedInformationSystems.Models.results GetStudentComposition(string pSearchField, string pSchYr)
        {
            string NATIONAL_PARK_API_PATH = BASE_URL + pSearchField;
            string studentData = "";
            DistributedInformationSystems.Models.results pStudentComposition = new Models.results();
            dynamic data = null;

            httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    studentData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    studentData = studentData.Replace(pSchYr + ".student.demographics.race_ethnicity.", "");
                    data = JObject.Parse(studentData);
                }

                if (!studentData.Equals(""))
                {
                    pStudentComposition.asian = data.results[0].asian;
                    pStudentComposition.black = data.results[0].black;
                    pStudentComposition.hispanic = data.results[0].hispanic;
                    pStudentComposition.nhpi = data.results[0].nhpi;
                    pStudentComposition.two_or_more = data.results[0].two_or_more;
                    pStudentComposition.unknown = data.results[0].unknown;
                    pStudentComposition.white = data.results[0].white;
                    pStudentComposition.asian_pacific_islander = 0;
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return pStudentComposition;
        }
    }

}