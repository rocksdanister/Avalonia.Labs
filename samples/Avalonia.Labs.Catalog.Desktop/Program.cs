﻿using System;
using System.IO;
using Avalonia;
using Avalonia.Labs.Controls.Cache;
using Avalonia.ReactiveUI;

namespace Avalonia.Labs.Catalog.Desktop;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .UseReactiveUI()
        .AfterSetup(builder =>
        {
            CacheOptions.SetDefault(new CacheOptions()
            {
                BaseCachePath = Path.Combine(Path.GetTempPath(), "Avalonia.Labs")
            });
#if DEBUG
            builder.Instance!.AttachDevTools(new Avalonia.Diagnostics.DevToolsOptions());
#endif
        })
            .LogToTrace();
}
