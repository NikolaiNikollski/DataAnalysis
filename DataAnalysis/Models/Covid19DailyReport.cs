using CsvHelper.Configuration.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnalysis.Models
{
    [Table("Covid19DailyReport")]
    public class Covid19DailyReport
    {
        [Key] //Primary key in table
        [Ignore] //Ignore in svc reading
        public long Id { get; set; }

        [Name("FIPS")] //Svc map
        public string FIPS { get; set; }

        [Name("Admin2")]
        public string Admin2 { get; set; }

        [Name("Province_State")]
        public string ProvinceState { get; set; }

        [Name("Country_Region")]
        public string CountryRegion { get; set; }

        [Name("Last_Update")]
        public DateTime LastUpdate { get; set; }

        [Name("Lat")]
        public double? Lat { get; set; }

        [Name("Long_")]
        public double? Long { get; set; }

        [Name("Confirmed")]
        public long Confirmed { get; set; }

        [Name("Deaths")]
        public int? Deaths { get; set; }

        [Name("Recovered")]
        public int? Recovered { get; set; }

        [Name("Active")]
        public int? Active { get; set; }

        [Name("Combined_Key")]
        public string CombinedKey { get; set; }

        [Name("Incident_Rate")]
        public double? IncidentRate { get; set; }

        [Name("Case_Fatality_Ratio")]
        public double? CaseFatalityRatio { get; set; }
    }
}
