﻿using System;

using RaceDirectorClientGUI.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RaceDirectorClientGUI.Views
{
    public sealed partial class RaceResultsPage : Page
    {
        private RaceResultsViewModel ViewModel
        {
            get { return DataContext as RaceResultsViewModel; }
        }

        public RaceResultsPage()
        {
            InitializeComponent();
            Loaded += RaceResultsPage_Loaded;
        }

        private async void RaceResultsPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }
    }
}