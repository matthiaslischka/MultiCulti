using System;
using System.Globalization;

namespace MultiCulti
{
    public static class CultureInfoExtensions
    {
        public static IDisposable AsCurrent(this CultureInfo cultureInfo)
        {
            return new CurrentCultureHandler(cultureInfo);
        }
    }
}