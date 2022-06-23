using Telemetrix.API.Context;
using Telemetrix.API.Model.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Telemetrix.API.Service
{
    public interface IDepartamentoService
    {
        public IEnumerable<DepartamentoDTO> FindById(int idEmpresa);
        public IEnumerable<DepartamentoDTO> FindByIdEmpresa(int idEmpresa);
    }
    public class DepartamentoService : IDepartamentoService
    {
        private readonly MetasContext _metasContext;

        public DepartamentoService(MetasContext metasContext)
        {
            _metasContext = metasContext;
        }

        public IEnumerable<DepartamentoDTO> FindByIdEmpresa(int idEmpresa)
        {
            var filialDTO = from departamento in _metasContext.Departamentos
                            join empresa in _metasContext.Empresas on departamento.EmpresaId equals empresa.Id
                            where empresa.Id == idEmpresa
                            select new DepartamentoDTO()
                            {
                                Id = departamento.Id,
                                Nome = departamento.Nome,
                                EmpresaId = empresa.Id
                            };
            return filialDTO;
        }

        public IEnumerable<DepartamentoDTO> FindById(int idDepartamento)
        {
            var filialDTO = from filial in _metasContext.Departamentos
                            where filial.Id == idDepartamento
                            select new DepartamentoDTO()
                            {
                                Id = filial.Id,
                                Nome = filial.Nome,
                            };
            return filialDTO;
        }
    }
}
