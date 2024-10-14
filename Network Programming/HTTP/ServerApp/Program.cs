using System.Net;
using System.Text.Json;

const int port = 7373;

HttpListener httpListener = new HttpListener();

httpListener.Prefixes.Add($"http://*:{port}/");

httpListener.Start();

System.Console.WriteLine($"HTTP Server started on 'http://localhost:{port}/'");

while(true) {
    var context = await httpListener.GetContextAsync();

    var writer = new StreamWriter(context.Response.OutputStream);

    System.Console.WriteLine(context.Request.RawUrl);
    System.Console.WriteLine(context.Request.ContentType);
    context.Response.ContentType = "text/plain";

    await writer.WriteLineAsync(await File.ReadAllTextAsync("Pages/index.html"));

    // var json = JsonSerializer.Serialize(new {
    //     name = "Bob",
    //     surname = "Marley",
    //     birthdate = new DateTime(1954, 2, 2),
    // });

    //await writer.WriteLineAsync(json);
    await writer.FlushAsync();

    context.Response.Close();








    /* WITH HTML

    string normalizedRawUrl = context.Request.RawUrl?.Trim('/', ' ').ToLower() ?? string.Empty;

    if(normalizedRawUrl == string.Empty) {
        normalizedRawUrl = "index";
    }

    string pagePath = $"Pages/{normalizedRawUrl}.html";

    System.Console.WriteLine(pagePath);

    var pageHtml = File.Exists(pagePath)
        ? await File.ReadAllTextAsync(pagePath)
        : await File.ReadAllTextAsync("Pages/notfound.html");

    var writer = new StreamWriter(context.Response.OutputStream);

    await writer.WriteLineAsync(pageHtml);
    await writer.FlushAsync();

    context.Response.Close();

    */
}
