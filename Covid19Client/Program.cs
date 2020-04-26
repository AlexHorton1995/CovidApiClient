using Covid19Client.Models;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;

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
                var CovidRequest = new RestRequest("countries", DataFormat.Json);

                //query the api to get a response
                var CovidResponse = CovidClient.Get(CovidRequest);

                //TODO - Parse out the response from the API into Objects using NewtonSoft here.
               //var CovidData =  CovidResponse.Content

                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

    }







}
