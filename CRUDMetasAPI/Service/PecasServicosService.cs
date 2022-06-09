using CRUDMetasAPI.Model;
using CRUDMetasAPI.Model.DTOs;
using System.Collections.Generic;

namespace CRUDMetasAPI.Service
{
    public interface IPecasEServicos
    {
        public IEnumerable<PecasEServicosDTO> FindAll();
        public IEnumerable<PecasEServicosDTO> FindById(int IdJogo);
        public bool Insert(PecasEServicos pecasEServicos);
        public bool Update(int id, PecasEServicos pecasEServicos);
        public PecasEServicos Exists(int Id);
    }
    public class PecasServicosService
    {
    }
}
