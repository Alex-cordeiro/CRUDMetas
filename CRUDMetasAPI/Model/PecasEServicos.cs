using System;

namespace CRUDMetasAPI.Model
{
    public class PecasEServicos
    {
        public int Id { get; set; }
        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }
        public int FilialId { get; set; }
        public Filial Filial { get; set; }
        public int Setor { get; set; }
        public string Vendedor { get; set; }
        public float Valor { get; set; }
        public DateTime DataValidade { get; set; }

        public PecasEServicos(int id, Empresa empresa, Filial filial, int setor, string vendedor, float valor)
        {
            Id = id;
            Empresa = empresa;
            Filial = filial;
            Setor = setor;
            Vendedor = vendedor;
            Valor = valor;
        }
    }
}
