using System.Net.Http.Json;

HttpClient httpClient = new HttpClient();

if(true) {
    var response = await httpClient.PostAsJsonAsync("http://localhost:7373/account/login", new {
        username = "bob",
        password = "secret12345"
    });

    var status = response.StatusCode;
    var responseBodyStr = await response.Content.ReadAsStringAsync();

    System.Console.WriteLine($"Response Status: {status}");
    System.Console.WriteLine($"Response Body: {responseBodyStr}");
}

if(false) {
    System.Console.Write("User id: ");
    var userIdStr = Console.ReadLine();

    ArgumentNullException.ThrowIfNullOrWhiteSpace(userIdStr);

    if(int.TryParse(userIdStr, out int userId)) {
        HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:7373/users/{userId}");

        var status = response.StatusCode;
        var responseBodyStr = await response.Content.ReadAsStringAsync();

        System.Console.WriteLine($"Response Status: {status}");
        System.Console.WriteLine($"Response Body: {responseBodyStr}");
    }
    else {
        System.Console.WriteLine("Incorrect input! User id is number!");
    }
}