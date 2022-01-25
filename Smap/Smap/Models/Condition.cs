using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smap.Models
{
    public class Condition
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Company { get; set; }
        public string Scope { get; set; }
        public string Key { get; set; }
        public DateTime EndDate { get; set; }
        public int User_Id { get; set; }
    }
}
