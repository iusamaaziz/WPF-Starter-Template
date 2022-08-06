using Microsoft.Extensions.Logging;

using Serilog;

using System;
using System.IO;
using System.Windows;

using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace WPF
{
	public class Logger : ILogger
	{
		private static ILogger _this;
		private static ILogger GetLogger() => _this ??= new Logger();
		public static void Log(string message, LogLevel logLevel)
		{
			_this = GetLogger();
			_this.Log(logLevel, message);
		}

		private readonly ILogger<BaseViewModel> _logger;
		private Logger()
		{
			Microsoft.Extensions.Logging.ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
			{
				LoggerConfiguration loggerConfiguration = new LoggerConfiguration()
					.WriteTo.File(Path.Combine("log.cs"), rollingInterval: RollingInterval.Day);

				builder.AddSerilog(loggerConfiguration.CreateLogger());
			});

			_logger = loggerFactory.CreateLogger<BaseViewModel>();
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			throw new NotImplementedException();
		}

		public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel)
		{
			throw new NotImplementedException();
		}

		public void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, Microsoft.Extensions.Logging.EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			_logger.Log(logLevel, eventId, state, exception, formatter);
		}
	}
}
