using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using SQLite;
using Smap.Models;
using System.Collections.ObjectModel;

namespace Smap.Services
{
    public class ReportService
    {
        static SQLiteConnection db;
        public static Report CurrentReport { get; set; }
        static void Init()
        {
            if (db != null)
                return;

            var dataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SmapDB2.db");

            db = new SQLiteConnection(dataBasePath);

            db.CreateTable<Ip>();
            db.CreateTable<OpenPort>();
            db.CreateTable<Report>();
            db.CreateTable<Network>();
            db.CreateTable<Vulnerbility>();
            db.CreateTable<User>();
            db.CreateTable<Models.Company>();
        }

        public static void CreateReport() 
        {
            Init();

            CurrentReport = new Report()
            {
                Date = DateTime.Now,
                Ip_Id = IpService.SelectedIp.Id,
                Company_Id = CompanyService.CurrentCompany.Id
            };
        }

        public static void SaveReport(ObservableCollection<Vulnerbility> vulnerbilities)
        {
            Init();
            VulnerbilityService.SaveVulnerabilities(vulnerbilities);
            db.Insert(CurrentReport);
        }

        public static List<Report> GetReports()
        {
            Init();

            List<Report> reports = db.Table<Report>().Where(r => r.Company_Id == CompanyService.CurrentCompany.Id).ToList();

            return reports;
        }
    }
}
