using System.Collections.Generic;

namespace CRUDMetasAPI.Model
{
    public class Empresa
    {
        public int Id { get; set; }
        public string NomeEmpresa { get; set; }
        public Filial Filial { get; set; }
        public List<Filial> Filiais { get; set; }

        public Empresa(int id, string nomeEmpresa)
        {
            Id = id;
            NomeEmpresa = nomeEmpresa;
        }

        public Empresa()
        {
        }
    }
}
