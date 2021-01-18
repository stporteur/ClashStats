using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashEntities
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class EnumDescriptionAttribute : Attribute
    {
        private string _description;

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public EnumDescriptionAttribute(string description) : base()
        {
            _description = description;
        }
    }
}
