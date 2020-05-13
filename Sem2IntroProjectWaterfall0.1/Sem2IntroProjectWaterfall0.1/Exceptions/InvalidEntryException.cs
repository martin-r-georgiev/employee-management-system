using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sem2IntroProjectWaterfall0._1
{
    public class InvalidEntryException : Exception
    {
        public InvalidEntryException()
        {
        }

        public InvalidEntryException(string message) : base(message)
        {
        }

        public InvalidEntryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidEntryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
