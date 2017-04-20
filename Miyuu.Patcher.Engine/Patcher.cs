using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Miyuu.Patcher.Engine.Modifications;
using Miyuu.TextWrapper;

namespace Miyuu.Patcher.Engine
{
	public class Patcher
	{
		public string SourceAssemblyPath { get; }

		public string OutputAssemblyPath { get; }

		public bool IsTml { get; private set; }

		public bool IsTmlServer { get; private set; }

		private ModuleDefMD _module;

		private Importer _importer;

		public Patcher(string sourcePath, string outputPath)
		{
			SourceAssemblyPath = sourcePath;
			OutputAssemblyPath = outputPath;
		}

		private void LoadAssembly()
		{
			var fullpath = Path.GetFullPath(SourceAssemblyPath);
			_module = ModuleDefMD.Load(fullpath);

			_importer = new Importer(_module);

			CheckTml();
		}

		private void Write()
		{
			ChangeTmlName();

			_module.Write(OutputAssemblyPath);
		}

		public void Run()
		{
			new Converter(@"C:\Users\zitwa\Documents\texts", @"..\TerrariaTextsInChinese\Texts").Run();
			Console.Read();

			try
			{
				LoadAssembly();

				Console.WriteLine("加载完毕: {0}", _module.Assembly.FullName);
			}
			catch
			{
				Console.WriteLine("加载失败!");
			}


			Console.WriteLine();

			var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(ModificationBase)));
			var mods = new List<KeyValuePair<int, ModificationBase>>();

			foreach (var t in types)
			{
				var ins = Activator.CreateInstance(t) as ModificationBase;

				if (ins?.TargetAssemblys.Contains(_module.Assembly.FullName) == true)
				{
					ins.Importer = _importer;
					ins.SourceModuleDef = _module;

					var order = t.GetCustomAttribute<ModOrderAttribute>()?.Order ?? 0;

					mods.Add(new KeyValuePair<int, ModificationBase>(order, ins));

					Console.WriteLine("模块 {0} 准备完毕!", ins.Name);
				}
			}

			Console.WriteLine();
			Console.WriteLine("开始运行修改..");

			foreach (var m in mods.OrderBy(m => m.Key))
			{
				m.Value.Run();
			}

			try
			{
				Write();
			}
			catch (Exception ex)
			{
				Console.WriteLine("保存失败!{0}\t{1}", Environment.NewLine, ex);

			}
		}

		private void CheckTml()
		{
			if (_module.Find("Terraria.ModLoader.ModLoader", false) == null)
			{
				return;
			}

			IsTml = true;

			if (_module.Find("Terraria.Program", false).FindMethod("LaunchGame")?.Body.Instructions.Any(
						 i => i.OpCode.Equals(OpCodes.Callvirt) && i.Operand.ToString().EndsWith("Main::DedServ()")) == true)
			{
				IsTmlServer = true;
				_module.Assembly.Name = "tModLoaderServer";
				return;
			}

			_module.Assembly.Name = "tModLoader";
		}

		private void ChangeTmlName()
		{
			if (!IsTml)
				return;

			_module.Assembly.Name = "Terraria";
		}
	}
}
