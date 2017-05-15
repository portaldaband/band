using EscolaDominio;
using EscolaInfra.EntidadeConfig;
using EscolaInfra.Migrations;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EscolaInfra.Context
{
    public class EscolaContexto : DbContext
    {

        public static EscolaContexto Create()
        {
            return new EscolaContexto();
        }

        public EscolaContexto()
        : base("EscolaBandeirantesContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EscolaContexto, Configuration>());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(
                    properties =>
                        properties.ReflectedType != null && properties.Name == properties.ReflectedType.Name + "Id")
                .Configure(properties => properties.IsKey());
            modelBuilder.Properties<string>().Configure(properties => properties.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(properties => properties.HasMaxLength(250));
            modelBuilder.Properties<DateTime>().Configure(properties => properties.HasColumnType("datetime2"));


            modelBuilder.Configurations.Add(new AlunoConfig());
            modelBuilder.Configurations.Add(new EscolaConfig());
            modelBuilder.Configurations.Add(new EscolaAlunoConfig());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Escola> Escola { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<EscolaAluno> EscolaAluno { get; set; }
    }
}
