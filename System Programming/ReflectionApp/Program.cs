#pragma warning disable CS0162

using ReflectionApp;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text.Json;

if(false) {
    User user = new User(120, "Bob", "Marley");

    var userJson = JsonSerializer.Serialize(user);

    await File.WriteAllTextAsync("users.json", userJson);
}

if(false) {
    var userJson = File.ReadAllText("users.json");
    var user = JsonSerializer.Deserialize<User>(userJson);

    System.Console.WriteLine(user);
}


/*

{
Prop1: value1
Prop2: value2
Prop3: value3
}
 
*/

string MyJsonSerializer<T>(T obj) {

    Type GenericTypeInfo = typeof(T);

    var propertiesInfo = GenericTypeInfo
        .GetProperties()
        .Select(p =>
        {
            var propName = p.Name;
            var propValue = p.GetValue(obj);

            return $"{propName}:{propValue}";
        });

    //var fieldsInfo = GenericTypeInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
    //    .Select(f =>
    //    {
    //        var fieldName = f.Name;
    //        var filedValue = f.GetValue(obj);

    //        return $"{fieldName}:{filedValue}";
    //    });

    //var infos = propertiesInfo.Concat(fieldsInfo);

    return $"{{\n{string.Join(",\n", propertiesInfo)}\n}}";
}

/*
{
Id: 120,
Firstname: Bob,
Lastname: Marley,
Fullname: Bob Marley
}
*/
T MyJsonDeserializer<T>(string json)
{
    var jsonWithoutBrackets = json.Trim('{', '}');

    var jsonProperties = jsonWithoutBrackets
        .Split(",\n")
        .Select(propStr => propStr.Trim(',', '\n'));

    var genericTypeInfo = typeof(T);

    var resultObj = Activator.CreateInstance<T>();

    foreach (var jsonProperty in jsonProperties)
    {
        var jsonPropertyNameAndValue = jsonProperty.Split(':', StringSplitOptions.TrimEntries);
        var jsonPropertyName = jsonPropertyNameAndValue.First();
        var jsonPropertyValueStr = jsonPropertyNameAndValue.Last();

        var propertyInfo = genericTypeInfo.GetProperty(jsonPropertyName);

        if(propertyInfo == null || propertyInfo.CanWrite == false)
            continue;

        var jsonPropertyValue = Convert.ChangeType(jsonPropertyValueStr, propertyInfo.PropertyType);

        propertyInfo.SetValue(resultObj, jsonPropertyValue);
    }

    return resultObj;
}

if(true)
{
    var user = new User(120, "Bob", "Marley");

    Console.WriteLine(user);
    var userJson = MyJsonSerializer(user);
    Console.WriteLine(userJson);
    var deserializedUser = MyJsonDeserializer<User>(userJson);
    Console.WriteLine(deserializedUser);
}

if(false) {

    User user = new User(120, "Bob", "Marley");
    var userJson = MyJsonSerializer(user);

    Console.WriteLine(userJson);




    //Type userType = typeof(User);

    //Type userType = user.GetType();

    //foreach (var fieldInfo in userType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
    //{
    //    var fieldValue = fieldInfo.GetValue(user);
    //    Console.WriteLine($"{fieldInfo.Name}: {fieldValue}");
    //}






    // var userFirstContructorParameterInfos = userType.GetConstructors().First().GetParameters();
    // foreach (var parameterInfo in userFirstContructorParameterInfos)
    // {
    //     System.Console.WriteLine(parameterInfo);
    // } 

    //foreach (var propertyInfo in user.GetType().GetProperties())
    //{
    //    System.Console.WriteLine(propertyInfo);
    //}

    // var userJson = MyJsonSerializer<User>(user);

    // System.Console.WriteLine(userJson);
}

if(false)
{
    User user = new User(120, "Bob", "Marley");

    Console.WriteLine(nameof(user.GetHashCode));

    Console.WriteLine(nameof(user.Fullname));
    Console.WriteLine(user.Fullname);
    Console.WriteLine(user.GetType());
}