using System.Runtime.Serialization;

namespace MsServiceApp.Domain
{
    public class MsServiceException : Exception
    {
        public MsServiceException()
        { }

        public MsServiceException(string message)
            : base(message)
        { }

        public MsServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected MsServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}