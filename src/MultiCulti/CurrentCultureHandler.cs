using System.Globalization;
using System;
using System.Threading;

namespace MultiCulti
{
    public class CurrentCultureHandler : IDisposable
    {
        readonly CultureInfo _originalCultureInfo;
        readonly CultureInfo _originalUiCultureInfo;

        public CurrentCultureHandler(CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
                throw new ArgumentNullException(nameof(cultureInfo));

            _originalCultureInfo = Thread.CurrentThread.CurrentCulture;
            _originalUiCultureInfo = Thread.CurrentThread.CurrentUICulture;

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = _originalCultureInfo;
            Thread.CurrentThread.CurrentUICulture = _originalUiCultureInfo;
        }
    }
}
