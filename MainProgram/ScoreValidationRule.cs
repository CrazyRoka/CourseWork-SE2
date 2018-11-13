using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SE2.CourseWork
{
    public class ScoreValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || (value as string).Length == 0) return new ValidationResult(false, "Дата не може бути пустою");
            try
            {
                decimal cur = decimal.Parse(value as string);
                if (cur < 0 || cur > 100) return new ValidationResult(false, "Поле повинно бути у діапазоні від 0 до 100");
            }catch(FormatException)
            {
                return new ValidationResult(false, "Поле повинно містити число");
            }
            return new ValidationResult(true, null);
        }
    }
}
