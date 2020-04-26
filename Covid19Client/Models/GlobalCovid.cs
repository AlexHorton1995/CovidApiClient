using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Client.Models
{
    /// <summary>
    /// GlobalCovid Class - contains all aggregated global data
    /// </summary>
    class GlobalCovid
    {
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int NewDeaths { get; set; }
        public int TotalDeaths { get; set; }
        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }
        public List<CountryData> Countries { get; set; }
    }
}
