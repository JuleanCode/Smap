using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smap.Models
{
    internal class OpenPort
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Number { get; set; }

        //Relations
        public int Ip_Id { get; set; }
    }
}