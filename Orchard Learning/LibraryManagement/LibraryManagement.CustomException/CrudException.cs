using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.CustomException
{
    public class CrudException : Exception
    {
        public CrudException(string message) : base(message)
        {
        }
    }
}
