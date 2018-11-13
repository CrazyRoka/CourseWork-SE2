using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SE2.CourseWork
{
    public class SpecialityValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || (value as string).Length == 0) return new ValidationResult(false, "Поле не може бути пустим");
            return new ValidationResult(true, null);
        }
    }
}
