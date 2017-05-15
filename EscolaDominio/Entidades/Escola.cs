using System.Collections.Generic;

namespace EscolaDominio
{
    public class Escola
    {
        public int EscolaId { get; set; }

        public string NomeEscola { get; set; }

        public virtual ICollection<EscolaAluno> EscolaAluno { get; set; }
    }
}
