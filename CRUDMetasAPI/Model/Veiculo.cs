using System;

namespace CRUDMetasAPI.Model
{
    public class Veiculo
    {

        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public int FilialId { get; set; }
        public int SetorId { get; set; }
        public int VendedorId { get; set; }
        public string Familia { get; set; }
        public int Quantidade { get; set; }
        public float Valor { get; set; }
        public DateTime DataValidade { get; set; }

        public Veiculo()
        {
        }

        public Veiculo(int idEmpresa, int idFilial, int idSetor, int idVendedor, string familia, int quantidade, float valor)
        {
            EmpresaId = idEmpresa;
            FilialId = idFilial;
            SetorId = idSetor;
            VendedorId = idVendedor;
            Familia = familia;
            Quantidade = quantidade;
            Valor = valor;
            DataValidade = InsereDataPeriodoMeta();
        }

        private DateTime InsereDataPeriodoMeta()
        {
            DateTime data = DateTime.Today;
            var ultimoDiaDoMes = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
            return ultimoDiaDoMes;
        }
    }
}
