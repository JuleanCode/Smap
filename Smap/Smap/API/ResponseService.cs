using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Smap.API
{
    public static class ResponseService
    {
        public static async Task<VulnerbiltiyResponse> GetVulnerbiltiys()
        {
            VulnerbiltiyResponse vulnerbiltiyResponse = new VulnerbiltiyResponse();

            var url = "https://services.nvd.nist.gov/rest/json/cves/1.0/";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                vulnerbiltiyResponse = JsonConvert.DeserializeObject<VulnerbiltiyResponse>(json);

            }

            return vulnerbiltiyResponse;
        }
    }
}
