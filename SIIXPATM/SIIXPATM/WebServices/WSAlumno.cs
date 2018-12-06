using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SIIXPATM.Modelos;
using System.Net.Http.Headers;

namespace SIIXPATM.WebServices
{
    class WSAlumno
    {
        public async Task<Alumno> getAlumno(String email)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Settings.Settings.host);
            var authData = string.Format("{0}:{1}", "root", "root");
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
            var resp = await httpClient.GetAsync("/api/wsalumnos/getAlumnos/" + email );
            var json = resp.Content.ReadAsStringAsync().Result;
            Alumno login = new Alumno();
            if (json != null)
            {

                login = JsonConvert.DeserializeObject<Alumno>(json);
            }

            Console.Write("si esta " + login.email);

            return login;
        }

    }
}
