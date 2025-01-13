namespace CCL.Identity
{
    public static class SecurityContext
    {
        private static User? _currentUser;

        public static void SetUser(User user)
        {
            _currentUser = user;
        }

        public static User? GetCurrentUser()
        {
            return _currentUser;
        }
    }
}
