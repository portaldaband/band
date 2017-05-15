using EscolaDominio;
using System.Data.Entity.ModelConfiguration;

namespace EscolaInfra.EntidadeConfig
{
    public class AlunoConfig : EntityTypeConfiguration<Aluno>
    {
        public AlunoConfig()
        {
            HasKey(a => a.AlunoId);
        }
    }
}
