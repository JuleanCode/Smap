using Smap.Models;
using Smap.Services;
using Smap.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Smap.ViewModels
{
    public class PreviousScansViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PreviousScansViewModel()
        {

        }

        public ObservableCollection<Scan> PreviousScans { get; set; } = new ObservableCollection<Scan>()
        {
            new Scan(){Id = 1, Date = Convert.ToDateTime("04/15/2021") },
            new Scan(){Id = 2, Date = Convert.ToDateTime("04/16/2021") },
            new Scan(){Id = 3, Date = Convert.ToDateTime("05/15/2021") },
            new Scan(){Id = 4, Date = Convert.ToDateTime("07/23/2021") }
        };

        public Scan SelectedScan { get; set; }
    }
}
