﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Microsoft.Toolkit.Uwp.UI.Controls;
using SlotCarsGo.Models;
using SlotCarsGo.Services;
using SlotCarsGo.Models.Racing;
using SlotCarsGo.Models.Manager;
using GalaSoft.MvvmLight.Ioc;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Views;
using SlotCarsGo.Views;
using Windows.UI.Xaml;

namespace SlotCarsGo.ViewModels
{
    public class RaceTypeSelectViewModel : NavigableViewModelBase
    {
        private RaceType _selected;

        public RaceType Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<RaceType> RaceTypeItems { get; private set; } = new ObservableCollection<RaceType>();

        public RaceTypeSelectViewModel()
        {
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            RaceTypeItems.Clear();

            var data = await SelectRaceTypeService.GetRaceTypesDataAsync();

            foreach (var item in data)
            {
                this.RaceTypeItems.Add(item);
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = RaceTypeItems.First();
            }
        }

        public void ProceedToDriverSetup(RaceType configuredRaceType)
        {
            SimpleIoc.Default.GetInstance<NavigationServiceEx>().Navigate(typeof(GridConfirmationViewModel).FullName, configuredRaceType);
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            return Task.CompletedTask;
        }

        public override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
        }

        public override void OnNavigatedFrom()
        {
        }
    }
}
