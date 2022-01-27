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
    public class PortService
    {
        static SQLiteConnection db;
        public static OpenPort SelectedPort { get; set; }
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

        public static void SavePort()
        {
            Init(); 

            OpenPort openPort = db.Table<OpenPort>().Where(o => o.Number == SelectedPort.Number && o.Ip_Id == IpService.SelectedIp.Id).FirstOrDefault();
            if(openPort == null)
            {
                SelectedPort.Ip_Id = IpService.SelectedIp.Id;
                db.Insert(SelectedPort);
                SelectedPort = db.Table<OpenPort>().Where(o => o.Number == SelectedPort.Number && o.Ip_Id == IpService.SelectedIp.Id).FirstOrDefault();
            }
            else
            {
                SelectedPort = openPort;
            }
        }

        public static OpenPort GetReportOpenPort(int id)
        {
            Init();

            OpenPort openPort = db.Table<OpenPort>().Where(op => op.Ip_Id == id).FirstOrDefault();
            return openPort;
        }
    }
}
