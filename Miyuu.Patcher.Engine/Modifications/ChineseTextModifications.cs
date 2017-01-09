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
using Miyuu.TextWrapper;

namespace Miyuu.Patcher.Engine.Modifications
{
	[ModOrder(5000)]
	internal class ChineseTextModifications : ModificationBase
	{
		public const string Terraria = "Terraria, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string TerrariaServer = "TerrariaServer, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string Otapi = "OTAPI, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string Tml = "tModLoader, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";
		public const string TmlServer = "tModLoaderServer, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null";

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

		[ModApplyTo("*")]
		public void RewriteEvilGood()
		{
			Info("evilGood");
			var method = SourceModuleDef.Find("Terraria.Lang", false).FindMethod("evilGood");
			var inst = method.Body.Instructions;

			var secondLang = inst.Line("::lang", inst.Line("::lang") + 1);

			var count = inst.Count;
			for (var index = secondLang; index < count; index++)
			{
				inst.RemoveAt(secondLang);
			}

			var first = inst.Line("::tGood");
			for (var index = 0; index < first; index++)
			{
				inst.RemoveAt(0);
			}

			var newinst = method.Body.Instructions.Where(i => i.OpCode == OpCodes.Ldstr && !string.IsNullOrWhiteSpace(i.Operand?.ToString())).ToList();
			var cnText = new Reader(@"..\TerrariaTextsInChinese\Texts\evilGood.json").GetTextItems();

			for (var i = 0; i < newinst.Count; i++)
			{
				newinst[i].Operand = cnText.Single(t => t.Id == i).Content;
			}
		}

		[ModApplyTo("*")]
		public void ReplaceAngler()
		{
			Info("Angler..");
			var method = SourceModuleDef.Find("Terraria.Lang", false).FindMethod("AnglerQuestChat");
			var inst = method.Body.Instructions.Where(i => i.OpCode == OpCodes.Ldstr && !string.IsNullOrWhiteSpace(i.Operand?.ToString())).ToList();
			var cnText = new Reader(@"..\TerrariaTextsInChinese\Texts\AnglerQuestChat.json").GetTextItems();

			for (var i = 0; i < inst.Count; i++)
			{
				inst[i].Operand = cnText.Single(t => t.Id == i).Content;
			}
		}

