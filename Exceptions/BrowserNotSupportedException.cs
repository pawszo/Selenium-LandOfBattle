using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandOfBattlePage.Exceptions
{
    class BrowserNotSupportedException : Exception
    {
        public override string ToString()
        {
            return "Provided browser is not supported";
        }
    }
}
