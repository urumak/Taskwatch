using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskwatch
{
    public static class Extensions
    {
        public static string ToShortTimeString(this TimeSpan elapsed)
        {
            return string.Format("{0:00}:{1:00}:{2:00}", elapsed.Hours, elapsed.Minutes, elapsed.Seconds);
        }
    }
}
