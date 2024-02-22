using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Areas
    {
        public int ID_Area { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }

        public Areas(int Id_Area, string nombre, string ubicacion)
        {
            ID_Area = Id_Area;
            Nombre = nombre;
            Ubicacion = ubicacion;

        }
        public Areas() { }

    }
}
