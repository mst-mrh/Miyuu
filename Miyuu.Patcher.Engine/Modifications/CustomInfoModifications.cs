using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet.Emit;
using Miyuu.Cns;
using Miyuu.Extensions;

namespace Miyuu.Patcher.Engine.Modifications
{
	internal class CustomInfoModifications : ModificationBase
	{
		public const string Terraria = "Terraria, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string TerrariaServer = "TerrariaServer, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string Otapi = "OTAPI, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string Tml = "Terraria, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";

		[ModApplyTo(Terraria, Tml, Otapi)]
		public void AddGroupInfoDraw()
		{
			Info("加入汉化组信息..");

			const string beginLine =
				"Microsoft.Xna.Framework.Graphics.SpriteBatch::Begin" +
			   "(Microsoft.Xna.Framework.Graphics.SpriteSortMode," +
				"Microsoft.Xna.Framework.Graphics.BlendState," +
				"Microsoft.Xna.Framework.Graphics.SamplerState," +
				"Microsoft.Xna.Framework.Graphics.DepthStencilState," +
				"Microsoft.Xna.Framework.Graphics.RasterizerState)";
			var method = SourceModuleDef.Find("Terraria.Main", false).FindMethod("DrawMenu");
			var inst = method.Body.Instructions;

			var line = inst.Line(beginLine, inst.Line(beginLine) + 1) + 1;
			var ins = inst[line];

			inst.Insert(line,
				new { OpCodes.Ldloc_3 },
				new { OpCodes.Call, Operand = Importer.Import(typeof(CnsMain), "DrawGroupInfo") }
			);

			var inserted = inst[line];
			var tmpIndex = inst.IndexOf(inst.Single(i => i.OpCode == OpCodes.Brfalse && i.Operand == ins));
			inst[tmpIndex] = OpCodes.Brfalse.ToInstruction(inserted); // 用于循环跳出

			
		}

		[ModApplyTo("*")]
		public void ModifyVersionNumber()
		{
			Info("修改版本信息..");
			var type = SourceModuleDef.Find("Terraria.Main", false);
			var versionNumberField = type.FindField("versionNumber");
			var versionNumber2Field = type.FindField("versionNumber2");
			var method = type.FindMethod(".cctor");
			var inst = method.Body.Instructions;

			for (var index = 0; index < inst.Count; index++)
			{
				var ins = inst[index];
				if (ins.OpCode == OpCodes.Ldstr &&
					inst[index + 1].OpCode == OpCodes.Stsfld &&
					(inst[index + 1].Operand == versionNumberField ||
					inst[index + 1].Operand == versionNumber2Field))
				{
					ins.Operand = "v1.3.4.4汉化版v3";
				}
			}
		}

		public CustomInfoModifications() : base("信息修改") { }

		public override IEnumerable<string> TargetAssemblys => new[]
		{
			Terraria,
			TerrariaServer,
			Otapi,
			Tml
		};
	}
}
