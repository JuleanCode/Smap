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
        public Models.Company ReportCompany { get; set; } = CompanyService.CurrentCompany;
        public Ip ReportIp { get; set; }
        public OpenPort ReportPort { get; set; }
        public ObservableCollection<Vulnerbility> Vulnerbilities { get; set; } = new ObservableCollection<Vulnerbility>();
        public Vulnerbility SelectedVulnerbility { get; set; }

        public ReportViewModel()
        {
            if(IpService.SelectedIp == null)
            {
                ReportIp = IpService.GetReportIp(CurrentReport.Ip_Id);
                ReportPort = PortService.GetReportOpenPort(ReportIp.Id);
                GetSavedVulnerbilities();
            }
            else
            {
                GetNewVulnerbilities();
                ReportIp = IpService.SelectedIp;
                ReportPort = PortService.SelectedPort;
            }

            OnSelect = new Command(ShowVulnerbilityDescription);

            Save = new Command(OnSave);

        }

        public Command OnSelect { get; }

        public ICommand Save { get; }

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

        void GetNewVulnerbilities()
        {
            List<Vulnerbility> tempVulnerbilities = VulnerbilityService.GetNewVulnerbilities();
            foreach(Vulnerbility vulnerbility in tempVulnerbilities)
            {
                Vulnerbilities.Add(vulnerbility);
            }
        }

        void GetSavedVulnerbilities()
        {
            List<Vulnerbility> tempVulnerbilities = VulnerbilityService.GetReportVulnerbilities(ReportPort.Id);
            foreach (Vulnerbility vulnerbility in tempVulnerbilities)
            {
                Vulnerbilities.Add(vulnerbility);
            }
        }

        void OnSave()
        {
            ReportService.SaveReport(Vulnerbilities);
            Application.Current.MainPage.DisplayAlert("Succes", "Report succesvol opgeslagen", "Ok");
        }
    }
}
