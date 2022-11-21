using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR30_2021_POP2022.Exceptions
{
    class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base() { }

        public UserNotFoundException(string message) : base(message) { }

        public UserNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
