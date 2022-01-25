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
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Smap.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private User user = new User();

        public LoginViewModel()
        {
            Login = new Command(OnLogin);
            Register = new Command(OnRegister);

            VDB();
        }

        public ICommand Login { get; }
        public ICommand Register { get; }

        public string Email
        {
            get => user.Email;
            set
            {
                if (value == user.Email)
                    return;

                user.Email = value;
                NotifyPropertyChanged("Email");
            }
        }

        public string Password
        {
            get => user.Password;
            set
            {
                if (value == user.Password)
                    return;

                user.Password = value;
                NotifyPropertyChanged("Password");
            }
        }

        void OnLogin()
        {
            //Anders blijft hij nieuwe accounts aanmaken
            Helper.FreshInstall();

            if (user.Email != "" && user.Password != "")
            {
                if (UserService.CheckUser(user.Email, user.Password))
                {
                    //get the curent location of the user
                    Geolocation.GetLastKnownLocationAsync().ToString(); ;

                    Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Login credentials are incorrect ", "Ok");
                }
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Alert", "All fields must be filled!!!", "Ok");
            }
        }

        void OnRegister()
        {
            Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }


        async void VDB()
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://vuldb.com/?api");
            request.Method = HttpMethod.Get;
            request.Headers.Add("apikey", "ee9a2baf05302ba59b50c290a88097fd");
            HttpResponseMessage response = httpClient.SendAsync(request).Result;
            var responseString = await response.Content.ReadAsStringAsync();
            var statusCode = response.StatusCode;
        }
    }
}
