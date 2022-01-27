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

        private Models.Company company = new Models.Company();

        public Company SelectedCompany { get; set; }

        public ObservableCollection<Company> Companies { get; set; } = new ObservableCollection<Company>();

        public AgreementViewModel()
        {
            AddCompany = new Command(OnAddCompany);

            SelectCompany = new Command(OnSelectCompany);

            GetCompanies();
        }

        public ICommand AddCompany { get; }
        public ICommand SelectCompany { get; }

        public string Company
        {
            get => company.Name;
            set
            {
                if (value == company.Name)
                    return;

                company.Name = value;
                NotifyPropertyChanged("Company");
            }
        }

        public string Scope
        {
            get => company.Scope;
            set
            {
                if (value == company.Scope)
                    return;

                company.Scope = value;
                NotifyPropertyChanged("Scope");
            }
        }

        public string Key
        {
            get => company.Key;
            set
            {
                if (value == company.Key)
                    return;

                company.Key = value;
                NotifyPropertyChanged("Key");
            }
        }

        public DateTime EndDate
        {
            get => company.EndDate;
            set
            {
                if (value == company.EndDate)
                    return;

                company.EndDate = value;
                NotifyPropertyChanged("EndDate");
            }
        }

        void OnAddCompany()
        {
            string companyKey = "1234";
            if(Key == companyKey)
            {
                Services.CompanyService.CurrentCompany = company;
                Services.CompanyService.AddCompany(company);

                Application.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Foute key", "De ingevoerde sleutel komt niet overeen met de sleutel van het bedrijf", "Ok");
            }
        }

        void OnSelectCompany()
        {
            CompanyService.CurrentCompany = SelectedCompany;

            Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

        void GetCompanies()
        {
            List<Company> companies = CompanyService.GetCompanies();
            foreach (Company company in companies)
            {
                Companies.Add(company);
            }
        }
    }
}
