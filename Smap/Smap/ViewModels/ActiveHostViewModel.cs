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
            RandomIpFill();
            
            OnSelect = new Command(SelectIp);
        }

        public ObservableCollection<Ip> IpList { get; set; } = new ObservableCollection<Ip>();

        public Ip SelectedIp { get; set; }

        public Command OnSelect { get; set; }

        void SelectIp()
        {
            IpService.SelectedIp = SelectedIp;
            Application.Current.MainPage.Navigation.PushAsync(new OpenPortsPage());
        }

        void RandomIpFill()
        {
            Random random = new Random();
            for (int i = 0; i < random.Next(5, 10); i++) 
            {
                Ip ip = new Ip();
                string adress = "192.168." + random.Next(1, 2) + random.Next(1, 5) + random.Next(1, 4) + "." + random.Next(1, 5) + random.Next(1, 4);

                ip.Address = adress;

                IpList.Add(ip);
            }
        }
    }
}
