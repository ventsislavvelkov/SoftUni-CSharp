using System;
using System.Linq;
using System.Reflection;
using ValidationAttribute.Attributes;

namespace ValidationAttribute.Utilities
{
    public static class Validator
    {/// <summary>
    /// Check all the properties for out custom attributes and if they are valid - the obj is valid 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
        public static bool IsValid(object obj)
        {
            if (obj is null)
            {
                return false; 
            }
            Type objType = obj.GetType();

            PropertyInfo[] objProperties = objType.GetProperties();

            foreach (var property in objProperties)
            {
                MyValidationAttribute[] attributes = property.GetCustomAttributes()
                    .Where(ca => ca is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (var attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
 