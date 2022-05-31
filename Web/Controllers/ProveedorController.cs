using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PE_AAUDIT_ACL_WEB.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Controllers.Security;

namespace Web.Controllers
{
    public class ProveedorController : BaseController
    {
        private readonly IConfiguration _configuration;

        public ProveedorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> getAgendaAll()
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().GetAsync(api + "Proveedor/getAgendaAll" );
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }

        public async Task<IActionResult> getAgendaDetalle(int id)
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "Proveedor/getAgendaDetalle", new { id = id });
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }

        }
        
        public async Task<IActionResult> setAprobacionAgenda(int id, int value)
        {
            try
            {
                bool val = value == 0 ? false : true;
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "Proveedor/setAprobacionAgenda", new { id = id, Aprobacion = val });
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }

        }
    }
}
