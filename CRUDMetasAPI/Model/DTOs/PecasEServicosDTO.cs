using System;

namespace CRUDMetasAPI.Model.DTOs
{
    public class PecasEServicosDTO
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Empresa { get; set; }
        public int IdFilial { get; set; }
        public string Filial { get; set; }
        public int IdSetor { get; set; }
        public string Setor { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
