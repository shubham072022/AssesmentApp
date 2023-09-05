namespace Todo.Application.Common.Constants
{
    public static class Messages
    {
        public static string Success => "Success";
        public static string RegisteredSuccesfully => "Registered Successfully";
        public static string AddedSuccesfully => "{0} Added Successfully";
        public static string UpdatedSuccessfully => "{0} Updated Successfully";
        public static string DeletedSuccessfully => "{0} Deleted Successfully";
        public static string NotFound => "Entity not found";
        public static string DataFound => "Data found";
        public static string NoDataFound => "No Data found";
        public static string IssueWithData => "There is some issue with the data";
        public static string CheckCredentials => "Please check login credentials";
        public static string UserNameOrPasswordIsIncorrect => "Username or password is incorrect";
        public static string PasswordDontMatchWithConfirmation => "Password doesn't match its confirmation";
        public static string UserNotFound => "User not found";
        public static string TokenOrUserNotFound => "Token or User Not Found";
        public static string RefreshTokenNotFound => "Refresh Token Not Found";
        public static string IsRequired => "{0} is required";
        public static string AlreadyExists => "{0} already exist";
        public static string MaxCharLimit => "{0} is exceeding the limit of {1} characters.";
    }
}
