﻿namespace UWP.AvaliacaoFinal.Context
{
    using Microsoft.EntityFrameworkCore;
    using UWP.AvaliacaoFinal.Model;

    /// <summary>
    /// Defines the app database context.
    /// </summary>
    public class AppDbContext : DbContext
    {
        #region Properties

        /// <summary>
        /// Gets or sets da receita .
        /// </summary>
        public DbSet<Receita> Receitas { get; set; }

        /// <summary>
        /// Gets or sets do tipo de receita.
        /// </summary>
        public DbSet<TipoReceita> TiposReceita { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// This method is called for each instance of the context that is created.
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=UWP.db");
        }

        #endregion
    }
}
