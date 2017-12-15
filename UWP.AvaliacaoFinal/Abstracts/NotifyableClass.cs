namespace UWP.AvaliacaoFinal.Abstracts
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Define a classe de notificação.
    /// </summary>
    public abstract class NotifyableClass : INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        /// O evento de alterações de propriedade para realizar a notificação. Ocorre quando uma propriedade é alterada.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        /// Ocorre quando uma propriedade é alterada.
        /// </summary>
        /// <param name="propertyName">Nome da propriedade.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets da propriedade da classe.
        /// </summary>
        /// <typeparam name="T">Tipo da classe.</typeparam>
        /// <param name="data">Dado</param>
        /// <param name="value">Valor</param>
        /// <param name="propertyName">Nome da propriedade</param>
        public void Set<T>(ref T data, T value, [CallerMemberName]string propertyName = null)
        {
            if (!Equals(data, value))
            {
                data = value;
                OnPropertyChanged(propertyName);
            }
        }

        #endregion
    }
}
