using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FisticularRiskScore.LanguagePage;

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

        private void OnSelectingLanguage(object sender, EventArgs e)
        {
            var page = new LanguagePage();
            page.LanguageSelection.ItemSelected += (source, args) =>
            {
                var selectedItem = args.SelectedItem as Language;
                languageSelected.Text = selectedItem.Name;
                //return new System.Globalization.CultureInfo(selectedItem.Sign);

                Navigation.PopAsync();
                //Debug.WriteLine(selectedItem.Sign);
            };
            Navigation.PushAsync(page);
        }
    }
}