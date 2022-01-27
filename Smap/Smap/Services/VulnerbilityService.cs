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
using System.Collections.ObjectModel;

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
            db.CreateTable<Models.Company>();
        }

        public static List<Vulnerbility> GetNewVulnerbilities()
        {
            Init();

            Random random = new Random();
            VulnerbiltiyResponse vulnerbiltiyResponse = ResponseService.GetVulneribilties();
            List<Vulnerbility> vulnerbilities = new List<Vulnerbility>();
            if(vulnerbiltiyResponse != null)
            {
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
            }

            return vulnerbilities;
        }

        public static List<Vulnerbility> GetReportVulnerbilities(int portId)
        {
            Init();

            List<Vulnerbility> vulnerbilities = db.Table<Vulnerbility>().Where(vb => vb.OpenPort_Id == portId).ToList();
            return vulnerbilities;
        }

        public static void SaveVulnerabilities(ObservableCollection<Vulnerbility> vulnerbilities)
        {
            Init();

            foreach (Vulnerbility vulnerbility in vulnerbilities)
            {
                db.Insert(vulnerbility);
            }
        }
    }
}
