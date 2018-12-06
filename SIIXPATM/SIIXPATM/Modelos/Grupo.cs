using System;
using System.Collections.Generic;
using System.Text;

namespace SIIXPATM.Modelos
{
    class Grupo
    {
        public static Grupo SelectedItem { get; internal set; }
        public String materia { get; set; }
        public String cvemat { get; set; }
        public String nogpo { get; set; }
        public String dia { get; set; }       
        public String horario{ get; set; }
        public String salon { get; set; }
        public String maestro { get; set; }
        public int horteo { get; set; }
        public int horpra { get; set; }
        public int creditos { get; set; }
    
    }
}
