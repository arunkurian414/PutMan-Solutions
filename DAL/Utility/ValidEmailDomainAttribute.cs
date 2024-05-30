using System.ComponentModel.DataAnnotations;

namespace Flavours_InvMgtPortal.Utilities
{
    public class ValidEmailDomainAttribute: ValidationAttribute
    {
        private readonly string allowedDomain;

        public ValidEmailDomainAttribute(string allowedDomain)
        {
            var x = "Arun";
            var y = base.ErrorMessage;
            this.allowedDomain = allowedDomain;
        }
        //public override bool IsValid(object? value)
        //{
        //    string[] strings = value.ToString().Split("@");
        //    return strings[1].ToLower() == allowedDomain.ToLower(); 
        //}
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

             string[] strings = value.ToString().Split("@");
            strings = strings[1].Split(".");
            string[] allowed = allowedDomain.Split(",");
            if(strings[1].ToLower() == allowed[0].ToLower() || strings[1].ToLower() == allowed[1].ToLower())
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);//$"This email is not valid");
            }
        }
    }
}
