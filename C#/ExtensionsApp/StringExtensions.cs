namespace ExtensionsApp;

static class StringExtensions
{
    public static string Capitalize(this string word)
    {
        if (string.IsNullOrEmpty(word) || word.Length <= 1)
            return word;

        return char.ToUpper(word[0]) + word[1..].ToLower();
    }
}