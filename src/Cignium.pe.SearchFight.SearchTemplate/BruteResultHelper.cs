using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.pe.SearchFight.SearchTemplate
{
    public static class BruteResultHelper
    {
        public static String GetDigits(string input)
        {
            return new String(input.Where(Char.IsDigit).ToArray());
        }
    }
}
