using System;

namespace HK.Toolkit.Exceptions
{
    [Serializable]
    public class DateConversionFromGregorianToPersianInvalidException : Exception
    {
        public DateConversionFromGregorianToPersianInvalidException()
        {
        }

        public DateConversionFromGregorianToPersianInvalidException(string input, string message)
        {
        }

        public DateConversionFromGregorianToPersianInvalidException(string message) : base(message)
        {
        }

        public DateConversionFromGregorianToPersianInvalidException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DateConversionFromGregorianToPersianInvalidException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}