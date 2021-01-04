using Avalonia;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;
using Serilog;
using Serilog.Events;
using System;

namespace CheckPoints.Editor
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args)
        {
            InitializeLogging();
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseReactiveUI();

        private static void InitializeLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                /*.MinimumLevel.Override("NHibernate", LogEventLevel.Debug)*/
                .MinimumLevel.Override("NHibernate.SQL", LogEventLevel.Debug)
                .WriteTo.Async(a => a.File($"logs/{DateTime.Now.ToString("s").Replace(":", ".")}.log"))
                .CreateLogger();

            SerilogLogger.Initialize(Log.Logger);
        }
    }
}
