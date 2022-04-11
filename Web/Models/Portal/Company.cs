using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Portal
{
    public class Company
    {
        public List<CompanyResponse> Companies { get; set; }
        public Company(IEnumerable<dynamic> companies)
        {
            Companies = new List<CompanyResponse>();
            foreach (var company in companies)
            {
                Companies.Add(new CompanyResponse(company));
            }
        }
        public class CompanyResponse
        {
            public int CodEmpresa { get; set; }
            public string Ruc { get; set; }
            public string RazonSocial { get; set; }
            public string ServerAd { get; set; }
            public string UsuarioAd { get; set; }
            public string PasswordAd { get; set; }
            public bool Activo { get; set; }
            public int? CodUsuarioIngreso { get; set; }
            public DateTime? FechaIngreso { get; set; }
            public int? CodUsuarioActualizacion { get; set; }
            public DateTime? FechaActualizacion { get; set; }
            public CompanyResponse(dynamic company)
            {
                CodEmpresa = company.CodUsuario;
                Ruc = company.Login;
                RazonSocial = company.Nombres;
                ServerAd = company.Apellidos;
                UsuarioAd = company.NombreCompleto;
                PasswordAd = company.CodEmpresa;
                Activo = company.TipoUsuarioMa;
                CodUsuarioIngreso = company.Clave;
                FechaIngreso = company.CodUsuarioIngreso;
                CodUsuarioActualizacion = company.FechaIngreso;
                FechaActualizacion = company.CodUsuarioActualizacion;
            }
        }
    }
}
