using EscolaDominio;
using System.Data.Entity.ModelConfiguration;

namespace EscolaInfra.EntidadeConfig
{
    public class EscolaAlunoConfig : EntityTypeConfiguration<EscolaAluno>
    {
        public EscolaAlunoConfig()
        {
            HasKey(ea => new {
                ea.AlunoId,
                ea.EscolaId
            });
        }
    }
}
