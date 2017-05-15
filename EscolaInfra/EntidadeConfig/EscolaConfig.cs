using EscolaDominio;
using System.Data.Entity.ModelConfiguration;

namespace EscolaInfra.EntidadeConfig
{
    public class EscolaConfig : EntityTypeConfiguration<Escola>
    {
        public EscolaConfig()
        {
            HasKey(e => e.EscolaId);
        }
    }
}
