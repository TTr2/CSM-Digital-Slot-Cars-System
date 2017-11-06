﻿using System;

using RaceDirectorClientGUI.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RaceDirectorClientGUI.Views
{
    public sealed partial class RaceTypeSelectDetailControl : UserControl
    {
        public SampleOrder MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleOrder; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(RaceTypeSelectDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public RaceTypeSelectDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RaceTypeSelectDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
