using Xamarin.Forms;

namespace MvvmExample
{
    public class App : Application
    {
        public App()
        {
            var viewModel = new ViewModel(new Model(defaultValue: 5));
            var mainPage = new MainPageXaml { BindingContext = viewModel };
//            var mainPage = new MainPageCode { BindingContext = viewModel };
            MainPage = new NavigationPage(mainPage);
        }
    }
}

