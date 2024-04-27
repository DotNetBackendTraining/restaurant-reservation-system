using Microsoft.Extensions.Configuration;

var configurationRoot = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var connectionString = configurationRoot.GetConnectionString("SQLServerConnection");

Console.WriteLine(connectionString);