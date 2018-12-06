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
    class WSAccesos
    {
        public async Task<String> conexion(String user, String password)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://192.168.8.103:3000");
            var authData = string.Format("{0}:{1}", "root", "root");
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
            var resp = await httpClient.GetAsync("/api/wsaccesos/getAccesos/" + user + "/" + password);
            var json = resp.Content.ReadAsStringAsync().Result;

            Login login = new Login();
            if (json != null)
            {
                login = JsonConvert.DeserializeObject<Login>(json);
            }
            return login.nocont;
        }
    }
}
