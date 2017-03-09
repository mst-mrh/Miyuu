using System.Collections.Generic;
using System.IO;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Microsoft.Xna.Framework;
using Miyuu.Cns;
using Miyuu.Extensions;

namespace Miyuu.Patcher.Engine.Modifications
{
	[ModOrder(-1000)]
	internal class CnsLibModifications : ModificationBase
	{
		public const string Terraria = "Terraria, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
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
		public void AddCnsField()
		{
			var main = SourceModuleDef.Find("Terraria.Main", true);
			var field = new FieldDefUser("Cns", new FieldSig(Importer.ImportAsTypeSig(typeof(CnsMain))));

			main.Fields.Add(field);

			var method = main.FindMethod(".ctor");
			var inst = method.Body.Instructions;

			inst.Insert(0,
				new { OpCodes.Ldarg_0 },
				new { OpCodes.Ldarg_0 },
				new { OpCodes.Newobj, Operand = Importer.Import(typeof(CnsMain).GetConstructor(new[] { typeof(Game) })) },
				new { OpCodes.Stfld, Operand = (IField)field }
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
