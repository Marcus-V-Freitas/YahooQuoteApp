using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooQuoteApp.ExtensionMethods
{
    public static class Utils
    {
        public static double ToMoney(this string text)
        {
            StringBuilder sb = new StringBuilder();
            bool isDecimal = false;
            double value = 0;

            if (string.IsNullOrEmpty(text))
            {
                return value;
            }

            foreach (var letter in text)
            {
                if (letter == '.' || letter == ',')
                {
                    isDecimal = true;
                    continue;
                }

                if (letter == '-' || letter >= '0' || letter <= '9')
                {
                    sb.Append(letter);
                }
            }

            if (double.TryParse(sb.ToString(), out value) && isDecimal)
            {
                value /= 100;
            }

            return value;
        }
    }
}
