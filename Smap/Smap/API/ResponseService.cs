using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Smap.API
{
    public static class ResponseService
    {
        
        public static VulnerbiltiyResponse GetVulneribilties()
        {
            WebRequest request = HttpWebRequest.Create("https://services.nvd.nist.gov/rest/json/cves/1.0/");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());



            string Vulnerabilities_JSON = reader.ReadToEnd();



            VulnerbiltiyResponse vulnerabilities = Newtonsoft.Json.JsonConvert.DeserializeObject<VulnerbiltiyResponse>(Vulnerabilities_JSON);



            return vulnerabilities;
        }
    }


}
