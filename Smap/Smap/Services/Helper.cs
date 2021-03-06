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
    public class Helper
    {
        static SQLiteConnection db;
        public static void Init()
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

        public static void FreshInstall()
        {
            Init();
            DeleteAllData("Delete All Data");

            List<User> users = new List<User>()
            {
                new User()
                {
                    Email = "Admin",
                    Password = "P@ssw0rd"
                },
                new User()
                {
                    Email = "juleanhommel@gmail.com",
                    Password = "P@ssw0rd"
                },
                new User()
                {
                    Email = "brandonweinands@gmail.com",
                    Password = "P@ssw0rd"
                },
                new User()
                {
                    Email = "kevindisseldorp@gmail.com",
                    Password = "P@ssw0rd"
                },
                new User()
                {
                    Email = "xanderdenheijer@gmail.com",
                    Password = "P@ssw0rd"
                }
            };

            db.InsertAll(users);
        }

        public static void DeleteAllData(string delete)
        {
            //check so I don't accidentally use this function
            if (delete == "Delete All Data")
            {
                Init();

                db.DeleteAll<Ip>();
                db.DeleteAll<OpenPort>();
                db.DeleteAll<Report>();
                db.DeleteAll<Network>();
                db.DeleteAll<Vulnerbility>();
                db.DeleteAll<User>();
                db.DeleteAll<Models.Company>();
            }
        }
    }
}
