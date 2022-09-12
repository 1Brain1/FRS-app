using FisticularRiskScore.Helper;
using System;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FisticularRiskScore.LanguagePage;

namespace FisticularRiskScore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : TabbedPage
    {
        public DashboardPage(string currentLang = null)
        {
            InitializeComponent();

            if (currentLang != null)
                languageSelected.Text = currentLang;
        }

        public interface ILocalize
        {
            CultureInfo GetCurrentCultureInfo(string currentLanguage);
        }

        private async void OnSignIn(object sender, EventArgs e)
        {
            var response = await DisplayAlert("", LocalizationHelper.Localize("AlertMessage"),
                LocalizationHelper.Localize("AlertPositiveButton"),
                LocalizationHelper.Localize("AlertNegativeButton"));
            if (response)
                await Navigation.PushAsync(new SignInPage());
        }

        private void OnSelectingLanguage(object sender, EventArgs e)
        {
            var page = new LanguagePage();
            page.LanguageSelection.ItemSelected += (source, args) =>
            {
                var selectedItem = args.SelectedItem as Language;
                languageSelected.Text = selectedItem.Name;
                
                if (TranslateExtension.currentLanguage != selectedItem.Sign)
                {
                    TranslateExtension.currentLanguage = selectedItem.Sign;
                    Navigation.PushAsync(new DashboardPage(selectedItem.Name));
                }
                else
                    Navigation.PopAsync();
                //Debug.WriteLine(selectedItem.Sign);
            };
            Navigation.PushAsync(page);
        }
    }
}