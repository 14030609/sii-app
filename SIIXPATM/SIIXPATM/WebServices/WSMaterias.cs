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
    class WSKMaterias
    {
        HttpClient httpClient;

        public async Task<List<Materia>> getKardex()
        {
            List<Materia> listKardex = null;
            try
            {
                httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri(Settings.Settings.host);
                var authData = string.Format("{0}:{1}", "root", "root");
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
                var resp = await httpClient.GetAsync("/api/wsmaterias/getMaterias/");

                var cadena = resp.Content.ReadAsStringAsync().Result;
                var objJson = JObject.Parse(cadena);
                listKardex = new List<Materia>();
                Console.Write("este es el json " + objJson);
                var arrJson = objJson.SelectToken("materias").ToList();

                Materia mat;
                foreach (var kar in arrJson)
                {
                    mat = new Materia();
                    mat = JsonConvert.DeserializeObject<Materia>(kar.ToString());
                    listKardex.Add(mat);
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