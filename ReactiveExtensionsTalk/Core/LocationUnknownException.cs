using System;
using System.Runtime.Serialization;

namespace Core
{
    [Serializable]
    public class LocationUnknownException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public LocationUnknownException()
        {
        }

        public LocationUnknownException(string message) : base(message)
        {
        }

        public LocationUnknownException(string message, Exception inner) : base(message, inner)
        {
        }

        protected LocationUnknownException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}