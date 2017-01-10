using System.Collections.Generic;
using System.IO;
using dnlib.DotNet;
using Miyuu.Cns;

namespace Miyuu.Patcher.Engine.Modifications
{
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
