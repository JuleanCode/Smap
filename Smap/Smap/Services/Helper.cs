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

            var dataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SmapDB.db");

            db = new SQLiteConnection(dataBasePath);

            db.CreateTable<Ip>();
            db.CreateTable<Port>();
            db.CreateTable<Report>();
            db.CreateTable<Scan>();
            db.CreateTable<Service>();
            db.CreateTable<User>();
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
                db.DeleteAll<Port>();
                db.DeleteAll<Report>();
                db.DeleteAll<Scan>();
                db.DeleteAll<Service>();
                db.DeleteAll<User>();
            }
        }
    }
}
