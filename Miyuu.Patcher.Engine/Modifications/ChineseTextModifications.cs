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

namespace Miyuu.Patcher.Engine.Modifications
{
	[ModOrder(5000)]
	internal class ChineseTextModifications : ModificationBase
	{
		public const string Terraria = "Terraria, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string TerrariaServer = "TerrariaServer, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string Otapi = "OTAPI, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string Tml = "Terraria, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";

		[ModApplyTo("*"), ModOrder(50)]
		public void AddCnJson()
		{
			Info("替换外置语言包判定..");
			var inst = SourceModuleDef.Find("Terraria.Lang", false).FindMethod("setLang").Body.Instructions;
			var line = inst.Line("German\"");
			inst[line].Operand = "Chinese";

			Info("加入外置语言包..");
			SourceModuleDef.Resources.Add(new EmbeddedResource("Terraria.Localization.Content.Chinese.json", File.ReadAllBytes(@"C:\Users\zitwa\Source\News\TerrariaTextsInChinese\Texts\Terraria.Localization.Content.Chinese.json"), ManifestResourceAttributes.Public));
			SourceModuleDef.Resources.Add(new EmbeddedResource("Terraria.Localization.Content.Chinese.Town.json", File.ReadAllBytes(@"C:\Users\zitwa\Source\News\TerrariaTextsInChinese\Texts\Terraria.Localization.Content.Chinese.Town.json"), ManifestResourceAttributes.Public));
		}

		[ModApplyTo(Terraria, Tml), ModOrder]
		public void ReplaceForUi()
		{
			Info("替换菜单项目..");
			var inst = SourceModuleDef.Find("Terraria.Main", false).FindMethod("DrawMenu").Body.Instructions;
			var line = inst.Line("Wählen Sie die Sprache\"");

			inst[line].Operand = "选择语言";
			line = inst.Line("Deutsch\"");
			inst[line].Operand = "简体中文";

			line = inst.Line("Wählen Sie die Sprache\"");
			inst[line].Operand = "选择语言";
			line = inst.Line("Deutsch\"");
			inst[line].Operand = "简体中文";

			Info("去除英文连字符..");
			var method = SourceModuleDef.Find("Terraria.Utils", false).FindMethod("WordwrapString");
			inst = method.Body.Instructions;

			for (var index = 0; index < inst.Count; index++)
			{
				var current = inst[index];
				if (current.OpCode == OpCodes.Box && inst[index - 1].OpCode == OpCodes.Ldc_I4_S)
				{
					inst[index - 1] = OpCodes.Ldc_I4_S.ToInstruction((sbyte)' ');
				}
			}

			Info("替换输入设定文字...");
			method = SourceModuleDef.Find("Terraria.GameInput.PlayerInput", false).FindMethod("Initialize");
			inst = method.Body.Instructions;

			for (var index = 0; index < inst.Count; index++)
			{
				var current = inst[index];
				if (current?.OpCode == OpCodes.Ldstr
					&& !string.IsNullOrWhiteSpace(current?.Operand.ToString())
					&& current.Operand.ToString() == "Custom")
				{
					current.Operand = "自定义";
				}
			}

			method = SourceModuleDef.Find("Terraria.GameInput.PlayerInput", false).FindMethod("ManageVersion_1_3");
			inst = method.Body.Instructions;

			for (var index = 0; index < inst.Count; index++)
			{
				var current = inst[index];
				if (current?.OpCode == OpCodes.Ldstr
					&& !string.IsNullOrWhiteSpace(current?.Operand.ToString())
					&& current.Operand.ToString() == "Custom")
				{
					current.Operand = "自定义";
				}
			}
		}

