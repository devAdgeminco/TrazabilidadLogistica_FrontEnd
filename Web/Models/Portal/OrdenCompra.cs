using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Portal
{
    public class OrdenCompra
    {
        public string OCompra { get; set; }
        public DateTime FecOCompra { get; set; }
        public string REQUERIM { get; set; }
        public DateTime FecEntrega { get; set; }
        public string RUCProv { get; set; }
        public string RazonSocial { get; set; }
        public string DetalleOC { get; set; }
        public string Comprador { get; set; }
        public string Solicitante { get; set; }

    }
}
