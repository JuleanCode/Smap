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
    public class AgreementViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public AgreementViewModel()
        {
            Accept = new Command(OnAccept);
        }

        public ICommand Accept { get; }

        void OnAccept()
        {
            Application.Current.MainPage.Navigation.PushAsync(new ScannerPage());
        }
    }
}
