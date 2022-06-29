using System.Collections.Generic;

namespace Telemetrix.API.Model
{
    public class Empresa
    {
        public int Id { get; set; }
        public string NomeEmpresa { get; set; }
        public List<Vendedor> Vendedores { get; set; }
        public List<Departamento> EmpresaDepartamentos { get; set; }

        public Empresa(int id, string nomeEmpresa)
        {
            Id = id;
            NomeEmpresa = nomeEmpresa;
        }

        public Empresa()
        {
        }
    }
}
