using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FisticularRiskScore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : TabbedPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        private async void OnSignIn(object sender, EventArgs e)
        {
            var response = await DisplayAlert("", "Are you sure to exit", "Yes", "No");
            if (response)
                await Navigation.PopAsync();
        }
    }
}