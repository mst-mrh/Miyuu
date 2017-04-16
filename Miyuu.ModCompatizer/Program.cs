using System;
using System.IO;
using NDesk.Options;

namespace Miyuu.ModCompatizer
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("{0} v{1}{2}", typeof(Program).Namespace,
				System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3),
				Environment.NewLine);

			if (args.Length > 0)
				Console.WriteLine("args: {0}", string.Join(" ", args));

			string path = null;

			var options = new OptionSet
			{
				{"f|file=", "Mod file path", v => path = v }
			};

			options.Parse(args);

			if (string.IsNullOrWhiteSpace(path))
			{
				PatchMods();
			}
			else
			{
				new CnCompatizer(new TmodFile(path)).Run();
			}
		}

		private static void PatchMods()
		{
			var dirInfo = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Games", "Terraria", "ModLoader", "Mods"));
			if (!dirInfo.Exists)
			{
				Console.WriteLine("模组目录不存在! 请检查路径 {0} 是否正确.");
			}
			else
			{
				var files = dirInfo.GetFiles("*.tmod");
				foreach (var file in files)
				{
					new CnCompatizer(new TmodFile(file.FullName)).Run();
					Console.WriteLine();
					try
					{

					}
					catch (Exception e)
					{
#if DEBUG
						throw;
#endif
						Console.WriteLine("修改 {0} 时出错: 跳过修改{1}\t错误消息{1}\t\t{2}", file.Name, Environment.NewLine, e.Message);
					}
				}
			}
		}
	}
}
