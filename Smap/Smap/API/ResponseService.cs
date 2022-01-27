using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Xamarin.Forms;

namespace Smap.API
{
    public static class ResponseService
    {
        
        public static VulnerbiltiyResponse GetVulneribilties()
        {
            WebRequest request = HttpWebRequest.Create("https://services.nvd.nist.gov/rest/json/cves/1.0/");
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());



            string Vulnerabilities_JSON = reader.ReadToEnd();



            VulnerbiltiyResponse vulnerabilities = null;

            try
            {
                vulnerabilities = Newtonsoft.Json.JsonConvert.DeserializeObject<VulnerbiltiyResponse>(Vulnerabilities_JSON);
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Fout", "Er is iets fout gegaan met het ophalen van de vulnerabilties, probeer het later opnieuw", "Ok");
            }


            return vulnerabilities;
        }
    }


}
