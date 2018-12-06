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
    class WSGrupos
    {
        HttpClient httpClient;

        public async Task<List<Grupo>> getKardex()
        {
            List<Grupo> listKardex = null;
            try
            {
                httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri(Settings.Settings.host);
                var authData = string.Format("{0}:{1}", "root", "root");
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                listKardex = new List<Grupo>();

                if (Settings.Settings.rol.Equals("Alumno"))
                {
                   var  resp = await httpClient.GetAsync("/api/wsgrupos/getGrupos/" + Settings.Settings.nocont);
                    var cadena = resp.Content.ReadAsStringAsync().Result;
                    var objJson = JObject.Parse(cadena);
                    var arrJson = objJson.SelectToken("grupos").ToList();
                    Grupo grup;
                    foreach (var kar in arrJson)
                    {
                        grup = new Grupo();
                        grup = JsonConvert.DeserializeObject<Grupo>(kar.ToString());
                        listKardex.Add(grup);
                    }

                }
                else
                {
                    var  resp = await httpClient.GetAsync("/api/wsgrupos/getGruposAsignados/" + Settings.Settings.cvemae);
                    var cadena = resp.Content.ReadAsStringAsync().Result;
                    var objJson = JObject.Parse(cadena);
                    Console.Write("este es el json  de gupos lala " + objJson);

                    var arrJson = objJson.SelectToken("grupos").ToList();
                    Grupo grup;
  
                        foreach (var kar in arrJson)
                        {
                            grup = new Grupo();
                            grup = JsonConvert.DeserializeObject<Grupo>(kar.ToString());

                            listKardex.Add(grup);
                        }
                 



                }



//                Console.Write("este es el json " + objJson);
  
            }
            catch (Exception e)
            {

                e.ToString();
            }

            return listKardex;

        }
    }
}