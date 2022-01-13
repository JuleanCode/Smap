using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smap.Models
{
    public class Service
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
