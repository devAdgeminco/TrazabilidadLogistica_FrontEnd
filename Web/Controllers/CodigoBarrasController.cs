using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Controllers.Security;

namespace Web.Controllers
{
    public class CodigoBarrasController : BaseController
    {
        public IActionResult ImpresionEtiquetas()
        {
            return View();
        }
        public IActionResult EscaneoProductos()
        {
            return View();
        }
        public IActionResult Interface()
        {
            return View();
        }
    }
}
