using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.AvaliacaoFinal.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWP.AvaliacaoFinal.ViewModel
{
    public class IncluirReceitaViewModel
    {
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
