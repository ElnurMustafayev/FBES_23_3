using ExtensionsApp;

//string Capitalize(string word)
//{
//    if(string.IsNullOrEmpty(word) || word.Length <= 1)
//        return word;

//    return char.ToUpper(word[0]) + word[1..].ToLower();
//}

/*
string name = "BOB";

//Console.WriteLine(Capitalize(name));
Console.WriteLine(name.Capitalize());
*/

User user = new User()
{
    Age = 17
};
Console.WriteLine(user.IsAdult());