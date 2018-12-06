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
    class WSAlumnos
    {
        HttpClient httpClient;

        public async Task<List<Alumnos>> getALumnos(String cvemae)
        {
            List<Alumnos> listKardex = null;
            try
            {
                httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri(Settings.Settings.host);
                var authData = string.Format("{0}:{1}", "root", "root");
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
                var resp = await httpClient.GetAsync("/api/wsgrupos/getGrupoAlumnos/" + cvemae);

                var cadena = resp.Content.ReadAsStringAsync().Result;
                var objJson = JObject.Parse(cadena);
                listKardex = new List<Alumnos>();
                Console.Write("este es el json " + objJson);
                var arrJson = objJson.SelectToken("alumnos").ToList();

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






        private string result = "si";

        private string result3;

        public async Task<String> actAlumno(listas alumno)
        {
            List<Usuarios> listKardex = null;
            try
            {
                httpClient = new HttpClient();

                alumno.parcial_1 = 0;
                alumno.parcial_2 = 0;
                alumno.parcial_3 = 0;
                alumno.parcial_4 = 0;

                    var json = JsonConvert.SerializeObject(alumno);
                    HttpContent contenido = new StringContent(json, Encoding.UTF8, "application/json");




                    httpClient.BaseAddress = new Uri(Settings.Settings.host);

                    //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var authData = string.Format("{0}:{1}", "root", "root");
                    var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                    var respuesta = await httpClient.PostAsync("/api/wslistas/postLista/", contenido);
                    var json2 = respuesta.Content.ReadAsStringAsync().Result;
                    var objJson = JObject.Parse(json2);

                    if (json2 != null)
                    {
                 
                        var arrJson = objJson.SelectToken("message").ToList();
                        Console.Write("este es el mensaje exitossmente si lista " + arrJson);

                    }




            }
            catch (Exception e)
            {

                e.ToString();
            }


            return result;

        }





    }
}