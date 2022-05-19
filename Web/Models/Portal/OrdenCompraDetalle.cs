using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Portal
{
    public class OrdenCompraDetalle
    {
        public string ITEM { get; set; }
        public string CODIGO { get; set; }
        public string DETALLEPROD { get; set; }
        public string UNIDAD { get; set; }
        public decimal CANT { get; set; }
        public string COMENTARIO { get; set; }
        public DateTime FecOCompra { get; set; }
        public string CCosto { get; set; }
    }
}
