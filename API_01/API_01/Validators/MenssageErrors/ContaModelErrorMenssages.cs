namespace API_01.Validators.MenssageErrors
{
    public static class ContaModelErrorMenssages
    {
        public static string NameCantBeEmpty = "The Name can't be empty !";
        public static string NameExceededMaxLength = "The Name exceeded the maxlength";
        public static string NameCantBeLessThan10 = "The Name can't be less than 10 characters";

        public static string DateCantBeEmpty = "The Date can't be empty !";
        public static string DateCantBeGreaterThanNow = "The Date can't be greater than now";

        public static string ValueCantBeNull = "The Value can't be null !";
        public static string ValueCantBeLessThan1 = "The Value can't be less than 1";

        public static string EmailCantBeEmpty = "The Email can't be empty";
        public static string EmailCantBeLessThan13 = "The Email can't be less than 13 characters";
        public static string EmailCantBeGreaterThan100 = "The Email can't be greater than 100 characters";
    }
}
