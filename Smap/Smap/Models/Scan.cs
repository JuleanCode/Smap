using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smap.Models
{
    public class Scan
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
