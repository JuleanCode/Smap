using Smap.Models;
using Smap.Services;
using Smap.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Smap.ViewModels
{
    public class PreviousReportsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PreviousReportsViewModel()
        {
            OnSelect = new Command(SelectReport);

            GetReports();
        }

        public ObservableCollection<Report> PreviousReports { get; set; } = new ObservableCollection<Report>();

        public Report SelectedReport { get; set; }

        public Command OnSelect { get; }

        void SelectReport()
        {
            ReportService.CurrentReport = SelectedReport;
            Application.Current.MainPage.Navigation.PushAsync(new ReportPage());
        }

        void GetReports()
        {
            List<Report> reports = ReportService.GetReports();
            foreach (Report report in reports)
            {
                PreviousReports.Add(report);
            }
        }
    }
}
