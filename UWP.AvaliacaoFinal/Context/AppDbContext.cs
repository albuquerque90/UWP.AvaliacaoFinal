namespace UWP.AvaliacaoFinal.Context
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;
    using UWP.AvaliacaoFinal.Model;
    using Windows.Storage;

    /// <summary>
    /// Defines the app database context.
    /// </summary>
    public class AppDbContext : DbContext
    {
        #region Properties

        /// <summary>
        /// Gets or sets da receita .
        /// </summary>
        public DbSet<Receita> Receita { get; set; }

        /// <summary>
        /// Gets or sets do tipo de receita.
        /// </summary>
        public DbSet<TipoReceita> TipoReceita { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// This method is called for each instance of the context that is created.
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(GetAppSetings().GetAwaiter().GetResult());
        }

        /// <summary>
        /// Configure the model for this context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tipo Receita
            modelBuilder.Entity<TipoReceita>()
                .ForSqliteToTable("TipoReceita");

            modelBuilder.Entity<TipoReceita>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<TipoReceita>()
                .Property(x => x.Descricao)
                    .HasColumnType("varchar(500)")
                    .HasMaxLength(500);

            // Receita
            modelBuilder.Entity<Receita>()
                .ForSqliteToTable("Receita");

            modelBuilder.Entity<Receita>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<Receita>()
              .HasOne(x => x.TipoReceita)
              .WithMany(x => x.Receitas)
              .HasForeignKey(x => x.TipoReceitaId);

            modelBuilder.Entity<Receita>()
                .Property(x => x.Ingredientes)
                    .HasColumnType("varchar(500)")
                    .HasMaxLength(500);

            modelBuilder.Entity<Receita>()
                .Property(x => x.ModoPreparo)
                    .HasColumnType("varchar(500)")
                    .HasMaxLength(500);

            base.OnModelCreating(modelBuilder);
        }

        #region Auxiliary

        /// <summary>
        /// Gets the app settings file.
        /// </summary>
        /// <returns></returns>
        private async Task<string> GetAppSetings()
        {
            var storageFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///AppSettings.xml"));

            return await FileIO.ReadTextAsync(storageFile);
        }

        #endregion

        #endregion
    }
}
