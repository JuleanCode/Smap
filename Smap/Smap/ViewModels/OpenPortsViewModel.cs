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
    public class OpenPortsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public OpenPort SelectedPort { get; set; }

        public OpenPortsViewModel()
        {
            fillPorts();

            OnSelect = new Command(SelectPort);
        }

        public ObservableCollection<OpenPort> OpenPorts { get; set; } = new ObservableCollection<OpenPort>();

        public Command OnSelect { get; }

        void SelectPort()
        {
            PortService.SelectedPort = SelectedPort;
            //moet gedaan worden om de juiste id's te verkrijgen
            IpService.SaveIp();
            PortService.SavePort();
            //Dit is al ingevuld wanneer het condition scherm erbij komt, dus wordt dan ook verwijderd
            ConditionService.CurrentCondition = new Models.Condition()
            {
                Id = 1,
                Company = "Coca Cola",
                User_Id = UserService.LoggedInUser.Id
            };
            //Random vulnerability's
            ReportService.CreateReport();
            Application.Current.MainPage.Navigation.PushAsync(new ReportPage());
        }

        void fillPorts()
        {
            Random random = new Random();
            for (int i = 0; i < random.Next(5, 11); i++)
            {
                OpenPort openPort = new OpenPort();
                openPort.Number = i + 1;
                OpenPorts.Add(openPort);
            }
        }
    }
}