		[ModApplyTo("*")]
		public void ReplaceUtils()
		{
			Info("替换不规则Npc召唤文本..");
			var method = SourceModuleDef.Find("Terraria.NPC", true).FindMethod("NewNPC");
			var inst = method.Body.Instructions;

			var nameFieldOfEntity = SourceModuleDef.Find("Terraria.Entity", true).FindField("name");
			var displayNameFieldOfNpc = SourceModuleDef.Find("Terraria.NPC", true).FindField("displayName");

			for (var index = 0; index < inst.Count; index++)
			{
				var ins = inst[index];
				if (ins.OpCode == OpCodes.Ldfld && ins.Operand == nameFieldOfEntity)
				{
					inst[index] = OpCodes.Ldfld.ToInstruction(displayNameFieldOfNpc);
				}
			}

			method = SourceModuleDef.Find("Terraria.NPC", true).FindMethod("SpawnOnPlayer");
			inst = method.Body.Instructions;

			for (var index = 0; index < inst.Count; index++)
			{
				var ins = inst[index];
				if (ins.OpCode == OpCodes.Ldfld && ins.Operand == nameFieldOfEntity)
				{
					inst[index] = OpCodes.Ldfld.ToInstruction(displayNameFieldOfNpc);
				}
			}

			Info("修改守卫者熔炉名特殊调用..");
			method = SourceModuleDef.Find("Terraria.UI.ChestUI", false).FindMethod("DrawName");
			inst = method.Body.Instructions;

			var target = inst.Single(i => i.OpCode.Equals(OpCodes.Ldsfld) && i.Operand.ToString().EndsWith("::itemName"));
			var line = inst.IndexOf(target);

			inst[line] = OpCodes.Ldsfld.ToInstruction(Importer.Import(typeof(ChineseTexts).GetField("CnItemName")));
		}

		[ModApplyTo("*")]
		public void ReplaceSetLang()
		{
			Info("setLang(bool)..");
			var method = SourceModuleDef.Find("Terraria.Lang", false).FindMethod("setLang");
			var inst = method.Body.Instructions;
			var start =
					inst.Line("Lang::lang",
					inst.Line("Lang::lang",
					inst.Line("Lang::lang") + 1) + 1) + 3; // 中文第一个misc
			var end = inst.Line("Lang::lang", start + 1) - 1; // 跳转语句前一个

			for (var index = start; index < end; index++) // 要删除的部分
			{
				inst.RemoveAt(start);
			}

			inst.Insert(start, OpCodes.Call.ToInstruction(Importer.Import(typeof(ChineseTexts), "SetLang")));
		}

		[ModApplyTo("*")]
		public void ReplaceDdbp()
		{
			Info("dialog");

			var method = SourceModuleDef.Find("Terraria.Lang", false).FindMethod("dialog");
			var inst = method.Body.Instructions;
			var secondLang = inst.Line("::lang", inst.Line("::lang") + 1);
			var thirdLang = inst.Line("::lang", secondLang + 1);
			var start = secondLang + 3;

			for (var index = start; index < thirdLang; index++)
			{
				inst.RemoveAt(start);
			}

			inst.Insert(start,
				new { OpCodes.Ldarg_0 },
				new { OpCodes.Call, Operand = Importer.Import(typeof(ChineseTexts), "Dialog") },
				new { OpCodes.Ret }
			);
			
			Info("DyeTrader!!");
			method = SourceModuleDef.Find("Terraria.Lang", false).FindMethod("DyeTraderQuestChat");
			InsertIfStatement(method, "DyeTraderQuestChat", 0, true, typeof(bool));
			
			Info("Birthday!!");
			method = SourceModuleDef.Find("Terraria.Lang", false).FindMethod("GetBirthdayDialog");
			InsertIfStatement(method, "GetBirthdayDialog", 3, false, typeof(int));

			Info("ProjName!!");
			method = SourceModuleDef.Find("Terraria.Lang", false).FindMethod("GetProjectileNameByType");
			InsertIfStatement(method, "GetProjectileNameByType", 0, true, typeof(int));
		}

