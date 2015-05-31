using Xamarin.Forms;

namespace MvvmExample
{
    public partial class SliderLabelView : ContentView
    {
        public static BindableProperty ValueProperty = BindableProperty.Create<SliderLabelView, double>(
            sliderLabelView => sliderLabelView.Value,
            defaultValue: 0,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnValuePropertyChanged);

        public static BindableProperty MinimumProperty = BindableProperty.Create<SliderLabelView, double>(
            sliderLabelView => sliderLabelView.Minimum,
            defaultValue: 0,
            propertyChanged: OnMinimumPropertyChanged);

        public static BindableProperty MaximumProperty = BindableProperty.Create<SliderLabelView, double>(
            sliderLabelView => sliderLabelView.Maximum,
            defaultValue: 10,
            propertyChanged: OnMaximumPropertyChanged);

        public static BindableProperty LabelColorProperty = BindableProperty.Create<SliderLabelView, Color>(
            sliderLabelView => sliderLabelView.LabelColor,
            defaultValue: Color.Black,
            propertyChanged: OnLabelColorPropertyChanged);

        public SliderLabelView ()
        {
            InitializeComponent ();

            _slider.ValueChanged += (sender, e) => Value = _slider.Value;
        }

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public Color LabelColor
        {
            get { return (Color)GetValue(LabelColorProperty); }
            set { SetValue(LabelColorProperty, value); }
        }

        private static void OnValuePropertyChanged(BindableObject bindable, double oldValue, double newValue)
        {
            var sliderLabelView = (SliderLabelView)bindable;
            sliderLabelView._slider.Value = newValue;
            sliderLabelView._label.Text = newValue.ToString();
        }

        private static void OnMinimumPropertyChanged(BindableObject bindable, double oldValue, double newValue)
        {
            var sliderLabelView = (SliderLabelView)bindable;
            sliderLabelView._slider.Minimum = newValue;
        }

        private static void OnMaximumPropertyChanged(BindableObject bindable, double oldValue, double newValue)
        {
            var sliderLabelView = (SliderLabelView)bindable;
            sliderLabelView._slider.Maximum = newValue;
        }

        private static void OnLabelColorPropertyChanged(BindableObject bindable, Color oldValue, Color newValue)
        {
            var sliderLabelView = (SliderLabelView)bindable;
            sliderLabelView._label.TextColor = newValue;
        }
    }
}

