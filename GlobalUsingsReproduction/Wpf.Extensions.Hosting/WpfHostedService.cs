﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Windows;
using Microsoft.Extensions.Hosting;

namespace Wpf.Extensions.Hosting;

internal class WpfHostedService<TApplication, TWindow> : IHostedService
    where TApplication : Application
    where TWindow : Window
{
    private readonly TApplication _application;
    private readonly TWindow? _window;
    private readonly IHostApplicationLifetime _hostApplicationLifetime;

    public WpfHostedService(TApplication application, TWindow? window, IHostApplicationLifetime hostApplicationLifetime)
    {
        _application = application;
        _window = window;
        _hostApplicationLifetime = hostApplicationLifetime;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _application.Run(_window);
        _hostApplicationLifetime.StopApplication();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}