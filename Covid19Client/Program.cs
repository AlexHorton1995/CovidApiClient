using Covid19Client.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;

namespace Covid19Client
{
    /// <summary>
    /// Covid19Client - A Client to consume data from the https://covid19api.com/ API.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            GlobalCovid gc = new GlobalCovid();

            GetCovidInfo();
        }

        /// <summary>
        /// GetCovidInfo
        /// </summary>
        /// <returns>For Now Boolean value</returns>
        static bool GetCovidInfo()
        {
            try
            {
                //establish a connection to the api
                var CovidClient = new RestClient(@"https://api.covid19api.com/");

                //create a request with the correct API Operation
                var CovidRequest = new RestRequest("summary", DataFormat.Json);

                //query the api to get a response
                var CovidResponse = CovidClient.Get(CovidRequest);

                //Parse out the response from the API into Objects using NewtonSoft here.
                var JSONData = JsonConvert.DeserializeObject<MainModel>(CovidResponse.Content);

                //Create a CSV File with all of our object data
                string FileName = string.Format(@"COVID-19_{0}.csv", DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                string FilePath = @"C:\Covid19Data\";
                string FullFilePath = string.Format(@"C:\Covid19Data\{0}", FileName);

                //if the file path does not exist, then create it.
                if (Directory.Exists(FilePath))
                {
                    Directory.SetCurrentDirectory(FilePath);
                }
                else
                {
                    Directory.CreateDirectory(FilePath);
                    Directory.SetCurrentDirectory(FilePath);
                }

                using (var sr = new StreamWriter(string.Format(@".\{0}", FileName)))
                {
                    var header = @"Country,CountryCode,Slug,NewConfirmed,TotalConfirmed,NewDeaths,TotalDeaths,NewRecovered,TotalRecovered,Date";
                    sr.WriteLine(header);
                    foreach (var cLine in JSONData.Countries)
                    {
                        sr.WriteLine(string.Format(@"{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                        RemoveSpecials(cLine.Country),
                        cLine.CountryCode,
                        RemoveSpecials(cLine.Slug),
                        cLine.NewConfirmed,
                        cLine.TotalConfirmed,
                        cLine.NewDeaths,
                        cLine.TotalDeaths,
                        cLine.NewRecovered,
                        cLine.TotalRecovered,
                        cLine.Date
                        ));
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        static string RemoveSpecials(string data)
        {
            string retString = string.Empty;
            int charToE = 101;
            int charToO = 111;
            int charToSpace = 32;

            foreach(var c in data)
            {
                if (c == 233)
                    retString += (char)charToE;
                else if (c == 244)
                    retString += (char)charToO;
                else if (c == 44)
                    retString += (char)charToSpace;
                else
                    retString += c;
            }

            return retString;
        }

    }







}
