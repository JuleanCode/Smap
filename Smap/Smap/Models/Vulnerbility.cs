using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smap.Models
{
    public class Vulnerbility
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Cve { get; set; }
        public string Description { get; set; }
        public int OpenPort_Id { get; set; }
    }
}
