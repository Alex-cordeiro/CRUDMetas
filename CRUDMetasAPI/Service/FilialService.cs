using CRUDMetasAPI.Context;
using CRUDMetasAPI.Model.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace CRUDMetasAPI.Service
{
    public interface IFilialService
    {
        public IEnumerable<FilialDTO> FindById(int idEmpresa);
        public IEnumerable<FilialDTO> FindByIdEmpresa(int idEmpresa);
    }
    public class FilialService : IFilialService
    {
        private readonly MetasContext _metasContext;

        public FilialService(MetasContext metasContext)
        {
            _metasContext = metasContext;
        }

        public IEnumerable<FilialDTO> FindByIdEmpresa(int idEmpresa)
        {
            var filialDTO = from filial in _metasContext.Filial
                            join empresa in _metasContext.Empresas on filial.EmpresaId equals empresa.Id
                            where empresa.Id == idEmpresa
                            select new FilialDTO()
                            {
                                Id = filial.Id,
                                Nome = filial.NomeFilial,
                                EmpresaId = empresa.Id
                            };
            return filialDTO;
        }

        public IEnumerable<FilialDTO> FindById(int idEmpresa)
        {
            var filialDTO = from filial in _metasContext.Filial
                            where filial.Id == idEmpresa
                            select new FilialDTO()
                            {
                                Id = filial.Id,
                                Nome = filial.NomeFilial,
                            };
            return filialDTO;
        }
    }
}
