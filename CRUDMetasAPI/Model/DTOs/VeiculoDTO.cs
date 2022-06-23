using System;

namespace Telemetrix.API.Model.DTOs
{
    public class VeiculoDTO
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Empresa { get; set; }
        public string Departamento { get; set; }
        public int IdDepartamento { get; set; }
        public int IdSetor { get; set; }
        public string Setor { get; set; }
        public string Vendedor { get; set; }
        public int IdVendedor { get; set; }
        public string Familia { get; set; }
        public int Quantidade { get; set; }
        public float Valor { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
