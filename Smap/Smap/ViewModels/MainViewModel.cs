using Smap.Models;
using Smap.Services;
using Smap.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Smap.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public User LoggedInUser { get; set; }

        public MainViewModel()
        {
            LoggedInUser = UserService.LoggedInUser;

            NewScan = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new AgreementPage());
            });

            PreviousScans = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new PreviousScansPage());
            });

            Logout = new Command(() =>
            {
                UserService.LoggedInUser = null;
                Application.Current.MainPage.Navigation.PopToRootAsync();
            });
        }

        public Command NewScan { get; }
        public Command PreviousScans { get; }

        public Command Logout { get; set; }
    }
}
