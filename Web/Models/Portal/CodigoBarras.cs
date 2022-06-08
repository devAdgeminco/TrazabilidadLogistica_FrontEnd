using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Portal
{
    public class CodigoBarras
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Almacen { get; set; }
        public decimal Stock { get; set; }
        public string Unidad { get; set; }
    }
}
