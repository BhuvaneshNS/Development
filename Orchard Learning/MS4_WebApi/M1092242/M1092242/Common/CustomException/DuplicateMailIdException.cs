using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1092242.Common.CustomException
{
    public class DuplicateMailIdException : Exception
    {
        public DuplicateMailIdException(string message) : base(message)
        {
        }
    }
}
