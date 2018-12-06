using System;
using System.Collections.Generic;
using System.Text;

namespace SIIXPATM.Interfaces
{
    public interface ICorreo
    {
        void CrearCorreo(string direccion, string asunto, string mensaje);
    }
}