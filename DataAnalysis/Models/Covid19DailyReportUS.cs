using CsvHelper.Configuration.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnalysis.Models
{
    [Table("Covid19DailyReportUS")]
    public class Covid19DailyReportUS
    {
        [Key] //Primary key in table
        [Ignore] //Ignore in svc reading
        public long Id { get; set; }

        [Name("Province_State")] //Svc map
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
        public int? Confirmed { get; set; }

        [Name("Deaths")]
        public int? Deaths { get; set; }

        [Name("Recovered")]
        public int? Recovered { get; set; }

        [Name("Active")]
        public int? Active { get; set; }

        [Name("FIPS")]
        public int? FIPS { get; set; }

        [Name("Incident_Rate")]
        public double? IncidentRate { get; set; }

        [Name("Total_Test_Results")]
        public int? TotalTestResults { get; set; }

        [Name("People_Hospitalized")]
        public int? PeopleHospitalized { get; set; }

        [Name("Case_Fatality_Ratio")]
        public double? CaseFatalityRatio { get; set; }

        [Name("UID")]
        public int? UID { get; set; }

        [Name("ISO3")]
        public string? ISO3 { get; set; }

        [Name("Testing_Rate")]
        public double? TestingRate { get; set; }

        [Name("Hospitalization_Rate")]
        public double? HospitalizationRate { get; set; }
    }
}
