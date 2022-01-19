using Smap.Models;
using Smap.Services;
using Smap.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Smap.ViewModels
{
    public class NetworkInformationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Ip ip = new Ip();
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public NetworkInformationViewModel()
        {
            GatherInformation();
            GetGateway();
        }
        public string address
        {
            get => ip.Address;
            set
            {
                if (value == ip.Address)
                    return;

                ip.Address = value;
                NotifyPropertyChanged("Address");
            }
        }
        public string gateway
        {
            get => ip.Gateway;
            set
            {
                if (value == ip.Gateway)
                    return;

                ip.Gateway = value;
                NotifyPropertyChanged("Gateway");
            }
        }
        void GatherInformation()
        {
            ip.Address = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
        }
        void GetGateway()
        {
            try
            {
                ip.Gateway = GetDefaultGateway().ToString();
            }
            catch (Exception)
            {
                Application.Current.MainPage.DisplayAlert("Niet verbonden met netwerk", "U bent niet verbonden met het netwerk", "Ok");
            }
        }
        private IPAddress GetDefaultGateway()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                .Select(g => g?.Address)
                .Where(a => a != null)
                .FirstOrDefault();
        }
    }
}
