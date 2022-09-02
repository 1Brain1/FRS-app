using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FisticularRiskScore.Extensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCustomButton : ContentView
    {
        public static readonly BindableProperty LabelPropery =
            BindableProperty.Create("Label", typeof(string), typeof(MyCustomButton));

        public string Label
        {
            get { return (string)GetValue(LabelPropery); }
            set { SetValue(LabelPropery, value); }
        }

        public MyCustomButton()
        {
            InitializeComponent();

            BindingContext = this;
        }
    }
}