using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telemetrix.API.Context;
using Telemetrix.API.Model;
using Telemetrix.API.Model.DTOs;

namespace Telemetrix.API.Service
{
    interface IServicoService
    { 
        public IEnumerable<ServicoDTO> FindAll();
        public IEnumerable<ServicoDTO> FindById(int Id);
        public bool Insert(ServicoDTO servicosDTO);
        public bool Update(ServicoDTO servicosDTO);
        public Servico Exists(int Id);
    }
    public class ServicoService : IServicoService
    {
        private readonly MetasContext _metasContext;

        public ServicoService(MetasContext metasContext)
        {
            _metasContext = metasContext;
        }

        public IEnumerable<ServicoDTO> FindAll()
        {
            var servicosRetornados = from servicos in _metasContext.Servicos
                                          join empresas in _metasContext.Empresas on servicos.EmpresaId equals empresas.Id
                                          join departamentos in _metasContext.Setores on servicos.DepartamentoId equals departamentos.Id
                                          join setores in _metasContext.Setores on servicos.SetorId equals setores.Id
                                          join vendedores in _metasContext.Vendedores on servicos.VendedorId equals vendedores.Id
                                          select new ServicoDTO()
                                          {
                                              Id = servicos.Id,
                                              IdEmpresa = empresas.Id,
                                              Empresa = empresas.NomeEmpresa,
                                              Vendedor = vendedores.Nome,
                                              IdDepartamento = departamentos.Id,
                                              Departamento = departamentos.Nome,
                                              IdSetor = setores.Id,
                                              Setor = setores.Nome,
                                              DataValidade = servicos.DataValidade
                                          };
            return servicosRetornados;
        }

        public IEnumerable<ServicoDTO> FindById(int Id)
        {

            var servicoRetornado = from servicos in _metasContext.Servicos
                                     join empresas in _metasContext.Empresas on servicos.EmpresaId equals empresas.Id
                                     join departamentos in _metasContext.Setores on servicos.DepartamentoId equals departamentos.Id
                                     join setores in _metasContext.Setores on servicos.SetorId equals setores.Id
                                     join vendedores in _metasContext.Vendedores on servicos.VendedorId equals vendedores.Id
                                     where servicos.Id == Id
                                     select new ServicoDTO()
                                     {
                                         Id = servicos.Id,
                                         IdEmpresa = empresas.Id,
                                         Empresa = empresas.NomeEmpresa,
                                         Vendedor = vendedores.Nome,
                                         IdDepartamento = departamentos.Id,
                                         Departamento = departamentos.Nome,
                                         IdSetor = setores.Id,
                                         Setor = setores.Nome,
                                         DataValidade = servicos.DataValidade
                                     };

            return servicoRetornado;
        }

        public bool Insert(ServicoDTO servicodto)
        {
            var servicoParaInsercao = new Servico(servicodto.IdEmpresa, servicodto.IdDepartamento, servicodto.IdSetor, servicodto.IdVendedor, servicodto.Valor, servicodto.DataValidade);

            if (servicoParaInsercao != null)
            {
                try
                {
                    _metasContext.Servicos.Add(servicoParaInsercao);
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

        public bool Update(ServicoDTO servicodto)
        {
            try
            {
                var servicoRetornado = Exists(servicodto.Id);
                if (servicoRetornado != null)
                {
                    _metasContext.Entry(servicoRetornado).CurrentValues.SetValues(servicodto);
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


        public Servico Exists(int id)
        {
            try
            {
                var servico = _metasContext.Servicos.SingleOrDefault(p => p.Id.Equals(id));

                if (servico != null)
                    return servico;
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
    }
}
