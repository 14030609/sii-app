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
    class WSActualizarCalificaciones
    {
        public async Task<Boolean> getKardex(String parcial_1, String parcial_2, String parcial_3, String parcial_4)
        {

            Boolean bandera = false;
            try
            {

                listas lista = new listas();
                lista.parcial_1 = Int32.Parse( parcial_1);
                lista.parcial_2 = Int32.Parse(parcial_2);
                lista.parcial_3 = Int32.Parse(parcial_3);
                lista.parcial_4 = Int32.Parse(parcial_4);

                var json = JsonConvert.SerializeObject(lista);

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(Settings.Settings.host);
                var authData = string.Format("{0}:{1}", "root", "root");
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                var resp = await httpClient.PutAsync("/api/wslistas/putCalificaciones/" + Settings.Settings.nogpo+"/"+Settings.Settings.nocont, content);
                if (resp.IsSuccessStatusCode)
                    bandera = true;
            }
            catch (Exception e)
            {

                e.ToString();
            }

            return bandera;
        }
    }
}




