using CRUDMetasAPI.Context;
using CRUDMetasAPI.Model;
using CRUDMetasAPI.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDMetasAPI.Service
{
    interface IVeiculosService
    {
        public IEnumerable<VeiculoDTO> FindAll();
        public IEnumerable<VeiculoDTO> FindById(int Id);
        public bool Insert(VeiculoDTO veiculodto);
        public bool Update(VeiculoDTO veiculodto);
        public Veiculo Exists(int Id);
    }

    public class VeiculosService : IVeiculosService
    {
        private readonly MetasContext _metasContext;
        public VeiculosService(MetasContext metasContext)
        {
            _metasContext = metasContext;
        }

        public IEnumerable<VeiculoDTO> FindAll()
        {
            var veiculosRetornados = from veiculos in _metasContext.Veiculos
                                          join empresa in _metasContext.Empresas on veiculos.EmpresaId equals empresa.Id
                                          join filial in _metasContext.Filial on veiculos.FilialId equals filial.Id
                                          join setor in _metasContext.Setores on veiculos.SetorId equals setor.Id
                                          join vendedor in _metasContext.Vendedores on veiculos.VendedorId equals vendedor.Id
                                          select new VeiculoDTO()
                                          {
                                              Id = veiculos.Id,
                                              IdEmpresa = empresa.Id,
                                              Empresa = empresa.NomeEmpresa,
                                              IdFilial = filial.Id,
                                              Filial = filial.NomeFilial,
                                              IdSetor = setor.Id,
                                              Setor = setor.Nome,
                                              IdVendedor = vendedor.Id,
                                              Vendedor = vendedor.Nome,
                                              DataValidade = veiculos.DataValidade
                                          };
            return veiculosRetornados;
        }

        public IEnumerable<VeiculoDTO> FindById(int Id)
        {

            var veiculoRetornado = from veiculos in _metasContext.Veiculos
                                     join empresa in _metasContext.Empresas on veiculos.EmpresaId equals empresa.Id
                                     join filial in _metasContext.Filial on veiculos.FilialId equals filial.Id
                                     join setor in _metasContext.Setores on veiculos.SetorId equals setor.Id
                                     join vendedor in _metasContext.Vendedores on veiculos.VendedorId equals vendedor.Id
                                     where veiculos.Id == Id
                                     select new VeiculoDTO()
                                     {
                                         Id = veiculos.Id,
                                         IdEmpresa = empresa.Id,
                                         Empresa = empresa.NomeEmpresa,
                                         IdFilial = filial.Id,
                                         Filial = filial.NomeFilial,
                                         IdSetor = setor.Id,
                                         Setor = setor.Nome,
                                         IdVendedor = vendedor.Id,
                                         Vendedor = vendedor.Nome,
                                         DataValidade = veiculos.DataValidade
                                     };

            return veiculoRetornado;
        }

        public bool Insert(VeiculoDTO veiculodto)
        {
            var veiculoParaInsercao = new Veiculo(veiculodto.IdEmpresa, veiculodto.IdFilial, veiculodto.IdSetor,veiculodto.IdVendedor, veiculodto.Familia, veiculodto.Quantidade, veiculodto.Valor);

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
            int veiculoId = Convert.ToInt32(veiculoDTO.Id);
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
