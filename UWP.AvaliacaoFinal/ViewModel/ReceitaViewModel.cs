namespace UWP.AvaliacaoFinal.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using UWP.AvaliacaoFinal.Model;
    using UWP.AvaliacaoFinal.Repositories;
    using UWP.AvaliacaoFinal.Services;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Define a classe de modelo de visualização de receita.
    /// </summary>
    public class ReceitaViewModel
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
    }
}
