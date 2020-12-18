using System;

namespace ClashBusiness.Exceptions
{
    public class UnkownClanException : Exception
    {
        public UnkownClanException() : 
            base("Clan doesn't exist")
        {
        }
    }
}
