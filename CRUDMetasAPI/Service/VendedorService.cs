using CRUDMetasAPI.Context;
using CRUDMetasAPI.Model.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace CRUDMetasAPI.Service
{
    public interface IVendedorService
    {
        public IEnumerable<VendedorDTO> FindByIdEmpresa(int idEmpresa);
        public IEnumerable<VendedorDTO> FindById(int idVendedor);
    }
    public class VendedorService : IVendedorService
    {
        private readonly MetasContext _metasContext;

        public VendedorService(MetasContext metasContext)
        {
            _metasContext = metasContext;
        }

        public IEnumerable<VendedorDTO> FindByIdEmpresa(int idEmpresa)
        {

            var vendedorDTO = from vendedor in _metasContext.Vendedores
                              join empresa in _metasContext.Empresas on vendedor.EmpresaId equals empresa.Id
                                where empresa.Id == idEmpresa
                              select new VendedorDTO()
                               {
                                Id = vendedor.Id,
                                Nome = vendedor.Nome,
                                EmpresaId = empresa.Id
                               };
            return vendedorDTO;
        }

        public IEnumerable<VendedorDTO> FindById(int idVendedor)
        {

            var vendedorDTO = from vendedor in _metasContext.Vendedores
                              where vendedor.Id == idVendedor
                              select new VendedorDTO()
                              {
                                  Id = vendedor.Id,
                                  Nome = vendedor.Nome
                              };
            return vendedorDTO;
        }
    }

}
