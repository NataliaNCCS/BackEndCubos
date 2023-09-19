using System.ComponentModel.DataAnnotations;

namespace BackEndCubos.Domain.CustomValidations.Attributes
{
    public class CpfOrCnpjAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string document = value.ToString()!;

                if (!DocumentValidationService.IsValidCpf(document) && !DocumentValidationService.IsValidCnpj(document))
                    return new ValidationResult("CPF ou CNPJ inválido.");

                return ValidationResult.Success!;
            }

            return new ValidationResult("O campo é obrigatório.");
        }
    }
}
