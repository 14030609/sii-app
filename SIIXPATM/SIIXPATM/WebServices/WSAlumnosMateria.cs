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
    class WSAlumnosMateria
    {
        HttpClient httpClient;

        public async Task<List<Alumnos>> getALumnos(String cvemat, String nogpo)
        {
            List<Alumnos> listKardex = null;
            try
            {
                httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri(Settings.Settings.host);
                var authData = string.Format("{0}:{1}", "root", "root");
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
                var resp = await httpClient.GetAsync("/api/wsgrupos/getGrupoAlumnosMaterias/"+Settings.Settings.cvemat+"/"+Settings.Settings.nogpo);

                var cadena = resp.Content.ReadAsStringAsync().Result;
                var objJson = JObject.Parse(cadena);
                listKardex = new List<Alumnos>();
//                Console.Write("este es el json alumnos materia " + objJson);
                var arrJson = objJson.SelectToken("alumnos").ToList();
                Console.Write("este es el json alumnos materia por alumnos " + arrJson);

                



                    Alumnos grup;
                foreach (var kar in arrJson)
                {
                    grup = new Alumnos();
                    grup = JsonConvert.DeserializeObject<Alumnos>(kar.ToString());
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