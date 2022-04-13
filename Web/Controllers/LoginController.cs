using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PE_AAUDIT_ACL_WEB.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Models.Portal;
using Web.Models.Seguridad;

namespace Web.Controllers.Security
{
    //[Area("Security")]
    public class LoginController : Controller
    {

        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> Authenticate(Login login)
        {
            try
            {
                var httpClient = new HttpClient();
                var api = _configuration["Api:root"];

                List<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>();

                queries.Add(new KeyValuePair<string, string>("login", login.User));
                queries.Add(new KeyValuePair<string, string>("CodEmpresa", login.Company.ToString()));

                HttpContent httpContent = new FormUrlEncodedContent(queries);

                var response = await httpClient.PostAsync(api + "User/login", httpContent);
                var sResponse = await response.Content.ReadAsStringAsync();
                return Ok(new { value = sResponse, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }

        }


        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().GetAsync(api + "Company/companies");
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
            
        }
    }
}
