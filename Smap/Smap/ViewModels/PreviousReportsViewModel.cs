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
        }

        public ObservableCollection<Report> PreviousReports { get; set; } = new ObservableCollection<Report>()
        {
            new Report(){Id = 1, Date = Convert.ToDateTime("04/15/2021") },
            new Report(){Id = 2, Date = Convert.ToDateTime("04/16/2021") },
            new Report(){Id = 3, Date = Convert.ToDateTime("05/15/2021") },
            new Report(){Id = 4, Date = Convert.ToDateTime("07/23/2021") }
        };

        public Report SelectedReport { get; set; }

        public Command OnSelect { get; }

        void SelectReport()
        {
            ReportService.CurrentReport = SelectedReport;
            Application.Current.MainPage.Navigation.PushAsync(new ReportPage());
        }
    }
}
