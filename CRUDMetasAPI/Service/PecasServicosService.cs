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
        public bool Insert(PecasEServicosDTO pecasEServicosDTO);
        public bool Update(PecasEServicosDTO pecasEServicosDTO);
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
                                          join setor in _metasContext.Setores on pecasServicos.SetorId equals setor.Id
                                          join vendedor in _metasContext.Vendedores on pecasServicos.VendedorId equals vendedor.Id
                                        select new PecasEServicosDTO()
                                        {
                                            Id = pecasServicos.Id,
                                            IdEmpresa = empresa.Id,
                                            Empresa = empresa.NomeEmpresa,
                                            Vendedor = vendedor.Nome,
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
                                          join setor in _metasContext.Setores on pecasServicos.SetorId equals setor.Id
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

        public bool Insert(PecasEServicosDTO pecasdto)
        {    
            var pecasServicosParaInsercao = new PecasEServicos(pecasdto.IdEmpresa, pecasdto.IdFilial, pecasdto.IdSetor, pecasdto.IdVendedor, pecasdto.Valor);

            if (pecasdto != null)
            {
                try
                {
                    _metasContext.PecasEServicos.Add(pecasServicosParaInsercao);
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

        public bool Update(PecasEServicosDTO pecasdto)
        {
            int pecasId = Convert.ToInt32(pecasdto.Id);
            try
            {
                var pecasRetornada = Exists(pecasdto.Id);
                if (pecasRetornada != null)
                {
                    _metasContext.Entry(pecasRetornada).CurrentValues.SetValues(pecasdto);
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
