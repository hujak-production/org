using System;
using System.ComponentModel.DataAnnotations;

namespace server.Infrastructure.CustomDataAnnotations
{
    public class YearInPastAttribute : RangeAttribute
    {
        public YearInPastAttribute()
            :base(typeof(int), "0", DateTime.Now.Year.ToString())
        { }
    }
}
