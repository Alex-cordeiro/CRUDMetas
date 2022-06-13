using CRUDMetasAPI.Context;
using CRUDMetasAPI.Model;
using CRUDMetasAPI.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDMetasAPI.Service
{
    interface IPecasEServicosService
    {
        public IEnumerable<PecasEServicosDTO> FindAll();
        public IEnumerable<PecasEServicosDTO> FindById(int Id);
        public bool Insert(PecasEServicos pecasEServicos);
        public bool Update(PecasEServicos pecasEServicos);
        public PecasEServicos Exists(int Id);
    }

    public class PecasServicosService : IPecasEServicosService
    {
        private readonly MetasContext _metasContext;
        public PecasServicosService(MetasContext metasContext)
        {
            _metasContext = metasContext;
        }

        public IEnumerable<PecasEServicosDTO> FindAll()
        {
            var pecasServicosRetornados = from pecasServicos in _metasContext.PecasEServicos
                                          join empresa in _metasContext.Empresas on pecasServicos.EmpresaId equals empresa.Id
                                          join filial in _metasContext.Filial on pecasServicos.FilialId equals filial.Id
                                          join setor in _metasContext.Setores on pecasServicos.Setor equals setor.Id
                                        select new PecasEServicosDTO()
                                        {
                                            Id = pecasServicos.Id,
                                            IdEmpresa = empresa.Id,
                                            Empresa = empresa.NomeEmpresa,
                                            IdFilial = filial.Id,
                                            Filial = filial.NomeFilial,
                                            IdSetor = setor.Id,
                                            Setor = setor.Nome,
                                            DataValidade = pecasServicos.DataValidade
                                        };
            return pecasServicosRetornados;
        }

        public IEnumerable<PecasEServicosDTO> FindById(int Id)
        {

            var pecasServicosRetornados = from pecasServicos in _metasContext.PecasEServicos
                                          join empresa in _metasContext.Empresas on pecasServicos.EmpresaId equals empresa.Id
                                          join filial in _metasContext.Filial on pecasServicos.FilialId equals filial.Id
                                          join setor in _metasContext.Setores on pecasServicos.Setor equals setor.Id
                                          where pecasServicos.Id == Id
                                          select new PecasEServicosDTO()
                                          {
                                              Id = pecasServicos.Id,
                                              IdEmpresa = empresa.Id,
                                              Empresa = empresa.NomeEmpresa,
                                              IdFilial = filial.Id,
                                              Filial = filial.NomeFilial,
                                              IdSetor = setor.Id,
                                              Setor = setor.Nome,
                                              DataValidade = pecasServicos.DataValidade
                                          };

            return pecasServicosRetornados;
        }

        public bool Insert(PecasEServicos pecas)
        {
            try
            {
                _metasContext.PecasEServicos.Add(pecas);
                _metasContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Update(PecasEServicos pecas)
        {
            int pecasId = Convert.ToInt32(pecas.Id);
            try
            {
                var pecasRetornada = Exists(pecas.Id);
                if (pecasRetornada != null)
                {
                    _metasContext.Entry(pecasRetornada).CurrentValues.SetValues(pecas);
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


        public PecasEServicos Exists(int Id)
        {
            var pecas = _metasContext.PecasEServicos.SingleOrDefault(p => p.Id.Equals(Id));
            if (pecas != null)
                return pecas;
            return null;
        }
    }
}
