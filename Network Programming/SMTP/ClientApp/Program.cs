using System.Net;
using System.Net.Mail;


var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
{
    Credentials = new NetworkCredential(
            Environment.GetEnvironmentVariable("smpt_username"),
            Environment.GetEnvironmentVariable("smpt_password")
        ),
    EnableSsl = true
};

var htmlMessage = new MailMessage("elnur@example.com", "elnur.mustafayeev@gmail.com")
{
    IsBodyHtml = true,
    Body = @"
    <h1 style=""color: gray;"">Message Header</h1>

    <p style=""text-align: center; color: brown;"">
        This is body
    </p>
"
};

client.Send(htmlMessage);

//client.Send("elnur@example.com", "bob@example.com", "Test Title", "Test Body");
