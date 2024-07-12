namespace ExtensionsApp;

static class UserExtensions
{
    public static bool IsAdult(this User user)
    {
        return user.Age >= 18;
    }
}
