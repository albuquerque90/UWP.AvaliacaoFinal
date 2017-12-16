using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UWP.AvaliacaoFinal.Context;

namespace UWP.AvaliacaoFinal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20171216153843_0001")]
    partial class _0001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3");

            modelBuilder.Entity("UWP.AvaliacaoFinal.Model.Receita", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ingredientes")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("ModoPreparo")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<Guid>("TipoReceitaId");

                    b.Property<string>("Titulo");

                    b.HasKey("Id");

                    b.HasIndex("TipoReceitaId");

                    b.ToTable("Receita");

                    b.HasAnnotation("Sqlite:TableName", "Receita");
                });

            modelBuilder.Entity("UWP.AvaliacaoFinal.Model.TipoReceita", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("TipoReceita");

                    b.HasAnnotation("Sqlite:TableName", "TipoReceita");
                });

            modelBuilder.Entity("UWP.AvaliacaoFinal.Model.Receita", b =>
                {
                    b.HasOne("UWP.AvaliacaoFinal.Model.TipoReceita", "TipoReceita")
                        .WithMany("Receitas")
                        .HasForeignKey("TipoReceitaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
