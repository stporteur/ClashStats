using System;

namespace ClashBusiness.Exceptions
{
    public class UnkownapplicationSettingException : Exception
    {
        public UnkownapplicationSettingException() : 
            base("Application Setting doesn't exist")
        {
        }
    }
}
