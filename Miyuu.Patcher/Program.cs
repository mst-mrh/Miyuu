using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NDesk.Options;

namespace Miyuu.Patcher
{
	internal class Program
	{
		private static OptionSet _option;

		private static void Main(string[] args)
		{
			Console.WriteLine("Miyuu patcher v{0}", Assembly.GetExecutingAssembly().GetName().Version.ToString(2));
			Console.WriteLine();

			string input = string.Empty,
				output = string.Empty;

			_option = new OptionSet
			{
				{"in=|src=", str => input = str},
				{"out=", str => output = str }
			};

			_option.Parse(args);

			if (!string.IsNullOrWhiteSpace(input))
			{
				Engine.Logging.InitLoggers();

				output = !string.IsNullOrWhiteSpace(output) ? output : "Terraria_cn.exe";
				var patcher = new Engine.Patcher(input, output);
				patcher.Run();
			}
			else
			{
				_option.WriteOptionDescriptions(Console.Out);
			}

			Console.ReadKey();
		}
	}
}
