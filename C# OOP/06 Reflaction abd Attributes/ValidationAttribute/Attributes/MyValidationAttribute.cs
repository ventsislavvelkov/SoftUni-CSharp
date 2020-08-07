using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttribute.Attributes
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =true)]
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
