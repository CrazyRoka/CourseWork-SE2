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
    public class GroupNumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || (value as string)?.Length == 0) return new ValidationResult(false, "Поле не може бути пустим");
            try
            {
                int course = int.Parse(value as string);
                if (course < 1) return new ValidationResult(false, "Введіть число більше 0");
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Введіть у поле число");
            }
            return new ValidationResult(true, null);
        }
    }
}
