using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.CustomAttributes
{
    internal class MaxValueAttribute : ValidationAttribute
    {
        private readonly int _max;

        public MaxValueAttribute(int max)
        {
            _max = max;
        }

        public override bool IsValid(object value)
        {
            return (int)value <= _max;
        }
    }
}
