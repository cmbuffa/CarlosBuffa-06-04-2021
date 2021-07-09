using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbum.Models
{
    public class Extraba
	{
        //"CEDULA":73555,
        //"NOMBRES":"GILBERTO BAEZ ROLON",
        //"ORGANIZACION":"ACECUIB",
        //"NIVEL":4,
        //"FALLECIDO":true,
        //"MANUAL":false,
        //"GRABADO":false

        public int Cedula { get; set; }
        public string Nombres { get; set; }
        public string Organizacion { get; set; }
        public string Nivel { get; set; }
        public bool Fallecido { get; set; }
        public bool Manual { get; set; }
        public bool Grabado { get; set; }
    }
}
