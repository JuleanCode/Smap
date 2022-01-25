﻿using System;
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
            db.CreateTable<Models.Condition>();
        }

        public static void CreateReport() 
        {
            Init();

            CurrentReport = new Report()
            {
                Date = DateTime.Now,
                Ip_Id = IpService.SelectedIp.Id,
                Condition_Id = ConditionService.CurrentCondition.Id
            };
        }
    }
}
