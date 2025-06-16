using Microsoft.Extensions.Configuration;
using SettingConsumer.Extensions;

var configuration = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json", true, false)
#if DEBUG
	.AddJsonFile("appsettings.Development.json", true, false)
#endif
	.AddApiConfiguration("https://localhost:7013/api/settings")
	.Build();

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var settingNames = new[] { "Bool", "Int", "DateTime", "String" };

foreach (var name in settingNames)
{
	Console.WriteLine("{0} = {1}", name, configuration[name]);
}

var settingTime = DateTime.Parse(configuration["DateTime"]);
Console.WriteLine("Current time: {0}", settingTime);

Console.ReadKey();