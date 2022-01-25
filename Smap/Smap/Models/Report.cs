using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smap.Models
{
    public class Report
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        //Relations
        public int Ip_Id { get; set; }
        public int Network_Id { get; set; }
        public int Condition_Id { get; set; }
    }
}
