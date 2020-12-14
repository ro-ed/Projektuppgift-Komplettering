using System;
using System.Collections.Generic;
using System.Text;


namespace Logic.Exceptions
{
    public class DateTimeException : Exception
    {
        public override string Message
        {
            get
            {
                return "You entered an invalid date format. Please restart the program and try again with this format (YYYY-MM-DD).";
            }
        }
        public DateTimeException()
        {
           


        }
       
    }
}