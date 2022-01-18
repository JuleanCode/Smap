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
    public class IpService
    {
        static SQLiteConnection db;
        static void Init()
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
    }
}
