using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PE_AAUDIT_ACL_WEB.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class TrazabilidadController : Controller
    {
        private readonly IConfiguration _configuration;

        public TrazabilidadController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> getRequerimientos(DateTime fecIni, DateTime fecFin)
        {
            try
            {
                var httpClient = new HttpClient();
                var api = _configuration["Api:root"];

                List<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>();

                queries.Add(new KeyValuePair<string, string>("fecIni", fecIni.ToString()));
                queries.Add(new KeyValuePair<string, string>("fecFin", fecFin.ToString()));

                HttpContent httpContent = new FormUrlEncodedContent(queries);

                var response = await httpClient.PostAsync(api + "Requerimiento/getRequerimientos", httpContent);
                var data = await response.Content.ReadAsStringAsync();

                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }

        public async Task<IActionResult> getRequerimientoDetalle(string idReq)
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "Requerimiento/getRequerimientoDetalle", new { idReq = idReq });
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }
    }
}
