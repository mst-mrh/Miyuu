using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Miyuu.Cns;
using Miyuu.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Miyuu.Patcher.Engine.Modifications;

namespace Miyuu.Patcher.Engine
{
	public class Patcher
	{
		public string SourceAssemblyPath { get; }

		public string OutputAssemblyPath { get; }

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
		}

		private void Write()
		{
			_module.Write(OutputAssemblyPath);
		}

		public void Run()
		{
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
			var mods = new List<ModificationBase>();

			foreach (var t in types)
			{
				var ins = Activator.CreateInstance(t) as ModificationBase;

				if (ins?.TargetAssemblys.Contains(_module.Assembly.FullName) == true)
				{
					ins.Importer = _importer;
					ins.SourceModuleDef = _module;
					mods.Add(ins);

					Console.WriteLine("修改 {0} 准备完毕!", ins.Name);
				}
			}

			Console.WriteLine();
			Console.WriteLine("开始运行修改..");

			foreach (var m in mods)
			{
				m.Run();
			}

			try
			{
				Write();
			}
			catch(Exception ex)
			{
				Console.WriteLine("保存失败!{0}\t{1}", Environment.NewLine, ex);

			}
		}
	}
}
