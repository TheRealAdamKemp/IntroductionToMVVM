using System;
using Xamarin.Forms;

namespace MvvmExample
{
    public partial class MainPageXaml : ContentPage
    {
        public MainPageXaml()
        {
            InitializeComponent();
        }

        private async void OnListButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListViewPage { BindingContext = new ListViewModel() });
        }
    }
}

