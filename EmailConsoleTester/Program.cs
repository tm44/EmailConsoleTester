using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

var builder = new ConfigurationBuilder();
IConfiguration c = builder.AddJsonFile("appsettings.json")
	.AddEnvironmentVariables()
	.Build();

var settings = c.GetRequiredSection("Settings").Get<Settings>();

var email = new MimeMessage();
email.From.Add(MailboxAddress.Parse(settings.From));

foreach (var recip in settings.To.Split(','))
{
	email.To.Add(MailboxAddress.Parse(recip));
}

email.Subject = "Email Test";

var file = @"c:\temp\test.html";
string htmlSource = "";
using (var stream = new StreamReader(file, System.Text.Encoding.ASCII, true))
{
	htmlSource = stream.ReadToEnd();
}

email.Body = new TextPart(TextFormat.Html) { Text = htmlSource };

// send email
using (var smtp = new SmtpClient())
{
	smtp.Connect(settings.SmtpHost, settings.Port, false);
	smtp.Authenticate(settings.Username, settings.Password);
	smtp.Send(email);
	smtp.Disconnect(true);
}

public class Settings
{
	public string SmtpHost { get; set; } = string.Empty;
	public string To { get; set; } = string.Empty;
	public string From { get; set; } = string.Empty;

	public string Username { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public int Port { get; set; } = 587;
}