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
    class WSActualizarAlumno
    {
      
        public async Task<Boolean> getKardex( String contraseña, String telefono,String nss,String direccion, String email)
        {

            Boolean bandera = false;
            try
            {

                Usuario user= new Usuario();
                user.contraseña = contraseña;
                user.telefono = telefono;
                user.nss = nss;
                user.direccion = direccion;

                var json = JsonConvert.SerializeObject(user);

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(Settings.Settings.host);
                var authData = string.Format("{0}:{1}", "root", "root");
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                var resp = await httpClient.PutAsync("/api/wsusuarios/putUsuarios/"+Settings.Settings.email, content);
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




