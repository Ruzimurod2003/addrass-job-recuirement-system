using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Common;
public class SalaryRangeAttribute : ValidationAttribute
{
    private readonly string _minSalaryPropertyName;

    public SalaryRangeAttribute(string minSalaryPropertyName)
    {
        _minSalaryPropertyName = minSalaryPropertyName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var maxSalaryProperty = validationContext.ObjectType.GetProperty(validationContext.MemberName);
        var minSalaryProperty = validationContext.ObjectType.GetProperty(_minSalaryPropertyName);

        if (maxSalaryProperty != null && minSalaryProperty != null)
        {
            var maxSalaryValue = maxSalaryProperty.GetValue(validationContext.ObjectInstance, null);
            var minSalaryValue = minSalaryProperty.GetValue(validationContext.ObjectInstance, null);

            if (maxSalaryValue != null && minSalaryValue != null && (decimal)maxSalaryValue <= (decimal)minSalaryValue)
            {
                return new ValidationResult("<MAX SALARY> must be greater than <MIN SALARY>.");
            }
        }

        return ValidationResult.Success;
    }
}