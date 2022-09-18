using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Resources;
using System.Globalization;
using System.Reflection;
using static FisticularRiskScore.DashboardPage;
using System;

namespace FisticularRiskScore
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private static CultureInfo ci;
        public static string currentLanguage = "en-US";
        private const string ResourceId = "FisticularRiskScore.Resources.Resource";

        public TranslateExtension()
        {
            ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo(currentLanguage);
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            ResourceManager resmgr = new ResourceManager(ResourceId,
            typeof(TranslateExtension).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, ci);

            if (translation == null)
            {
                translation = Text;
            }
            return translation;
        }

        public static string LocalizeHelper(string key)
        {
            string ret = string.Empty;
            ResourceManager resmgr = new ResourceManager(ResourceId,
            typeof(TranslateExtension).GetTypeInfo().Assembly);
            ret = resmgr.GetString(key, ci);

            return ret;
        }
    }
}