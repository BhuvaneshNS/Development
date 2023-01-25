using System;

namespace LibraryManagement.CustomException
{
    public class RegistrationFailedException : Exception
    {
        public RegistrationFailedException(string message) : base(message)
        {
        }
    }
}
