using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sem2IntroProjectWaterfall0._1.Forms
{
    class NameTakenException : Exception
    {
        public NameTakenException()
        {
        }

        public NameTakenException(string message) : base(message)
        {
        }

        public NameTakenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NameTakenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
