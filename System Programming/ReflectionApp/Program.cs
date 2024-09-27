#pragma warning disable CS0162

using ReflectionApp;
using System.Reflection;
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
Field1: value4
Field2: value5
Field3: value6
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

            return $"\"{propName}\": {propValue}";
        });

    var fieldsInfo = GenericTypeInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
        .Select(f =>
        {
            var fieldName = f.Name;
            var filedValue = f.GetValue(obj);

            return $"\"{fieldName}\": {filedValue}";
        });

    var infos = propertiesInfo.Concat(fieldsInfo);

    return $"{{\n{string.Join(",\n", infos)}\n}}";
}

if(true) {

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