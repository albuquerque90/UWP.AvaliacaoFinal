﻿namespace UWP.AvaliacaoFinal.ViewModel
{
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

    /// <summary>
    /// 
    /// </summary>
    public class MainPageViewModel : NotifyableClass
    {
        #region Variables

        /// <summary>
        /// 
        /// </summary>
        private Receita _receita;
        
        /// <summary>
        /// 
        /// </summary>
        private TipoReceita _selectedTipoReceita;

        /// <summary>
        /// 
        /// </summary>
        private IEnumerable<Receita> _filteredReceitaItems;

        /// <summary>
        /// 
        /// </summary>
        private IEnumerable<TipoReceita> _filteredTipoReceitaItems;

        #endregion

        #region Properties

        /// <summary>
        /// Gets a instância do repositório de receita.
        /// </summary>
        public EFReceitaRepository ReceitaRepository => EFReceitaRepository.Instance;

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Receita> ReceitaItens => ReceitaRepository.Items;
        
        /// <summary>
        /// 
        /// </summary>
        public Receita Receita
        {
            get { return _receita ?? new Receita(); }
            set { Set(ref _receita, value); }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Receita> FilteredReceitaItems
        {
            get { return _filteredReceitaItems; }
            set
            {
                var newValue = value;

                //if (SelectedTipoReceita != null)
                //{
                //    newValue = newValue.Where(t => t.TipoReceitaId == SelectedTipoReceita.Id);
                //}

                Set(ref _filteredReceitaItems, newValue);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task Initialize()
        {
            await ReceitaRepository.LoadAll();

            ReceitaItens.CollectionChanged += ReceitaItens_CollectionChanged;
        }

        #region Events
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddReceitaButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate<IncluirReceitaPage>();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReceitaItens_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
