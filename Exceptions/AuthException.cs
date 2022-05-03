using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionTesteConsole.Exceptions
{
    public class AuthException : Exception
    {
        public AuthException()
        {
        }
        public AuthException(string message)
            : base(message)
        {

        } 
        public AuthException(string message, Exception innerExcepetiom)
            :base(message, innerExcepetiom)
        {
        }
    }
}
