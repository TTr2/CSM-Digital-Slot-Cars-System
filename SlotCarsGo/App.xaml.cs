﻿using System;

using SlotCarsGo.Services;

using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight.Threading;
using AutoMapper;
using SlotCarsGo.Models.Racing;
using SlotCarsGo_Server.Models.DTO;

namespace SlotCarsGo
{
    public sealed partial class App : Application
    {
        private Lazy<ActivationService> _activationService;

        private ActivationService ActivationService
        {
            get { return _activationService.Value; }
        }

        public App()
        {
            InitializeComponent();

            // Deferred execution until used. Check https://msdn.microsoft.com/library/dd642331(v=vs.110).aspx for further info on Lazy<T> class.
            _activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
                DispatcherHelper.Initialize();
            }
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(this, typeof(ViewModels.MainViewModel), new Views.ShellPage());
        }
    }
}
