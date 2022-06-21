using System.Collections.Generic;

namespace CRUDMetasAPI.Model
{
    public class Departamento
    {
        public int Id { get; set; }
        public string NomeDepartamento { get; set; }
        public int EmpresaId { get; set; }

        public Departamento(int id, string nomeDepartamento)
        {
            Id = id;
            NomeDepartamento = nomeDepartamento;
        }

        public Departamento()
        {
        }
    }
}
