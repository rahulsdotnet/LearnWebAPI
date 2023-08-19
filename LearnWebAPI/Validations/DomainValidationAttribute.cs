using System;
using System.ComponentModel.DataAnnotations;

namespace LearnWebAPI
{
    public class DomainValidationAttribute : ValidationAttribute
    {
        private readonly string _domain;
        public DomainValidationAttribute(string domain)
        {
            _domain = domain;
        }

        public override bool IsValid(object value)
        {
            if (value is string email)
            {
                var splitEmail = email.Split("@");
                return splitEmail.Length == 2 && splitEmail[1].Contains(_domain, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} only allowed {_domain} domain.";
        }
    }
}
