using Xamarin.Forms;
using static FisticularRiskScore.DashboardPage;

[assembly: Dependency(typeof(FisticularRiskScore.Droid.Localize))]

namespace FisticularRiskScore.Droid
{
    public class Localize : ILocalize
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo(string currentLanguage)
        {
            return new System.Globalization.CultureInfo(currentLanguage);
        }
    }
}