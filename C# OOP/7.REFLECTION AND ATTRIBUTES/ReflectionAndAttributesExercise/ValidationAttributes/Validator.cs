using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Type objType = obj.GetType();
            var properties = objType.GetProperties();


            foreach (var prop in properties)
            {
                MyValidationAttribute[] attributes = prop.GetCustomAttributes()
                    .Where(a => a is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (var attribute in attributes)
                {
                    if (!attribute.IsValid(prop.GetValue(obj)))
                    {
                        return false;
                    }
                    
                }
            }

            return true;
        }

    }
}
