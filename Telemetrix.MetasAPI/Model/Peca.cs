using Telemetrix.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telemetrix.API.Model.Enums;

namespace Telemetrix.API.Model
{
    public class Peca
    {

        public int Id { get; set; }
        public Empresa Empresa { get; set; }
        public int? EmpresaId { get; set; }
        public int? DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public int? SetorId { get; set; }
        public Setor Setor { get; set; }
        public int? VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        public float Valor { get; set; }
        public DateTime DataValidade { get; set; }
        public string? Codigo { get; set; }
        public int? Tipo { get; set; }
        public string? Cpf { get; set; }

        public Peca(int Idempresa, int? IdDepartamento, int Idsetor, int Idvendedor, float valor, DateTime dataValidade, int tipo, string codigo, string cpf)
        {
            EmpresaId = Idempresa;
            DepartamentoId = IdDepartamento;
            SetorId = Idsetor;
            VendedorId = Idvendedor;
            Valor = valor;
            DataValidade = InsereDataPeriodoMeta(dataValidade);
            Tipo = tipo;
            Codigo = codigo;
            Cpf = cpf;
        }

        public Peca()
        {
        }

        private DateTime InsereDataPeriodoMeta(DateTime dataValidade)
        {
            var ultimoDiaDoMes = new DateTime(dataValidade.Year, dataValidade.Month, DateTime.DaysInMonth(dataValidade.Year, dataValidade.Month));
            return ultimoDiaDoMes;
        }
    }
}
