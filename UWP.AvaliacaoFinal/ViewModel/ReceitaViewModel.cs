namespace UWP.AvaliacaoFinal.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using UWP.AvaliacaoFinal.Abstracts;
    using UWP.AvaliacaoFinal.Model;
    using UWP.AvaliacaoFinal.Pages;
    using UWP.AvaliacaoFinal.Repositories;
    using UWP.AvaliacaoFinal.Services;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Define a classe de modelo de visualização de receita.
    /// </summary>
    public class ReceitaViewModel : NotifyableClass
    {
        #region Variables

        /// <summary>
        /// Sets a receita.
        /// </summary>
        private Receita _Receita;
        
        #endregion

        #region Properties

        /// <summary>
        /// Gets a instância do repositório de receita.
        /// </summary>
        public EFReceitaRepository ReceitaRepository => EFReceitaRepository.Instance;

        /// <summary>
        /// Gets a instância do repositório de receita.
        /// </summary>
        public EFTipoReceitaRepository TipoReceitaRepository => EFTipoReceitaRepository.Instance;

        /// <summary>
        /// Gets a coleção de receitas do repositório.
        /// </summary>
        public ObservableCollection<Receita> Receitas => ReceitaRepository.Items;

        /// <summary>
        /// Gets a coleção de receitas do repositório.
        /// </summary>
        public ObservableCollection<TipoReceita> TiposReceita => TipoReceitaRepository.Items;

        /// <summary>
        /// Gets or sets a receita.
        /// </summary>
        public Receita Receita
        {
            get { return _Receita; }
            set { Set(ref _Receita, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task Initialize()
        {
            await ReceitaRepository.LoadAll();
            await TipoReceitaRepository.LoadAll();
        }

        /// <summary>
        /// Persiste a receita no banco de dados.
        /// </summary>
        public void AddReceita_Click()
        {
            NavigationService.Navigate<IncluirReceitaPage>(new Receita());
        }

        /// <summary>
        /// Persiste a receita no banco de dados.
        /// </summary>
        public async void SaveReceita_Click()
        {
            if (Receitas.Any(t => t.Id == Receita.Id))
                await ReceitaRepository.Update(Receita);
            else
                await ReceitaRepository.Create(Receita);

            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        /// <summary>
        /// 
        /// </summary>
        public async void CancelReceita_Click()
        {
            var dialog = new ContentDialog
            {
                Title = "Confirmação",
                Content = "Você quer cancelar a operação ? Todos os dados serão perdidos",
                PrimaryButtonText = "Sim",
                SecondaryButtonText = "Não"
            };


            dialog.PrimaryButtonClick += async (s, e) =>
            {
                await Task.CompletedTask;
                NavigationService.GoBack();
            };

            await dialog.ShowAsync();
        }

        #endregion
    }
}
