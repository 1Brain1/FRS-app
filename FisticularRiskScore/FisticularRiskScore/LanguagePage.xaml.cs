using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FisticularRiskScore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagePage : ContentPage
    {
        public List<Language> Languages { get; set; }

        public class Language
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Sign { get; set; }
        }

        public LanguagePage()
        {
            InitializeComponent();

            languageList.ItemsSource = new List<Language>
            {
                new Language {Id = 1, Name = TranslateExtension.LocalizeHelper("LanguageEN"), Sign="en-US" },
                new Language {Id = 2, Name = TranslateExtension.LocalizeHelper("LanguageRU"), Sign="ru-RU" }
            };
        }

        public ListView LanguageSelection
        { get { return languageList; } }
    }
}