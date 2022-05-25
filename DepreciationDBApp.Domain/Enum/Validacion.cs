using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Domain.Enum
{
     public  static class Validacion
    {
        public static bool emptyFIelds(string Cadena1, string Cadena2, string Cadena3, string Cadena4, string Cadena5, int index)
        {
            if (String.IsNullOrEmpty(Cadena1) || String.IsNullOrEmpty(Cadena2) || String.IsNullOrEmpty(Cadena3) || String.IsNullOrEmpty(Cadena4) || String.IsNullOrEmpty(Cadena5) || index == -1)
            {
                return false;
            }
            return true;
        }

        public static bool ValidationAmount(decimal Value1, decimal Value2)
        {
            if (Value1 > Value2)
            {
                return true;
            }
            return false;
        }
    }
}
