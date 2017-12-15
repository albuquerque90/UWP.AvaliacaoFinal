namespace UWP.AvaliacaoFinal.Repositories
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using UWP.AvaliacaoFinal.Abstracts;
    using UWP.AvaliacaoFinal.Interfaces;

    /// <summary>
    /// Define a classe do repositório gnérico.
    /// </summary>
    /// <typeparam name="T">Tipo do repositório.</typeparam>
    public abstract class Repository<T> : NotifyableClass, IRepository<T> where T : class
    {
        #region Variables

        /// <summary>
        /// Sets a coleção de items do tipo do repositório.
        /// </summary>
        private ObservableCollection<T> _Items = new ObservableCollection<T>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or protected sets os items do repositório.
        /// </summary>
        public ObservableCollection<T> Items
        {
            protected set { Set(ref _Items, value); }
            get { return _Items; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Carrega todos os items do tipo do repositório.
        /// </summary>
        /// <returns>Uma tarefa assincrona.</returns>
        public abstract Task LoadAll();

        /// <summary>
        /// Persiste o item do tipo do repositório do banco de dados.
        /// </summary>
        /// <param name="entity">A entidade a ser persistida.</param>
        /// <returns>Uma tarefa assincrona.</returns>
        public abstract Task Create(T entity);

        /// <summary>
        /// Persiste as alterações do item do tipo do repositório do banco de dados.
        /// </summary>
        /// <param name="entity">A entidade a ser persistida.</param>
        /// <returns>Uma tarefa assincrona.</returns>
        public abstract Task Update(T entity);

        /// <summary>
        /// Persiste a remoção do item do tipo do repositório do banco de dados.
        /// </summary>
        /// <param name="entity">A entidade a ser persistida.</param>
        /// <returns>Uma tarefa assincrona.</returns>
        public abstract Task Delete(T entity);

        #endregion
    }
}
