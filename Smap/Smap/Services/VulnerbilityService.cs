using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using SQLite;
using Smap.Models;
using Smap.API;

namespace Smap.Services
{
    public class VulnerbilityService
    {
        static SQLiteConnection db;
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

        public static async Task<List<Vulnerbility>> GetVulnerbilities()
        {
            Init();

            Random random = new Random();
            VulnerbiltiyResponse vulnerbiltiyResponse = await ResponseService.GetVulnerbiltiys();
            List<Vulnerbility> vulnerbilities = new List<Vulnerbility>();
            for (int i = 0; i < random.Next(1, 7); i++)
            {
                Vulnerbility vulnerbility = new Vulnerbility()
                {
                    Cve = vulnerbiltiyResponse.result.CVE_Items[i].cve.CVE_data_meta.ID,
                    Description = vulnerbiltiyResponse.result.CVE_Items[i].cve.description.description_data[0].value,
                    OpenPort_Id = PortService.SelectedPort.Id
                };

                vulnerbilities.Add(vulnerbility);
            }

            return vulnerbilities;
        }
    }
}
