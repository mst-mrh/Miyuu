using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Miyuu.Cns;
using Miyuu.Extensions;
using Terraria;

namespace Miyuu.ModCompatizer
{
	public class CnCompatizer
	{
		public TmodFile Tmod { get; }

		public string PdbPath { get; }

		private ModuleDefMD _module;

		private Importer _importer;

		public string SourceAssemblyPath { get; set; }

		public CnCompatizer(TmodFile tmod)
		{
			Tmod = tmod;

			Console.WriteLine("开始读取tmod文件..");
			tmod.Read();
			SourceAssemblyPath = tmod.GetTempMainAssembly();
			PdbPath = tmod.GetTempMainPdb();

			if (string.IsNullOrWhiteSpace(SourceAssemblyPath))
			{
				throw new Exception("处理模组格式无效: 缺少dll文件");
			}
			Console.WriteLine("输出临时路径: {0}", SourceAssemblyPath);
			if (!string.IsNullOrWhiteSpace(PdbPath))
			{
				Console.WriteLine("Pdb文件路径: {0}", PdbPath);
			}
		}

		protected void LoadAssembly()
		{
			if (string.IsNullOrEmpty(SourceAssemblyPath))
			{
				throw new ArgumentNullException(nameof(SourceAssemblyPath));
			}

			_module = ModuleDefMD.Load(SourceAssemblyPath);

			_importer = new Importer(_module);

			Console.WriteLine("成功加载模组: {0}", Tmod.Name);
		}

		public void Run()
		{
			LoadAssembly();

			ReplaceDeclarations();
			ReplaceDsCall();
			Test();

			Save();
		}

		private void Test()
		{
			foreach (var t in _module.Types)
			{
				foreach (var m in t.Methods)
				{
					var inst = m.Body?.Instructions;
					if (inst == null)
						continue;
					for (var index = 0; index < inst.Count; index++)
					{
						var i = inst[index];
						if (i.OpCode.Equals(OpCodes.Ldsfld) &&
							i.Operand?.ToString().StartsWith("Microsoft.Xna.Framework.Graphics.SpriteFont") == true)
						{
							(i.Operand as MemberRef).FieldSig.Type = _importer.ImportAsTypeSig(typeof(SpriteFontCn));
						}

						// ReSharper disable once InvertIf
						if (i.OpCode.Equals(OpCodes.Call))
						{
							if (i.Operand is IMethodDefOrRef)
							{
								var method = (IMethodDefOrRef) i.Operand;
								for (var i1 = 0; i1 < method.MethodSig.Params.Count; i1++)
								{
									var type = method.MethodSig.Params[i1];
									method.MethodSig.Params[i1] = RightType(type, _importer.ImportAsTypeSig(typeof(SpriteFont)),
										_importer.ImportAsTypeSig(typeof(SpriteFontCn)));
								}
							}
						}
					}
				}
			}
		}

		private void ReplaceDeclarations()
		{
			foreach (var type in _module.Types)
			{
				ReplaceDs(type, _importer.ImportAsTypeSig(typeof(SpriteFont)), _importer.ImportAsTypeSig(typeof(SpriteFontCn)));
			}

			Console.WriteLine($"声明类型替换: {_declCount}");
		}

		private void ReplaceDsCall()
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

			foreach (var type in _module.Types)
			{
				ReplaceAllInstructions(type,
						new[]
						{
							new ReplaceItem
							{
								Old = OpCodes.Callvirt.ToInstruction(_importer.Import(typeOfSf, ms, new[] {typeOfString})),
								New = OpCodes.Call.ToInstruction(_importer.Import(typeOfSfcn, ms, new[] {typeOfString}))
							},
							new ReplaceItem
							{
								Old = OpCodes.Callvirt.ToInstruction(_importer.Import(typeOfSb, ds, new[] {typeOfSf, typeOfString, typeOfVector2, typeOfColor})),
								New = OpCodes.Call.ToInstruction(_importer.Import(typeOfSbcn, ds, new[] {typeOfSb, typeOfSfcn, typeOfString, typeOfVector2, typeOfColor}))
							},
							new ReplaceItem
							{
								Old = OpCodes.Callvirt.ToInstruction(_importer.Import(typeOfSb, ds, new[] {typeOfSf, typeOfString, typeOfVector2, typeOfColor, typeOfFloat, typeOfVector2, typeOfFloat, typeOfSe, typeOfFloat})),
								New = OpCodes.Call.ToInstruction(_importer.Import(typeOfSbcn, ds, new[] {typeOfSb, typeOfSfcn, typeOfString, typeOfVector2, typeOfColor, typeOfFloat, typeOfVector2, typeOfFloat, typeOfSe, typeOfFloat}))
							},
							new ReplaceItem
							{
								Old = OpCodes.Callvirt.ToInstruction(_importer.Import(typeOfSb, ds, new[] {typeOfSf, typeOfString, typeOfVector2, typeOfColor, typeOfFloat, typeOfVector2, typeOfVector2, typeOfSe, typeOfFloat})),
								New = OpCodes.Call.ToInstruction(_importer.Import(typeOfSbcn, ds, new[] {typeOfSb, typeOfSfcn, typeOfString, typeOfVector2, typeOfColor, typeOfFloat, typeOfVector2, typeOfVector2, typeOfSe, typeOfFloat}))
							},
							new ReplaceItem
							{
								Old = OpCodes.Callvirt.ToInstruction(_importer.Import(typeOfSf, "get_LineSpacing")),
								New = OpCodes.Callvirt.ToInstruction(_importer.Import(typeOfSfcn, "get_LineSpacing"))
							}
						},
						ref replaces);
			}

			Console.WriteLine($"替换调用方法: {replaces}");
		}

		protected void Save()
		{
			var tmpPath = Path.GetTempFileName();

			_module.Write(tmpPath);
			Tmod.SetFile(Tmod.HasFile("All.dll") ? "All.dll" : "Windows.dll", File.ReadAllBytes(tmpPath));
			Tmod.Save();

			Console.WriteLine("保存完毕: {0}", Tmod.Path);
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

			foreach (var property in type.Properties)
			{
				PropertySig s;
				if ((s = property.Type as PropertySig)?.RetType != null)
				{
					var t = s.RetType;
					s.RetType = RightType(t, t1, t2);
				}
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
				method.ReturnType = RightType(method.ReturnType, t1, t2);
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
	}
}
