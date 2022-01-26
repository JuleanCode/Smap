using Smap.Models;
using Smap.Services;
using Smap.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Smap.ViewModels
{
    public class ReportViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Report CurrentReport { get; set; } = ReportService.CurrentReport;
        public Models.Condition CurrentCondition { get; set; } = ConditionService.CurrentCondition;
        public Ip ReportIp { get; set; }
        public OpenPort ReportPort { get; set; }
        public User UserOfReport { get; set; }
        public ObservableCollection<Vulnerbility> Vulnerbilities { get; set; } = new ObservableCollection<Vulnerbility>();
        public Vulnerbility SelectedVulnerbility { get; set; }

        public ReportViewModel()
        {
            if(IpService.SelectedIp == null)
            {
                //code voor het ophalen van eerdere report data, moet gedaan worden vanuit de services
            }
            else
            {
                GetVulnerbilities();
                ReportIp = IpService.SelectedIp;
                ReportPort = PortService.SelectedPort;
            }

            OnSelect = new Command(ShowVulnerbilityDescription);

        }

        public Command OnSelect { get; }

        public ICommand Refresh { get; set; }

        void ShowVulnerbilityDescription()
        {
            Application.Current.MainPage.DisplayAlert(SelectedVulnerbility.Cve, SelectedVulnerbility.Description, "Ok");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        void GetVulnerbilities()
        {
            List<Vulnerbility> tempVulnerbilities = VulnerbilityService.GetVulnerbilities();
            foreach(Vulnerbility vulnerbility in tempVulnerbilities)
            {
                Vulnerbilities.Add(vulnerbility);
            }
        }
    }
}
