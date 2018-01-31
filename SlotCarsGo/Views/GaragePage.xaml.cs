﻿using System;

using SlotCarsGo.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SlotCarsGo.Views
{
    public sealed partial class GaragePage : Page
    {
        private GarageViewModel ViewModel
        {
            get { return DataContext as GarageViewModel; }
        }

        public GaragePage()
        {
            InitializeComponent();
            Loaded += GaragePage_Loaded;
        }

        private async void GaragePage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }
    }
}