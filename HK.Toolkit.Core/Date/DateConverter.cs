using HK.Toolkit.Exceptions;
using System;
using System.Globalization;

namespace HK.Toolkit.Date
{
    public static class DateConverter
    {
        /// <summary>
        /// Convert To Georgian Date From Persina Date
        /// </summary>
        /// <param name="persianDate">persian Date like this "1393/05/20"</param>
        /// <returns>Georgian DateTime</returns>
        public static DateTime ToGeorgianDateTimeFromPersian(this string persianDate)
        {
            try
            {
                var persianCalendar = new PersianCalendar();

                var intYear = Convert.ToInt32(persianDate.Substring(0, 4));
                var intMonth = Convert.ToInt32(persianDate.Substring(5, 2));
                var intDay = Convert.ToInt32(persianDate.Substring(8, 2));

                return persianCalendar.ToDateTime(intYear, intMonth, intDay, 0, 0, 0, 0);
            }
            catch (Exception ex)
            {
                throw new DateConversionFromGregorianToPersianInvalidException(persianDate, ex.Message);
            }
        }
    }
}