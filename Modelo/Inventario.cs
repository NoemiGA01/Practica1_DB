using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Inventario
    {
        public int ID_Inventario { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public string Serie { get; set; }
        public string Color { get; set; }
        public string FechaAdquisicion { get; set; }
        public string TipoAdquisicion { get; set; }
        public string Observaciones { get; set; }

        public int Area { get; set; }
        public Inventario(int Id_Inventario, string nombreCorto, string descripcion, string serie, string color, string fechaAdquisicion, string tipoAdquisicion, string observaciones, int area)
        {
            ID_Inventario = Id_Inventario;
            NombreCorto = nombreCorto;
            Descripcion = descripcion;
            Serie = serie;
            Color = color;
            FechaAdquisicion = fechaAdquisicion;
            TipoAdquisicion = tipoAdquisicion;
            Observaciones = observaciones;
            Area = area;
        }
        public Inventario() { }

    }
}
