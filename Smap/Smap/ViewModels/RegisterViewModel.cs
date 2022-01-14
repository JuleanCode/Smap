using Smap.Models;
using Smap.Services;
using Smap.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Smap.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
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

        public RegisterViewModel()
        {
            Register = new Command(OnRegister);
            Back = new Command(OnBack);
        }

        public ICommand Register { get; }
        public ICommand Back { get; }

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

        string passwordCheck;
        public string PasswordCheck
        {
            get => passwordCheck;
            set
            {
                if (value == passwordCheck)
                    return;

                passwordCheck = value;
                NotifyPropertyChanged("PasswordCheck");
            }
        }

        void OnRegister()
        {
            if (user.Email != "" && user.Password != "" && user.Password == passwordCheck)
            {
                UserService.CreateUser(user);

                Application.Current.MainPage.Navigation.PushAsync(new AgreementPage());
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Alert", "All fields must be filled!!!", "OK");
            }
        }

        void OnBack()
        {
            Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
    }
}
