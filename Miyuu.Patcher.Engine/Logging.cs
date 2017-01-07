using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog.Config;
using NLog.Targets;
using NLog;

namespace Miyuu.Patcher.Engine
{
	public class Logging
	{
		private const string GeneralLayout = @"${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|" + LayoutMessage;
		private const string LayoutMessage = @"${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}";

		public static void InitLoggers()
		{
			var config = new LoggingConfiguration();

			var coloredConsoleTarget = new ColoredConsoleTarget("ColoredConsole")
			{
				DetectConsoleAvailable = false,
				Layout = GeneralLayout
			};

			config.AddTarget(coloredConsoleTarget);
			config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, coloredConsoleTarget));

			LogManager.Configuration = config;
		}
	}
}
