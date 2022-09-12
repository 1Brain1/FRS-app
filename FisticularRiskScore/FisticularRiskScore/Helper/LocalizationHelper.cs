using FisticularRiskScore.Resources;

namespace FisticularRiskScore.Helper
{
    public class LocalizationHelper
    {
        public static string Localize(string key)
        {
            string ret = string.Empty;

            ret = Resource.ResourceManager.GetString(key);

            return ret;
        }
    }
}