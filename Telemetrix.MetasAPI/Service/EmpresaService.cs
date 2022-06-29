using Telemetrix.API.Context;
using Telemetrix.API.Model.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Telemetrix.API.Service
{
    public interface IEmpresaService
    {
        public IEnumerable<EmpresaDTO> FindAll();
    }
    public class EmpresaService : IEmpresaService
    {
        private readonly MetasContext _metasContext;

        public EmpresaService(MetasContext metasContext)
        {
            _metasContext = metasContext;
        }

        public IEnumerable<EmpresaDTO> FindAll()
        {

            var empresasDTO = from empresa in _metasContext.Empresas
                              select new EmpresaDTO()
                              {
                                  Id = empresa.Id,
                                  Nome = empresa.NomeEmpresa,
                                   
                              };
            return empresasDTO;
        }
    }
}