		[ModApplyTo(Tml)]
		public void TmodLoaderUi()
		{
			Info("正在替换TML界面信息..");

			var items = new Dictionary<string, string>
			{
				["Mods"] = "模组列表",
				["Mod Sources"] = "模组源码",
				["Mod Browser (Beta)"] = "模组浏览器 (测试版)",
				["Download Mods From Servers: On"] = "从服务器下载模组: 开启",
				["Download Mods From Servers: Off"] = "从服务器下载模组: 关闭",
				["Only Download Signed Mods From Servers: On"] = "只从服务器上下载经签名的模组: 开启",
				["Only Download Signed Mods From Servers: Off"] = "只从服务器上下载经签名的模组: 关闭",
				["Experimental Features: On"] = "实验特性: 开启",
				["Experimental Features: Off"] = "实验特性: 关闭",
				["Terraria Server "] = "Terraria 服务器 ",
				["enabled"] = "开启",
				["disabled"] = "关闭",
				["e\t\tEnable All"] = "e\t\t启用所有",
				["d\t\tDisable All"] = "d\t\t禁用所有",
				["r\t\tReload and return to world menu"] = "r\t\t重新加载后返回世界菜单",
				["Type a number to switch between enabled/disabled"] = "输入数字以切换启用或禁用",
				["Type a command: "] = "输入指令: ",
			};
			InvokeReplace("Interface", items);

			items = new Dictionary<string, string>
			{
				["Cancel"] = "取消",
				["Downloading: "] = "下载中: "
			};
			InvokeReplace("UIDownloadMod", items);

			items = new Dictionary<string, string>
			{
				["Please Enter Your Passcode"] = "请输入你的密码",
				["Submit"] = "提交",
				["Visit Website to Generate Passphrase"] = "访问网站以生成密码",
				["Paste Passphrase (ctrl-v)"] = "粘贴密码 (CTRL+V)"
			};
			InvokeReplace("UIEnterPassphraseMenu", items);

			items = new Dictionary<string, string>
			{
				["Continue"] = "继续",
				["Open Logs"] = "打开日志"
			};
			InvokeReplace("UIErrorMessage", items);

			items = new Dictionary<string, string>
			{
				["OK"] = "好"
			};
			InvokeReplace("UIInfoMessage", items);

			items = new Dictionary<string, string>
			{
				["Finding Mods..."] = "寻找模组中..",
				["Compatibilizing: "] = "兼容处理中: ",
				["Reading: "] = "读取中: ",
				["Setting up..."] = "设置中: ",
				["Loading Mod: "] = "加载中: ",
				["Adding Recipes..."] = "增加配方: ",
				["Initializing: "] = "初始化: "
			};
			InvokeReplace("UILoadMods", items);

			items = new Dictionary<string, string>
			{
				["My Published Mods"] = "我的已发布模组",
				["Back"] = "返回",
				["Mod Browser OFFLINE (Busy)"] = "模组浏览器离线. (忙)",
				["Mod Browser OFFLINE."] = "模组浏览器离线."
			};
			InvokeReplace("UIManagePublished", items);

			items = new Dictionary<string, string>
			{
				["Mod Browser"] = "模组浏览器",
				["Reload List"] = "重新加载列表",
				["Back"] = "返回",
				["Type to search"] = "键入以搜索",
				["You have updated a mod. Remember to reload mods for it to take effect."] = "你已经更新了模组. \n记得运行中文兼容处理程序后重新加载来使其生效.",
				["Your recently downloaded mods are currently disabled. Remember to enable and reload if you intend to use them."] = "你最近下载的模组现在被禁用了. \n记得运行中文兼容处理程序后启用并重新加载该模组.",
				["Mod Browser OFFLINE (Busy)"] = "模组浏览器离线. (忙)",
				["Mod Browser OFFLINE (404)"] = "模组浏览器离线. (404)",
				["Mod Browser OFFLINE.."] = "模组浏览器离线..",
				["Mod Browser OFFLINE (Unknown)"] = "模组浏览器离线. (未知)",
				["Mod Browser OFFLINE."] = "模组浏览器离线."
			};
			InvokeReplace("UIModBrowser", items);

			items = new Dictionary<string, string>
			{
				["More info"] = "更多信息",
				[" - by "] = " - 制作者: ",
				["Update"] = "更新",
				["Download"] = "下载",
				["Updated: "] = "更新: ",
				["The Mod Browser server is under heavy load. Try again later."] = "模组浏览器正忙, 请稍后再试.",
				["Unknown Mod Browser Error. Try again later."] = "未知模组浏览器错误, 请稍后再试.",
			};
			InvokeReplace("UIModDownloadItem", items);

			items = new Dictionary<string, string>
			{
				["This is a test of mod info here."] = "这里是一条测试消息.",
				["Mod Info"] = "模组信息",
				["Visit the Mod's Homepage for even more info"] = "访问该模组的网页来获取更多信息",
				["Back"] = "返回",
				["No description available"] = "无可用描述",
			};
			InvokeReplace("UIModInfo", items);

			items = new Dictionary<string, string>
			{
				[" - by "] = " - 作者: ",
				["More info"] = "更多信息",
				["Click to Disable"] = "点击以禁用",
				["Click to Enable"] = "点击以启用",
				["This mod originated from the Mod Browser"] = "该模组来自模组浏览器",
				["Enabled"] = "已启用",
				["Disabled"] = "已禁用",
				["Reload Required"] = "需要重新加载",
			};
			InvokeReplace("UIModItem", items);

			items = new Dictionary<string, string>
			{
				[" - by "] = " - 作者: ",
				[" downloads ("] = " 次下载 (",
				[" latest version)"] = " 最新版本)",
				["Unpublish"] = "取消发布"
			};
			InvokeReplace("UIModManageItem", items);

			items = new Dictionary<string, string>
			{
				["View List"] = "查看列表",
				["Enable this List"] = "启用该列表",
				["Enable only this List"] = "只启用该列表",
				["{0} Total, {1} Enabled, {2} Disabled, {3} Missing"] = "总共 {0}, 启用了 {1} , 禁用了 {2} , 缺少 {3}",
				["The following mods were not found:\n"] = "以下模组未找到:\n",
				["This list contains the following mods:\n"] = "该列表包含以下模组:\n",
				[" - Missing"] = " - 缺少"
			};
			InvokeReplace("UIModPackItem", items);

			items = new Dictionary<string, string>
			{
				["Mod Packs"] = "模组整合包",
				["Back"] = "返回",
				["Save Enabled as New Mod Pack"] = "保存已开启模组为新整合包",
				["Enter Mod Pack name"] = "输入新整合包名"
			};
			InvokeReplace("UIModPacks", items);

			items = new Dictionary<string, string>
			{
				["Mods List"] = "模组列表",
				["Enable All"] = "启用全部模组",
				["Disable All"] = "禁用全部模组",
				["Reload Mods"] = "重新加载模组",
				["Back"] = "返回",
				["Open Mods Folder"] = "打开模组文件夹",
				["Type to search"] = "键入以搜索",
				["Mod Packs"] = "模组整合包",
			};
			InvokeReplace("UIMods", items);

			items = new Dictionary<string, string>
			{
				["Build"] = "取消",
				["Build + Reload"] = "生成并重新加载",
				["Publish"] = "发布"
			};
			InvokeReplace("UIModSourceItem", items);

			items = new Dictionary<string, string>
			{
				["Mod Sources"] = "模组源码",
				["Build All"] = "生成所有模组",
				["Build + Reload All"] = "生成并重新加载所有模组",
				["Back"] = "返回",
				["Open Sources"] = "打开源码",
				["Manage Published"] = "管理已发布模组"
			};
			InvokeReplace("UIModSources", items);

			items = new Dictionary<string, string>
			{
				["Ignore"] = "忽略",
				["Download"] = "下载"
			};
			InvokeReplace("UIUpdateMessage", items);
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

		private void InvokeReplace(string typeName, IDictionary<string, string> items)
		{
			Info($"执行类 {typeName} 文本更改..");

			var type = SourceModuleDef.Types.Single(t => t.Name == typeName);
			foreach (var m in type.Methods)
				ReplaceAllLdstr(m.Body.Instructions, items);
		}

		private static void ReplaceAllLdstr(IList<Instruction> inst, IDictionary<string, string> items)
		{
			if (inst == null) throw new ArgumentNullException(nameof(inst));
			if (items == null) throw new ArgumentNullException(nameof(items));

			foreach (var ins in inst)
			{
				if (!ins.OpCode.Equals(OpCodes.Ldstr)) continue;
				string newString;
				if (!items.TryGetValue(ins.Operand.ToString(), out newString))
				{
					continue;
				}
				ins.Operand = newString;
			}
		}

		public ChineseTextModifications() : base("导入中文文本") { }

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
