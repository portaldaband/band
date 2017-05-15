using System;

namespace Apresentacao.Api.ViewModel
{
    public class AlunoEscolaViewModel
    {
        public int AlunoId { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }

        public DateTime? dtNascimento { get; set; }

        public string NomeEscola { get; set; }

        public string CodigoMatricula { get; set; }
    }
}