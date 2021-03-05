using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_01.Validators.MenssageErrors
{
    public static class ContaModelErrorMenssages
    {
        public static string NameCantBeEmpty = "The Name can't be empty !";
        public static string NameExceededMaxLength = "The Name exceeded the maxlength";
        public static string NameCantBeLessThan10 = "The Name can't be less than 10 characters";
        public static string DateCantBeEmpty = "The Date can't be empty !";
        public static string ValueCantBeNull = "The Value can't be null !";
        public static string ValueCantBeLessThan1 = "The Value can't be less than 1";
    }
}
