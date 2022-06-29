using Telemetrix.API.Context;
using Telemetrix.API.Model;
using Telemetrix.API.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Telemetrix.API.Service
{
    interface IVeiculoService
    {
        public IEnumerable<VeiculoDTO> FindAll();
        public IEnumerable<VeiculoDTO> FindById(int Id);
        public bool Insert(VeiculoDTO veiculodto);
        public bool Update(VeiculoDTO veiculodto);
        public Veiculo Exists(int Id);
    }

    public class VeiculoService : IVeiculoService
    {
        private readonly MetasContext _metasContext;
        public VeiculoService(MetasContext metasContext)
        {
            _metasContext = metasContext;
        }

        public IEnumerable<VeiculoDTO> FindAll()
        {
            var veiculosRetornados = from veiculos in _metasContext.Veiculos
                                   join empresas in _metasContext.Empresas on veiculos.EmpresaId equals empresas.Id
                                   join departamentos in _metasContext.Departamentos on veiculos.DepartamentoId equals departamentos.Id
                                   join setores in _metasContext.Setores on veiculos.SetorId equals setores.Id
                                   join vendedores in _metasContext.Vendedores on veiculos.VendedorId equals vendedores.Id
                                   join tipoentradaMeta in _metasContext.TiposEntradasMetas on veiculos.Tipo equals tipoentradaMeta.Id
                                   select new VeiculoDTO()
                                   {
                                       Id = veiculos.Id,
                                       IdEmpresa = empresas.Id,
                                       Empresa = empresas.NomeEmpresa,
                                       IdDepartamento = departamentos.Id,
                                       Departamento = departamentos.Nome,
                                       IdSetor = setores.Id,
                                       Setor = setores.Nome,
                                       IdVendedor = vendedores.Id,
                                       Vendedor = vendedores.Nome,
                                       DataValidade = veiculos.DataValidade,
                                       Tipo = tipoentradaMeta.Id,
                                       DescricaoTipo = tipoentradaMeta.Nome,
                                       Valor = veiculos.Valor
                                   };
            return veiculosRetornados;
        }

        public IEnumerable<VeiculoDTO> FindById(int Id)
        {

            var veiculoRetornado = from veiculos in _metasContext.Veiculos
                                     join empresas in _metasContext.Empresas on veiculos.EmpresaId equals empresas.Id
                                     join departamentos in _metasContext.Departamentos on veiculos.DepartamentoId equals departamentos.Id
                                     join setores in _metasContext.Setores on veiculos.SetorId equals setores.Id
                                     join vendedores in _metasContext.Vendedores on veiculos.VendedorId equals vendedores.Id
                                     join tiposMetas in _metasContext.TiposEntradasMetas on veiculos.Tipo equals tiposMetas.Id
                                   where veiculos.Id == Id
                                     select new VeiculoDTO()
                                     {
                                         Id = veiculos.Id,
                                         IdEmpresa = empresas.Id,
                                         Empresa = empresas.NomeEmpresa,
                                         IdDepartamento = departamentos.Id,
                                         Departamento = departamentos.Nome,
                                         IdSetor = setores.Id,
                                         Setor = setores.Nome,
                                         IdVendedor = vendedores.Id,
                                         Vendedor = vendedores.Nome,
                                         DataValidade = veiculos.DataValidade,
                                         DescricaoTipo = tiposMetas.Descricao
                                     };

            return veiculoRetornado;
        }

        public bool Insert(VeiculoDTO veiculodto)
        {
            var veiculoParaInsercao = new Veiculo(veiculodto.IdEmpresa, veiculodto.IdDepartamento, veiculodto.IdSetor,veiculodto.IdVendedor, veiculodto.Familia, veiculodto.Quantidade, veiculodto.Valor, veiculodto.DataValidade, veiculodto.Tipo, veiculodto.Codigo, veiculodto.Cpf);

            if(veiculoParaInsercao != null)
            {
                try
                {
                    _metasContext.Veiculos.Add(veiculoParaInsercao);
                    _metasContext.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public bool Update(VeiculoDTO veiculoDTO)
        {
            try
            {
                var veiculoRetornado = Exists(veiculoDTO.Id);
                if (veiculoRetornado != null)
                {
                    _metasContext.Entry(veiculoRetornado).CurrentValues.SetValues(veiculoDTO);
                    _metasContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public Veiculo Exists(int Id)
        {
            var veiculo = _metasContext.Veiculos.SingleOrDefault(p => p.Id.Equals(Id));
            if (veiculo != null)
                return veiculo;
            return null;
        }
    }
}
