using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sem2IntroProjectWaterfall0._1
{
    public class MinimalEmployeesException : Exception
    {
        public MinimalEmployeesException() : base ()
        {
        }

        public MinimalEmployeesException(string message) : base(message)
        {
        }

        public MinimalEmployeesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MinimalEmployeesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
