using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPrep
{
    public static class Extensions
    {


        public static DateTime? ToDateTime(this string self,string format)
        {
            try
            {
                return DateTime.ParseExact(self, format, null);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
