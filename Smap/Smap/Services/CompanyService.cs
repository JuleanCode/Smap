using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using SQLite;
using Smap.Models;

namespace Smap.Services
{
    public class CompanyService
    {
        static SQLiteConnection db;
        public static Models.Company CurrentCompany;
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

        public static void AddCompany(Models.Company company)
        {
            Init();

            db.Insert(company);
        }

        public static List<Company> GetCompanies() 
        {
            Init();

            List<Company> companies = db.Table<Company>().ToList();

            return companies;
        }
    }
}
