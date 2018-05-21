using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Web.Infrastructure.Validators
{
    public class PersonNameAttribute  : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            throw new NotImplementedException();
        }
    }
}