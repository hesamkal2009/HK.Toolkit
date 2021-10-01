using System;

namespace HK.Toolkit.Exceptions
{
    [Serializable]
    public class InputIsNotConvertableToRequiredTypeException : Exception
    {
        public InputIsNotConvertableToRequiredTypeException()
        {
        }

        public InputIsNotConvertableToRequiredTypeException(string message) : base(message)
        {
        }

        public InputIsNotConvertableToRequiredTypeException(string message, Exception inner) : base(message, inner)
        {
        }

        public InputIsNotConvertableToRequiredTypeException(object input, object outputType, string message) : base(message)
        {
        }

        protected InputIsNotConvertableToRequiredTypeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}