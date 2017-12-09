using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.AvaliacaoFinal.Pages;
using UWP.AvaliacaoFinal.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWP.AvaliacaoFinal.ViewModel
{
    public class MainPageViewModel
    {

        public void AddReceita_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate<IncluirReceitaPage>();
        }

        
    }
}
