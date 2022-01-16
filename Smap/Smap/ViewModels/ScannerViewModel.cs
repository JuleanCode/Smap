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
    public class ScannerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private Ip ip = new Ip();

        public ScannerViewModel()
        {
            Scan = new Command(OnScan);
        }

        public ICommand Scan { get; }

        public string IpAddress
        {
            get => ip.Address;
            set
            {
                if (value == ip.Address)
                    return;

                ip.Address = value;
                NotifyPropertyChanged("IpAddress");
            }
        }

        void OnScan()
        {
            Application.Current.MainPage.Navigation.PushAsync(new ActiveHostPage());
        }
    }
}
