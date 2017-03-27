using System;
using System.IO;

namespace Miyuu.ModCompatizer
{
	internal class Program
	{
		private static void Main()
		{
			PatchMods();

			Console.ReadKey();
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
