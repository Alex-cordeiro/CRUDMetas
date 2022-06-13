using System.Collections.Generic;

namespace CRUDMetasAPI.Model
{
    public class Filial
    {
        public int Id { get; set; }
        public string NomeFilial { get; set; }
        public int EmpresaId { get; set; }

        public Filial(int id, string nomeFilial)
        {
            Id = id;
            NomeFilial = nomeFilial;
        }

        public Filial()
        {
        }
    }
}
