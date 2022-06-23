using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telemetrix.API.Context;
using Telemetrix.API.Model;
using Telemetrix.API.Model.DTOs;

namespace Telemetrix.API.Service
{
    interface IPecaService
    {
        public IEnumerable<PecaDTO> FindAll();
        public IEnumerable<PecaDTO> FindById(int Id);
        public bool Insert(PecaDTO pecasEServicosDTO);
        public bool Update(PecaDTO pecasEServicosDTO);
        public Peca Exists(int Id);
    }

    public class PecaService : IPecaService
    {
        private readonly MetasContext _metasContext;
        public PecaService(MetasContext metasContext)
        {
            _metasContext = metasContext;
        }

        public IEnumerable<PecaDTO> FindAll()
        {
            var pecasRetornados = from pecas in _metasContext.Pecas
                                          join empresas in _metasContext.Empresas on pecas.EmpresaId equals empresas.Id
                                          join departamentos in _metasContext.Departamentos on pecas.DepartamentoId equals departamentos.Id
                                          join setores in _metasContext.Setores on pecas.SetorId equals setores.Id
                                          join vendedores in _metasContext.Vendedores on pecas.VendedorId equals vendedores.Id
                                          select new PecaDTO()
                                          {
                                              Id = pecas.Id,
                                              IdEmpresa = empresas.Id,
                                              Empresa = empresas.NomeEmpresa,
                                              Vendedor = vendedores.Nome,
                                              IdDepartamento = departamentos.Id,
                                              Departamento = departamentos.Nome,
                                              IdSetor = setores.Id,
                                              Setor = setores.Nome,
                                              DataValidade = pecas.DataValidade,
                                              Valor = pecas.Valor,
                                          };
            return pecasRetornados;
        }

        public IEnumerable<PecaDTO> FindById(int Id)
        {

            var pecaRetornado = from pecas in _metasContext.Pecas
                                          join empresas in _metasContext.Empresas on pecas.EmpresaId equals empresas.Id
                                          join departamentos in _metasContext.Departamentos on pecas.DepartamentoId equals departamentos.Id
                                          join setores in _metasContext.Setores on pecas.SetorId equals setores.Id
                                          join vendedores in _metasContext.Vendedores on pecas.VendedorId equals vendedores.Id
                                          where pecas.Id == Id
                                          select new PecaDTO()
                                          {
                                              Id = pecas.Id,
                                              IdEmpresa = empresas.Id,
                                              Empresa = empresas.NomeEmpresa,
                                              Vendedor = vendedores.Nome,
                                              IdDepartamento = departamentos.Id,
                                              Departamento = departamentos.Nome,
                                              IdSetor = setores.Id,
                                              Setor = setores.Nome,
                                              //DataValidade = pecas.DataValidade
                                          };

            return pecaRetornado;
        }

        public bool Insert(PecaDTO pecasdto)
        {
            var pecasServicosParaInsercao = new Peca(pecasdto.IdEmpresa, pecasdto.IdDepartamento, pecasdto.IdSetor, pecasdto.IdVendedor, pecasdto.Valor, pecasdto.DataValidade);

            if (pecasdto != null)
            {
                try
                {
                    _metasContext.Pecas.Add(pecasServicosParaInsercao);
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

        public bool Update(PecaDTO pecadto)
        {
            try
            {
                var pecaRetornada = Exists(pecadto.Id);
                if (pecaRetornada != null)
                {
                    _metasContext.Entry(pecaRetornada).CurrentValues.SetValues(pecadto);
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


        public Peca Exists(int Id)
        {
            var pecas = _metasContext.Pecas.SingleOrDefault(p => p.Id.Equals(Id));
            if (pecas != null)
                return pecas;
            return null;
        }
    }
}
