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
        public DateTime Date { get; set; }
        public string Cve { get; set; }

        public int Report_Id { get; set; }

        public int entry_id { get; set; }
        public string entry_title { get; set; }
        public string entry_timestamp_create { get; set; }
        public string entry_timestamp_change { get; set; }
        public int vulnerabiltiy_risk_value { get; set; }
        public string vulnerability_risk_name { get; set; }
        public string advisory_date { get; set; }
        public int source_cve_id { get; set; }

    }
}
