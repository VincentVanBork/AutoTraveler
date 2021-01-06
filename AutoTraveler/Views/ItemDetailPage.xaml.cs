using AutoTraveler.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AutoTraveler.Views
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