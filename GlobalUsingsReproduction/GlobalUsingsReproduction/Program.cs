using System;
using System.Threading;
using GlobalUsingsReproduction;

Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown);
Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

var app = new App();
app.Run(new MainWindow());