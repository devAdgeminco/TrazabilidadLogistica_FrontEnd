using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Controllers.Security;
using BarcodeLib;
using PE_AAUDIT_ACL_WEB.Helper;
using Microsoft.Extensions.Configuration;

namespace Web.Controllers
{
    public class CodigoBarrasController : BaseController
    {
        private readonly IConfiguration _configuration;

        public CodigoBarrasController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
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

        public async Task<IActionResult> getProductoCB(string id)
        {
            try
            {
                var api = _configuration["Api:root"];
                var productos = await new HttpRestClientServices<string>().PostAsync(api + "Requerimiento/getOrdenCompraDetalle", new { id = id });

                return Ok(new { value = productos, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }
    }
}
