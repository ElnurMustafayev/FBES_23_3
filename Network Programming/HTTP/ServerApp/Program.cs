using System.Net;
using System.Text.Json;

const int port = 7373;

HttpListener httpListener = new HttpListener();

httpListener.Prefixes.Add($"http://*:{port}/");

httpListener.Start();

System.Console.WriteLine($"HTTP Server started on 'http://localhost:{port}/'");


while(true) {

    // READ REQUEST BODY
    var context = await httpListener.GetContextAsync();

    var reader = new StreamReader(context.Request.InputStream);
    //context.Request.QueryString["test"].First()

    var requestBodyStr = await reader.ReadToEndAsync();

    System.Console.WriteLine();
    System.Console.WriteLine("RawUrl: " + context.Request.RawUrl);
    System.Console.WriteLine("ContentType: " + context.Request.ContentType);
    System.Console.WriteLine("HttpMethod: " + context.Request.HttpMethod);
    System.Console.WriteLine("requestBodyStr: " + requestBodyStr);

    var writer = new StreamWriter(context.Response.OutputStream);
    await writer.WriteLineAsync("IT IS OK!");
    await writer.FlushAsync();

    context.Response.Close();






/* ROUTING
    var context = await httpListener.GetContextAsync();

    var writer = new StreamWriter(context.Response.OutputStream);

    System.Console.WriteLine(context.Request.RawUrl);
    //System.Console.WriteLine(context.Request.ContentType);
    context.Response.ContentType = "application/json";

    //await writer.WriteLineAsync(await File.ReadAllTextAsync("Pages/index.html"));

    var normalizedRawUrl = context.Request.RawUrl?.Trim().ToLower() ?? "/";
    var rawUrlItems = normalizedRawUrl.Split("/", StringSplitOptions.RemoveEmptyEntries);

    if(rawUrlItems.Length == 0) {
        await writer.WriteLineAsync("<h1>Welcome</h1>");
        await writer.FlushAsync();

        context.Response.StatusCode = (int)HttpStatusCode.OK;
    }
    else if(rawUrlItems[0] == "users") {

        if(context.Request.HttpMethod == HttpMethod.Get.Method) {

            if(rawUrlItems.Length == 2) {
                if(int.TryParse(rawUrlItems[1], out int userId)) {
                    var json = JsonSerializer.Serialize(new {
                        id = userId,
                        name = "Bob",
                        surname = "Marley",
                        birthdate = new DateTime(1954, 2, 2),
                    });

                    await writer.WriteLineAsync(json);
                    await writer.FlushAsync();

                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                }
                else {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
            }
            else {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
        }
        else {
            context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
        }
    }
    else {
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
    }

    context.Response.Close();
*/







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
