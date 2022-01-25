using Smap.Models;
using Smap.Services;
using Smap.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Smap.ViewModels
{
    public class ActiveHostViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ActiveHostViewModel()
        {
            OnSelect = new Command(SelectIp);
        }

        public ObservableCollection<Ip> IpList { get; set; } = new ObservableCollection<Ip>()
        {
            new Ip(){ Id = 1},
            new Ip(){ Id = 2},
            new Ip(){ Id = 3},
            new Ip(){ Id = 4},
            new Ip(){ Id = 5}
        };

        public Ip SelectedIp { get; set; }

        public Command OnSelect { get; set; }

        void SelectIp()
        {
            IpService.SelectedIp = SelectedIp;
            Application.Current.MainPage.Navigation.PushAsync(new ReportPage());
        }
    }
}
