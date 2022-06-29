using System.Collections.Generic;

namespace Telemetrix.API.Model
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EmpresaId { get; set; }

        public Departamento(int id, string nomeDepartamento)
        {
            Id = id;
            Nome = nomeDepartamento;
        }

        public Departamento()
        {
        }
    }
}
