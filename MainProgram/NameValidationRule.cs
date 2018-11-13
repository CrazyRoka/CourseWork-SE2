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
    public class NameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || (value as string)?.Length == 0) return new ValidationResult(false, "Поле не може бути пустим");
            string name = value as string;
            if(!char.IsUpper(name[0]))return new ValidationResult(false, "Перший символ повинен бути великою літерою");
            for (int i = 1; i < name.Length; i++) if (!char.IsLower(name[i])) return new ValidationResult(false, "Неправильне значення. Дозволяються лише велика буква на початку та малі букви у полі.");
            return new ValidationResult(true, null);
        }
    }
}
