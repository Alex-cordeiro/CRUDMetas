using Telemetrix.API.Model;
using System;

namespace Telemetrix.API.Model
{
    public class Servico
    {
        public int Id { get; set; }
        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public int SetorId { get; set; }
        public Setor Setor { get; set; }
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        public float Valor { get; set; }
        public DateTime DataValidade { get; set; }

        public Servico(int Idempresa, int IdDepartamento, int Idsetor, int Idvendedor, float valor, DateTime dataValidade)
        {
            EmpresaId = Idempresa;
            DepartamentoId = IdDepartamento;
            SetorId = Idsetor;
            VendedorId = Idvendedor;
            Valor = valor;
            DataValidade = InsereDataPeriodoMeta(dataValidade);
        }

        public Servico()
        {
        }

        private DateTime InsereDataPeriodoMeta(DateTime dataValidade)
        {
            var ultimoDiaDoMes = new DateTime(dataValidade.Year, dataValidade.Month, DateTime.DaysInMonth(dataValidade.Year, dataValidade.Month));
            return ultimoDiaDoMes;
        }
    }
}
