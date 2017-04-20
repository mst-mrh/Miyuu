using System.Collections.Generic;
using System.IO;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Miyuu.Cns;
using Miyuu.Extensions;

namespace Miyuu.Patcher.Engine.Modifications
{
	[ModOrder(-1000)]
	internal class CnsLibModifications : ModificationBase
	{
		public const string Terraria = "Terraria, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null";
		public const string TerrariaServer = "TerrariaServer, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string Otapi = "OTAPI, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string Tml = "tModLoader, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string TmlServer = "tModLoaderServer, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";

		[ModApplyTo("*")]
		public void InsertCnLib()
		{
			var name = $"{typeof(CnsMain).Assembly.GetName().Name}.dll";

			SourceModuleDef.Resources.Add(new EmbeddedResource(name, File.ReadAllBytes(name), ManifestResourceAttributes.VisibilityMask));
		}

		[ModApplyTo(Terraria, Tml)]
		public void InsertPostInitCall()
		{
			var main = SourceModuleDef.Find("Terraria.Main", false);
			var method = main.FindMethod("Initialize");

			var inst = method.Body.Instructions;

			inst.Insert(inst.Count - 1,
				new { OpCodes.Call, Operand = Importer.Import(typeof(CnsMain), "PostInitialize") }
			);
		}

		[ModApplyTo("*")]
		public void ReplaceGetInputText()
		{
			var method = SourceModuleDef.Find("Terraria.Main", false).FindMethod("GetInputText");

			var inst = method.Body.Instructions;
			var ins = method.Body.Instructions[0];

			inst.Insert(0,
				new { OpCodes.Call, Operand = Importer.Import(typeof(CnsMain), "GetInputText") },
				new { OpCodes.Brfalse_S, Operand = ins },
				new { OpCodes.Ldarg_0 },
				new { OpCodes.Ret }
			);
		}

		public CnsLibModifications() : base("中文库支持") { }

		public override IEnumerable<string> TargetAssemblys => new[]
		{
			Terraria,
			TerrariaServer,
			Otapi,
			Tml,
			TmlServer
		};
	}
}
