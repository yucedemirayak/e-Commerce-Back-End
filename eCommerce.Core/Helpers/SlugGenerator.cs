using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace eCommerce.Core.Helpers
{
    public static class SlugGenerator
    {
        public static string GenerateSlug(string incomingString, string slugSeparator = "-")
        {
            var alphaNum = Regex.Replace(incomingString, @"[^a-zA-Z0-9\s]", string.Empty);
            alphaNum = Regex.Replace(alphaNum, @"\s+", slugSeparator);

            return alphaNum.ToLower();
        }
    }
}
