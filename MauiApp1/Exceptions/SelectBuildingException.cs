using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooQuoteApp.Exceptions
{
    public class SelectBuildingException : Exception
    {
        internal SelectBuildingException(string message) : base(message) { }
    }
}
