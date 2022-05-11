using CSS.Proveedores.Libreria.Seguridad;
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
    public class UserController : BaseController
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> getUsers()
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().GetAsync(api + "User/users");
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }

        public async Task<IActionResult> getPerfiles()
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().GetAsync(api + "User/getPerfiles");
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }

        public async Task<IActionResult> GetUserForm(int CodUsuario)
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "User/userForm", new { CodUsuario = CodUsuario });
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }

        public async Task<IActionResult> InsertUser(string Login, string Nombres, string Apellidos, int CodEmpresa, string TipoUsuarioMa, string Clave)
        {
            try
            {
                Clave = Encryptor.Encriptar(Clave);
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "User/insertUser", new { Login = Login, Nombres = Nombres, Apellidos = Apellidos, CodEmpresa = CodEmpresa, TipoUsuarioMa = TipoUsuarioMa, Clave = Clave, CodUsuarioActualizacion = UsuarioLogueado.CodUsuario });
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }

        public async Task<IActionResult> UpdateUser(int CodUsuario, string Login, string Nombres, string Apellidos, int CodEmpresa, string TipoUsuarioMa)
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "User/updateUser", new { CodUsuario = CodUsuario, Login = Login, Nombres = Nombres, Apellidos = Apellidos, CodEmpresa = CodEmpresa, TipoUsuarioMa = TipoUsuarioMa, CodUsuarioActualizacion = UsuarioLogueado.CodUsuario });
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }
        public async Task<IActionResult> DeleteUser(int CodUsuario)
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "User/deleteUser", new { CodUsuario = CodUsuario, CodUsuarioActualizacion = UsuarioLogueado.CodUsuario });
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }
        public async Task<IActionResult> UpdatePswdUser(int CodUsuario, string Clave)
        {
            try
            {
                Clave = Encryptor.Encriptar(Clave);
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "User/updatePswdUser", new { CodUsuario = CodUsuario, Clave = Clave });
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }
    }
}
