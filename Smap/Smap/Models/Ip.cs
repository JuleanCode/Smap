using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smap.Models
{
    public class Ip
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Address { get; set; }
        public string Gateway { get; set; }

        //Relations
        public int Network_Id { get; set; }
    }
}
