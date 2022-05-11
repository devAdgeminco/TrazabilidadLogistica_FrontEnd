using CSS.Proveedores.Libreria.Seguridad;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PE_AAUDIT_ACL_WEB.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Controllers.Security;
using Web.Models.Portal;
using Web.Models.Seguridad;
using static Web.Models.Seguridad.User;

namespace Web.Controllers
{
    //[Area("Security")]
    public class LoginController : BaseController
    {

        private readonly IConfiguration _configuration;

        public object DatetimeHelper { get; private set; }

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
                if (login.User == "" || login.User == null)
                {
                    throw new Exception("Usuario no valido");
                }
                if (login.Contrasena == "" || login.Contrasena == null)
                {
                    throw new Exception("Contraseña no valida");
                }
                var httpClient = new HttpClient();
                var api = _configuration["Api:root"];

                List<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>();

                queries.Add(new KeyValuePair<string, string>("login", login.User));
                queries.Add(new KeyValuePair<string, string>("CodEmpresa", login.Company.ToString()));

                HttpContent httpContent = new FormUrlEncodedContent(queries);

                var response = await httpClient.PostAsync(api + "User/login", httpContent);
                var sResponse = await response.Content.ReadAsStringAsync();
                
                JObject jusuario = JObject.Parse(sResponse);
                if (jusuario["login"].Count() == 0)
                {
                    throw new Exception("Usuario no se encuentra registrado");
                }

                UserLoginAPI _UserLoginAPI = new UserLoginAPI() { 
                    CodUsuario = (int?)jusuario["login"][0]["CodUsuario"],
                    Login = (string)jusuario["login"][0]["Login"],
                    Nombres = (string)jusuario["login"][0]["Nombres"],
                    Apellidos = (string)jusuario["login"][0]["Apellidos"],
                    NombreCompleto = (string)jusuario["login"][0]["NombreCompleto"],
                    CodEmpresa = (int?)jusuario["login"][0]["CodEmpresa"],
                    RazonSocial = (string)jusuario["login"][0]["RazonSocial"],
                    TipoUsuarioMa = (string)jusuario["login"][0]["TipoUsuarioMa"],
                    NivelUsuario = (string)jusuario["login"][0]["NivelUsuario"],
                    Activo = (bool)jusuario["login"][0]["Activo"],
                    ActivoLogueo = (bool)jusuario["login"][0]["ActivoLogueo"],
                    CodUsuarioIngreso = (int?)jusuario["login"][0]["CodUsuarioIngreso"],
                    FechaIngreso = (DateTime?)jusuario["login"][0]["FechaIngreso"],
                    CodUsuarioActualizacion = (int?)jusuario["login"][0]["CodUsuarioActualizacion"],
                    FechaActualizacion = (DateTime?)jusuario["login"][0]["FechaActualizacion"],
                    IdPerfil = (int)jusuario["login"][0]["IdPerfil"],
                    Perfil = (string)jusuario["login"][0]["Perfil"],
                    Token = (string)jusuario["token"]
                };

                string contrasena = (string)jusuario["login"][0]["Clave"];
                string pswd = Encryptor.Encriptar(login.Contrasena.Trim());

                //string desecn = Encryptor.Desencriptar(contrasena);
                if (contrasena != pswd)
                {
                    throw new Exception("Contraseña incorrecta");
                }

                UserLogueado usuarioLogueado = JsonConvert.SerializeObject(_UserLoginAPI);

                List<Claim> lstClaim = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, usuarioLogueado)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(lstClaim, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = false,
                        ExpiresUtc = DateTime.Now.AddDays(100)
                    });


                return Ok(new { value = sResponse, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }

        }

        [HttpPost]
        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new { value = "", status = true });
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

        public async Task<IActionResult> GetModulos(int CodUsuario)
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "User/getModulos", new { CodUsuario = CodUsuario });
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }

        }
    }
}
