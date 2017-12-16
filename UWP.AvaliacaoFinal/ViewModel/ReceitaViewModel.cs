namespace UWP.AvaliacaoFinal.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using UWP.AvaliacaoFinal.Abstracts;
    using UWP.AvaliacaoFinal.Model;
    using UWP.AvaliacaoFinal.Repositories;
    using UWP.AvaliacaoFinal.Services;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Define a classe de modelo de visualização de receita.
    /// </summary>
    public class ReceitaViewModel : NotifyableClass
    {
        #region Properties

        /// <summary>
        /// Gets a instância do repositório de receita.
        /// </summary>
        public EFReceitaRepository ReceitaRepository => EFReceitaRepository.Instance;

        /// <summary>
        /// Gets a instância do repositório de tipos de receita.
        /// </summary>
        public EFTipoReceitaRepository TipoReceitaRepository => EFTipoReceitaRepository.Instance;

        /// <summary>
        /// Gets a coleção de receitas do repositório.
        /// </summary>
        public ObservableCollection<Receita> Receitas => ReceitaRepository.Items;

        /// <summary>
        /// Gets a coleção de tipos de receitas do repositório.
        /// </summary>
        public ObservableCollection<TipoReceita> TiposReceita => TipoReceitaRepository.Items;

        private Receita _receita;

        public Receita Receita
        {
            get { return _receita; }
            set { Set(ref _receita, value); }
        }

        #endregion

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
                NavigationService.GoBack();
            };

            await dialog.ShowAsync();
        }

        public async void SaveReceita_Click()
        {
            if (Receitas.Any(t => t.Id == Receita.Id))
            {
                await ReceitaRepository.Update(Receita);
            }
            else
            {
                await ReceitaRepository.Create(Receita);
            }

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
