using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Client.Models
{
    class MainModel
    {
        public GlobalCovid Global { get; set; }
        public List<CountryData> Countries { get; set; }
        public DateTime ZuluDate { get; set; }
    }
}
