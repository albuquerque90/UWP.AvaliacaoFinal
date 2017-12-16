using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.AvaliacaoFinal.Abstracts;
using UWP.AvaliacaoFinal.Model;
using UWP.AvaliacaoFinal.Pages;
using UWP.AvaliacaoFinal.Repositories;
using UWP.AvaliacaoFinal.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWP.AvaliacaoFinal.ViewModel
{
    public class MainPageViewModel : NotifyableClass
    {
        /// <summary>
        /// Gets a instância do repositório de receita.
        /// </summary>
        public EFReceitaRepository ReceitaRepository => EFReceitaRepository.Instance;

        /// <summary>
        /// Gets a instância do repositório de tipos de receita.
        /// </summary>
        public EFTipoReceitaRepository TipoReceitaRepository => EFTipoReceitaRepository.Instance;

        public ObservableCollection<Receita> ReceitaItens => ReceitaRepository.Items;

        public async Task Initialize()
        {
            await TipoReceitaRepository.LoadAll();
            await ReceitaRepository.LoadAll();

            LstReceitas = ReceitaItens;
        }

        private IEnumerable<Receita> _lstReceitas;
        public IEnumerable<Receita> LstReceitas
        {
            get { return _lstReceitas; }
            set
            {
                Set(ref _lstReceitas, value);
            }
        }

        public enum PageState
        {
            MinWidth0 = 0,
            MinWidth700
        }

        public PageState State { get; set; }

        private Receita _receita;
        public Receita Receita
        {
            get { return _receita ?? new Receita(); }
            set { Set(ref _receita, value); }
        }


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



            var listView = (ListView)sender;

            if (listView.SelectedItem == null)
            {
                return;
            }

            if (State == PageState.MinWidth700)
            {
                Receita = JsonConvert.DeserializeObject<Receita>(JsonConvert.SerializeObject(listView.SelectedItem));
            }
            else
            {
                NavigationService.Navigate<ReceitaDetalhePage>(listView.SelectedItem);
            }
        }
    }
}
