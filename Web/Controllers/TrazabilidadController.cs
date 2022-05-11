using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PE_AAUDIT_ACL_WEB.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Controllers.Security;

namespace Web.Controllers
{
    public class TrazabilidadController : BaseController
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
        public IActionResult OrdenCompra()
        {
            return View();
        }
        public IActionResult PartesEntrada()
        {
            return View();
        }
        public IActionResult AlmacenD()
        {
            return View();
        }
        public IActionResult ValeEntrada()
        {
            return View();
        }
        public IActionResult Trazabilidad()
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
                queries.Add(new KeyValuePair<string, string>("empresa", UsuarioLogueado.CodEmpresa.ToString()));

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

        public async Task<IActionResult> getRequerimiento(string idReq)
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "Requerimiento/getRequerimiento", new { idReq = idReq, empresa = UsuarioLogueado.CodEmpresa });
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

        public async Task<IActionResult> getTrazabilidadDetalle(string idReq)
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "Requerimiento/getTrazabilidadDetalle", new { idReq = idReq });
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }

        public async Task<IActionResult> getOrdenCompra(DateTime fecIni, DateTime fecFin)
        {
            try
            {
                var httpClient = new HttpClient();
                var api = _configuration["Api:root"];

                List<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>();

                queries.Add(new KeyValuePair<string, string>("fecIni", fecIni.ToString()));
                queries.Add(new KeyValuePair<string, string>("fecFin", fecFin.ToString()));
                queries.Add(new KeyValuePair<string, string>("empresa", UsuarioLogueado.CodEmpresa.ToString()));

                HttpContent httpContent = new FormUrlEncodedContent(queries);

                var response = await httpClient.PostAsync(api + "Requerimiento/getOrdenCompra", httpContent);
                var data = await response.Content.ReadAsStringAsync();

                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }

        public async Task<IActionResult> getOCompra(string idReq)
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "Requerimiento/getOCompra", new { idReq = idReq, empresa = UsuarioLogueado.CodEmpresa });
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }

        public async Task<IActionResult> getOrdenCompraDetalle(string id)
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "Requerimiento/getOrdenCompraDetalle", new { id = id });
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }

        public async Task<IActionResult> getPartesEntrada(DateTime fecIni, DateTime fecFin)
        {
            try
            {
                var httpClient = new HttpClient();
                var api = _configuration["Api:root"];

                List<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>();

                queries.Add(new KeyValuePair<string, string>("fecIni", fecIni.ToString()));
                queries.Add(new KeyValuePair<string, string>("fecFin", fecFin.ToString()));
                queries.Add(new KeyValuePair<string, string>("empresa", UsuarioLogueado.CodEmpresa.ToString()));

                HttpContent httpContent = new FormUrlEncodedContent(queries);

                var response = await httpClient.PostAsync(api + "Requerimiento/getPartesEntrada", httpContent);
                var data = await response.Content.ReadAsStringAsync();

                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }

        public async Task<IActionResult> getParteEntrada(string idReq)
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "Requerimiento/getParteEntrada", new { idReq = idReq, empresa = UsuarioLogueado.CodEmpresa });
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }

        public async Task<IActionResult> getPartesEntradaDetalle(string id)
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "Requerimiento/getPartesEntradaDetalle", new { id = id });
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }
    }
}
