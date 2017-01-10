using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Miyuu.Cns;
using Miyuu.Extensions;

namespace Miyuu.Patcher.Engine.Modifications
{
	internal class ClientChineseDisplayModifications : ModificationBase
	{
		public const string Terraria = "Terraria, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string Tml = "tModLoader, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string Otapi = "OTAPI, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";

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

		[ModApplyTo(Terraria, Tml), ModOrder(10)]
		public void ReplaceFontLoad()
		{
			var main = SourceModuleDef.Find("Terraria.Main", true);
			var loadFont = main.FindMethod("LoadFonts");

			var inst = loadFont.Body.Instructions;

			inst.Clear();

			inst.Insert(0,
				new { OpCodes.Ldarg_0 },
				new { OpCodes.Ldfld, Operand = (IField)main.FindField("Cns") },
				new { OpCodes.Call, Operand = Importer.Import(typeof(CnsMain), "LoadFonts") },
				new { OpCodes.Ret }
			);
		}

		[ModApplyTo(Terraria, Tml), ModOrder(11)]
		public void ReplaceDeclarations()
		{
			var main = SourceModuleDef.Find("Terraria.Main", true);

			var inst = main.FindMethod(".cctor").Body.Instructions;

			Info("替换字体声明类型..");
			var line = inst.IndexOf(inst.Single(i => i.Operand?.ToString().EndsWith("fontCombatText") == true)) - 1;
			inst[line] = OpCodes.Newarr.ToInstruction(Importer.ImportAsTypeSig(typeof(SpriteFontCn)).ScopeType);

			foreach (var type in SourceModuleDef.Types)
			{
				ReplaceDs(type, Importer.ImportAsTypeSig(typeof(SpriteFont)), Importer.ImportAsTypeSig(typeof(SpriteFontCn)));
			}

			Info($"声明类型替换: {_declCount}");
		}

		[ModApplyTo("*"), ModOrder(12)]
		public void ReplaceDsCall()
		{
			const string ds = "DrawString";
			const string ms = "MeasureString";

			var typeOfString = typeof(string);
			var typeOfFloat = typeof(float);
			var typeOfVector2 = typeof(Vector2);
			var typeOfColor = typeof(Color);
			var typeOfSb = typeof(SpriteBatch);
			var typeOfSf = typeof(SpriteFont);
			var typeOfSe = typeof(SpriteEffects);

			var typeOfSfcn = typeof(SpriteFontCn);
			var typeOfSbcn = typeof(SpriteBatchCn);

			var replaces = 0;

			foreach (var type in SourceModuleDef.Types)
			{
				ReplaceAllInstructions(type,
						new[]
						{
							new ReplaceItem
							{
								Old = OpCodes.Callvirt.ToInstruction(Importer.Import(typeOfSf, ms, new[] {typeOfString})),
								New = OpCodes.Call.ToInstruction(Importer.Import(typeOfSfcn, ms, new[] {typeOfString}))
							},
							new ReplaceItem
							{
								Old = OpCodes.Callvirt.ToInstruction(Importer.Import(typeOfSb, ds, new[] {typeOfSf, typeOfString, typeOfVector2, typeOfColor})),
								New = OpCodes.Call.ToInstruction(Importer.Import(typeOfSbcn, ds, new[] {typeOfSb, typeOfSfcn, typeOfString, typeOfVector2, typeOfColor}))
							},
							new ReplaceItem
							{
								Old = OpCodes.Callvirt.ToInstruction(Importer.Import(typeOfSb, ds, new[] {typeOfSf, typeOfString, typeOfVector2, typeOfColor, typeOfFloat, typeOfVector2, typeOfFloat, typeOfSe, typeOfFloat})),
								New = OpCodes.Call.ToInstruction(Importer.Import(typeOfSbcn, ds, new[] {typeOfSb, typeOfSfcn, typeOfString, typeOfVector2, typeOfColor, typeOfFloat, typeOfVector2, typeOfFloat, typeOfSe, typeOfFloat}))
							},
							new ReplaceItem
							{
								Old = OpCodes.Callvirt.ToInstruction(Importer.Import(typeOfSb, ds, new[] {typeOfSf, typeOfString, typeOfVector2, typeOfColor, typeOfFloat, typeOfVector2, typeOfVector2, typeOfSe, typeOfFloat})),
								New = OpCodes.Call.ToInstruction(Importer.Import(typeOfSbcn, ds, new[] {typeOfSb, typeOfSfcn, typeOfString, typeOfVector2, typeOfColor, typeOfFloat, typeOfVector2, typeOfVector2, typeOfSe, typeOfFloat}))
							}
						},
						ref replaces);
			}

			Info($"替换调用方法: {replaces}");

			replaces = 0;

			ReplaceAllInstructions(SourceModuleDef.Find("Terraria.UI.Chat.ChatManager", true),
				new[]
				{
					new ReplaceItem
					{
						Old = OpCodes.Callvirt.ToInstruction(Importer.Import(typeOfSf, "get_LineSpacing")),
						New = OpCodes.Callvirt.ToInstruction(Importer.Import(typeOfSfcn, "get_LineSpacing"))
					}
				},
				ref replaces);

			Info($"替换字体属性访问: {replaces}");
		}

		#region replaces

		private static void ReplaceDs(TypeDef type, TypeSig t1, TypeSig t2)
		{
			foreach (var nested in type.NestedTypes)
			{
				ReplaceDs(nested, t1, t2);
			}

			foreach (var field in type.Fields)
			{
				field.FieldType = RightType(field.FieldType, t1, t2);
			}

			foreach (var method in type.Methods)
			{
				if (method.Parameters?.Count > 0)
				{
					foreach (var p in method.Parameters)
					{
						p.Type = RightType(p.Type, t1, t2);
					}
				}
				// ReSharper disable once InvertIf
				if (method.Body?.HasVariables == true && method.Body.Variables != null)
				{
					foreach (var d in method.Body.Variables)
					{
						d.Type = RightType(d.Type, t1, t2);
					}
				}
			}
		}

		private static int _declCount;

		private static TypeSig RightType(TypeSig origin, TypeSig old, TypeSig @new)
		{
			if (!origin.IsSZArray && origin.FullName != old.FullName)
			{
				return origin;
			}
			if (origin.IsSZArray && origin.Next.FullName != old.FullName)
			{
				return origin;
			}

			_declCount++;
			return origin.IsSZArray ? new SZArraySig(@new) : @new;
		}

		private static void ReplaceAllInstructions(TypeDef type, ReplaceItem[] replaces, ref int count)
		{
			foreach (var nested in type.NestedTypes)
			{
				ReplaceAllInstructions(nested, replaces, ref count);
			}

			foreach (var method in type.Methods)
			{
				if (method.Body == null)
					continue;

				var inst = method.Body.Instructions;

				for (var index = 0; index < inst.Count; index++)
				{
					var ins = inst[index];

					foreach (var item in replaces)
					{
						if (!ins.OpCode.Equals(item.Old.OpCode) || ins.Operand.ToString() != item.Old.Operand.ToString())
							continue;

						inst[index] = item.New.Clone();
						count++;
					}
				}
			}
		}

		private struct ReplaceItem
		{
			public Instruction Old;

			public Instruction New;
		}

		#endregion

		public ClientChineseDisplayModifications() : base("中文显示支持") { }

		public override IEnumerable<string> TargetAssemblys => new[]
		{
			Terraria,
			Otapi,
			Tml
		};
	}
}
