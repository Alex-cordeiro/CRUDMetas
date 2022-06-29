using System;
using Telemetrix.API.Model.Enums;

namespace Telemetrix.API.Model
{
    public class Veiculo
    {

        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public int? SetorId { get; set; }
        public int? VendedorId { get; set; }
        public string? Familia { get; set; }
        public int? Quantidade { get; set; }
        public float Valor { get; set; }
        public DateTime DataValidade { get; set; }
        public int? Tipo { get; set; }
        public string? Codigo { get; set; }
        public string? Cpf { get; set; }

        public Veiculo()
        {
        }

        public Veiculo(int idEmpresa, int idDepartamento, int idSetor, int idVendedor, string familia, int quantidade, float valor, DateTime dataValidade, int tipo, string codigo, string cpf)
        {
            EmpresaId = idEmpresa;
            DepartamentoId = idDepartamento;
            SetorId = idSetor;
            VendedorId = idVendedor;
            Familia = familia;
            Quantidade = quantidade;
            Valor = valor;
            DataValidade = InsereDataPeriodoMeta(dataValidade);
            Tipo = tipo;
            Codigo = codigo;
            Cpf = cpf;
        }

        private DateTime InsereDataPeriodoMeta(DateTime dataValidade)
        {
            var ultimoDiaDoMes = new DateTime(dataValidade.Year, dataValidade.Month, DateTime.DaysInMonth(dataValidade.Year, dataValidade.Month));
            return ultimoDiaDoMes;
        }
    }
}
