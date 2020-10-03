using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Infrastructure.CustomDataAnnotations
{
    public class DateInPastAttribute : RangeAttribute
    {
        public DateInPastAttribute()
            :base(typeof(DateTime), DateTime.MinValue.ToShortDateString(), DateTime.Now.ToShortDateString())
        { }
    }
}
