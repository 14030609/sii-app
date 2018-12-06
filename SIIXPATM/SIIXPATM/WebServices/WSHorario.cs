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
    class WSHorario
    {
        HttpClient httpClient;

        public async Task<List<Horario>> getHorario(string nocont)
        {

            List<Horario> listHorarios = null;
            try
            {
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(Settings.Settings.host);
                var authData = string.Format("{0}:{1}", "root", "root");
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
                var resp = await httpClient.GetAsync("/api/wshorario/getHorario/"+nocont);

                var cadena = resp.Content.ReadAsStringAsync().Result;
                var objJson = JObject.Parse(cadena);
                listHorarios = new List<Horario>();
                Console.Write("este es el json " + objJson);
                var arrJson = objJson.SelectToken("horario").ToList();


                Horario horario;

                foreach (var hor in arrJson)
                {
                    horario = new Horario();
                    horario = JsonConvert.DeserializeObject<Horario>(hor.ToString());
                    listHorarios.Add(horario);
                }
                
            }
            catch (Exception e)
            {

                e.ToString();
            }

            return listHorarios;

        }
    }
}