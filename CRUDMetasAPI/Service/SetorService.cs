using Telemetrix.API.Context;
using Telemetrix.API.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telemetrix.API.Service
{
    public interface ISetorService
    {
        public IEnumerable<SetorDTO> FindById(int idEmpresa);
        public IEnumerable<SetorDTO> FindByIdEmpresa(int idEmpresa);
    }
    public class SetorService : ISetorService
    {
        private readonly MetasContext _metasContext;

        public SetorService(MetasContext metasContext)
        {
            _metasContext = metasContext;
        }

        public IEnumerable<SetorDTO> FindByIdEmpresa(int idEmpresa)
        {
            var filialDTO = from setor in _metasContext.Setores
                            join empresa in _metasContext.Empresas on setor.EmpresaId equals empresa.Id
                            where empresa.Id == idEmpresa
                            select new SetorDTO()
                            {
                                Id = setor.Id,
                                Nome = setor.Nome,
                                EmpresaId = empresa.Id
                            };
            return filialDTO;
        }

        public IEnumerable<SetorDTO> FindById(int idEmpresa)
        {
            var filialDTO = from setor in _metasContext.Setores
                            where setor.Id == idEmpresa
                            select new SetorDTO()
                            {
                                Id = setor.Id,
                                Nome = setor.Nome,
                            };
            return filialDTO;
        }
    }
}
