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
    public class ProfessorGroupValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if ((value as string).Length == 0) return new ValidationResult(true, null);
            Regex regex = new Regex(@"^[\p{L}]+[0-9][0-9]+$");
            if (!regex.IsMatch(value as string)) return new ValidationResult(false, "Група повинна містити абревіатуру, курс та номер");
            return new ValidationResult(true, null);
        }
    }
}
