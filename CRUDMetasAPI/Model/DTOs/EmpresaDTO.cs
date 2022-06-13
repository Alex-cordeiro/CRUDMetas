using System.Collections.Generic;

namespace CRUDMetasAPI.Model.DTOs
{
    public class EmpresaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Setor> Setores { get; set; }
        public List<Filial> Filiais { get; set; }
        public List<Vendedor> Vendedores { get; set; }
    }
}
