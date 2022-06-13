using System;

namespace CRUDMetasAPI.Model.DTOs
{
    public class VeiculoDTO
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Empresa { get; set; }
        public string Filial { get; set; }
        public int IdFilial { get; set; }
        public int IdSetor { get; set; }
        public string Setor { get; set; }
        public string Vendedor { get; set; }
        public string Familia { get; set; }
        public float Quantidade { get; set; }
        public float Valor { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
