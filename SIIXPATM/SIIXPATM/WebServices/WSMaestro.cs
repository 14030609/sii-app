using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SIIXPATM.Modelos;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Linq;


namespace SIIXPATM.WebServices
{
    class WSMaestro
    {
        HttpClient httpClient;
        public async Task<Maestro> getMaestro(String email)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Settings.Settings.host);
            var authData = string.Format("{0}:{1}", "root", "root");
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
            var resp = await httpClient.GetAsync("/api/wsmaestros/getMaestros/"+email);
            var json = resp.Content.ReadAsStringAsync().Result;
            Maestro login = new Maestro();
            if (json != null)
            {

                login = JsonConvert.DeserializeObject<Maestro>(json);
            }

            Console.Write("si esta " + login.email);

            return login;
        }

        public async Task<List<Maestro>> getMaestros()
        {
            List<Maestro> listKardex = null;
            try
            {
                httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri(Settings.Settings.host);
                var authData = string.Format("{0}:{1}", "root", "root");
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
                var resp = await httpClient.GetAsync("/api/wsmaestros/getMaestrosAlumno/" + Settings.Settings.nocont);

                var cadena = resp.Content.ReadAsStringAsync().Result;
                var objJson = JObject.Parse(cadena);
                listKardex = new List<Maestro>();
                Console.Write("este es el json " + objJson);
                var arrJson = objJson.SelectToken("maestros").ToList();

                Maestro grup;
                foreach (var kar in arrJson)
                {
                    grup = new Maestro();
                    grup = JsonConvert.DeserializeObject<Maestro>(kar.ToString());
                    listKardex.Add(grup);
                }
            }
            catch (Exception e)
            {

                e.ToString();
            }

            return listKardex;


        }



    }
}
