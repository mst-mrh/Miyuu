using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Miyuu.Cns;
using Miyuu.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

			//Test();
			AddCns();
			RemoveEnFontLoad();
			FuckFields();

			try
			{
				Write();
			}
			catch(Exception ex)
			{
				Console.WriteLine("保存失败!{0}\t{1}", Environment.NewLine, ex);

			}
		}

		private void Test()
		{
			var main = _module.FindThrow("Terraria.Main", true);

			Console.WriteLine(main.FindField("curRelease").Constant.Value);

			var init = main.FindMethod("Initialize");

			foreach (var i in init.Body.Instructions)
			{
				Console.WriteLine(i.OpCode);
			}
		}

		private void AddCns()
		{
			var main = _module.Find("Terraria.Main", true);
			var field = new FieldDefUser("Cns", new FieldSig(_importer.ImportAsTypeSig(typeof(CnsMain))));

			main.Fields.Add(field);

			var method = main.FindMethod(".ctor");
			var inst = method.Body.Instructions;

			inst.Insert(0, 
				new {OpCodes.Ldarg_0},
				new {OpCodes.Ldarg_0},
				new {OpCodes.Newobj, Operand = _importer.Import(typeof(CnsMain).GetConstructor(new [] {typeof(Game)}))},
				new {OpCodes.Stfld, Operand = (IField) field}
			);
		}

		private void RemoveEnFontLoad()
		{
			var main = _module.Find("Terraria.Main", true);
			var loadFont = main.FindMethod("LoadFonts");

			var inst = loadFont.Body.Instructions;

			inst.Clear();

			inst.Insert(0,
				new { OpCodes.Ldarg_0 },
				new { OpCodes.Ldfld, Operand = (IField) main.FindField("Cns") },
				new { OpCodes.Call, Operand = _importer.Import(typeof(CnsMain), "LoadFonts") },
				new { OpCodes.Ret }
			);
		}

		private void FuckFields()
		{
			var main = _module.Find("Terraria.Main", true);

			var fields = main.Fields.Where(f => f.FieldType.FullName.EndsWith("SpriteFont"));
			foreach (var fieldDef in fields)
			{
				fieldDef.FieldType = _importer.ImportAsTypeSig(typeof(int));
			}

			fields = main.Fields.Where(f => f.FieldType.Next.FullName.EndsWith("SpriteFont"));
			foreach (var fieldDef in fields)
			{
				fieldDef.FieldType = new SZArraySig(_importer.ImportAsTypeSig(typeof(int)));
			}

			var foo = main.FindField("fontCombatText");
			Console.WriteLine(foo.FieldType.Next);


		}
	}
}
