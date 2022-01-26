using Smap.API;
using Smap.Models;
using Smap.Services;
using Smap.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Smap.ViewModels
{
    public class AgreementViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private Models.Condition condition = new Models.Condition();

        public AgreementViewModel()
        {
            Accept = new Command(OnAccept);
        }

        public ICommand Accept { get; }

        public string Company
        {
            get => condition.Company;
            set
            {
                if (value == condition.Company)
                    return;

                condition.Company = value;
                NotifyPropertyChanged("Company");
            }
        }

        public string Scope
        {
            get => condition.Scope;
            set
            {
                if (value == condition.Scope)
                    return;

                condition.Scope = value;
                NotifyPropertyChanged("Scope");
            }
        }

        public string Key
        {
            get => condition.Key;
            set
            {
                if (value == condition.Key)
                    return;

                condition.Key = value;
                NotifyPropertyChanged("Key");
            }
        }

        public DateTime EndDate
        {
            get => condition.EndDate;
            set
            {
                if (value == condition.EndDate)
                    return;

                condition.EndDate = value;
                NotifyPropertyChanged("EndDate");
            }
        }

        void OnAccept()
        {
            Services.ConditionService.CurrentCondition = condition;
            Services.ConditionService.AddCondition(condition);

            Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
    }
}
