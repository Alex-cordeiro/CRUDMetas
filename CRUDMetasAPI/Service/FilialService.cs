using CRUDMetasAPI.Context;
using CRUDMetasAPI.Model.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace CRUDMetasAPI.Service
{
    public interface IFilialService
    {
        public IEnumerable<FilialDTO> FindById(int idEmpresa);
    }
    public class FilialService : IFilialService
    {
        private readonly MetasContext _metasContext;

        public FilialService(MetasContext metasContext)
        {
            _metasContext = metasContext;
        }

        public IEnumerable<FilialDTO> FindById(int idEmpresa)
        {
            var filialDTO = from filial in _metasContext.Filial
                                where filial.EmpresaId == idEmpresa
                                select new FilialDTO()
                                {
                                    Id = filial.Id,
                                    Nome = filial.NomeFilial,
                                };
            return filialDTO;
        }
    }
}
