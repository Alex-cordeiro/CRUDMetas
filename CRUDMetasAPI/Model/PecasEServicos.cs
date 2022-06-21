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
        public int SetorId { get; set; }
        public Setor Setor { get; set; }
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        public float Valor { get; set; }
        public DateTime DataValidade { get; set; }

        public PecasEServicos(int Idempresa, int Idfilial, int Idsetor, int Idvendedor, float valor)
        {
            EmpresaId = Idempresa;
            FilialId = Idfilial;
            SetorId = Idsetor;
            VendedorId = Idvendedor;
            Valor = valor;
            DataValidade = InsereDataPeriodoMeta();
        }

        public PecasEServicos()
        {
        }

        private DateTime InsereDataPeriodoMeta()
        {
            DateTime data = DateTime.Today;
            var ultimoDiaDoMes = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year,data.Month));
            return ultimoDiaDoMes;
        }
    }
}
