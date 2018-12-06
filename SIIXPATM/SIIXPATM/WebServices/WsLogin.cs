using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SIIXPATM.Modelos;
using System.Net.Http.Headers;

namespace SIIXPATM.NewFolder
{
    class WsLogin
    {
        public async Task<Usuarios> conexion(String email, String password)
        {           Usuarios login;

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Settings.Settings.host);
            var authData = string.Format("{0}:{1}", "root", "root");
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
            var resp = await httpClient.GetAsync("/api/wsusuarios/getUsuarios/"+email+"/"+password);
            var json = resp.Content.ReadAsStringAsync().Result;
            login = new Usuarios();
            if(json != null)
            {

                login = JsonConvert.DeserializeObject<Usuarios>(json);
            }
            Settings.Settings.email = login.email;
            Settings.Settings.rol = login.rol;
                
            Console.Write("si esta " + login.email);

            return login;
        }
    }
}
