using System;

namespace Clasess
{
    public class UriValidator
    {
        public bool IsValidUri(string uriString)
        {
            return Uri.IsWellFormedUriString(uriString, UriKind.Absolute);
        }
    }
}
