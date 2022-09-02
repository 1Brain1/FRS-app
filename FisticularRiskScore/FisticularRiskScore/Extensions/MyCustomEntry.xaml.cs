using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FisticularRiskScore.Extensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCustomEntry : ContentView
    {
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(MyCustomEntry), string.Empty, BindingMode.TwoWay);

        public static readonly BindableProperty TextColorPropetry =
            BindableProperty.Create("TextColor", typeof(Color), typeof(MyCustomEntry), Color.Default, BindingMode.TwoWay);

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create("Placeholder", typeof(string), typeof(MyCustomEntry), string.Empty, BindingMode.TwoWay);

        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create("Keyboard", typeof(Keyboard), typeof(MyCustomEntry), Xamarin.Forms.Keyboard.Default, BindingMode.TwoWay);

        public static readonly BindableProperty ReturnTypeProperty =
            BindableProperty.Create("ReturnType", typeof(ReturnType), typeof(MyCustomEntry), Xamarin.Forms.ReturnType.Default, BindingMode.TwoWay);

        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create("IsPassword", typeof(Boolean), typeof(MyCustomEntry), false, BindingMode.TwoWay);

        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(nameof(IsChecked), typeof(Boolean), typeof(MyCustomEntry), true, BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorPropetry); }
            set { SetValue(TextColorPropetry, value); }
        }

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        public ReturnType ReturnType
        {
            get { return (ReturnType)GetValue(ReturnTypeProperty); }
            set { SetValue(ReturnTypeProperty, value); }
        }

        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = default)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TextProperty.PropertyName)
            {
                entryView.Text = Text;
            }

            if (propertyName == TextColorPropetry.PropertyName)
            {
                entryView.TextColor = TextColor;
            }

            if (propertyName == PlaceholderProperty.PropertyName)
            {
                entryView.Placeholder = Placeholder;
            }

            if (propertyName == KeyboardProperty.PropertyName)
            {
                entryView.Keyboard = Keyboard;
            }

            if (propertyName == ReturnTypeProperty.PropertyName)
            {
                entryView.ReturnType = ReturnType;
            }

            if (propertyName == IsPasswordProperty.PropertyName)
            {
                entryView.IsPassword = IsPassword;
            }

            if (propertyName == IsCheckedProperty.PropertyName)
            {
                cheking.IsVisible = true;
                cheking.Source = IsChecked ? "ic_true.png" : "ic_false.png";
            }
        }

        public EventHandler<TextChangedEventArgs> OnChangedText { get; set; }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Text = e.NewTextValue;

            OnChangedText?.Invoke(sender, e);
        }

        public MyCustomEntry()
        {
            InitializeComponent();

            entryView.TextChanged -= OnTextChanged;
            entryView.TextChanged += OnTextChanged;
        }
    }
}