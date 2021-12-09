using Smap.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Smap.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}