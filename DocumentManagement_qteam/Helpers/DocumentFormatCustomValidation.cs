using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DocumentManagement.Helpers
{
    public class DocumentFormatCustomValidation  : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string documentFile = ((IFormFile)value).FileName;
                if (documentFile.Contains(".pdf") || documentFile.Contains(".xls") || documentFile.Contains(".doc") || documentFile.Contains(".docx") || documentFile.Contains(".xlsx"))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Please insert a valid file");
        }
    }
}

