﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace TaskyWinPhone {
    public partial class MainPage : PhoneApplicationPage {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            DataContext = new TaskListViewModel();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            ((TaskListViewModel)DataContext).BeginUpdate(Dispatcher);
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ((TaskListViewModel)DataContext).BeginUpdate(Dispatcher);
        }
        private void HandleAdd(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/TaskDetailsPage.xaml?id=-1", UriKind.RelativeOrAbsolute));
        }

        private void HandleTaskTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var item = ((Grid)sender).DataContext as TaskViewModel;

            if (item != null) {
                NavigationService.Navigate(new Uri("/TaskDetailsPage.xaml?id=" + item.ID, UriKind.RelativeOrAbsolute));
            }
        }

        private void Cam_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/PageCam.xaml?id=-1", UriKind.RelativeOrAbsolute));
        }

        private void Assinar_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/PageAssinatura.xaml?id=-1", UriKind.RelativeOrAbsolute));
        }
            
        }
    }
