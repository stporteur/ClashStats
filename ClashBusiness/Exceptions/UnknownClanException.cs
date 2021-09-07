using System;

namespace ClashBusiness.Exceptions
{
    public class UnknownClanException : Exception
    {
        public UnknownClanException() : 
            base("Clan doesn't exist")
        {
        }
    }
}
