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
        public bool Update(int id, PecaDTO pecasEServicosDTO);
        public bool Delete(int id);
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
                                  from setores in _metasContext.Setores
                                  .Where(setores => setores.Id == pecas.SetorId)
                                  .Where(departamentos => departamentos.Id == pecas.SetorId)
                                  .Where(vendedores => vendedores.Id == pecas.VendedorId)
                                  .Where(empresas => empresas.Id == pecas.EmpresaId)
                                  join empresas in _metasContext.Empresas on pecas.EmpresaId equals empresas.Id                                       
                                  join tiposMetas in _metasContext.TiposEntradasMetas on pecas.Tipo equals tiposMetas.Id
                                          select new PecaDTO()
                                          {
                                              Id = pecas.Id,
                                              IdEmpresa = empresas.Id,
                                              Empresa = empresas.NomeEmpresa,
                                              Vendedor = pecas.Vendedor.Nome,
                                              IdDepartamento = pecas.DepartamentoId,
                                              Departamento = pecas.Departamento.Nome,
                                              IdSetor = setores.Id,
                                              Setor = setores.Nome,
                                              DataValidade = pecas.DataValidade,
                                              Valor = pecas.Valor,
                                              DescricaoTipo = tiposMetas.Nome,
                                              Tipo = tiposMetas.Id,
                                              Cpf = pecas.Cpf
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
                                              DataValidade = pecas.DataValidade
                                          };

            return pecaRetornado;
        }

        public bool Insert(PecaDTO pecasdto)
        {
            var pecasServicosParaInsercao = new Peca(pecasdto.IdEmpresa, pecasdto?.IdDepartamento, pecasdto.IdSetor, pecasdto.IdVendedor, pecasdto.Valor, pecasdto.DataValidade, pecasdto.Tipo, pecasdto.Codigo, pecasdto.Cpf);

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

        public bool Update( int idPeca, PecaDTO pecadto)
        {
            try
            {
                var pecaRetornada = Exists(idPeca);
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
        public bool Delete(int id)
        {
            try
            {
                var objetoRetornado = _metasContext.Pecas.SingleOrDefault(p => p.Id.Equals(id));
                if (objetoRetornado != null)
                {
                    _metasContext.Pecas.Remove(objetoRetornado);
                    _metasContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
            return false;
        }

        public Peca Exists(int Id)
        {
            var pecas = _metasContext.Pecas.SingleOrDefault(p => p.Id.Equals(Id));
            if (pecas != null)
                return pecas;
            return null;
        }

        public bool Atualizar(PecaDTO pecaDTO)
        {
            if(pecaDTO != null)
            {
                try
                {
                    var pecaRetornada = Exists(pecaDTO.Id);
                    if (pecaRetornada != null)
                        Update(pecaDTO.Id, pecaDTO);

                    Insert(pecaDTO);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
              
            }
            return false;
        }
    }
}
