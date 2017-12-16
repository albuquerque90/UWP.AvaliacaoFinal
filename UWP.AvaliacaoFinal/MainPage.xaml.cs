namespace UWP.AvaliacaoFinal
{
    using UWP.AvaliacaoFinal.ViewModel;
    using Windows.UI.Core;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public MainPageViewModel ViewModel { get; } = new MainPageViewModel();

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods
        
        #region Events

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

        #endregion
    }
}
