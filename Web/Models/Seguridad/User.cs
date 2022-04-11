using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Seguridad
{
    public class User
    {
        public List<UserResponse> Users{ get; set; }
        public User(IEnumerable<dynamic> users) {
            Users = new List<UserResponse>();
            foreach (var user in users)
            {
                Users.Add(new UserResponse(user));
            }
        }
        public class UserResponse
        {
            public int CodUsuario { get; set; }
            public string Login { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string NombreCompleto { get; set; }
            public int CodEmpresa { get; set; }
            public string TipoUsuarioMa { get; set; }
            public string Clave { get; set; }
            public bool Activo { get; set; }
            public bool ActivoLogueo { get; set; }
            public int CodUsuarioIngreso { get; set; }
            public DateTime FechaIngreso { get; set; }
            public int? CodUsuarioActualizacion { get; set; }
            public DateTime? FechaActualizacion { get; set; }

            public UserResponse(dynamic user)
            {
                CodUsuario = user.CodUsuario;
                Login = user.Login;
                Nombres = user.Nombres;
                Apellidos = user.Apellidos;
                NombreCompleto = user.NombreCompleto;
                CodEmpresa = user.CodEmpresa;
                TipoUsuarioMa = user.TipoUsuarioMa;
                Clave = user.Clave;
                Activo = user.Activo;
                ActivoLogueo = user.ActivoLogueo;
                CodUsuarioIngreso = user.CodUsuarioIngreso;
                FechaIngreso = user.FechaIngreso;
                CodUsuarioActualizacion = user.CodUsuarioActualizacion;
                FechaActualizacion = user.FechaActualizacion;
            }
        }
        

    }
}
