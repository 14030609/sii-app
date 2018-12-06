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
    class WSCalificaciones
    {
        HttpClient httpClient;

        public async Task<List<listas>> getKardex()
        {
            List<listas> listKardex = null;
            try
            {
                httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri(Settings.Settings.host);
                var authData = string.Format("{0}:{1}", "root", "root");
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
                var resp = await httpClient.GetAsync("/api/wsalumnos/getCalificaciones/" + Settings.Settings.nocont);

                var cadena = resp.Content.ReadAsStringAsync().Result;
                var objJson = JObject.Parse(cadena);
                listKardex = new List<listas>();
                Console.Write("este es el json " + objJson);
                var arrJson = objJson.SelectToken("calificaciones").ToList();
                Console.Write("y este es el arrjson  " + arrJson);

                listas grup;
                foreach (var kar in arrJson)
                {
                    grup = new listas();
                    grup = JsonConvert.DeserializeObject<listas>(kar.ToString());
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