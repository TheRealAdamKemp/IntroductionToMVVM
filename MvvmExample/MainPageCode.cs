using Xamarin.Forms;

namespace MvvmExample
{
    public class MainPageCode : ContentPage
    {
        public MainPageCode()
        {
            Title = "Main Page";
            this.SetBinding(VisualElement.BackgroundColorProperty, "BackgroundColor");

            var slider = new Slider
            {
                Minimum = -5,
                Maximum = 15,
            };
            slider.SetBinding(Slider.ValueProperty, "Value", BindingMode.TwoWay);

            var label = new Label
            {
                XAlign = TextAlignment.Center,
            };
            label.SetBinding(Label.TextProperty, "Value");
            label.SetBinding(
                Label.TextColorProperty,
                new Binding(
                    "IsOutOfRange",
                    converter: new BooleanToTConverter<Color>
                    {
                        TrueValue = Color.White,
                        FalseValue = Color.Green
                    }));

            var resetButton = new Button
            {
                Text = "Reset",
            };
            resetButton.SetBinding(Button.CommandProperty, "ResetCommand");

            var listButton = new Button
            {
                Text = "List",
            };
            listButton.Clicked += async (sender, e) => await Navigation.PushAsync(new ListViewPage { BindingContext = new ListViewModel() });

            Content = new StackLayout
            { 
                Children =
                {
                    slider,
                    label,
                    resetButton,
                    listButton,
                }
            };
        }
    }
}


