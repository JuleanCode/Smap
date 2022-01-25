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
    public class UserService
    {
        static SQLiteConnection db;
        public static User LoggedInUser { get; set; }
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

        public static void CreateUser(User user)
        {
            Init();

            db.Insert(user);

            user = GetUserByEmail(user.Email);
            Application.Current.Properties["CurentUser_id"] = user.Id.ToString();
        }

        public static User GetUser(int Id)
        {
            Init();

            User user = db.Get<User>(Id);
            return user;
        }

        public static User GetUserByEmail(string Email)
        {
            Init();

            User user = db.Table<User>().First(x => x.Email == Email);
            return user;
        }

        public static void DeleteUser(int Id)
        {
            Init();

            db.Delete<User>(Id);
        }

        public static List<User> GetAllUser()
        {
            Init();

            List<User> users = db.Query<User>($"SELECT * FROM user WHERE Id != {Application.Current.Properties["CurentUser_id"]}");
            return users;
        }

        public static bool CheckUser(string Email, string Password)
        {
            Init();

            try
            {
                var user = db.Table<User>().First(x => x.Email == Email && x.Password == Password);

                LoggedInUser = user;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void DeleteAllUsers()
        {
            Init();

            db.DeleteAll<User>();
        }
    }
}
