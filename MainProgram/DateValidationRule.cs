using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SE2.CourseWork
{
    public class DateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || (value as string).Length == 0) return new ValidationResult(false, "Дата не може бути пустою");
            try
            {
                DateTime.ParseExact(value as string, "yyyy-MM-dd", null);
            }catch(FormatException)
            {
                return new ValidationResult(false, "Неправильний формат дати. Будь ласка, дотримуйтесь формату: рік-місяць-день");
            }
            return new ValidationResult(true, null);
        }
    }
}
