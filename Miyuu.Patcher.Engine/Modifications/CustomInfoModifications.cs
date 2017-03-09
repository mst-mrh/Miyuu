using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Miyuu.Cns;
using Miyuu.Extensions;
using FieldAttributes = dnlib.DotNet.FieldAttributes;
using MethodAttributes = dnlib.DotNet.MethodAttributes;

namespace Miyuu.Patcher.Engine.Modifications
{
	internal class CustomInfoModifications : ModificationBase
	{
		public const string Terraria = "Terraria, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string TerrariaServer = "TerrariaServer, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string Otapi = "OTAPI, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string Tml = "tModLoader, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string TmlServer = "tModLoaderServer, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";

		[ModApplyTo(Terraria, Tml)]
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
					ins.Operand = "v1.3.4.4汉化版v4";
				}
			}
		}

		private MethodDefUser _cr, _ut;

		[ModApplyTo("*"), ModOrder]
		public void AddTwoAttribute()
		{
			var type = new TypeDefUser("Miyuu", "制作者Attribute", Importer.ImportAsTypeSig(typeof(Attribute)).ToTypeDefOrRef());

			type.Fields.Add(new FieldDefUser("_creators", new FieldSig(new SZArraySig(SourceModuleDef.CorLibTypes.String)), FieldAttributes.Private));

			var ctor = new MethodDefUser(".ctor",
				MethodSig.CreateInstance(SourceModuleDef.CorLibTypes.Void, new SZArraySig(SourceModuleDef.CorLibTypes.String)),
				MethodAttributes.HideBySig | MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName)
			{
				Body = new CilBody()
			};

			_cr = ctor;

			var inst = ctor.Body.Instructions;
			IMethod baseCtor = new MemberRefUser(SourceModuleDef, ".ctor", MethodSig.CreateInstance(SourceModuleDef.CorLibTypes.Void), SourceModuleDef.CorLibTypes.GetTypeRef("System", "Attribute"));

			inst.Insert(0,
				new { OpCodes.Ldarg_0 },
				new { OpCodes.Call, Operand = baseCtor },
				new { OpCodes.Ldarg_0 },
				new { OpCodes.Ldarg_1 },
				new { OpCodes.Stfld, Operand = (IField)type.FindField("_creators") },
				new { OpCodes.Ret }
			);

			type.Methods.Add(ctor);

			SourceModuleDef.Types.Add(type);

			type = new TypeDefUser("Miyuu", "好有趣啊wwwAttribute", Importer.ImportAsTypeSig(typeof(Attribute)).ToTypeDefOrRef());

			type.Fields.Add(new FieldDefUser("_utterance", new FieldSig(SourceModuleDef.CorLibTypes.String), FieldAttributes.Private));

			ctor = new MethodDefUser(".ctor",
				MethodSig.CreateInstance(SourceModuleDef.CorLibTypes.Void, SourceModuleDef.CorLibTypes.String),
				MethodAttributes.HideBySig | MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName)
			{
				Body = new CilBody()
			};

			_ut = ctor;

			inst = ctor.Body.Instructions;
			baseCtor = new MemberRefUser(SourceModuleDef, ".ctor", MethodSig.CreateInstance(SourceModuleDef.CorLibTypes.Void), SourceModuleDef.CorLibTypes.GetTypeRef("System", "Attribute"));

			inst.Insert(0,
				new { OpCodes.Ldarg_0 },
				new { OpCodes.Call, Operand = baseCtor },
				new { OpCodes.Ldarg_0 },
				new { OpCodes.Ldarg_1 },
				new { OpCodes.Stfld, Operand = (IField)type.FindField("_utterance") },
				new { OpCodes.Ret }
			);

			type.Methods.Add(ctor);

			SourceModuleDef.Types.Add(type);
		}

		[ModApplyTo("*"), ModOrder(20)]
		public void AddAttrs()
		{
			Info("加入制作者名单..");
			var n = new CustomAttribute(_cr);
			var staffs = new List<string>
			{
				"R (@avgxfj)",
				"火子 (@lio990527)",
				"mistzzt (@庄生华年)",
				"大佬 (@ll239509)",
				"S (@S_lv0)",
				"Xrodo (@Xrodo)",
				"Tian (@经典皇家理发)",
				"御坂 (@御坂妹19009)",
				"AS.T (@ffushiyun)",
				"彩色火把 (@toomuchoverit)"
			};
			staffs.Sort();

			n.ConstructorArguments.Add(
				new CAArgument(
					new SZArraySig(SourceModuleDef.CorLibTypes.String),
						staffs.Select(s => new CAArgument(SourceModuleDef.CorLibTypes.String, s)).ToArray()));
			SourceModuleDef.Assembly.CustomAttributes.Add(n);

			Info("加入恶趣味文本..");
			n = new CustomAttribute(_ut);
			n.ConstructorArguments.Add(new CAArgument(SourceModuleDef.CorLibTypes.String, "盯~~ 你反编译我们的汉化干什么呢! 你是坏人! 系内!"));
			SourceModuleDef.Assembly.CustomAttributes.Add(n);
		}

		public CustomInfoModifications() : base("信息修改") { }

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
