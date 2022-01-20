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
    }
}
