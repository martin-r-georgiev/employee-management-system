using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    class MinimalEmployeesException : Exception
    {
        public MinimalEmployeesException()
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
