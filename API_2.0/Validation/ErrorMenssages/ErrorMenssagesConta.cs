using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2._0.Validation.ErrorMenssages
{
    public static class ErrorMenssagesConta
    {
        public static string NameEmpty = "The Name can't be null!";
        public static string NameMaxLength = "The Name can't be greater than 80 characters!";
        public static string NameMinmLength = "The Name can't be less than 3 characters!";

        public static string DateNull = "The Date can't be null!";
        public static string DateMinm = "The Date can't be less than today!"; 
        public static string DateMax = "The Date can't be future!";

        public static string ValueMinm = "The value can't be less than 1!";
        public static string ValueNull = "the Value can't be null!";

        public static string EmailNull = "Email can't be null!";
        public static string EmailAlreadyRegistered = "The Email already registered";
    }
}
