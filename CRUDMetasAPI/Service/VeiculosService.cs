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
        public bool Insert(Veiculo veiculo);
        public bool Update(Veiculo veiculo);
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
                                          join setor in _metasContext.Setores on veiculos.Setor equals setor.Id
                                          select new VeiculoDTO()
                                          {
                                              Id = veiculos.Id,
                                              IdEmpresa = empresa.Id,
                                              Empresa = empresa.NomeEmpresa,
                                              IdFilial = filial.Id,
                                              Filial = filial.NomeFilial,
                                              IdSetor = setor.Id,
                                              Setor = setor.Nome,
                                              DataValidade = veiculos.DataValidade
                                          };
            return veiculosRetornados;
        }

        public IEnumerable<VeiculoDTO> FindById(int Id)
        {

            var veiculoRetornado = from veiculos in _metasContext.Veiculos
                                     join empresa in _metasContext.Empresas on veiculos.EmpresaId equals empresa.Id
                                     join filial in _metasContext.Filial on veiculos.FilialId equals filial.Id
                                     join setor in _metasContext.Setores on veiculos.Setor equals setor.Id
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
                                         DataValidade = veiculos.DataValidade
                                     };

            return veiculoRetornado;
        }

        public bool Insert(Veiculo veiculo)
        {
            try
            {
                _metasContext.Veiculos.Add(veiculo);
                _metasContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Update(Veiculo veiculo)
        {
            int veiculoId = Convert.ToInt32(veiculo.Id);
            try
            {
                var veiculoRetornado = Exists(veiculo.Id);
                if (veiculoRetornado != null)
                {
                    _metasContext.Entry(veiculoRetornado).CurrentValues.SetValues(veiculo);
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
