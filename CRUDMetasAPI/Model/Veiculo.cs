using System;

namespace Telemetrix.API.Model
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

        public Veiculo(int idEmpresa, int idFilial, int idSetor, int idVendedor, string familia, int quantidade, float valor, DateTime dataValidade)
        {
            EmpresaId = idEmpresa;
            FilialId = idFilial;
            SetorId = idSetor;
            VendedorId = idVendedor;
            Familia = familia;
            Quantidade = quantidade;
            Valor = valor;
            DataValidade = InsereDataPeriodoMeta(dataValidade);
        }

        private DateTime InsereDataPeriodoMeta(DateTime dataValidade)
        {
            var ultimoDiaDoMes = new DateTime(dataValidade.Year, dataValidade.Month, DateTime.DaysInMonth(dataValidade.Year, dataValidade.Month));
            return ultimoDiaDoMes;
        }
    }
}
