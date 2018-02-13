using System;
using System.Globalization;
public class DateModifier
{
   
    public long Difference(string first, string second)
    {
        var startDate = DateTime.ParseExact(first, "yyyy MM dd", CultureInfo.InvariantCulture); 
        var endDate = DateTime.ParseExact(second, "yyyy MM dd", CultureInfo.InvariantCulture);
        return (long)Math.Abs((startDate - endDate).TotalDays);
    }
}

