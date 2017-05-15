using System;
using System.Collections.Generic;

namespace EscolaDominio
{
    public class Aluno
    {
        public int AlunoId { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }

        public DateTime? dtNascimento { get; set; }

        public virtual ICollection<EscolaAluno> EscolaAluno { get; set; }
    }
}
