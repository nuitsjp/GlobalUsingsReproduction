// Create a builder by specifying the application and main window.
using GlobalUsingsReproduction;

var builder = WpfApplication<App, MainWindow>.CreateBuilder(args);

// Build and run the application.
var app = builder.Build();
await app.RunAsync();