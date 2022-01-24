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
    public class ReportViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Report CurrentReport { get; set; }
        public User UserOfReport { get; set; }

        public ReportViewModel()
        {
            CurrentReport = ReportService.SelectedReport;
            //Hier moet wel nog de gebruiker van het report binnengehaald worden, maar dit kan pas gedaan worden als we niet steeds onze database vernieuwen
        }

        public ObservableCollection<Vulnerbility> Vulnerbilitys { get; set; } = new ObservableCollection<Vulnerbility>()
        {
            new Vulnerbility() {Id = 1, vulnerability_risk_name = "EternalBlue", vulnerabiltiy_risk_value = 5},
            new Vulnerbility() {Id = 2, vulnerability_risk_name = "OpenPort", vulnerabiltiy_risk_value = 2}
        };
    }
}
