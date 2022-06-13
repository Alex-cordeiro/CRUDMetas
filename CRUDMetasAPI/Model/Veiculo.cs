using System;

namespace CRUDMetasAPI.Model
{
    public class Veiculo
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public Filial Filial { get; set; }
        public int FilialId { get; set; }
        public int Setor { get; set; }
        public string Vendedor { get; set; }
        public string Familia { get; set; }
        public float Quantidade { get; set; }
        public float Valor { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
