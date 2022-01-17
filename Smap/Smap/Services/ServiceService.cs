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
    public class ServiceService
    {
        static SQLiteConnection db;
        static void Init()
        {
            Helper.Init();
        }
    }
}
