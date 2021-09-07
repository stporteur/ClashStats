using System;

namespace ClashBusiness.Exceptions
{
    public class DifferentTypeImportException : Exception
    {
        public DifferentTypeImportException() : 
            base("Import selected type differs from file type")
        {
        }
    }
}
