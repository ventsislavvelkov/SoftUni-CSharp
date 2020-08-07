using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttribute.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxalue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.ValidateRange(minValue, maxValue);
            this.minValue = minValue;
            this.maxalue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            if (obj is Int32)
            {
                var value = (int)obj;

                if (value >= this.minValue && value <= this.maxalue)
                {
                    return true;
                }
                return false;
            }
            else
            {
                throw new InvalidOperationException("Validation unsuccessfull due to invalid income data");
            }
        }

        private void ValidateRange(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("Invalid range!");
            }
        }
    }
}
