using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1092242.Common.CustomException
{
    public class RequestEmptyException : Exception
    {
        public RequestEmptyException(string message) : base(message)
        {
        }
    }
}