		[ModApplyTo("*")]
		public void ReplaceId()
		{
			Info("批量替换ID项目..");

			var method = SourceModuleDef.Find("Terraria.Lang", false).FindMethod("itemName");
			var inst = method.Body.Instructions;
			var index = RemoveIls(inst);

			inst.Insert(index, OpCodes.Call.ToInstruction(Importer.Import(typeof(ChineseTexts), "ItemName")));
			inst.Insert(index, OpCodes.Ldarg_0.ToInstruction());

			method = SourceModuleDef.Find("Terraria.Lang", false).FindMethod("npcName");
			inst = method.Body.Instructions;
			index = RemoveIls(inst);

			inst.Insert(index, OpCodes.Call.ToInstruction(Importer.Import(typeof(ChineseTexts), "NpcName")));
			inst.Insert(index, OpCodes.Ldarg_0.ToInstruction());

			method = SourceModuleDef.Find("Terraria.Lang", false).FindMethod("toolTip");
			inst = method.Body.Instructions;
			index = RemoveIls(inst);

			inst.Insert(index, OpCodes.Call.ToInstruction(Importer.Import(typeof(ChineseTexts), "ToolTip")));
			inst.Insert(index, OpCodes.Ldarg_0.ToInstruction());

			method = SourceModuleDef.Find("Terraria.Lang", false).FindMethod("toolTip2");
			inst = method.Body.Instructions;
			index = RemoveIls(inst);

			inst.Insert(index, OpCodes.Call.ToInstruction(Importer.Import(typeof(ChineseTexts), "ToolTip2")));
			inst.Insert(index, OpCodes.Ldarg_0.ToInstruction());

			method = SourceModuleDef.Find("Terraria.Lang", false).FindMethod("title");
			inst = method.Body.Instructions;
			index = RemoveIls(inst);

			inst.Insert(index, OpCodes.Call.ToInstruction(Importer.Import(typeof(ChineseTexts), "Title")));

			method = SourceModuleDef.Find("Terraria.Lang", false).FindMethod("setBonus");
			inst = method.Body.Instructions;
			index = RemoveIls(inst);

			inst.Insert(index, OpCodes.Call.ToInstruction(Importer.Import(typeof(ChineseTexts), "SetBonus")));
			inst.Insert(index, OpCodes.Ldarg_0.ToInstruction());
		}

		[ModApplyTo("*")]
		public void ReplaceDeathMsg()
		{
			Info("deathMsg..");

			var method = SourceModuleDef.Find("Terraria.Lang", false).FindMethod("deathMsg");
			var inst = method.Body.Instructions;
			var index = RemoveIls(method.Body.Instructions);

			inst.Insert(index,
				new { OpCodes.Ldarg_0 },
				new { OpCodes.Ldarg_1 },
				new { OpCodes.Ldarg_2 },
				new { OpCodes.Ldarg_3 },
				new { OpCodes.Ldarg_S, Operand = method.Parameters[4] },
				new { OpCodes.Ldarg_S, Operand = method.Parameters[5] },
				new { OpCodes.Call, Operand = Importer.Import(typeof(ChineseTexts), "DeathMsg") }
			);
		}

		private void InsertIfStatement(MethodDef method, string name, int elseIndex, bool isArg, params Type[] t)
		{
			var inst = method.Body.Instructions;
			var target = inst[elseIndex];

			var tmp = isArg ? OpCodes.Ldarg_0 : OpCodes.Ldloc_0;

			inst.Insert(elseIndex,
				new { OpCodes.Ldsfld, Operand = (IField) SourceModuleDef.Find("Terraria.Lang", false).FindField("lang") },
				new { OpCodes.Ldc_I4_2 },
				new { OpCodes.Bne_Un_S, Operand = target },
				new { tmp },
				new { OpCodes.Call, Operand = Importer.Import(typeof(ChineseTexts), name, t) },
				new { OpCodes.Ret }
			);
		}

		private static int RemoveIls(IList<Instruction> inst)
		{
			var start = inst.Line("::lang", inst.Line("::lang") + 1);
			var stop = inst.Line("::lang", start + 1);

			var s = start + 3;
			var e = stop - 1;

			for (var index = s; index < e; index++)
			{
				inst.RemoveAt(s);
			}

			return s;
		}

		public ChineseTextModifications() : base("导入中文文本") { }

		public override IEnumerable<string> TargetAssemblys => new[]
		{
			Terraria,
			TerrariaServer,
			Otapi,
			Tml
		};
	}
}
