using Avalonia;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;
using CheckPoints.Logic;
using CheckPoints.NHibernate;
using Serilog;
using Serilog.Events;
using Splat;
using Splat.Serilog;
using System;

namespace CheckPoints.Editor
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*RxApp.DefaultExceptionHandler = new ExceptionHandler();*/
            InitializeLogging();
            Register();
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        private static void InitializeLogging()
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                /*.MinimumLevel.Override("NHibernate", LogEventLevel.Debug)*/
                .MinimumLevel.Override("NHibernate.SQL", LogEventLevel.Debug)
                .WriteTo.Async(a => a.File($"logs/{DateTime.Now.ToString("s").Replace(":", ".")}.log"))
                .CreateLogger();

            Log.Logger = logger;
            SerilogLogger.Initialize(logger);
            Locator.CurrentMutable.UseSerilogFullLogger(logger);
        }

        private static void Register()
        {
            Locator.CurrentMutable.RegisterConstant(new ProjectRepository(), typeof(IProjectRepository));
            //Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseReactiveUI();
    }
}
