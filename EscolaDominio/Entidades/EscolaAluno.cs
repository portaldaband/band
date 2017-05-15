using System;

namespace EscolaDominio
{
    public class EscolaAluno
    {
        public int AlunoId { get; set; }

        public int EscolaId { get; set; }

        public string CodigoMatricula { get; set; }

        public virtual Aluno aluno { get; set; }

        public virtual Escola escola { get; set; }
    }
}
