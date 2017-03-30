using System;
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

		private readonly List<Tuple<TypeDef, MethodDef>> _vanillaMethods = new List<Tuple<TypeDef, MethodDef>>();

		[ModApplyTo(Tml), ModOrder(8)]
		public void PrepareBackup()
		{
			var vType = Importer.ImportAsTypeSig(typeof(SpriteFont));

			foreach (var type in SourceModuleDef.Types)
			{
				foreach (var method in type.Methods)
				{
					if (method.Parameters == null)
						continue;

					if (method.Parameters.Any(p => p.Type.FullName.Equals(vType.FullName, StringComparison.Ordinal)))
					{
						_vanillaMethods.Add(new Tuple<TypeDef, MethodDef>(type, Clone(method)));
					}
				}
			}

			Info("完成记录原版支持 " + _vanillaMethods.Count);

			MethodDef Clone(MethodDef origin)
			{
				var pas = origin.Parameters.Skip(origin.IsStatic ? 0 : 1).ToList();

				var sig = origin.IsStatic
					? MethodSig.CreateStatic(origin.ReturnType, pas.Select(p => p.Type).ToArray())
					: MethodSig.CreateInstance(origin.ReturnType, pas.Select(p => p.Type).ToArray());

				var ret = new MethodDefUser(origin.Name, sig, origin.ImplAttributes, origin.Attributes);

				foreach (var originParameter in pas)
				{
					ret.ParamDefs.Add(new ParamDefUser(originParameter.Name));
				}

				foreach (var ca in origin.CustomAttributes)
					ret.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)Importer.Import(ca.Constructor)));

				if (origin.HasBody)
				{
					ret.Body = new CilBody(origin.Body.InitLocals, new List<Instruction>(), new List<ExceptionHandler>(), new List<Local>())
					{
						MaxStack = origin.Body.MaxStack
					};

					var bodyMap = new Dictionary<object, object>();

					foreach (var local in origin.Body.Variables)
					{
						var newLocal = new Local(Importer.Import(local.Type));
						ret.Body.Variables.Add(newLocal);
						newLocal.Name = local.Name;
						newLocal.PdbAttributes = local.PdbAttributes;

						bodyMap[local] = newLocal;
					}

					foreach (var instr in origin.Body.Instructions)
					{
						var newInstr = new Instruction(instr.OpCode, instr.Operand);
						newInstr.SequencePoint = instr.SequencePoint;

						if (newInstr.Operand is IType)
							newInstr.Operand = Importer.Import((IType)newInstr.Operand);

						else if (newInstr.Operand is IMethod)
							newInstr.Operand = Importer.Import((IMethod)newInstr.Operand);

						else if (newInstr.Operand is IField)
							newInstr.Operand = Importer.Import((IField)newInstr.Operand);

						ret.Body.Instructions.Add(newInstr);
						bodyMap[instr] = newInstr;
					}

					foreach (var instr in ret.Body.Instructions)
					{
						if (instr.Operand != null && bodyMap.ContainsKey(instr.Operand))
							instr.Operand = bodyMap[instr.Operand];

						else if (instr.Operand is Instruction[])
							instr.Operand = ((Instruction[])instr.Operand).Select(target => (Instruction)bodyMap[target]).ToArray();
					}

					foreach (var eh in origin.Body.ExceptionHandlers)
						ret.Body.ExceptionHandlers.Add(new ExceptionHandler(eh.HandlerType)
						{
							CatchType = eh.CatchType == null ? null : (ITypeDefOrRef)Importer.Import(eh.CatchType),
							TryStart = (Instruction)bodyMap[eh.TryStart],
							TryEnd = (Instruction)bodyMap[eh.TryEnd],
							HandlerStart = (Instruction)bodyMap[eh.HandlerStart],
							HandlerEnd = (Instruction)bodyMap[eh.HandlerEnd],
							FilterStart = eh.FilterStart == null ? null : (Instruction)bodyMap[eh.FilterStart]
						});

					ret.Body.SimplifyMacros(ret.Parameters);
				}

				return ret;
			}
		}

		[ModApplyTo(Tml), ModOrder(9)]
		public void AddCnFontField()
		{
			var fontType = Importer.ImportAsTypeSig(typeof(SpriteFontCn));
			var fields = SourceModuleDef.Find("Terraria.Main", true).Fields;
			var fieldSig = new FieldSig(fontType);

			var field = new FieldDefUser("XfontMouseText", fieldSig, FieldAttributes.Public | FieldAttributes.Static);
			fields.Add(field);

			field = new FieldDefUser("XfontItemStack", fieldSig, FieldAttributes.Public | FieldAttributes.Static);
			fields.Add(field);

			field = new FieldDefUser("XfontDeathText", fieldSig, FieldAttributes.Public | FieldAttributes.Static);
			fields.Add(field);

			field = new FieldDefUser("XfontCombatText", new FieldSig(new SZArraySig(fontType)), FieldAttributes.Public | FieldAttributes.Static);
			fields.Add(field);
		}

		[ModApplyTo(Terraria), ModOrder(10)]
		public void ClearFontLoad()
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

		[ModApplyTo(Tml), ModOrder(10)]
		public void AddCnFontLoad()
		{
			var main = SourceModuleDef.Find("Terraria.Main", true);
			var loadFont = main.FindMethod("LoadFonts");

			var inst = loadFont.Body.Instructions;

			inst.Insert(inst.Count - 1,
				new { OpCodes.Ldarg_0 },
				new { OpCodes.Ldfld, Operand = (IField)main.FindField("Cns") },
				new { OpCodes.Call, Operand = Importer.Import(typeof(CnsMain), "LoadFonts") }
			);
		}

		[ModApplyTo(Terraria), ModOrder(11)]
		public void ReplaceDeclarationsNormal()
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

		[ModApplyTo(Tml), ModOrder(11)]
		public void ReplaceDeclarationsTml()
		{
			Info("替换字体声明类型..");

			foreach (var type in SourceModuleDef.Types)
			{
				ReplaceDs(type, Importer.ImportAsTypeSig(typeof(SpriteFont)), Importer.ImportAsTypeSig(typeof(SpriteFontCn)));
			}

			Info($"声明类型替换: {_declCount}");

			Info("恢复字体...");

			var fonts = new[]
			{
				"fontCombatText",
				"fontDeathText",
				"fontItemStack",
				"fontMouseText"
			};
			var main = SourceModuleDef.Find("Terraria.Main", true);
			var vType = Importer.ImportAsTypeSig(typeof(SpriteFont));

			foreach (var name in fonts)
			{
				main.FindField(name).FieldType = vType;
			}
		}

		[ModApplyTo(Tml), ModOrder(11)]
		public void ReplaceCnFontName()
		{
			var replaces = 0;
			var main = SourceModuleDef.Find("Terraria.Main", true);
			var loadfont = main.FindMethod("LoadFonts");

			main.Methods.Remove(loadfont); // 避免数组名被更改

			foreach (var type in SourceModuleDef.Types)
			{
				ReplaceAllInstructionsX(type,
						new[]
						{
							new ReplaceItem
							{
								Old = OpCodes.Ldsfld.ToInstruction(main.FindField("fontMouseText")),
								New = OpCodes.Ldsfld.ToInstruction(main.FindField("XfontMouseText"))
							},
							new ReplaceItem
							{
								Old = OpCodes.Ldsfld.ToInstruction(main.FindField("fontItemStack")),
								New = OpCodes.Ldsfld.ToInstruction(main.FindField("XfontItemStack"))
							},
							new ReplaceItem
							{
								Old = OpCodes.Ldsfld.ToInstruction(main.FindField("fontDeathText")),
								New = OpCodes.Ldsfld.ToInstruction(main.FindField("XfontDeathText"))
							},
							new ReplaceItem
							{
								Old = OpCodes.Ldsfld.ToInstruction(main.FindField("fontCombatText")),
								New = OpCodes.Ldsfld.ToInstruction(main.FindField("XfontCombatText"))
							}
						},
						ref replaces);
			}

			main.Methods.Add(loadfont);

			Info($"替换调用方法: {replaces}");
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

		[ModApplyTo(Tml), ModOrder(13)]
		public void ApplyBackup()
		{
			foreach (var vanillaMethod in _vanillaMethods)
			{
				vanillaMethod.Item1.Methods.Add(vanillaMethod.Item2);
			}
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
			if (origin == null) return null;
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

		private static void ReplaceAllInstructionsX(TypeDef type, ReplaceItem[] replaces, ref int count)
		{
			foreach (var nested in type.NestedTypes)
			{
				ReplaceAllInstructionsX(nested, replaces, ref count);
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

						inst[index].Operand = item.New.Operand;
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
			Tml
		};
	}
}
