using CsvHelper;
using CsvHelper.Configuration;
using DataAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace DataAnalysis
{
    class Program
    {
        const string Covid19DailyReportPath = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_daily_reports/";
        const string Covid19DailyReportUSPath = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_daily_reports_us/";
        static DateTime StartDate = new DateTime(2021, 1, 1);
        static DateTime EndDate = DateTime.Today;

        static void Main(string[] args)
        {
            DateTime date = StartDate;

            while (date < EndDate)
            {
                List<Covid19DailyReport> records = new List<Covid19DailyReport>();
                HttpClient Client = new HttpClient();

                //Get data
                var response = Client.GetAsync($"{Covid19DailyReportPath}{date.ToString("dd-MM-yyyy")}.csv");
                if (response.Result.StatusCode != HttpStatusCode.OK)
                {
                    date = date.AddDays(1);
                    continue;
                }
                Stream responseBody = response.Result.Content.ReadAsStreamAsync().Result;

                //Read and transform data
                using (var reader = new StreamReader(responseBody))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    records = csv.GetRecords<Covid19DailyReport>().ToList();
                }

                //Add records to database
                using (UserContext db = new UserContext())
                {
                    db.Covid19DailyReports.AddRange(records);
                    db.SaveChanges();
                }

                date = date.AddDays(1);
            }

            /*while (date < EndDate)
            {
                List<Covid19DailyReportUS> records = new List<Covid19DailyReportUS>();
                HttpClient Client = new HttpClient();

                //Get data
                var response = Client.GetAsync($"{Covid19DailyReportUSPath}{date.ToString("dd-MM-yyyy")}.csv");
                if (response.Result.StatusCode != HttpStatusCode.OK)
                {
                    date = date.AddDays(1);
                    continue;
                }
                Stream responseBody = response.Result.Content.ReadAsStreamAsync().Result;

                //Read and transform data
                using (var reader = new StreamReader(responseBody))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    records = csv.GetRecords<Covid19DailyReportUS>().ToList();
                }

                //Add records to database
                using (UserContext db = new UserContext())
                {
                    db.Covid19DailyUSReports.AddRange(records);
                    db.SaveChanges();
                }

                date = date.AddDays(1);
            }*/
        }
    }
}