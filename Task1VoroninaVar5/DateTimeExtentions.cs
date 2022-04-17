using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1VoroninaVar5
{
    static class DateTimeExtentions
    {

        public static DateTime ToDateTime(this int value)
        {
            return new DateTime(value, 1, 1);
        }
    }
}
