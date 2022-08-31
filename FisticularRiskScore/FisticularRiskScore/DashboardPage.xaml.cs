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
            await Navigation.PopAsync();
        }
    }
}