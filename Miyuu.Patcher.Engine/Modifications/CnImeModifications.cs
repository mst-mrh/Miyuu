using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Miyuu.Cns;
using Miyuu.Extensions;

namespace Miyuu.Patcher.Engine.Modifications
{
	[ModOrder(9000)]
	internal class CnImeModifications : ModificationBase
	{
		public const string Terraria = "Terraria, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string Tml = "tModLoader, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";

		[ModApplyTo("*")]
		public void InsertPostInitCall()
		{
			var main = SourceModuleDef.Find("Terraria.Main", false);
			var method = main.FindMethod("Initialize");

			var inst = method.Body.Instructions;

			inst.Insert(0,
				new { OpCodes.Ldarg_0 },
				new { OpCodes.Ldfld, Operand = (IField)main.FindField("Cns") },
				new { OpCodes.Call, Operand = Importer.Import(typeof(CnsMain), "Initialize") }
			);
		}

		[ModApplyTo("*")]
		public void InsertPostUpdateCall()
		{
			var main = SourceModuleDef.Find("Terraria.Main", false);
			var method = main.FindMethod("Update");

			var inst = method.Body.Instructions;

			inst.Insert(0,
				new { OpCodes.Call, Operand = Importer.Import(typeof(CnsMain), "Update") }
			);
		}

		[ModApplyTo("*")]
		public void ReplaceGetInputText()
		{
			var method = SourceModuleDef.Find("Terraria.Main", false).FindMethod("GetInputText");

			var inst = method.Body.Instructions;
			var ins = method.Body.Instructions[0];

			inst.Insert(0,
				new { OpCodes.Ldarga_S, Operand = method.Parameters[0] },
				new { OpCodes.Call, Operand = Importer.Import(typeof(ClaymanInputCaputure), "GcsTest") },
				new { OpCodes.Brfalse_S, Operand = ins },
				new { OpCodes.Ldarg_0 },
				new { OpCodes.Ret }
			);
		}

		private static int Line(IList<Instruction> inst, Func<Instruction, Instruction, bool> pre)
		{
			for (var index = 0; index < inst.Count - 1; index++)
			{
				var ins = inst[index];

				var next = inst[index + 1];

				if (pre(ins, next))
				{
					return index;
				}
			}

			throw new IndexOutOfRangeException("cannot find");
		}

		public CnImeModifications() : base("中文输入法支持") { }

		public override IEnumerable<string> TargetAssemblys => new[]
		{
			Terraria,
			Tml,
		};
	}
}