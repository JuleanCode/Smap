using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smap.Models
{
    internal class Port
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
