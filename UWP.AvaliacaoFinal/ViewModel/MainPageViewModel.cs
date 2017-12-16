namespace UWP.AvaliacaoFinal.ViewModel
{
    using UWP.AvaliacaoFinal.Abstracts;
    using UWP.AvaliacaoFinal.Pages;
    using UWP.AvaliacaoFinal.Services;
    using Windows.UI.Xaml;

    /// <summary>
    /// 
    /// </summary>
    public class MainPageViewModel : NotifyableClass
    {
        #region Methods
        
        #region Events
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddReceitaButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate<ReceitaListPage>();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TipoReceitaButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate<TipoReceitaListPage>();
        }

        #endregion

        #endregion
    }
}
