namespace UWP.AvaliacaoFinal.Pages
{
    using UWP.AvaliacaoFinal.ViewModel;
    using Windows.UI.Core;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TipoReceitaListPage : Page
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public TipoReceitaViewModel ViewModel { get; } = new TipoReceitaViewModel();

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public TipoReceitaListPage()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (this.Frame.CanGoBack) this.Frame.GoBack();
        }

        #endregion
    }
}
