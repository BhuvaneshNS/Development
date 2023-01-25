using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalShopManagementSystem.Common.CustomException
{
    public class EmptyException : Exception
    {
        public EmptyException(string message) : base(message)
        {

        }
    }
}
