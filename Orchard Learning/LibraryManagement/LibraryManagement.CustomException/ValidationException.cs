﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.CustomException
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {

        }
    }
}
