namespace UWP.AvaliacaoFinal.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using UWP.AvaliacaoFinal.Abstracts;
    using UWP.AvaliacaoFinal.Model;
    using UWP.AvaliacaoFinal.Pages;
    using UWP.AvaliacaoFinal.Repositories;
    using UWP.AvaliacaoFinal.Services;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Define a classe de modelo de visualização de tipo de receita.
    /// </summary>
    public class TipoReceitaViewModel : NotifyableClass
    {
        #region Variables

        /// <summary>
        /// Sets a receita.
        /// </summary>
        private TipoReceita _TipoReceita;

        #endregion

        #region Properties
        
        /// <summary>
        /// Gets a instância do repositório de tipos de receita.
        /// </summary>
        public EFTipoReceitaRepository TipoReceitaRepository => EFTipoReceitaRepository.Instance;
        
        /// <summary>
        /// Gets a coleção de tipos de receitas do repositório.
        /// </summary>
        public ObservableCollection<TipoReceita> TiposReceita => TipoReceitaRepository.Items;
        
        /// <summary>
        /// Gets or sets o tipo da receita.
        /// </summary>
        public TipoReceita TipoReceita
        {
            get { return _TipoReceita; }
            set { Set(ref _TipoReceita, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Persiste a receita no banco de dados.
        /// </summary>
        public void AddTipoReceita_Click()
        {
            NavigationService.Navigate<IncluirTipoReceitaPage>(new TipoReceita());
        }

        /// <summary>
        /// Persiste a receita no banco de dados.
        /// </summary>
        public async void SaveTipoReceita_Click()
        {
            if (TiposReceita.Any(t => t.Id == TipoReceita.Id))
            {
                await TipoReceitaRepository.Update(TipoReceita);
            }
            else
            {
                await TipoReceitaRepository.Create(TipoReceita);
            }

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public async void CancelTipoReceita_Click()
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
                NavigationService.GoBack();
            };

            await dialog.ShowAsync();
        }

        #endregion
    }
}
