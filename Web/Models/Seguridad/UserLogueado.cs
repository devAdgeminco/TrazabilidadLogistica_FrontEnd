using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Seguridad
{
    public class UserLogueado
    {
        public int? CodUsuario { get; set; }
        public string Login { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreCompleto { get; set; }
        public int? CodEmpresa { get; set; }
        public string TipoUsuarioMa { get; set; }
        public string NivelUsuario { get; set; }
        public bool Activo { get; set; }
        public bool ActivoLogueo { get; set; }
        public int? CodUsuarioIngreso { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? CodUsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string Token { get; set; }

        public static implicit operator UserLogueado(string usuarioAuthentication)
        {
            JObject jusuario = JObject.Parse(usuarioAuthentication);
            UserLogueado usuario = new UserLogueado()
            {
                CodUsuario = (int?)jusuario[nameof(CodUsuario)],
                Login = (string)jusuario[nameof(Login)],
                Nombres = (string)jusuario[nameof(Nombres)],
                Apellidos = (string)jusuario[nameof(Apellidos)],
                NombreCompleto = (string)jusuario[nameof(NombreCompleto)],
                CodEmpresa = (int?)jusuario[nameof(CodEmpresa)],
                TipoUsuarioMa = (string)jusuario[nameof(TipoUsuarioMa)],
                NivelUsuario = (string)jusuario[nameof(NivelUsuario)],
                Activo = (bool)jusuario[nameof(Activo)],
                ActivoLogueo = (bool)jusuario[nameof(ActivoLogueo)],
                CodUsuarioIngreso = (int?)jusuario[nameof(CodUsuarioIngreso)],
                FechaIngreso = (DateTime?)jusuario[nameof(FechaIngreso)],
                CodUsuarioActualizacion = (int?)jusuario[nameof(CodUsuarioActualizacion)],
                FechaActualizacion = (DateTime?)jusuario[nameof(FechaActualizacion)],
                Token = (string)jusuario[nameof(Token)],
            };
            return usuario;
        }

        public static implicit operator string(UserLogueado usuarioAuthentication)
        {
            JObject jusuario = new JObject()
            {
                [nameof(CodUsuario)] = usuarioAuthentication.CodUsuario,
                [nameof(Login)] = usuarioAuthentication.Login,
                [nameof(Nombres)] = usuarioAuthentication.Nombres,
                [nameof(Apellidos)] = usuarioAuthentication.Apellidos,
                [nameof(NombreCompleto)] = usuarioAuthentication.NombreCompleto,
                [nameof(CodEmpresa)] = usuarioAuthentication.CodEmpresa,
                [nameof(TipoUsuarioMa)] = usuarioAuthentication.TipoUsuarioMa,
                [nameof(Activo)] = usuarioAuthentication.Activo,
                [nameof(ActivoLogueo)] = usuarioAuthentication.ActivoLogueo,
                [nameof(CodUsuarioIngreso)] = usuarioAuthentication.CodUsuarioIngreso,
                [nameof(FechaIngreso)] = usuarioAuthentication.FechaIngreso,
                [nameof(CodUsuarioActualizacion)] = usuarioAuthentication.CodUsuarioActualizacion,
                [nameof(FechaActualizacion)] = usuarioAuthentication.FechaActualizacion,
                [nameof(Token)] = usuarioAuthentication.Token
            };
            return jusuario.ToString();
        }
    }
}
