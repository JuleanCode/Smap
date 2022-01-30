using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public User LoggedInUser { get; set; }
        public Company CurrentCompany { get; set; } = CompanyService.CurrentCompany;

        public MainViewModel()
        {
            LoggedInUser = UserService.LoggedInUser;

            NewScan = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new ScannerPage());
            });

            PreviousScans = new Command(() =>
            {
                IpService.SelectedIp = null;
                Application.Current.MainPage.Navigation.PushAsync(new PreviousReportsPage());
            });

            Logout = new Command(() =>
            {
                UserService.LoggedInUser = null;
                Application.Current.MainPage.Navigation.PopToRootAsync();
            });

            NetworkInfo = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new NetworkInformationPage());
            });

            SelectPic = new Command(async () =>
            {
                await CrossMedia.Current.Initialize();
                var mediaOptions = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                try
                {
                    var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);
                    var picStream = selectedImageFile.GetStream();
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("Geen foto", "Er is geen foto geselecteerd", "Ok");
                }
            });
        }

        public Command NewScan { get; }
        public Command PreviousScans { get; }
        public Command Logout { get; set; }
        public Command NetworkInfo { get; set; }
        public Command SelectPic { get; set; }
    }
}
