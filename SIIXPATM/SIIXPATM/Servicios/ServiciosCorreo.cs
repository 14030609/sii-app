
using SIIXPATM.Interfaces;

using Xamarin.Forms;

namespace SIIXPATM.Servicios
{
    public static class ServiciosCorreo
    {
        public static void EnviarCorreo(string direccion, string asunto, string mensaje)
        {
            var correo = DependencyService.Get<ICorreo>();
            correo.CrearCorreo(direccion, asunto, mensaje);
        }
    }
}