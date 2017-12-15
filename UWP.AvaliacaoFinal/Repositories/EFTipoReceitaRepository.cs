namespace UWP.AvaliacaoFinal.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using UWP.AvaliacaoFinal.Context;
    using UWP.AvaliacaoFinal.Model;

    /// <summary>
    /// Define a classe do repositório de tipos de receita.
    /// </summary>
    public class EFTipoReceitaRepository : Repository<TipoReceita>
    {
        #region Variables

        /// <summary>
        /// Sets a intância do repositório.
        /// </summary>
        private static readonly Lazy<EFTipoReceitaRepository> _Instance = new Lazy<EFTipoReceitaRepository>(() => new EFTipoReceitaRepository());

        #endregion

        #region Properties

        /// <summary>
        /// Gets a intância do repositório.
        /// </summary>
        public static EFTipoReceitaRepository Instance => _Instance.Value;

        #endregion

        #region Methods

        /// <summary>
        /// Carrega assincronamente todas os tiposd e receita.
        /// </summary>
        /// <returns>Uma tarefa assincrona.</returns>
        public override async Task LoadAll()
        {
            if (Items.Count == 0)
            {
                using (var context = new AppDbContext())
                {
                    foreach (var item in context.TiposReceita.ToList())
                    {
                        Items.Add(item);
                    }
                }
            }

            await Task.CompletedTask;
        }

        /// <summary>
        /// Persiste o tipo da receita no banco de dados.
        /// </summary>
        /// <param name="entity">A entidade a ser persistida.</param>
        /// <returns>Uma tarefa assincrona.</returns>
        public override async Task Create(TipoReceita entity)
        {
            using (var context = new AppDbContext())
            {
                entity.Id = Guid.NewGuid();
                Items.Add(entity);

                context.TiposReceita.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Persiste as alterações do tipo da receita no banco de dados.
        /// </summary>
        /// <param name="entity">A entidade a ser persistida.</param>
        /// <returns>Uma tarefa assincrona.</returns>
        public override async Task Update(TipoReceita entity)
        {
            using (var context = new AppDbContext())
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

                var collectionIndex = Items.Select((value, index) => new { value, index })
                    .Where(c => c.value.Id == entity.Id)
                    .Select(x => x.index)
                    .First();

                Items[collectionIndex] = entity;
            }
        }

        /// <summary>
        /// Persiste a remoção do item do tipo do repositório do banco de dados.
        /// </summary>
        /// <param name="entity">A entidade a ser persistida.</param>
        /// <returns>Uma tarefa assincrona.</returns>
        public override async Task Delete(TipoReceita entity)
        {
            var category = Items.SingleOrDefault(c => c.Id == entity.Id);

            if (category != null)
            {
                using (var context = new AppDbContext())
                {
                    Items.Remove(category);

                    context.TiposReceita.Remove(category);
                    await context.SaveChangesAsync();
                }
            }
        }

        #endregion
    }
}
