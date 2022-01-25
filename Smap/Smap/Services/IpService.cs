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
        public static Ip SelectedIp;
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
            db.CreateTable<Models.Condition>();
        }

        public static void SaveIp()
        {
            Init();
            Ip ip = db.Table<Ip>().Where(i => i.Address == SelectedIp.Address).FirstOrDefault();
            if(ip == null)
            {
                db.Insert(SelectedIp);
                SelectedIp = db.Table<Ip>().Where(i => i.Address == SelectedIp.Address).FirstOrDefault();
            }
            else
            {
                SelectedIp = ip;
            }
        }
    }
}
