namespace HK.Toolkit.Core
{
    public static class RegExPatterns
    {
        public static readonly string PasswordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}";
        public static readonly string EmailPattern = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}";
    }
}