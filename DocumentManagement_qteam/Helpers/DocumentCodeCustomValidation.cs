using DocumentManegemant.Data;
using System.ComponentModel.DataAnnotations;

namespace DocumentManagement.Helpers
{
    public class DocumentCodeCustomValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            var newDocumentCode = Convert.ToInt32(value);

            if(!context.Document.Any(x=>x.Code == newDocumentCode))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("This document code it's already in use. please choose another.");
        }
    }
}
