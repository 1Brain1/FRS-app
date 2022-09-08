using Xamarin.Forms;
using static FisticularRiskScore.DashboardPage;

[assembly: Dependency(typeof(FisticularRiskScore.Droid.Localize))]

namespace FisticularRiskScore.Droid
{
    public class Localize : ILocalize
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-");
            return new System.Globalization.CultureInfo(netLanguage);
        }
    }
}