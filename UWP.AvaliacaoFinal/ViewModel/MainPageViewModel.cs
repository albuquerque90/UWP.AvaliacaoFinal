using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.AvaliacaoFinal.Abstracts;
using UWP.AvaliacaoFinal.Pages;
using UWP.AvaliacaoFinal.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWP.AvaliacaoFinal.ViewModel
{
    public class MainPageViewModel : NotifyableClass
    {


        private bool _isSplitViewOpen;

        public bool IsSplitViewOpen
        {
            get { return _isSplitViewOpen; }
            set { Set(ref _isSplitViewOpen, value); }
        }

        public void AddReceita_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate<IncluirReceitaPage>();
        }

        public void HamburguerButton_Click(object sender, RoutedEventArgs e)
        {
            IsSplitViewOpen = !IsSplitViewOpen;
        }

        public  void AddTipoReceitaButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public void teste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate<ReceitaDetalhePage>();
        }
    }
}
