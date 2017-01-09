using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;
using Terraria.Map;
#if TML
using Terraria.ModLoader;
#endif
using Terraria.Social;

namespace Miyuu.Cns
{
	public static class ChineseTexts
	{
		public static string[] CnItemName = new string[Main.maxItemTypes];

		public static string DeathMsg(int plr = -1, int npc = -1, int proj = -1, int other = -1, int projType = 0,
			int plrItemType = 0)
		{
			var projKiller = "";
			var npcKiller = "";
			var playerKiller = "";
			var killerItem = "";
			if (proj >= 0)
				projKiller = Main.projName[Main.projectile[proj].type];
			if (npc >= 0)
				npcKiller = Main.npc[npc].displayName;
			if ((plr >= 0) && (plr < 255))
				playerKiller = Main.player[plr].name;
			if (plrItemType >= 0)
				killerItem = Main.itemName[plrItemType];
			var flag = projKiller != "";
			var flag2 = (plr >= 0) && (plr < 255);
			var flag3 = npcKiller != "";
			var result = "";
			var deathN = "";
			var num = Main.rand.Next(26);
			switch (num)
			{
				case 0:
					deathN = "杀害了";
					break;
				case 1:
				case 8:
					deathN = "肢解了";
					break;
				case 2:
					deathN = "谋杀了";
					break;
				case 3:
					deathN = "弄得血肉模糊";
					break;
				case 4:
					deathN = "撕裂内脏";
					break;
				case 5:
					deathN = "粉碎了";
					break;
				case 6:
					deathN = "碾碎了颅骨";
					break;
				case 7:
					deathN = "屠杀了";
					break;
				case 9:
					deathN = "撕成两半";
					break;
				case 10:
					deathN = "斩首";
					break;
				case 11:
					deathN = "扯下了胳膊";
					break;
				case 12:
				case 13:
					deathN = "开膛破肚";
					break;
				case 14:
					deathN = "剥夺了战斗能力";
					break;
				case 15:
					deathN = "碾碎了躯体";
					break;
				case 16:
					deathN = "的器官破裂";
					break;
				case 17:
					deathN = "碾成肉酱";
					break;
				case 18:
					deathN = "驱逐离开了" + Main.worldName + "的世界.";
					break;
				case 19:
					deathN = "切成了两半";
					break;
				case 20:
					deathN = "一刀两断";
					break;
				case 21:
					deathN = "切碎";
					break;
				case 22:
				case 23:
					deathN = "强迫接受了死神的召唤";
					break;
				case 24:
				case 25:
					deathN = "断头了";
					break;
			}
			if (flag2)
				result = string.Format("被{0}的{1}{2}。", playerKiller, flag ? projKiller : killerItem, deathN);
			else if (flag3)
				result = string.Format("被{0}{1}。", npcKiller, deathN);
			else if (flag)
				result = string.Format("被{0}{1}。", projKiller, deathN);
			else if (other >= 0)
				if (other == 0)
				{
					if (Main.rand.Next(2) == 0)
						result = "朝着死亡坠落。";
					else
						result = "摔死了。";
				}
				else if (other == 1)
				{
					var num2 = Main.rand.Next(4);
					if (num2 == 0)
						result = "忘记了呼吸。";
					else if (num2 == 1)
						result = "与鱼长眠。";
					else if (num2 == 2)
						result = "溺水而亡。";
					else if (num2 == 3)
						result = "成为了鲨鱼的美食";
				}
				else if (other == 2)
				{
					var num3 = Main.rand.Next(4);
					if (num3 == 0)
						result = "被融化了。";
					else if (num3 == 1)
						result = "被焚毁了。";
					else if (num3 == 2)
						result = "试图在岩浆里游泳。";
					else if (num3 == 3)
						result = "很想在岩浆里玩耍。";
				}
				else if (other == 3)
				{
					result = deathN + ".";
				}
				else if (other == 4)
				{
					result = "死了。";
				}
				else if (other == 5)
				{
					var num4 = Main.rand.Next(4);
					switch (num4)
					{
						case 0:
							result = "被分尸了。";
							break;
						case 1:
							result = "破破碎碎无法重组成一个身体。";
							break;
						case 2:
							result = "的尸块儿需要他人帮助洗地。";
							break;
						case 3:
							result = "化为泥土。";
							break;
					}
				}
				else if (other == 6)
				{
					result = "被捅死了。";
				}
				else if (other == 7)
				{
					result = Lang.dt[2];
				}
				else if (other == 8)
				{
					result = Lang.dt[1];
				}
				else if (other == 9)
				{
					result = Lang.dt[0];
				}
				else if (other == 10)
				{
					result = Lang.dt[3];
				}
				else if (other == 11)
				{
					result = Language.GetTextValue("Deaths.TriedToEscape");
				}
				else if (other == 12)
				{
					result = Language.GetTextValue("Deaths.WasLicked");
				}
				else if (other == 13)
				{
					result = Language.GetTextValue("Deaths.Teleport_1");
				}
				else if (other == 14)
				{
					result = Language.GetTextValue("Deaths.Teleport_2_Male");
				}
				else if (other == 15)
				{
					result = Language.GetTextValue("Deaths.Teleport_2_Female");
				}
				else if (other == 254)
				{
					result = "";
				}
				else if (other == 255)
				{
					result = "被谋害了...";
				}
			return result;
		}

		public static string GetBirthdayDialog(int id)
		{
			switch (id)
			{
				case 17:
					return "你知道派对的精髓是什么吗？从别人哪里买东西，当然，是从我这儿买。";
				case 18:
					return "不，我死也不会告诉你我的蛋糕上有多少支蜡烛。";
				case 19:
					return "派对是让人们“破壳而出”的好方法，就像子弹一样。";
				case 20:
					return "我觉得我会举办一个派对来庆祝我们过去的胜利, 和未来我们将会取得的胜利。";
				case 22:
					return "从来没有参加过派对吗？去看看其他人吧。人们有时会带来特别的派对礼品哦。";
				case 38:
					return "今天你可得小心点，我们矮人族喜欢开“火爆”的派对。";
				case 54:
					return "妈妈常说, 把往事抛诸脑后，才能玩得开心。";
				case 107:
					return "哥布林的派对和人类的大同小异。都有像“蒙眼钉人（驴）”的游戏…… 呃，我从来不在我的派对上弄这个。";
				case 108:
					return "很显然，我举办了一个最魔幻的派对。";
				case 124:
					return "你觉得会有人介意我把蛋糕上的蜡烛换成灯泡吗？";
				case 142:
					return "来吧宝贝，你该不会认为我只在圣诞节开派对吧？";
				case 160:
					return "我本来想邀请所有人去我家开派对的，但是这里没有其他的蘑菇房了。";
				case 178:
					return "你们都喜欢多层蛋糕，所以我在我的蛋糕上加了一个烟囱。";
				case 207:
					return "我爱极了派对，到处都是艳丽的颜色和快乐的人。";
				case 208:
					return
						Utils.SelectRandom(Main.rand,
							"啊哈？今天没什么特别的.... 逗你玩呢！现在是派对时间！然后是派对后时间",
							"终于，我的时间到了！");
				case 209:
					return "这个派对会变成螺母，甚至可能变成螺钉！";
				case 227:
					return "我试过去办一次染料弹丸大战，但是每个人都反倒更喜欢食物和装饰品。";
				case 228:
					return "我想看看你们是怎么庆祝的，我没失望。";
				case 229:
					return "这些蛋糕都吃完后，你可能就得叫我白胡子了。";
				case 353:
					return "我今天特地剪了新发型，但是实话说，我现在只想用我的剪刀戳破这些气球。";
				case 368:
					return "很多人说派对会给你丰富多彩的记忆。所以买点东西让记忆更加“丰富多彩”吧！";
				case 369:
					return "什么？你说我喜欢派对是因为我是个小孩？好吧，你说对了，所以开始派对啦！";
				case 550:
					return "我真的需要一些生日礼物, Yorai!";
				default:
					return string.Empty;
			}
		}

		public static string GetProjectileNameByType(int id)
		{
			switch (id)
			{
				case 1:
					return "木箭";
				case 2:
					return "燃烧箭";
				case 3:
					return "手里剑";
				case 4:
					return "邪影箭";
				case 5:
					return "小丑之箭";
				case 6:
					return "魔化回旋镖";
				case 7:
					return "邪恶荆棘";
				case 8:
					return "邪恶荆棘";
				case 9:
					return "群星之怒";
				case 10:
					return "净化粉末";
				case 11:
					return "邪恶粉末";
				case 12:
					return "落星";
				case 13:
					return "钩爪";
				case 14:
					return "枪弹";
				case 15:
					return "火球";
				case 16:
					return "魔法飞弹";
				case 17:
					return "泥土球";
				case 18:
					return "暗影光球";
				case 19:
					return "破空之炎";
				case 20:
					return "绿色激光";
				case 21:
					return "骨头";
				case 22:
					return "水流";
				case 23:
					return "鱼叉";
				case 24:
					return "尖钉球";
				case 25:
					return "伤害链球";
				case 26:
					return "蓝月";
				case 27:
					return "水球";
				case 28:
					return "炸弹";
				case 29:
					return "矿用雷管";
				case 30:
					return "手榴弹";
				case 31:
					return "沙球";
				case 32:
					return "常春藤鞭";
				case 33:
					return "荆棘旋刃";
				case 34:
					return "烈焰火鞭";
				case 35:
					return "日曜之怒";
				case 36:
					return "陨星弹";
				case 37:
					return "粘性炸弹";
				case 38:
					return "鹰身女妖羽毛";
				case 39:
					return "泥球";
				case 40:
					return "灰烬球";
				case 41:
					return "狱炎箭";
				case 42:
					return "沙球";
				case 43:
					return "墓碑";
				case 44:
					return "恶魔之镰";
				case 45:
					return "恶魔之镰";
				case 46:
					return "暗黑长矛";
				case 47:
					return "三叉戟";
				case 48:
					return "飞刀";
				case 49:
					return "长矛";
				case 50:
					return "荧光棒";
				case 51:
					return "种子";
				case 52:
					return "木制回旋镖";
				case 53:
					return "粘性荧光棒";
				case 54:
					return "剧毒飞刀";
				case 55:
					return "毒刺";
				case 56:
					return "黑檀沙球";
				case 57:
					return "钴蓝链锯";
				case 58:
					return "秘银链锯";
				case 59:
					return "钴蓝钻头";
				case 60:
					return "秘银钻头";
				case 61:
					return "精金链锯";
				case 62:
					return "精金钻头";
				case 63:
					return "无极";
				case 64:
					return "秘银长戟";
				case 65:
					return "黑檀沙球";
				case 66:
					return "精金长刀";
				case 67:
					return "珍珠沙球";
				case 68:
					return "珍珠沙球";
				case 69:
					return "圣洁水瓶";
				case 70:
					return "邪恶水瓶";
				case 71:
					return "泥砂球";
				case 72:
					return "蓝色妖精";
				case 73:
					return "双钩爪";
				case 74:
					return "双钩爪";
				case 75:
					return "笑脸炸弹";
				case 76:
					return "音符";
				case 77:
					return "音符";
				case 78:
					return "音符";
				case 79:
					return "彩虹";
				case 80:
					return "寒冰方块";
				case 81:
					return "木箭";
				case 82:
					return "燃烧箭";
				case 83:
					return "眼球激光";
				case 84:
					return "粉红激光";
				case 85:
					return "火焰";
				case 86:
					return "绿色精灵";
				case 87:
					return "粉色精灵";
				case 88:
					return "紫色激光";
				case 89:
					return "水晶弹";
				case 90:
					return "水晶碎片";
				case 91:
					return "神怒之箭";
				case 92:
					return "神圣落星";
				case 93:
					return "魔法飞刀";
				case 94:
					return "魔晶风暴";
				case 95:
					return "诅咒火焰";
				case 96:
					return "诅咒火焰";
				case 97:
					return "钴蓝薙刀";
				case 98:
					return "毒箭";
				case 99:
					return "巨石";
				case 100:
					return "死亡激光";
				case 101:
					return "魔眼咒火";
				case 102:
					return "炸弹";
				case 103:
					return "咒火箭";
				case 104:
					return "咒火弹";
				case 105:
					return "永恒之枪";
				case 106:
					return "光辉飞盘";
				case 107:
					return "神金钻头";
				case 108:
					return "TNT";
				case 109:
					return "雪球";
				case 110:
					return "枪弹";
				case 111:
					return "兔子";
				case 112:
					return "企鹅";
				case 113:
					return "回旋冰刃";
				case 114:
					return "邪恶三叉戟";
				case 115:
					return "邪恶三叉戟";
				case 116:
					return "长剑光束";
				case 117:
					return "白骨箭";
				case 118:
					return "冰晶飞弹";
				case 119:
					return "冰霜弹";
				case 120:
					return "冰霜箭";
				case 121:
					return "紫水晶飞弹";
				case 122:
					return "黄晶玉飞弹";
				case 123:
					return "蓝宝石飞弹";
				case 124:
					return "祖母绿飞弹";
				case 125:
					return "红宝石飞弹";
				case 126:
					return "钻石飞弹";
				case 127:
					return "海龟";
				case 128:
					return "寒霜爆弹";
				case 129:
					return "符文爆弹";
				case 130:
					return "蘑菇长枪";
				case 131:
					return "蘑菇";
				case 132:
					return "泰拉光剑";
				case 133:
					return "一号榴弹";
				case 134:
					return "一号火箭弹";
				case 135:
					return "一号智能地雷";
				case 136:
					return "二号榴弹";
				case 137:
					return "二号火箭弹";
				case 138:
					return "二号智能地雷";
				case 139:
					return "三号榴弹";
				case 140:
					return "三号火箭弹";
				case 141:
					return "三号智能地雷";
				case 142:
					return "四号榴弹";
				case 143:
					return "四号火箭弹";
				case 144:
					return "四号智能地雷";
				case 145:
					return "净化喷剂";
				case 146:
					return "神圣喷剂";
				case 147:
					return "腐化喷剂";
				case 148:
					return "蘑菇喷剂";
				case 149:
					return "血腥喷剂";
				case 150:
					return "爆裂刺棘";
				case 151:
					return "爆裂刺棘";
				case 152:
					return "爆裂刺棘";
				case 153:
					return "腐朽之刃";
				case 154:
					return "血肉之球";
				case 155:
					return "沙滩排球";
				case 156:
					return "光芒之剑";
				case 157:
					return "永夜光剑";
				case 158:
					return "铜币";
				case 159:
					return "银币";
				case 160:
					return "金币";
				case 161:
					return "铂金币";
				case 162:
					return "炮弹";
				case 163:
					return "照明弹";
				case 164:
					return "地雷";
				case 165:
					return "蛛网";
				case 166:
					return "雪球";
				case 167:
					return "红色烟花";
				case 168:
					return "绿色烟花";
				case 169:
					return "蓝色烟花";
				case 170:
					return "黄色烟花";
				case 171:
					return "绳圈";
				case 172:
					return "冰焰箭";
				case 173:
					return "魔化光刃";
				case 174:
					return "冰刺";
				case 175:
					return "小灵魂吞噬者";
				case 176:
					return "丛林尖刺";
				case 177:
					return "冰水喷吐";
				case 178:
					return "彩纸";
				case 179:
					return "雪砂球";
				case 180:
					return "枪弹";
				case 181:
					return "蜜蜂";
				case 182:
					return "魔化飞斧";
				case 183:
					return "蜜蜂手榴弹";
				case 184:
					return "剧毒飞刀";
				case 185:
					return "尖钉球";
				case 186:
					return "长矛";
				case 187:
					return "火焰喷射器";
				case 188:
					return "火焰";
				case 189:
					return "黄蜂";
				case 190:
					return "钢铁食人鱼";
				case 191:
					return "俾格米人";
				case 192:
					return "俾格米人";
				case 193:
					return "俾格米人";
				case 194:
					return "俾格米人";
				case 195:
					return "俾格米人";
				case 196:
					return "烟雾弹";
				case 197:
					return "小骷髅头";
				case 198:
					return "小黄蜂";
				case 199:
					return "提基之灵";
				case 200:
					return "宠物蜥蜴";
				case 201:
					return "墓碑";
				case 202:
					return "墓碑";
				case 203:
					return "墓碑";
				case 204:
					return "墓碑";
				case 205:
					return "墓碑";
				case 206:
					return "叶子";
				case 207:
					return "叶绿弹";
				case 208:
					return "鹦鹉";
				case 209:
					return "松露";
				case 210:
					return "树苗";
				case 211:
					return "瓶中灵";
				case 212:
					return "山铜长戟";
				case 213:
					return "山铜钻头";
				case 214:
					return "山铜链锯";
				case 215:
					return "钯金钩刃";
				case 216:
					return "钯金钻头";
				case 217:
					return "钯金链锯";
				case 218:
					return "钛金三叉戟";
				case 219:
					return "钛金钻头";
				case 220:
					return "钛金链锯";
				case 221:
					return "花瓣";
				case 222:
					return "叶绿帕提森钩刃";
				case 223:
					return "叶绿钻头";
				case 224:
					return "叶绿链锯";
				case 225:
					return "叶绿箭";
				case 226:
					return "叶绿水晶";
				case 227:
					return "叶绿水晶";
				case 228:
					return "孢子云";
				case 229:
					return "叶绿光球";
				case 230:
					return "紫水晶钩爪";
				case 231:
					return "黄晶玉钩爪";
				case 232:
					return "蓝宝石钩爪";
				case 233:
					return "祖母绿钩爪";
				case 234:
					return "红宝石钩爪";
				case 235:
					return "钻石钩爪";
				case 236:
					return "小恐龙";
				case 237:
					return "乌云";
				case 238:
					return "乌云";
				case 239:
					return "雨";
				case 240:
					return "加农炮弹";
				case 241:
					return "血腥沙球";
				case 242:
					return "子弹";
				case 243:
					return "血云";
				case 244:
					return "血云";
				case 245:
					return "血雨";
				case 246:
					return "毒刺";
				case 247:
					return "锦绣花团";
				case 248:
					return "锦绣花团";
				case 249:
					return "毒刺";
				case 250:
					return "彩虹";
				case 251:
					return "彩虹";
				case 252:
					return "叶绿冲击锤";
				case 253:
					return "冰霜球";
				case 254:
					return "磁暴之球";
				case 255:
					return "磁暴之球";
				case 256:
					return "骷髅钩爪";
				case 257:
					return "寒冰光线";
				case 258:
					return "火球";
				case 259:
					return "眼魔射线";
				case 260:
					return "热能射线";
				case 261:
					return "巨石";
				case 262:
					return "石巨人之拳";
				case 263:
					return "寒冰镰刀";
				case 264:
					return "雨";
				case 265:
					return "毒牙";
				case 266:
					return "小史莱姆";
				case 267:
					return "剧毒飞箭";
				case 268:
					return "弹跳眼球";
				case 269:
					return "小雪人";
				case 270:
					return "骷髅";
				case 271:
					return "拳击手套";
				case 272:
					return "香蕉回旋镖";
				case 273:
					return "链刃";
				case 274:
					return "死亡镰刀";
				case 275:
					return "种子";
				case 276:
					return "剧毒种子";
				case 277:
					return "刺球";
				case 278:
					return "脓血箭";
				case 279:
					return "脓血弹";
				case 280:
					return "黄金喷头";
				case 281:
					return "爆炸兔子";
				case 282:
					return "剧毒箭";
				case 283:
					return "剧毒弹";
				case 284:
					return "彩纸弹";
				case 285:
					return "纳米弹";
				case 286:
					return "高爆弹";
				case 287:
					return "金弹";
				case 288:
					return "黄金喷头";
				case 289:
					return "彩纸";
				case 290:
					return "暗影射线";
				case 291:
					return "地狱之火";
				case 292:
					return "地狱之火";
				case 293:
					return "失落幽魂";
				case 294:
					return "暗影射线";
				case 295:
					return "地狱之火";
				case 296:
					return "地狱之火";
				case 297:
					return "失落幽魂";
				case 298:
					return "幽魂治疗";
				case 299:
					return "暗影之炎";
				case 300:
					return "圣骑士之锤";
				case 301:
					return "圣骑士之锤";
				case 302:
					return "狙击枪子弹";
				case 303:
					return "火箭弹";
				case 304:
					return "吸血飞刀";
				case 305:
					return "吸血飞刀回血";
				case 306:
					return "吞噬者之咬";
				case 307:
					return "小吞噬者";
				case 308:
					return "冰霜九头蛇";
				case 309:
					return "冰霜爆炸";
				case 310:
					return "蓝色信号弹";
				case 311:
					return "糖豆";
				case 312:
					return "杰克爆弹";
				case 313:
					return "蜘蛛";
				case 314:
					return "南瓜人";
				case 315:
					return "蝙蝠钩爪";
				case 316:
					return "蝙蝠";
				case 317:
					return "乌鸦";
				case 318:
					return "腐烂鸡蛋";
				case 319:
					return "黑猫";
				case 320:
					return "鲜血屠刀";
				case 321:
					return "燃烧南瓜头";
				case 322:
					return "鬼木钩爪";
				case 323:
					return "尖木桩";
				case 324:
					return "诅咒鬼木";
				case 325:
					return "燃烧木枝";
				case 326:
					return "希腊火焰";
				case 327:
					return "希腊火焰 ";
				case 328:
					return "希腊火焰";
				case 329:
					return "火焰镰刀";
				case 330:
					return "八角茴香";
				case 331:
					return "拐杖糖钩爪";
				case 332:
					return "圣诞钩爪";
				case 333:
					return "水果蛋糕";
				case 334:
					return "小狗";
				case 335:
					return "装饰物";
				case 336:
					return "松针";
				case 337:
					return "暴风雪";
				case 338:
					return "火箭弹";
				case 339:
					return "火箭弹";
				case 340:
					return "火箭弹";
				case 341:
					return "火箭弹";
				case 342:
					return "北极";
				case 343:
					return "北极";
				case 344:
					return "北极";
				case 345:
					return "松针";
				case 346:
					return "装饰物";
				case 347:
					return "装饰物";
				case 348:
					return "冰浪";
				case 349:
					return "寒冰碎片";
				case 350:
					return "导弹";
				case 351:
					return "礼物炸弹";
				case 352:
					return "尖钉球";
				case 353:
					return "圣诞怪杰";
				case 354:
					return "血腥沙球";
				case 355:
					return "毒牙";
				case 356:
					return "幽魂之怒";
				case 357:
					return "脉冲波";
				case 358:
					return "水枪";
				case 359:
					return "寒冰球";
				case 360:
					return "浮标";
				case 361:
					return "浮标";
				case 362:
					return "浮标";
				case 363:
					return "浮标";
				case 364:
					return "浮标";
				case 365:
					return "浮标";
				case 366:
					return "浮标";
				case 367:
					return "黑曜石剑鱼";
				case 368:
					return "剑鱼";
				case 369:
					return "锯齿鲨";
				case 370:
					return "爱情药剂";
				case 371:
					return "恶臭药剂";
				case 372:
					return "鱼钩爪";
				case 373:
					return "蜜蜂";
				case 374:
					return "蜜蜂毒刺";
				case 375:
					return "飞翔的魔精";
				case 376:
					return "魔精火球";
				case 377:
					return "蜘蛛女皇";
				case 378:
					return "蜘蛛卵";
				case 379:
					return "小蜘蛛";
				case 380:
					return "微风鱼";
				case 381:
					return "浮标";
				case 382:
					return "浮标";
				case 383:
					return "铁锚";
				case 384:
					return "鲨龙卷";
				case 385:
					return "鲨龙卷旋涡";
				case 386:
					return "邪神风暴";
				case 387:
					return "激光眼";
				case 388:
					return "咒火眼";
				case 389:
					return "小型激光束";
				case 390:
					return "剧毒蜘蛛";
				case 391:
					return "跳跃蜘蛛";
				case 392:
					return "危险蜘蛛";
				case 393:
					return "独眼海盗";
				case 394:
					return "破坏狂海盗";
				case 395:
					return "海盗船长";
				case 396:
					return "史莱姆钩爪";
				case 397:
					return "粘性手榴弹";
				case 398:
					return "迷你牛头人";
				case 399:
					return "莫洛托夫鸡尾酒";
				case 400:
					return "莫洛托夫火焰";
				case 401:
					return "莫洛托夫火焰";
				case 402:
					return "莫洛托夫火焰";
				case 403:
					return "轨道钩子";
				case 404:
					return "猪鲨链球";
				case 405:
					return "猪鲨链球泡泡";
				case 406:
					return "史莱姆枪";
				case 407:
					return "鲨龙卷";
				case 408:
					return "小龙卷鲨";
				case 409:
					return "水刃龙卷";
				case 410:
					return "跟踪泡泡";
				case 411:
					return "铜币";
				case 412:
					return "银币";
				case 413:
					return "金币";
				case 414:
					return "铂金币";
				case 415:
					return "红烟花";
				case 416:
					return "绿烟花";
				case 417:
					return "蓝烟花";
				case 418:
					return "黄烟花";
				case 419:
					return "焰火喷泉";
				case 420:
					return "焰火喷泉";
				case 421:
					return "焰火喷泉";
				case 422:
					return "焰火喷泉";
				case 423:
					return "UFO";
				case 424:
					return "陨石";
				case 425:
					return "陨石";
				case 426:
					return "陨石";
				case 427:
					return "旋涡链锯";
				case 428:
					return "旋涡钻头";
				case 429:
					return "星云链锯";
				case 430:
					return "星云钻头";
				case 431:
					return "耀斑链锯";
				case 432:
					return "耀斑钻头";
				case 433:
					return "UFO激光";
				case 434:
					return "蛞蝓激光";
				case 435:
					return "电磁冲击波";
				case 436:
					return "脑控电波";
				case 437:
					return "磁暴枪头";
				case 438:
					return "激光束";
				case 439:
					return "激光机关枪";
				case 440:
					return "激光";
				case 441:
					return "火星蛞蝓准星";
				case 442:
					return "电磁球导弹";
				case 443:
					return "电磁球";
				case 444:
					return "异星泡泡枪";
				case 445:
					return "激光钻头";
				case 446:
					return "反重力钩爪";
				case 447:
					return "火星飞碟死光";
				case 448:
					return "火星火箭弹";
				case 449:
					return "飞碟激光";
				case 450:
					return "飞碟爆弹";
				case 451:
					return "波动剑气";
				case 452:
					return "幻象眼";
				case 453:
					return "钻头准星";
				case 454:
					return "幻象球";
				case 455:
					return "幻象死光";
				case 456:
					return "月之领主之舌";
				case 459:
					return "充能激光球";
				case 460:
					return "充能加农炮";
				case 461:
					return "充能激光";
				case 462:
					return "幻象闪电";
				case 463:
					return "邪恶粉末";
				case 464:
					return "神秘冰凌";
				case 465:
					return "闪电球";
				case 466:
					return "闪电球电弧";
				case 467:
					return "火焰球";
				case 468:
					return "暗影火焰球";
				case 469:
					return "蜜蜂箭";
				case 470:
					return "粘性雷管";
				case 471:
					return "骨头";
				case 472:
					return "蜘蛛网";
				case 473:
					return "探险荧光棒";
				case 474:
					return "白骨箭";
				case 475:
					return "藤绳圈";
				case 476:
					return "灵魂汲取";
				case 477:
					return "水晶飞箭";
				case 478:
					return "诅咒飞箭";
				case 479:
					return "脓血飞箭";
				case 480:
					return "诅咒飞箭";
				case 481:
					return "锁链断头台";
				case 482:
					return "诅咒火焰";
				case 483:
					return "种子爆弹";
				case 484:
					return "种子碎片";
				case 485:
					return "地狱蝙蝠";
				case 486:
					return "血筋钩爪";
				case 487:
					return "荆棘钩爪";
				case 488:
					return "荧光钩爪";
				case 489:
					return "蠕虫钩爪";
				case 490:
					return "光芒仪式";
				case 491:
					return "水晶飞刀";
				case 492:
					return "魔法灯笼";
				case 493:
					return "邪恶水晶碎片";
				case 494:
					return "邪恶水晶碎片";
				case 495:
					return "影炎箭";
				case 496:
					return "影炎六角娃娃";
				case 497:
					return "影炎小刀";
				case 498:
					return "钉子";
				case 499:
					return "巨脸怪幼体";
				case 500:
					return "血腥心脏";
				case 501:
					return "烧瓶";
				case 502:
					return "彩虹猫";
				case 503:
					return "星辰之怒";
				case 504:
					return "火花";
				case 505:
					return "绳圈";
				case 506:
					return "绳圈";
				case 507:
					return "标枪";
				case 508:
					return "标枪";
				case 509:
					return "屠夫的链锯";
				case 510:
					return "剧毒之瓶";
				case 511:
					return "致命毒云";
				case 512:
					return "致命毒云";
				case 513:
					return "致命毒云";
				case 514:
					return "钉子";
				case 515:
					return "弹性荧光棒";
				case 516:
					return "弹性炸弹";
				case 517:
					return "弹性手榴弹";
				case 518:
					return "金币传送门";
				case 519:
					return "炸弹鱼";
				case 520:
					return "冰霜短剑鱼";
				case 521:
					return "魔晶爆弹";
				case 522:
					return "魔晶爆弹";
				case 523:
					return "剧毒泡泡";
				case 524:
					return "脓血喷溅";
				case 525:
					return "飞翔的猪猪储蓄罐";
				case 526:
					return "能量";
				case 527:
					return "墓碑";
				case 528:
					return "墓碑";
				case 529:
					return "墓碑";
				case 530:
					return "墓碑";
				case 531:
					return "墓碑";
				case 532:
					return "十字骨架";
				case 533:
					return "致命球";
				case 534:
					return "代码：1";
				case 535:
					return "美杜莎头颅";
				case 536:
					return "美杜莎射线";
				case 537:
					return "星尘激光";
				case 538:
					return "闪光爆弹";
				case 539:
					return "激流入侵者";
				case 540:
					return "星标";
				case 541:
					return "木制悠悠球";
				case 542:
					return "虚弱";
				case 543:
					return "动脉";
				case 544:
					return "亚马逊";
				case 545:
					return "火瀑";
				case 546:
					return "雏鸟";
				case 547:
					return "代码：2";
				case 548:
					return "拉力";
				case 549:
					return "叶列茨悠悠球";
				case 550:
					return "瑞德之投掷";
				case 551:
					return "女武神悠悠球";
				case 552:
					return "狼神";
				case 553:
					return "地狱火";
				case 554:
					return "克拉肯";
				case 555:
					return "克苏鲁之眼";
				case 556:
					return "黑色配重块";
				case 557:
					return "蓝色配重块";
				case 558:
					return "绿色配重块";
				case 559:
					return "紫色配重块";
				case 560:
					return "红色配重块";
				case 561:
					return "黄色配重块";
				case 562:
					return "格式：C";
				case 563:
					return "梯度";
				case 564:
					return "勇气";
				case 565:
					return "混乱大脑";
				case 566:
					return "蜜蜂";
				case 567:
					return "孢子";
				case 568:
					return "孢子";
				case 569:
					return "孢子";
				case 570:
					return "孢子";
				case 571:
					return "孢子";
				case 572:
					return "剧毒喷吐";
				case 573:
					return "星云穿刺";
				case 574:
					return "星云之眼";
				case 575:
					return "星云之球";
				case 576:
					return "星云激光";
				case 577:
					return "漩涡激光";
				case 578:
					return "漩涡";
				case 579:
					return "漩涡";
				case 580:
					return "漩涡闪电";
				case 581:
					return "异星粘胶";
				case 582:
					return "电工扳手";
				case 583:
					return "注射器";
				case 584:
					return "注射器";
				case 585:
					return "骷髅头";
				case 586:
					return "树精的守护";
				case 587:
					return "彩弹";
				case 588:
					return "彩纸手榴弹";
				case 589:
					return "圣诞装饰";
				case 590:
					return "松露孢子";
				case 591:
					return "矿车激光";
				case 592:
					return "激光射线";
				case 593:
					return "先知的末路";
				case 594:
					return "硝烟";
				case 595:
					return "真空刃";
				case 596:
					return "沙漠游魂的诅咒";
				case 597:
					return "琥珀魔弹";
				case 598:
					return "白骨投枪";
				case 599:
					return "白骨飞刀";
				case 600:
					return "传送枪";
				case 601:
					return "传送门弹";
				case 602:
					return "传送门";
				case 603:
					return "泰拉瑞亚悠悠球";
				case 604:
					return "泰拉瑞亚悠悠球";
				case 605:
					return "史莱姆尖刺";
				case 606:
					return "激光";
				case 607:
					return "耀斑";
				case 608:
					return "日曜辐射";
				case 609:
					return "星尘钻头";
				case 610:
					return "星尘链锯";
				case 611:
					return "日曜链刃";
				case 612:
					return "日曜链刃";
				case 613:
					return "星尘细胞";
				case 614:
					return "星尘细胞";
				case 615:
					return "漩涡击碎者";
				case 616:
					return "漩涡火箭弹";
				case 617:
					return "星云奥秘";
				case 618:
					return "星云奥秘";
				case 619:
					return "星云奥秘";
				case 620:
					return "星云奥秘";
				case 621:
					return "血水";
				case 622:
					return "硝烟";
				case 623:
					return "星尘守护者";
				case 624:
					return "星爆";
				case 625:
					return "星尘龙";
				case 626:
					return "星尘龙";
				case 627:
					return "星尘龙";
				case 628:
					return "星尘龙";
				case 629:
					return "释放的能量";
				case 630:
					return "幻象";
				case 631:
					return "幻象";
				case 632:
					return "最终棱镜";
				case 633:
					return "最终棱镜";
				case 634:
					return "星云火焰";
				case 635:
					return "终极星云火焰";
				case 636:
					return "黎明";
				case 637:
					return "弹性雷管";
				case 638:
					return "月光子弹";
				case 639:
					return "月光箭";
				case 640:
					return "月光箭";
				case 641:
					return "月球传送门";
				case 642:
					return "月球传送门激光";
				case 643:
					return "彩虹水晶";
				case 644:
					return "彩虹爆破";
				case 645:
					return "月球耀斑";
				case 646:
					return "月球钩爪";
				case 647:
					return "月球钩爪";
				case 648:
					return "月球钩爪";
				case 649:
					return "月球钩爪";
				case 650:
					return "可疑的触手";
				case 651:
					return "电线";
				case 652:
					return "静止钩爪";
				case 653:
					return "伙伴方块";
				case 654:
					return "火焰喷泉";
				case 655:
					return "蜂巢";
				case 656:
					return "远古风暴";
				case 657:
					return "远古风暴";
				case 658:
					return "远古风暴";
				case 659:
					return "神灵火焰";
				case 660:
					return "天空撕裂";
				case 661:
					return "黑玛瑙冲击波";
				case 662:
					return "投枪";
				case 663:
					return "焰爆炮塔";
				case 664:
					return "焰爆炮塔";
				case 665:
					return "焰爆炮塔";
				case 666:
					return "焰爆炮塔";
				case 667:
					return "焰爆炮塔";
				case 668:
					return "焰爆炮塔";
				case 669:
					return "麦酒";
				case 670:
					return "食人魔践踏";
				case 671:
					return "龙吐息";
				case 672:
					return "幽暗终结";
				case 673:
					return "黑暗咒印";
				case 674:
					return "黑暗咒印";
				case 675:
					return "黑暗能量";
				case 676:
					return "食人魔喷吐";
				case 677:
					return "弩车";
				case 678:
					return "弩车";
				case 679:
					return "弩车";
				case 680:
					return "弩车";
				case 681:
					return "哥布林炸弹";
				case 682:
					return "凋零闪电";
				case 683:
					return "食人魔践踏";
				case 684:
					return "心斩";
				case 685:
					return "投枪";
				case 686:
					return "贝特西的火球";
				case 687:
					return "贝特西之怒";
				case 688:
					return "闪电光环";
				case 689:
					return "闪电光环";
				case 690:
					return "闪电光环";
				case 691:
					return "爆炸陷阱";
				case 692:
					return "爆炸陷阱";
				case 693:
					return "爆炸陷阱";
				case 694:
					return "爆炸陷阱";
				case 695:
					return "爆炸陷阱";
				case 696:
					return "爆炸陷阱";
				case 697:
					return "沉睡的八爪怪";
				case 698:
					return "极地破碎";
				case 699:
					return "恐怖长刀";
				case 700:
					return "恐怖鬼魂";
				case 701:
					return "霍尔龙";
				case 702:
					return "摇曳烛芯";
				case 703:
					return "螺旋猫";
				case 704:
					return "无尽智慧之旋风";
				case 705:
					return "幻影凤凰";
				case 706:
					return "幻影凤凰";
				case 707:
					return "天龙之怒";
				case 708:
					return "天龙之怒";
				case 709:
					return "天龙之怒";
				case 710:
					return "空之灾星";
				case 711:
					return "贝特西之怒";
				case 712:
					return "无限智慧之书";
				case 713:
					return "胜利!";
				default:
					return string.Empty;
			}
		}

		public static string ItemName(int id)
		{
			switch (id)
			{
				case -48:
					return "铂金短弓";
				case -47:
					return "铂金大锤";
				case -46:
					return "铂金斧头";
				case -45:
					return "铂金短剑";
				case -44:
					return "铂金宽刃剑";
				case -43:
					return "铂金锄头";
				case -42:
					return "钨金短弓";
				case -41:
					return "钨金大锤";
				case -40:
					return "钨金斧头";
				case -39:
					return "钨金短剑";
				case -38:
					return "钨金宽刃剑";
				case -37:
					return "钨金锄头";
				case -36:
					return "铅质短弓";
				case -35:
					return "铅质大锤";
				case -34:
					return "铅质斧头";
				case -33:
					return "铅质短剑";
				case -32:
					return "铅质宽刃剑";
				case -31:
					return "铅质锄头";
				case -30:
					return "锡质短弓";
				case -29:
					return "锡质大锤";
				case -28:
					return "锡质斧头";
				case -27:
					return "锡质短剑";
				case -26:
					return "锡质宽刃剑";
				case -25:
					return "锡质锄头";
				case -24:
					return "黄昏光刃";
				case -23:
					return "苍白光刃";
				case -22:
					return "紫晶光刃";
				case -21:
					return "翠绿光刃";
				case -20:
					return "真红光刃";
				case -19:
					return "冰蓝光刃";
				case -18:
					return "铜质短弓";
				case -17:
					return "铜质大锤";
				case -16:
					return "铜质斧头";
				case -15:
					return "铜质短剑";
				case -14:
					return "铜质宽刃剑";
				case -13:
					return "铜质锄头";
				case -12:
					return "白银短弓";
				case -11:
					return "白银大锤";
				case -10:
					return "白银斧头";
				case -9:
					return "白银短剑";
				case -8:
					return "白银宽刃剑";
				case -7:
					return "白银锄头";
				case -6:
					return "黄金短弓";
				case -5:
					return "黄金大锤";
				case -4:
					return "黄金斧头";
				case -3:
					return "黄金短剑";
				case -2:
					return "黄金宽刃剑";
				case -1:
					return "黄金锄头";
				case 1:
					return "铁质锄头";
				case 2:
					return "泥土块";
				case 3:
					return "岩石块";
				case 4:
					return "铁质宽刃剑";
				case 5:
					return "蘑菇";
				case 6:
					return "铁质短剑";
				case 7:
					return "铁质大锤";
				case 8:
					return "火把";
				case 9:
					return "木材";
				case 10:
					return "铁质斧头";
				case 11:
					return "铁矿石";
				case 12:
					return "铜矿石";
				case 13:
					return "金矿石";
				case 14:
					return "银矿石";
				case 15:
					return "铜怀表";
				case 16:
					return "银怀表";
				case 17:
					return "金怀表";
				case 18:
					return "深度计";
				case 19:
					return "金锭";
				case 20:
					return "铜锭";
				case 21:
					return "银锭";
				case 22:
					return "铁锭";
				case 23:
					return "凝胶";
				case 24:
					return "木剑";
				case 25:
					return "木门";
				case 26:
					return "岩石墙壁";
				case 27:
					return "橡树果实";
				case 28:
					return "弱效治疗药水";
				case 29:
					return "生命水晶";
				case 30:
					return "泥土墙壁";
				case 31:
					return "空瓶";
				case 32:
					return "木桌";
				case 33:
					return "熔炉";
				case 34:
					return "木椅";
				case 35:
					return "铁砧";
				case 36:
					return "工作台";
				case 37:
					return "护目镜";
				case 38:
					return "晶状体";
				case 39:
					return "木弓";
				case 40:
					return "木箭";
				case 41:
					return "燃烧箭";
				case 42:
					return "手里剑";
				case 43:
					return "可疑的眼球";
				case 44:
					return "恶魔长弓";
				case 45:
					return "暗夜战斧";
				case 46:
					return "光之驱逐";
				case 47:
					return "邪影箭";
				case 48:
					return "木箱";
				case 49:
					return "再生饰带";
				case 50:
					return "魔镜";
				case 51:
					return "小丑之箭";
				case 52:
					return "天使雕像";
				case 53:
					return "云瓶";
				case 54:
					return "赫尔墨斯之靴";
				case 55:
					return "魔化回旋镖";
				case 56:
					return "魔金矿石";
				case 57:
					return "魔金锭";
				case 58:
					return "红心";
				case 59:
					return "污染之种";
				case 60:
					return "邪恶蘑菇";
				case 61:
					return "黑檀石块";
				case 62:
					return "草种";
				case 63:
					return "向日葵";
				case 64:
					return "邪恶荆棘";
				case 65:
					return "群星之怒";
				case 66:
					return "净化粉末";
				case 67:
					return "邪恶粉末";
				case 68:
					return "腐肉";
				case 69:
					return "蠕虫毒牙";
				case 70:
					return "蠕虫诱饵";
				case 71:
					return "铜币";
				case 72:
					return "银币";
				case 73:
					return "金币";
				case 74:
					return "铂金币";
				case 75:
					return "落星";
				case 76:
					return "铜质护胫";
				case 77:
					return "铁质护胫";
				case 78:
					return "白银护胫";
				case 79:
					return "黄金护胫";
				case 80:
					return "铜质链甲";
				case 81:
					return "铁质链甲";
				case 82:
					return "白银链甲";
				case 83:
					return "黄金链甲";
				case 84:
					return "钩爪";
				case 85:
					return "锁链";
				case 86:
					return "暗影鳞片";
				case 87:
					return "猪猪储蓄罐";
				case 88:
					return "矿工头盔";
				case 89:
					return "铜质头盔";
				case 90:
					return "铁质头盔";
				case 91:
					return "白银头盔";
				case 92:
					return "黄金头盔";
				case 93:
					return "木墙";
				case 94:
					return "木质平台";
				case 95:
					return "燧发枪";
				case 96:
					return "滑膛枪";
				case 97:
					return "枪弹";
				case 98:
					return "迷你鲨";
				case 99:
					return "铁质短弓";
				case 100:
					return "暗影护胫";
				case 101:
					return "暗影鳞甲";
				case 102:
					return "暗影头盔";
				case 103:
					return "噩梦镐";
				case 104:
					return "破坏者巨锤";
				case 105:
					return "蜡烛";
				case 106:
					return "铜质吊灯";
				case 107:
					return "白银吊灯";
				case 108:
					return "黄金吊灯";
				case 109:
					return "魔法水晶";
				case 110:
					return "弱效魔力药水";
				case 111:
					return "星能饰带";
				case 112:
					return "火焰花魔杖";
				case 113:
					return "魔法飞弹";
				case 114:
					return "泥土魔杖";
				case 115:
					return "暗影光球";
				case 116:
					return "陨铁矿石";
				case 117:
					return "陨铁锭";
				case 118:
					return "钩子";
				case 119:
					return "破空之炎";
				case 120:
					return "熔火之怒";
				case 121:
					return "炽焰巨剑";
				case 122:
					return "熔岩镐";
				case 123:
					return "陨星面甲";
				case 124:
					return "陨星胸甲";
				case 125:
					return "陨星护腿";
				case 126:
					return "瓶装水";
				case 127:
					return "空间枪";
				case 128:
					return "火箭靴";
				case 129:
					return "灰色砖块";
				case 130:
					return "灰色砖墙";
				case 131:
					return "红色砖块";
				case 132:
					return "红色砖墙";
				case 133:
					return "粘土块";
				case 134:
					return "蓝色砖块";
				case 135:
					return "蓝色砖墙";
				case 136:
					return "挂链吊灯";
				case 137:
					return "绿色砖块";
				case 138:
					return "绿色砖墙";
				case 139:
					return "粉红砖块";
				case 140:
					return "粉红砖墙";
				case 141:
					return "黄金砖块";
				case 142:
					return "黄金砖墙";
				case 143:
					return "白银砖块";
				case 144:
					return "白银砖墙";
				case 145:
					return "铜砖块";
				case 146:
					return "铜砖墙";
				case 147:
					return "金属尖刺";
				case 148:
					return "水蜡烛";
				case 149:
					return "书";
				case 150:
					return "蜘蛛网";
				case 151:
					return "死灵头盔";
				case 152:
					return "死灵胸甲";
				case 153:
					return "死灵胫甲";
				case 154:
					return "骨头";
				case 155:
					return "妖刀村正";
				case 156:
					return "钴盾";
				case 157:
					return "海蓝权杖";
				case 158:
					return "幸运马掌";
				case 159:
					return "闪亮红气球";
				case 160:
					return "鱼叉链枪";
				case 161:
					return "尖钉球";
				case 162:
					return "伤害链球";
				case 163:
					return "蓝月";
				case 164:
					return "手枪";
				case 165:
					return "水箭魔法书";
				case 166:
					return "炸弹";
				case 167:
					return "矿用雷管";
				case 168:
					return "手榴弹";
				case 169:
					return "沙块";
				case 170:
					return "玻璃";
				case 171:
					return "标牌";
				case 172:
					return "灰烬块";
				case 173:
					return "黑曜石";
				case 174:
					return "狱岩石";
				case 175:
					return "狱岩锭";
				case 176:
					return "淤泥块";
				case 177:
					return "蓝宝石";
				case 178:
					return "红宝石";
				case 179:
					return "祖母绿";
				case 180:
					return "黄晶玉";
				case 181:
					return "紫水晶";
				case 182:
					return "钻石";
				case 183:
					return "夜光蘑菇";
				case 184:
					return "魔力星";
				case 185:
					return "常春藤鞭";
				case 186:
					return "芦苇杆";
				case 187:
					return "脚蹼";
				case 188:
					return "治疗药水";
				case 189:
					return "魔力药水";
				case 190:
					return "草薙";
				case 191:
					return "荆棘旋刃";
				case 192:
					return "黑曜石砖块";
				case 193:
					return "黑曜石头颅";
				case 194:
					return "夜光蘑菇孢子";
				case 195:
					return "丛林草种";
				case 196:
					return "木锤";
				case 197:
					return "星辰炮";
				case 198:
					return "蓝相位剑";
				case 199:
					return "红相位剑";
				case 200:
					return "绿相位剑";
				case 201:
					return "紫相位剑";
				case 202:
					return "白相位剑";
				case 203:
					return "黄相位剑";
				case 204:
					return "陨星锤斧";
				case 205:
					return "空桶";
				case 206:
					return "装满水的桶";
				case 207:
					return "装满岩浆的桶";
				case 208:
					return "丛林玫瑰";
				case 209:
					return "蜂刺";
				case 210:
					return "藤条";
				case 211:
					return "狂野之爪";
				case 212:
					return "疾风脚镯";
				case 213:
					return "绿化法杖";
				case 214:
					return "狱岩砖";
				case 215:
					return "整人坐垫";
				case 216:
					return "镣铐";
				case 217:
					return "熔岩锤斧";
				case 218:
					return "烈焰火鞭";
				case 219:
					return "凤凰冲击波";
				case 220:
					return "阳炎之怒";
				case 221:
					return "地狱熔炉";
				case 222:
					return "粘土花盆";
				case 223:
					return "自然的恩赐";
				case 224:
					return "木床";
				case 225:
					return "丝绸";
				case 226:
					return "弱效回复药水";
				case 227:
					return "回复药水";
				case 228:
					return "丛林帽";
				case 229:
					return "丛林上衣";
				case 230:
					return "丛林裤";
				case 231:
					return "熔岩头盔";
				case 232:
					return "熔岩胸甲";
				case 233:
					return "熔岩护胫";
				case 234:
					return "陨星弹";
				case 235:
					return "粘性炸弹";
				case 236:
					return "黑色晶状体";
				case 237:
					return "墨镜";
				case 238:
					return "巫师帽";
				case 239:
					return "黑礼帽";
				case 240:
					return "黑礼服";
				case 241:
					return "礼服裤";
				case 242:
					return "太阳帽";
				case 243:
					return "兔子兜帽";
				case 244:
					return "马里奥帽子";
				case 245:
					return "马里奥上衣";
				case 246:
					return "马里奥背带裤";
				case 247:
					return "林克的帽子";
				case 248:
					return "林克的上衣";
				case 249:
					return "林克的裤子";
				case 250:
					return "鱼缸";
				case 251:
					return "考古学家的帽子";
				case 252:
					return "考古学家的上衣";
				case 253:
					return "考古学家的裤子";
				case 254:
					return "黑色丝线";
				case 255:
					return "绿色丝线";
				case 256:
					return "忍者面罩";
				case 257:
					return "忍者夜行衣";
				case 258:
					return "忍者紧身裤";
				case 259:
					return "皮革";
				case 260:
					return "红帽";
				case 261:
					return "金鱼";
				case 262:
					return "长袍";
				case 263:
					return "库特的机械帽";
				case 264:
					return "王冠";
				case 265:
					return "狱炎箭";
				case 266:
					return "沙枪";
				case 267:
					return "向导巫毒玩偶";
				case 268:
					return "潜水头盔";
				case 269:
					return "眼熟的上衣";
				case 270:
					return "眼熟的裤子";
				case 271:
					return "眼熟的假发";
				case 272:
					return "恶魔之镰";
				case 273:
					return "永夜之刃";
				case 274:
					return "暗黑长矛";
				case 275:
					return "珊瑚";
				case 276:
					return "仙人掌";
				case 277:
					return "三叉戟";
				case 278:
					return "银弹";
				case 279:
					return "飞刀";
				case 280:
					return "长矛";
				case 281:
					return "吹管";
				case 282:
					return "荧光棒";
				case 283:
					return "种子";
				case 284:
					return "木制回旋镖";
				case 285:
					return "敏捷扣链";
				case 286:
					return "粘性荧光棒";
				case 287:
					return "剧毒飞刀";
				case 288:
					return "黑曜石皮肤药剂";
				case 289:
					return "再生药剂";
				case 290:
					return "敏捷药剂";
				case 291:
					return "鱼鳃药剂";
				case 292:
					return "铁皮药剂";
				case 293:
					return "魔力恢复药剂";
				case 294:
					return "魔能药剂";
				case 295:
					return "羽落药剂";
				case 296:
					return "勘探药剂";
				case 297:
					return "隐身药剂";
				case 298:
					return "光芒药剂";
				case 299:
					return "夜视药剂";
				case 300:
					return "战争药剂";
				case 301:
					return "荆棘药剂";
				case 302:
					return "水上行走药剂";
				case 303:
					return "箭术药剂";
				case 304:
					return "狩猎药剂";
				case 305:
					return "重力药剂";
				case 306:
					return "黄金箱子";
				case 307:
					return "太阳花种";
				case 308:
					return "月光草种";
				case 309:
					return "闪耀根种";
				case 310:
					return "死亡草种";
				case 311:
					return "波浪叶种";
				case 312:
					return "火焰花种";
				case 313:
					return "太阳花";
				case 314:
					return "月光草";
				case 315:
					return "闪耀根";
				case 316:
					return "死亡草";
				case 317:
					return "波浪叶";
				case 318:
					return "火焰花";
				case 319:
					return "鲨鱼鳍";
				case 320:
					return "羽毛";
				case 321:
					return "墓碑";
				case 322:
					return "丑角面具";
				case 323:
					return "蚁狮上颚";
				case 324:
					return "非法枪械部件";
				case 325:
					return "博士上衣";
				case 326:
					return "博士长裤";
				case 327:
					return "黄金钥匙";
				case 328:
					return "暗影宝箱";
				case 329:
					return "暗影钥匙";
				case 330:
					return "黑曜石砖";
				case 331:
					return "丛林孢子";
				case 332:
					return "织布机";
				case 333:
					return "钢琴";
				case 334:
					return "梳妆台";
				case 335:
					return "长椅";
				case 336:
					return "浴缸";
				case 337:
					return "红色旗帜";
				case 338:
					return "绿色旗帜";
				case 339:
					return "蓝色旗帜";
				case 340:
					return "黄色旗帜";
				case 341:
					return "路灯";
				case 342:
					return "提基火炬";
				case 343:
					return "木桶";
				case 344:
					return "灯笼";
				case 345:
					return "烹饪锅";
				case 346:
					return "保险箱";
				case 347:
					return "颅骨烛台";
				case 348:
					return "垃圾箱";
				case 349:
					return "大烛台";
				case 350:
					return "粉红花瓶";
				case 351:
					return "酒杯";
				case 352:
					return "酒桶";
				case 353:
					return "麦酒";
				case 354:
					return "书架";
				case 355:
					return "王座";
				case 356:
					return "空碗";
				case 357:
					return "蘑菇鱼汤";
				case 358:
					return "马桶";
				case 359:
					return "老式摆钟";
				case 360:
					return "装甲雕像";
				case 361:
					return "哥布林战旗";
				case 362:
					return "破布";
				case 363:
					return "锯木台";
				case 364:
					return "钴蓝矿石";
				case 365:
					return "秘银矿石";
				case 366:
					return "精金矿石";
				case 367:
					return "星云之锤";
				case 368:
					return "神圣之剑";
				case 369:
					return "神圣之种";
				case 370:
					return "黑檀沙块";
				case 371:
					return "钴蓝罩帽";
				case 372:
					return "钴蓝轻盔";
				case 373:
					return "钴蓝面罩";
				case 374:
					return "钴蓝胸甲";
				case 375:
					return "钴蓝护腿";
				case 376:
					return "秘银兜帽";
				case 377:
					return "秘银重盔";
				case 378:
					return "秘银护帽";
				case 379:
					return "秘银链甲";
				case 380:
					return "秘银腿甲";
				case 381:
					return "钴蓝锭";
				case 382:
					return "秘银锭";
				case 383:
					return "钴蓝链锯";
				case 384:
					return "秘银链锯";
				case 385:
					return "钴蓝钻头";
				case 386:
					return "秘银钻头";
				case 387:
					return "精金链锯";
				case 388:
					return "精金钻头";
				case 389:
					return "无极";
				case 390:
					return "秘银长戟";
				case 391:
					return "精金锭";
				case 392:
					return "玻璃幕墙";
				case 393:
					return "罗盘";
				case 394:
					return "潜水装置";
				case 395:
					return "GPS";
				case 396:
					return "黑曜石马掌";
				case 397:
					return "黑曜石盾";
				case 398:
					return "工匠作坊";
				case 399:
					return "云气球";
				case 400:
					return "精金头饰";
				case 401:
					return "精金战盔";
				case 402:
					return "精金面罩";
				case 403:
					return "精金胸甲";
				case 404:
					return "精金胫甲";
				case 405:
					return "风火靴";
				case 406:
					return "精金长刀";
				case 407:
					return "工具包";
				case 408:
					return "珍珠沙块";
				case 409:
					return "珍珠岩块";
				case 410:
					return "矿工衬衫";
				case 411:
					return "矿工长裤";
				case 412:
					return "珍珠岩砖";
				case 413:
					return "荧光砖块";
				case 414:
					return "淤泥石块";
				case 415:
					return "钴蓝砖块";
				case 416:
					return "秘银砖块";
				case 417:
					return "珍珠岩墙";
				case 418:
					return "荧光砖墙";
				case 419:
					return "淤泥石墙";
				case 420:
					return "钴蓝砖墙";
				case 421:
					return "秘银砖墙";
				case 422:
					return "圣洁水瓶";
				case 423:
					return "邪恶水瓶";
				case 424:
					return "泥砂块";
				case 425:
					return "妖精铃铛";
				case 426:
					return "破坏者之刃";
				case 427:
					return "蓝色火把";
				case 428:
					return "红色火把";
				case 429:
					return "绿色火把";
				case 430:
					return "紫色火把";
				case 431:
					return "白色火把";
				case 432:
					return "黄色火把";
				case 433:
					return "恶魔火把";
				case 434:
					return "发条式突击步枪";
				case 435:
					return "钴蓝连发弩";
				case 436:
					return "秘银连发弩";
				case 437:
					return "双钩爪";
				case 438:
					return "星辰雕像";
				case 439:
					return "剑雕像";
				case 440:
					return "史莱姆雕像";
				case 441:
					return "哥布林雕像";
				case 442:
					return "盾牌雕像";
				case 443:
					return "蝙蝠雕像";
				case 444:
					return "金鱼雕像";
				case 445:
					return "兔子雕像";
				case 446:
					return "骷髅雕像";
				case 447:
					return "死神雕像";
				case 448:
					return "女性雕像";
				case 449:
					return "魔精雕像";
				case 450:
					return "石像鬼雕像";
				case 451:
					return "阴森雕像";
				case 452:
					return "毒蜂雕像";
				case 453:
					return "炸弹雕像";
				case 454:
					return "螃蟹雕像";
				case 455:
					return "锤子雕像";
				case 456:
					return "药瓶雕像";
				case 457:
					return "长矛雕像";
				case 458:
					return "十字架雕像";
				case 459:
					return "水母雕像";
				case 460:
					return "短弓雕像";
				case 461:
					return "回旋镖雕像";
				case 462:
					return "靴子雕像";
				case 463:
					return "宝箱雕像";
				case 464:
					return "小鸟雕像";
				case 465:
					return "斧头雕像";
				case 466:
					return "腐化雕像";
				case 467:
					return "树木雕像";
				case 468:
					return "铁砧雕像";
				case 469:
					return "锄头雕像";
				case 470:
					return "蘑菇雕像";
				case 471:
					return "眼球雕像";
				case 472:
					return "石柱雕像";
				case 473:
					return "心形雕像";
				case 474:
					return "陶罐雕像";
				case 475:
					return "向日葵雕像";
				case 476:
					return "国王雕像";
				case 477:
					return "王后雕像";
				case 478:
					return "食人鱼雕像";
				case 479:
					return "板条墙";
				case 480:
					return "木梁";
				case 481:
					return "精金连发弩";
				case 482:
					return "精金斩杀剑";
				case 483:
					return "钴蓝轻剑";
				case 484:
					return "秘银重剑";
				case 485:
					return "月光咒符";
				case 486:
					return "标尺";
				case 487:
					return "水晶球";
				case 488:
					return "镭射球灯";
				case 489:
					return "咒术纹章";
				case 490:
					return "勇士纹章";
				case 491:
					return "游侠纹章";
				case 492:
					return "恶魔翅膀";
				case 493:
					return "天使翅膀";
				case 494:
					return "魔法竖琴";
				case 495:
					return "彩虹魔杖";
				case 496:
					return "寒冰魔杖";
				case 497:
					return "海神贝壳";
				case 498:
					return "木质模型";
				case 499:
					return "强效治疗药水";
				case 500:
					return "强效魔力药水";
				case 501:
					return "精灵尘";
				case 502:
					return "碎魔晶";
				case 503:
					return "小丑帽";
				case 504:
					return "小丑服";
				case 505:
					return "小丑裤";
				case 506:
					return "火焰喷射器";
				case 507:
					return "铃铛";
				case 508:
					return "竖琴";
				case 509:
					return "红色扳手";
				case 510:
					return "剪线钳";
				case 511:
					return "机关石块";
				case 512:
					return "机关石墙";
				case 513:
					return "控制杆";
				case 514:
					return "光束枪";
				case 515:
					return "魔晶弹";
				case 516:
					return "神怒之箭";
				case 517:
					return "魔法飞刀";
				case 518:
					return "魔晶风暴";
				case 519:
					return "诅咒魔焰";
				case 520:
					return "光明之魂";
				case 521:
					return "暗影之魂";
				case 522:
					return "诅咒火焰";
				case 523:
					return "诅咒火把";
				case 524:
					return "精金熔炉";
				case 525:
					return "秘银砧";
				case 526:
					return "独角兽的角";
				case 527:
					return "太阴";
				case 528:
					return "纯阳";
				case 529:
					return "红色压力盘";
				case 530:
					return "导线";
				case 531:
					return "空白魔法书";
				case 532:
					return "星辰披风";
				case 533:
					return "巨兽鲨";
				case 534:
					return "霰弹枪";
				case 535:
					return "炼金石";
				case 536:
					return "泰坦手套";
				case 537:
					return "钴蓝薙刀";
				case 538:
					return "开关";
				case 539:
					return "毒箭机关";
				case 540:
					return "巨石";
				case 541:
					return "绿色压力盘";
				case 542:
					return "灰色压力盘";
				case 543:
					return "棕色压力盘";
				case 544:
					return "机械魔眼";
				case 545:
					return "咒火箭";
				case 546:
					return "咒火弹";
				case 547:
					return "恐惧之魂";
				case 548:
					return "力量之魂";
				case 549:
					return "视域之魂";
				case 550:
					return "永恒之枪";
				case 551:
					return "神圣板甲";
				case 552:
					return "神圣腿甲";
				case 553:
					return "神圣头盔";
				case 554:
					return "十字架项链";
				case 555:
					return "魔法的礼物";
				case 556:
					return "机械蠕虫";
				case 557:
					return "机械颅骨";
				case 558:
					return "神圣头饰";
				case 559:
					return "神圣面罩";
				case 560:
					return "史莱姆王冠";
				case 561:
					return "光辉飞盘";
				case 562:
					return "八音盒 (地表清晨)";
				case 563:
					return "八音盒 (恐惧)";
				case 564:
					return "八音盒 (黑夜)";
				case 565:
					return "八音盒 (世界初始)";
				case 566:
					return "八音盒 (地底)";
				case 567:
					return "八音盒 (全能窥视者)";
				case 568:
					return "八音盒 (丛林)";
				case 569:
					return "八音盒 (腐化蔓延)";
				case 570:
					return "八音盒 (黑暗地底)";
				case 571:
					return "八音盒 (圣域之歌)";
				case 572:
					return "八音盒 (世界毁灭者)";
				case 573:
					return "八音盒 (地底之光)";
				case 574:
					return "八音盒 (深渊之主)";
				case 575:
					return "飞翔之魂";
				case 576:
					return "八音盒";
				case 577:
					return "魔金砖块";
				case 578:
					return "神圣连发弩";
				case 579:
					return "神金钻头";
				case 580:
					return "TNT";
				case 581:
					return "入水泵";
				case 582:
					return "出水泵";
				case 583:
					return "1秒触发器";
				case 584:
					return "3秒触发器";
				case 585:
					return "5秒触发器";
				case 586:
					return "红色糖块";
				case 587:
					return "红色糖墙";
				case 588:
					return "圣诞帽";
				case 589:
					return "圣诞外套";
				case 590:
					return "圣诞绒裤";
				case 591:
					return "绿色糖块";
				case 592:
					return "绿色糖墙";
				case 593:
					return "雪块";
				case 594:
					return "雪砖块";
				case 595:
					return "雪砖墙";
				case 596:
					return "蓝灯";
				case 597:
					return "红灯";
				case 598:
					return "绿灯";
				case 599:
					return "蓝色圣诞礼物";
				case 600:
					return "绿色圣诞礼物";
				case 601:
					return "黄色圣诞礼物";
				case 602:
					return "雪球仪";
				case 603:
					return "胡萝卜";
				case 604:
					return "精金柱";
				case 605:
					return "精金柱墙";
				case 606:
					return "魔金砖墙";
				case 607:
					return "砂石砖块";
				case 608:
					return "砂石砖墙";
				case 609:
					return "黑檀砖块";
				case 610:
					return "黑檀砖墙";
				case 611:
					return "红色泥灰块";
				case 612:
					return "黄色泥灰块";
				case 613:
					return "绿色泥灰块";
				case 614:
					return "灰色泥灰块";
				case 615:
					return "红色泥灰墙";
				case 616:
					return "黄色泥灰墙";
				case 617:
					return "绿色泥灰墙";
				case 618:
					return "灰色泥灰墙";
				case 619:
					return "乌木";
				case 620:
					return "红木";
				case 621:
					return "珍珠木";
				case 622:
					return "乌木墙";
				case 623:
					return "红木墙";
				case 624:
					return "珍珠木墙";
				case 625:
					return "乌木箱";
				case 626:
					return "红木箱";
				case 627:
					return "珍珠木箱";
				case 628:
					return "乌木椅";
				case 629:
					return "红木椅";
				case 630:
					return "珍珠木椅";
				case 631:
					return "乌木平台";
				case 632:
					return "红木平台";
				case 633:
					return "珍珠木平台";
				case 634:
					return "骨质平台";
				case 635:
					return "乌木工作台";
				case 636:
					return "红木工作台";
				case 637:
					return "珍珠木工作台";
				case 638:
					return "乌木桌";
				case 639:
					return "红木桌";
				case 640:
					return "珍珠木桌";
				case 641:
					return "乌木钢琴";
				case 642:
					return "红木钢琴";
				case 643:
					return "珍珠木钢琴";
				case 644:
					return "乌木床";
				case 645:
					return "红木床";
				case 646:
					return "珍珠木床";
				case 647:
					return "乌木梳妆台";
				case 648:
					return "红木梳妆台";
				case 649:
					return "珍珠木梳妆台";
				case 650:
					return "乌木门";
				case 651:
					return "红木门";
				case 652:
					return "珍珠木门";
				case 653:
					return "乌木剑";
				case 654:
					return "乌木锤";
				case 655:
					return "乌木短弓";
				case 656:
					return "红木剑";
				case 657:
					return "红木锤";
				case 658:
					return "红木短弓";
				case 659:
					return "珍珠木剑";
				case 660:
					return "珍珠木锤";
				case 661:
					return "珍珠木短弓";
				case 662:
					return "彩虹砖块";
				case 663:
					return "彩虹砖墙";
				case 664:
					return "冰块";
				case 665:
					return "瑞德之翼";
				case 666:
					return "瑞德战盔";
				case 667:
					return "瑞德战甲";
				case 668:
					return "瑞德护胫";
				case 669:
					return "鱼饵";
				case 670:
					return "回旋冰刃";
				case 671:
					return "巨战匙刃";
				case 672:
					return "海盗弯刀";
				case 673:
					return "北地木工作台";
				case 674:
					return "觉醒·神圣之剑";
				case 675:
					return "觉醒·永夜之刃";
				case 676:
					return "冰霜巨剑";
				case 677:
					return "北地木桌子";
				case 678:
					return "猎魂之镰";
				case 679:
					return "战术霰弹枪";
				case 680:
					return "常春藤箱";
				case 681:
					return "冰晶宝箱";
				case 682:
					return "骸骨魔弓";
				case 683:
					return "邪恶三叉戟";
				case 684:
					return "冰霜头盔";
				case 685:
					return "冰霜战甲";
				case 686:
					return "冰霜胫甲";
				case 687:
					return "锡质头盔";
				case 688:
					return "锡质链甲";
				case 689:
					return "锡质护胫";
				case 690:
					return "铅质头盔";
				case 691:
					return "铅质链甲";
				case 692:
					return "铅质护胫";
				case 693:
					return "钨金头盔";
				case 694:
					return "钨金链甲";
				case 695:
					return "钨金护胫";
				case 696:
					return "铂金头盔";
				case 697:
					return "铂金链甲";
				case 698:
					return "铂金护胫";
				case 699:
					return "锡矿石";
				case 700:
					return "铅矿石";
				case 701:
					return "钨金矿石";
				case 702:
					return "铂金矿石";
				case 703:
					return "锡锭";
				case 704:
					return "铅锭";
				case 705:
					return "钨金锭";
				case 706:
					return "铂金锭";
				case 707:
					return "锡质怀表";
				case 708:
					return "钨金怀表";
				case 709:
					return "铂金怀表";
				case 710:
					return "锡质吊灯";
				case 711:
					return "铅质吊灯";
				case 712:
					return "铂金吊灯";
				case 713:
					return "铂金蜡烛";
				case 714:
					return "铂金烛台";
				case 715:
					return "铂金王冠";
				case 716:
					return "铅砧";
				case 717:
					return "锡砖块";
				case 718:
					return "钨金砖块";
				case 719:
					return "铂金砖块";
				case 720:
					return "锡砖墙";
				case 721:
					return "钨金砖墙";
				case 722:
					return "铂金砖墙";
				case 723:
					return "光刃波动剑";
				case 724:
					return "寒冰之刃";
				case 725:
					return "寒冰组合弓";
				case 726:
					return "极冰魔杖";
				case 727:
					return "木制头盔";
				case 728:
					return "木制胸甲";
				case 729:
					return "木制护腿";
				case 730:
					return "乌木头盔";
				case 731:
					return "乌木胸甲";
				case 732:
					return "乌木护腿";
				case 733:
					return "红木头盔";
				case 734:
					return "红木胸甲";
				case 735:
					return "红木护腿";
				case 736:
					return "珍珠木头盔";
				case 737:
					return "珍珠木胸甲";
				case 738:
					return "珍珠木护腿";
				case 739:
					return "紫晶魔杖";
				case 740:
					return "黄玉魔杖";
				case 741:
					return "冰蓝魔杖";
				case 742:
					return "翠绿魔杖";
				case 743:
					return "真红魔杖";
				case 744:
					return "钻石魔杖";
				case 745:
					return "草墙";
				case 746:
					return "丛林墙";
				case 747:
					return "花墙";
				case 748:
					return "喷气背包";
				case 749:
					return "蝶翼";
				case 750:
					return "仙人掌墙";
				case 751:
					return "白云";
				case 752:
					return "白云墙";
				case 753:
					return "海草";
				case 754:
					return "符文法帽";
				case 755:
					return "符文法袍";
				case 756:
					return "蘑菇长枪";
				case 757:
					return "泰拉之刃";
				case 758:
					return "榴弹发射器";
				case 759:
					return "火箭发射器";
				case 760:
					return "智能地雷发射器";
				case 761:
					return "精灵羽翼";
				case 762:
					return "史莱姆块";
				case 763:
					return "血肉块";
				case 764:
					return "蘑菇墙";
				case 765:
					return "积雨云";
				case 766:
					return "骸骨块";
				case 767:
					return "冰霜史莱姆块";
				case 768:
					return "骸骨墙壁";
				case 769:
					return "史莱姆墙";
				case 770:
					return "血肉墙";
				case 771:
					return "火箭弹 I型";
				case 772:
					return "火箭弹 II型";
				case 773:
					return "火箭弹 III型";
				case 774:
					return "火箭弹 IV型";
				case 775:
					return "沥青";
				case 776:
					return "钴蓝镐";
				case 777:
					return "秘银镐";
				case 778:
					return "精金镐";
				case 779:
					return "环境改造器";
				case 780:
					return "绿色溶剂";
				case 781:
					return "蓝色溶剂";
				case 782:
					return "紫色溶剂";
				case 783:
					return "深蓝溶剂";
				case 784:
					return "红色溶剂";
				case 785:
					return "女妖之翼";
				case 786:
					return "骸骨之翼";
				case 787:
					return "粉碎之锤";
				case 788:
					return "爆裂刺棘";
				case 789:
					return "圣十字旗帜";
				case 790:
					return "蝮蛇旗帜";
				case 791:
					return "欧米加旗帜";
				case 792:
					return "血腥头盔";
				case 793:
					return "血腥鳞甲";
				case 794:
					return "血腥胫甲";
				case 795:
					return "血腥屠戮者";
				case 796:
					return "血筋角弓";
				case 797:
					return "碎肉机";
				case 798:
					return "死亡代言人";
				case 799:
					return "嗜血战斧";
				case 800:
					return "送葬者";
				case 801:
					return "血肉之球";
				case 802:
					return "腐朽之刃";
				case 803:
					return "爱斯基摩兜帽";
				case 804:
					return "爱斯基摩外套";
				case 805:
					return "爱斯基摩绒裤";
				case 806:
					return "生命木椅";
				case 807:
					return "仙人掌椅";
				case 808:
					return "骸骨椅";
				case 809:
					return "血肉椅";
				case 810:
					return "蘑菇椅";
				case 811:
					return "白骨工作台";
				case 812:
					return "仙人掌工作台";
				case 813:
					return "血肉工作台";
				case 814:
					return "蘑菇工作台";
				case 815:
					return "史莱姆工作台";
				case 816:
					return "仙人掌门";
				case 817:
					return "血肉门";
				case 818:
					return "蘑菇门";
				case 819:
					return "生命木门";
				case 820:
					return "骸骨门";
				case 821:
					return "炽焰之翼";
				case 822:
					return "冰晶之翼";
				case 823:
					return "幽魂之翼";
				case 824:
					return "日耀砖块";
				case 825:
					return "舞厅彩墙";
				case 826:
					return "天空椅";
				case 827:
					return "骸骨桌";
				case 828:
					return "血肉桌";
				case 829:
					return "生命木桌";
				case 830:
					return "天空桌";
				case 831:
					return "生命木箱";
				case 832:
					return "生命之树魔杖";
				case 833:
					return "紫色冰块";
				case 834:
					return "粉红冰块";
				case 835:
					return "血红冰块";
				case 836:
					return "血腥石块";
				case 837:
					return "天空门";
				case 838:
					return "天空宝箱";
				case 839:
					return "蒸汽朋克帽";
				case 840:
					return "蒸汽朋克外套";
				case 841:
					return "蒸汽朋克长裤";
				case 842:
					return "蜜蜂帽";
				case 843:
					return "蜜蜂外套";
				case 844:
					return "蜜蜂裤";
				case 845:
					return "世界旗帜";
				case 846:
					return "太阳旗帜";
				case 847:
					return "重力旗帜";
				case 848:
					return "法老面具";
				case 849:
					return "促动器";
				case 850:
					return "蓝色扳手";
				case 851:
					return "绿色扳手";
				case 852:
					return "蓝色压力板";
				case 853:
					return "黄色压力板";
				case 854:
					return "打折卡";
				case 855:
					return "幸运硬币";
				case 856:
					return "独角兽的头";
				case 857:
					return "沙暴之瓶";
				case 858:
					return "北地木沙发";
				case 859:
					return "沙滩球";
				case 860:
					return "传说坠饰";
				case 861:
					return "月光贝壳";
				case 862:
					return "星辰项链";
				case 863:
					return "水上行走靴";
				case 864:
					return "三重冠";
				case 865:
					return "公主裙";
				case 866:
					return "法老长袍";
				case 867:
					return "绿帽子";
				case 868:
					return "蘑菇软帽";
				case 869:
					return "苏格兰圆帽";
				case 870:
					return "木乃伊面罩";
				case 871:
					return "木乃伊绑身";
				case 872:
					return "木乃伊绑腿";
				case 873:
					return "牛仔皮帽";
				case 874:
					return "牛仔夹克衫";
				case 875:
					return "牛仔皮裤";
				case 876:
					return "海盗帽";
				case 877:
					return "海盗大衣";
				case 878:
					return "海盗裤子";
				case 879:
					return "维京战盔";
				case 880:
					return "血腥矿石";
				case 881:
					return "仙人掌剑";
				case 882:
					return "仙人掌镐";
				case 883:
					return "冰砖块";
				case 884:
					return "冰砖墙";
				case 885:
					return "粘性绷带";
				case 886:
					return "盔甲抛光剂";
				case 887:
					return "牛黄";
				case 888:
					return "眼罩";
				case 889:
					return "快速时钟";
				case 890:
					return "超大话筒";
				case 891:
					return "贡品";
				case 892:
					return "维生素";
				case 893:
					return "折叠地图";
				case 894:
					return "仙人掌头盔";
				case 895:
					return "仙人掌胸甲";
				case 896:
					return "仙人掌护腿";
				case 897:
					return "力量手套";
				case 898:
					return "闪电靴";
				case 899:
					return "日曜石戒指";
				case 900:
					return "月曜石戒指";
				case 901:
					return "助推器";
				case 902:
					return "治疗绷带";
				case 903:
					return "计划书";
				case 904:
					return "驱咒圣诗";
				case 905:
					return "硬币枪";
				case 906:
					return "熔岩咒符";
				case 907:
					return "黑曜石水行靴";
				case 908:
					return "熔岩漫步者";
				case 909:
					return "纯净喷泉";
				case 910:
					return "沙漠喷泉";
				case 911:
					return "阴影木";
				case 912:
					return "阴影木门";
				case 913:
					return "阴影木平台";
				case 914:
					return "阴影木箱";
				case 915:
					return "阴影木椅";
				case 916:
					return "阴影木工作台";
				case 917:
					return "阴影木桌";
				case 918:
					return "阴影木梳妆台";
				case 919:
					return "阴影木钢琴";
				case 920:
					return "阴影木床";
				case 921:
					return "阴影木剑";
				case 922:
					return "阴影木锤";
				case 923:
					return "阴影木短弓";
				case 924:
					return "阴影木头盔";
				case 925:
					return "阴影木胸甲";
				case 926:
					return "阴影木护腿";
				case 927:
					return "阴影木墙";
				case 928:
					return "加农炮";
				case 929:
					return "加农炮弹";
				case 930:
					return "信号枪";
				case 931:
					return "信号弹";
				case 932:
					return "骸骨魔杖";
				case 933:
					return "绿叶魔杖";
				case 934:
					return "飞翔魔毯";
				case 935:
					return "复仇者纹章";
				case 936:
					return "机械手套";
				case 937:
					return "地雷";
				case 938:
					return "圣骑士之盾";
				case 939:
					return "蛛网悬索";
				case 940:
					return "丛林喷泉";
				case 941:
					return "冰雪喷泉";
				case 942:
					return "腐化喷泉";
				case 943:
					return "深红喷泉";
				case 944:
					return "神圣喷泉";
				case 945:
					return "鲜血喷泉";
				case 946:
					return "雨伞";
				case 947:
					return "叶绿矿石";
				case 948:
					return "蒸汽朋克翅膀";
				case 949:
					return "雪球";
				case 950:
					return "冰鞋";
				case 951:
					return "雪球发射器";
				case 952:
					return "蛛网宝箱";
				case 953:
					return "攀爬爪";
				case 954:
					return "古代铁盔";
				case 955:
					return "古代金盔";
				case 956:
					return "古代暗影头盔";
				case 957:
					return "古代暗影鳞甲";
				case 958:
					return "古代暗影护胫";
				case 959:
					return "古代死灵头盔";
				case 960:
					return "古代钴蓝头盔";
				case 961:
					return "古代钴蓝胸甲";
				case 962:
					return "古代钴蓝胫甲";
				case 963:
					return "黑色腰带";
				case 964:
					return "三管猎枪";
				case 965:
					return "绳子";
				case 966:
					return "篝火";
				case 967:
					return "棉花糖";
				case 968:
					return "棉花糖串";
				case 969:
					return "烤棉花糖";
				case 970:
					return "红色火箭烟花";
				case 971:
					return "绿色火箭烟花";
				case 972:
					return "蓝色火箭烟花";
				case 973:
					return "黄色火箭烟花";
				case 974:
					return "冰火把";
				case 975:
					return "鞋钉";
				case 976:
					return "虎爪";
				case 977:
					return "忍者缠足";
				case 978:
					return "粉色爱斯基摩兜帽";
				case 979:
					return "粉色爱斯基摩外套";
				case 980:
					return "粉色爱斯基摩绒裤";
				case 981:
					return "粉色丝线";
				case 982:
					return "魔力恢复饰带";
				case 983:
					return "沙暴气球";
				case 984:
					return "忍者的极意";
				case 985:
					return "绳圈";
				case 986:
					return "吹箭";
				case 987:
					return "暴雪之瓶";
				case 988:
					return "冰焰箭";
				case 989:
					return "魔化之刃";
				case 990:
					return "斧镐";
				case 991:
					return "钴蓝战斧";
				case 992:
					return "秘银战斧";
				case 993:
					return "精金战斧";
				case 994:
					return "噬魂之骨";
				case 995:
					return "自动搅拌机";
				case 996:
					return "绞肉机";
				case 997:
					return "精炼机";
				case 998:
					return "凝固机";
				case 999:
					return "琥珀";
				case 1000:
					return "彩纸枪";
				case 1001:
					return "叶绿刺盔";
				case 1002:
					return "叶绿翼盔";
				case 1003:
					return "叶绿权冠";
				case 1004:
					return "叶绿板甲";
				case 1005:
					return "叶绿胫甲";
				case 1006:
					return "叶绿锭";
				case 1007:
					return "红色染料";
				case 1008:
					return "橙色染料";
				case 1009:
					return "黄色染料";
				case 1010:
					return "橙绿染料";
				case 1011:
					return "绿色染料";
				case 1012:
					return "青色染料";
				case 1013:
					return "靛青染料";
				case 1014:
					return "淡蓝染料";
				case 1015:
					return "蓝色染料";
				case 1016:
					return "紫色染料";
				case 1017:
					return "淡紫染料";
				case 1018:
					return "粉色染料";
				case 1019:
					return "红间黑染料";
				case 1020:
					return "橙间黑染料";
				case 1021:
					return "黄间黑染料";
				case 1022:
					return "橙绿间黑染料";
				case 1023:
					return "绿间黑染料";
				case 1024:
					return "青间黑染料";
				case 1025:
					return "靛间黑染料";
				case 1026:
					return "淡蓝间黑染料";
				case 1027:
					return "蓝间黑染料";
				case 1028:
					return "紫间黑染料";
				case 1029:
					return "淡紫间染料";
				case 1030:
					return "粉间黑染料";
				case 1031:
					return "焰色染料";
				case 1032:
					return "黑焰染料";
				case 1033:
					return "绿焰染料";
				case 1034:
					return "绿间黑焰染料";
				case 1035:
					return "蓝焰染料";
				case 1036:
					return "蓝间黑焰染料";
				case 1037:
					return "银色染料";
				case 1038:
					return "亮红染料";
				case 1039:
					return "亮橙染料";
				case 1040:
					return "亮黄染料";
				case 1041:
					return "亮橙绿染料";
				case 1042:
					return "亮绿染料";
				case 1043:
					return "亮青染料";
				case 1044:
					return "亮靛青染料";
				case 1045:
					return "亮天蓝染料";
				case 1046:
					return "亮蓝染料";
				case 1047:
					return "亮紫染料";
				case 1048:
					return "亮淡紫染料";
				case 1049:
					return "亮粉染料";
				case 1050:
					return "黑色染料";
				case 1051:
					return "红间银染料";
				case 1052:
					return "橙间银染料";
				case 1053:
					return "黄间银染料";
				case 1054:
					return "橙绿间银染料";
				case 1055:
					return "绿间银染料";
				case 1056:
					return "青间银染料";
				case 1057:
					return "靛青间银染料";
				case 1058:
					return "天蓝间银染料";
				case 1059:
					return "蓝间银染料";
				case 1060:
					return "紫间银染料";
				case 1061:
					return "淡紫间银染料";
				case 1062:
					return "粉间银染料";
				case 1063:
					return "烈焰染料";
				case 1064:
					return "绿色烈焰染料";
				case 1065:
					return "蓝色烈焰染料";
				case 1066:
					return "彩虹染料";
				case 1067:
					return "亮丽彩虹染料";
				case 1068:
					return "黄色渐变染料";
				case 1069:
					return "青色渐变染料";
				case 1070:
					return "淡紫渐变染料";
				case 1071:
					return "涂料刷";
				case 1072:
					return "涂料滚筒";
				case 1073:
					return "红色涂料";
				case 1074:
					return "橙色涂料";
				case 1075:
					return "黄色涂料";
				case 1076:
					return "橙绿涂料";
				case 1077:
					return "绿色涂料";
				case 1078:
					return "青色涂料";
				case 1079:
					return "靛青涂料";
				case 1080:
					return "天蓝涂料";
				case 1081:
					return "蓝色涂料";
				case 1082:
					return "紫色涂料";
				case 1083:
					return "浅紫涂料";
				case 1084:
					return "粉色涂料";
				case 1085:
					return "深红涂料";
				case 1086:
					return "深橙涂料";
				case 1087:
					return "深黄涂料";
				case 1088:
					return "深橙绿涂料";
				case 1089:
					return "深绿涂料";
				case 1090:
					return "深青涂料";
				case 1091:
					return "深靛青涂料";
				case 1092:
					return "深天蓝涂料";
				case 1093:
					return "深蓝涂料";
				case 1094:
					return "深紫涂料";
				case 1095:
					return "暗紫涂料";
				case 1096:
					return "暗粉涂料";
				case 1097:
					return "黑色涂料";
				case 1098:
					return "白色涂料";
				case 1099:
					return "灰色涂料";
				case 1100:
					return "涂料刮刀";
				case 1101:
					return "神庙蜥蜴砖";
				case 1102:
					return "神庙蜥蜴砖墙";
				case 1103:
					return "雪砂块";
				case 1104:
					return "钯金矿石";
				case 1105:
					return "山铜矿石";
				case 1106:
					return "钛金矿";
				case 1107:
					return "青色蘑菇";
				case 1108:
					return "绿色蘑菇";
				case 1109:
					return "天蓝花";
				case 1110:
					return "黄万寿菊";
				case 1111:
					return "蓝莓";
				case 1112:
					return "橙绿海藻";
				case 1113:
					return "粉色仙人掌花";
				case 1114:
					return "橙血根";
				case 1115:
					return "红色甲壳";
				case 1116:
					return "靛青甲壳";
				case 1117:
					return "浅紫甲壳";
				case 1118:
					return "紫粘液";
				case 1119:
					return "黑墨水";
				case 1120:
					return "染缸";
				case 1121:
					return "蜜蜂枪";
				case 1122:
					return "魔化飞斧";
				case 1123:
					return "养蜂人";
				case 1124:
					return "蜂巢";
				case 1125:
					return "蜂蜜块";
				case 1126:
					return "蜂巢墙";
				case 1127:
					return "易碎蜂蜜块";
				case 1128:
					return "装满蜂蜜的桶";
				case 1129:
					return "蜂巢魔杖";
				case 1130:
					return "蜜蜂手榴弹";
				case 1131:
					return "重力球";
				case 1132:
					return "蜂窝";
				case 1133:
					return "蜜蜂分泌物";
				case 1134:
					return "瓶装蜂蜜";
				case 1135:
					return "雨帽";
				case 1136:
					return "雨衣";
				case 1137:
					return "神庙门";
				case 1138:
					return "地牢门";
				case 1139:
					return "铅门";
				case 1140:
					return "铁门";
				case 1141:
					return "神庙钥匙";
				case 1142:
					return "神庙宝箱";
				case 1143:
					return "神庙椅";
				case 1144:
					return "神庙桌";
				case 1145:
					return "神庙工作台";
				case 1146:
					return "神庙毒箭机关";
				case 1147:
					return "火焰机关";
				case 1148:
					return "刺球机关";
				case 1149:
					return "长矛机关";
				case 1150:
					return "木制尖刺";
				case 1151:
					return "神庙压力板";
				case 1152:
					return "蜥蜴雕像";
				case 1153:
					return "蜥蜴侦察兵雕像";
				case 1154:
					return "蜥蜴守卫雕像";
				case 1155:
					return "黄蜂枪";
				case 1156:
					return "钢铁食人鱼";
				case 1157:
					return "俾格米召唤法杖";
				case 1158:
					return "俾格米骨链";
				case 1159:
					return "提基面罩";
				case 1160:
					return "提基衬衫";
				case 1161:
					return "提基裤子";
				case 1162:
					return "绿叶翅膀";
				case 1163:
					return "沙暴气球";
				case 1164:
					return "气球束";
				case 1165:
					return "暗黑蝠翼";
				case 1166:
					return "白骨之剑";
				case 1167:
					return "力神甲虫";
				case 1168:
					return "烟雾弹";
				case 1169:
					return "白骨钥匙";
				case 1170:
					return "花蜜";
				case 1171:
					return "提基图腾柱";
				case 1172:
					return "蜥蜴卵";
				case 1173:
					return "墓牌";
				case 1174:
					return "十字墓牌";
				case 1175:
					return "十字墓碑";
				case 1176:
					return "墓碑";
				case 1177:
					return "方尖碑";
				case 1178:
					return "飞叶枪";
				case 1179:
					return "叶绿弹";
				case 1180:
					return "鹦鹉饼干";
				case 1181:
					return "怪异夜光蘑菇";
				case 1182:
					return "树苗";
				case 1183:
					return "瓶中精灵";
				case 1184:
					return "钯金锭";
				case 1185:
					return "钯金波刃剑";
				case 1186:
					return "钯金钩刃";
				case 1187:
					return "钯金连发弩";
				case 1188:
					return "钯金镐";
				case 1189:
					return "钯金钻头";
				case 1190:
					return "钯金链锯";
				case 1191:
					return "山铜锭";
				case 1192:
					return "山铜紫刃";
				case 1193:
					return "山铜长戟";
				case 1194:
					return "山铜连发弩";
				case 1195:
					return "山铜镐";
				case 1196:
					return "山铜钻头";
				case 1197:
					return "山铜链锯";
				case 1198:
					return "钛金锭";
				case 1199:
					return "钛金破刃剑";
				case 1200:
					return "钛金三叉戟";
				case 1201:
					return "钛金连发弩";
				case 1202:
					return "钛金镐";
				case 1203:
					return "钛金钻头";
				case 1204:
					return "钛金链锯";
				case 1205:
					return "钯金面罩";
				case 1206:
					return "钯金战盔";
				case 1207:
					return "钯金翼盔";
				case 1208:
					return "钯金胸甲";
				case 1209:
					return "钯金护胫";
				case 1210:
					return "山铜面罩";
				case 1211:
					return "山铜角盔";
				case 1212:
					return "山铜头冠";
				case 1213:
					return "山铜胸甲";
				case 1214:
					return "山铜胫甲";
				case 1215:
					return "钛金面罩";
				case 1216:
					return "钛金战盔";
				case 1217:
					return "钛金刺盔";
				case 1218:
					return "钛金胸甲";
				case 1219:
					return "钛金护胫";
				case 1220:
					return "山铜砧";
				case 1221:
					return "钛金熔炉";
				case 1222:
					return "钯金战斧";
				case 1223:
					return "山铜战斧";
				case 1224:
					return "钛金战斧";
				case 1225:
					return "神圣锭";
				case 1226:
					return "叶绿巨剑";
				case 1227:
					return "叶绿军刀";
				case 1228:
					return "叶绿帕提森钩刃";
				case 1229:
					return "叶绿连发弩";
				case 1230:
					return "叶绿镐";
				case 1231:
					return "叶绿钻头";
				case 1232:
					return "叶绿链锯";
				case 1233:
					return "叶绿巨斧";
				case 1234:
					return "叶绿战锤";
				case 1235:
					return "叶绿箭";
				case 1236:
					return "紫水晶钩爪";
				case 1237:
					return "黄晶玉钩爪";
				case 1238:
					return "蓝宝石钩爪";
				case 1239:
					return "祖母绿钩爪";
				case 1240:
					return "红宝石钩爪";
				case 1241:
					return "钻石钩爪";
				case 1242:
					return "琥珀蚊";
				case 1243:
					return "雨伞帽";
				case 1244:
					return "雷云法杖";
				case 1245:
					return "橙火把";
				case 1246:
					return "血腥沙块";
				case 1247:
					return "蜜蜂披风";
				case 1248:
					return "巨人之眼";
				case 1249:
					return "蜂蜜气球";
				case 1250:
					return "蓝马掌气球";
				case 1251:
					return "白马掌气球";
				case 1252:
					return "黄马掌气球";
				case 1253:
					return "冰霜龟甲";
				case 1254:
					return "狙击步枪";
				case 1255:
					return "金星马格南";
				case 1256:
					return "血云魔杖";
				case 1257:
					return "血腥锭";
				case 1258:
					return "毒刺发射器";
				case 1259:
					return "锦绣花团";
				case 1260:
					return "彩虹枪";
				case 1261:
					return "毒刺";
				case 1262:
					return "叶绿冲击锤";
				case 1263:
					return "传送器";
				case 1264:
					return "冰霜之花";
				case 1265:
					return "乌兹冲锋枪";
				case 1266:
					return "磁暴之球";
				case 1267:
					return "紫色玻璃墙";
				case 1268:
					return "黄色玻璃墙";
				case 1269:
					return "蓝色玻璃墙";
				case 1270:
					return "绿色玻璃墙";
				case 1271:
					return "红色玻璃墙";
				case 1272:
					return "多彩玻璃墙";
				case 1273:
					return "骷髅爪";
				case 1274:
					return "白骨头颅";
				case 1275:
					return "巴拉帽";
				case 1276:
					return "摇滚帽";
				case 1277:
					return "水手帽";
				case 1278:
					return "眼罩";
				case 1279:
					return "水手服";
				case 1280:
					return "水手裤";
				case 1281:
					return "骷髅面具";
				case 1282:
					return "紫水晶法袍";
				case 1283:
					return "黄晶玉法袍";
				case 1284:
					return "蓝宝石法袍";
				case 1285:
					return "祖母绿法袍";
				case 1286:
					return "红宝石法袍";
				case 1287:
					return "钻石法袍";
				case 1288:
					return "白礼服";
				case 1289:
					return "白礼服裤";
				case 1290:
					return "恐慌项链";
				case 1291:
					return "生命之果";
				case 1292:
					return "蜥蜴祭坛";
				case 1293:
					return "蜥蜴能量组件";
				case 1294:
					return "链锯镐";
				case 1295:
					return "热能射线";
				case 1296:
					return "大地法杖";
				case 1297:
					return "巨人之拳";
				case 1298:
					return "水华宝箱";
				case 1299:
					return "双筒望远镜";
				case 1300:
					return "步枪瞄准镜";
				case 1301:
					return "毁灭者纹章";
				case 1302:
					return "高速弹";
				case 1303:
					return "水母项链";
				case 1304:
					return "僵尸之爪";
				case 1305:
					return "电音吉他";
				case 1306:
					return "寒冰之镰";
				case 1307:
					return "裁缝巫毒玩偶";
				case 1308:
					return "剧毒法杖";
				case 1309:
					return "史莱姆法杖";
				case 1310:
					return "剧毒吹箭";
				case 1311:
					return "弹簧眼球";
				case 1312:
					return "玩具雪橇";
				case 1313:
					return "骷髅之书";
				case 1314:
					return "KO之拳";
				case 1315:
					return "藏宝图";
				case 1316:
					return "玄武战盔";
				case 1317:
					return "玄武鳞甲";
				case 1318:
					return "玄武护胫";
				case 1319:
					return "雪球炮";
				case 1320:
					return "骸骨镐";
				case 1321:
					return "魔法箭袋";
				case 1322:
					return "熔岩之石";
				case 1323:
					return "黑曜石玫瑰";
				case 1324:
					return "香蕉回旋镖";
				case 1325:
					return "链刃";
				case 1326:
					return "传送法杖";
				case 1327:
					return "死亡镰刀";
				case 1328:
					return "龟甲";
				case 1329:
					return "组织样本";
				case 1330:
					return "脊椎骨";
				case 1331:
					return "血腥脊柱";
				case 1332:
					return "脓血";
				case 1333:
					return "金血火把";
				case 1334:
					return "脓血之箭";
				case 1335:
					return "脓血子弹";
				case 1336:
					return "黄金喷头";
				case 1337:
					return "兔子大炮";
				case 1338:
					return "爆炸兔子";
				case 1339:
					return "小瓶毒液";
				case 1340:
					return "恶毒之瓶";
				case 1341:
					return "恶毒之箭";
				case 1342:
					return "恶毒子弹";
				case 1343:
					return "火焰手套";
				case 1344:
					return "齿轮";
				case 1345:
					return "彩纸";
				case 1346:
					return "纳米材料";
				case 1347:
					return "炸药粉";
				case 1348:
					return "砂金";
				case 1349:
					return "彩纸弹";
				case 1350:
					return "纳米子弹";
				case 1351:
					return "高爆弹";
				case 1352:
					return "金弹";
				case 1353:
					return "魔焰之瓶";
				case 1354:
					return "火焰之瓶";
				case 1355:
					return "黄金之瓶";
				case 1356:
					return "腐蚀之瓶";
				case 1357:
					return "混乱之瓶";
				case 1358:
					return "彩纸之瓶";
				case 1359:
					return "毒素之瓶";
				case 1360:
					return "荣耀之证 (克苏鲁之眼)";
				case 1361:
					return "荣耀之证 (世界吞噬者)";
				case 1362:
					return "荣耀之证 (克苏鲁之脑)";
				case 1363:
					return "荣耀之证 (骷髅王)";
				case 1364:
					return "荣耀之证 (蜂后)";
				case 1365:
					return "荣耀之证 (血肉之墙)";
				case 1366:
					return "荣耀之证 (钢铁破坏者)";
				case 1367:
					return "荣耀之证 (骷髅总理)";
				case 1368:
					return "荣耀之证 (镭射之眼)";
				case 1369:
					return "荣耀之证 (魔焰之眼)";
				case 1370:
					return "荣耀之证 (世纪之花)";
				case 1371:
					return "荣耀之证 (石巨人)";
				case 1372:
					return "血月升起";
				case 1373:
					return "倒吊人";
				case 1374:
					return "火之荣耀";
				case 1375:
					return "碎骨";
				case 1376:
					return "悬挂骷髅";
				case 1377:
					return "倒吊骷髅";
				case 1378:
					return "蓝色板墙";
				case 1379:
					return "蓝色瓷墙";
				case 1380:
					return "粉色板墙";
				case 1381:
					return "粉色瓷墙";
				case 1382:
					return "绿色板墙";
				case 1383:
					return "绿色瓷墙";
				case 1384:
					return "蓝砖平台";
				case 1385:
					return "粉砖平台";
				case 1386:
					return "绿砖平台";
				case 1387:
					return "金属架";
				case 1388:
					return "黄铜架";
				case 1389:
					return "木架";
				case 1390:
					return "黄铜吊灯";
				case 1391:
					return "笼灯";
				case 1392:
					return "提灯";
				case 1393:
					return "炼金吊灯";
				case 1394:
					return "符文灯";
				case 1395:
					return "骨质烛台";
				case 1396:
					return "蓝色地牢椅";
				case 1397:
					return "蓝色地牢桌";
				case 1398:
					return "蓝色地牢工作台";
				case 1399:
					return "绿色地牢椅";
				case 1400:
					return "绿色地牢桌";
				case 1401:
					return "绿色地牢工作台";
				case 1402:
					return "粉色地牢椅";
				case 1403:
					return "粉色地牢桌";
				case 1404:
					return "粉色地牢工作台";
				case 1405:
					return "蓝色地牢蜡烛";
				case 1406:
					return "绿色地牢蜡烛";
				case 1407:
					return "粉色地牢蜡烛";
				case 1408:
					return "蓝色地牢花瓶";
				case 1409:
					return "绿色地牢花瓶";
				case 1410:
					return "粉色地牢花瓶";
				case 1411:
					return "蓝色地牢门";
				case 1412:
					return "绿色地牢门";
				case 1413:
					return "粉色地牢门";
				case 1414:
					return "蓝色地牢书架";
				case 1415:
					return "绿色地牢书架";
				case 1416:
					return "粉色地牢书架";
				case 1417:
					return "地下墓场";
				case 1418:
					return "地牢石架";
				case 1419:
					return "碎骨头颅";
				case 1420:
					return "被诅咒的人";
				case 1421:
					return "邪眼的末日";
				case 1422:
					return "邪恶窥视";
				case 1423:
					return "双子魔眼的苏醒";
				case 1424:
					return "尖叫者";
				case 1425:
					return "玩扑克的哥布林";
				case 1426:
					return "树妖";
				case 1427:
					return "向日葵";
				case 1428:
					return "哥特式泰拉";
				case 1429:
					return "便帽";
				case 1430:
					return "药水灌输器";
				case 1431:
					return "星瓶";
				case 1432:
					return "弹壳";
				case 1433:
					return "冲击";
				case 1434:
					return "由鸟驱动";
				case 1435:
					return "钢铁毁灭者";
				case 1436:
					return "眼球的执着";
				case 1437:
					return "穿过圣域的独角兽";
				case 1438:
					return "巨浪";
				case 1439:
					return "星光之夜";
				case 1440:
					return "向导";
				case 1441:
					return "守护者的凝视";
				case 1442:
					return "父亲";
				case 1443:
					return "丽莎护士";
				case 1444:
					return "暗影射线法杖";
				case 1445:
					return "地狱火之叉";
				case 1446:
					return "幽魂法杖";
				case 1447:
					return "木质栅栏";
				case 1448:
					return "金属栅栏";
				case 1449:
					return "泡泡机";
				case 1450:
					return "泡泡杖";
				case 1451:
					return "天灾军团旗帜";
				case 1452:
					return "死灵法师标志";
				case 1453:
					return "锈骨战团旗帜";
				case 1454:
					return "钙帮帮徽";
				case 1455:
					return "燃烧军团战旗";
				case 1456:
					return "恶魔印章";
				case 1457:
					return "黑曜石平台";
				case 1458:
					return "黑曜石门";
				case 1459:
					return "黑曜石椅";
				case 1460:
					return "黑曜石桌";
				case 1461:
					return "黑曜石工作台";
				case 1462:
					return "黑曜石花瓶";
				case 1463:
					return "黑曜石书架";
				case 1464:
					return "地狱边界旗帜";
				case 1465:
					return "地狱锤旗帜";
				case 1466:
					return "地狱瞭望塔旗帜";
				case 1467:
					return "绝望旗帜";
				case 1468:
					return "黑曜石守望者旗帜";
				case 1469:
					return "岩浆喷发旗帜";
				case 1470:
					return "蓝色地牢床";
				case 1471:
					return "绿色地牢床";
				case 1472:
					return "红色地牢床";
				case 1473:
					return "黑曜石床";
				case 1474:
					return "规则";
				case 1475:
					return "黑暗";
				case 1476:
					return "暗魂收割者";
				case 1477:
					return "大地";
				case 1478:
					return "被困的幽灵";
				case 1479:
					return "恶魔之眼";
				case 1480:
					return "黄金的发现";
				case 1481:
					return "第一次相遇";
				case 1482:
					return "清爽的早晨";
				case 1483:
					return "地底宝藏";
				case 1484:
					return "窗外";
				case 1485:
					return "云外苍天";
				case 1486:
					return "别踩草坪";
				case 1487:
					return "冰原之河";
				case 1488:
					return "幽暗裂缝";
				case 1489:
					return "梦幻假象";
				case 1490:
					return "日光";
				case 1491:
					return "沙的秘辛";
				case 1492:
					return "活死人之地";
				case 1493:
					return "邪恶凝视";
				case 1494:
					return "天空守护者";
				case 1495:
					return "美洲炸药";
				case 1496:
					return "新发现";
				case 1497:
					return "顽强";
				case 1498:
					return "老矿工";
				case 1499:
					return "骷髅头";
				case 1500:
					return "面对克苏鲁之脑";
				case 1501:
					return "火焰之湖";
				case 1502:
					return "三英雄";
				case 1503:
					return "幽魂兜帽";
				case 1504:
					return "幽魂法衣";
				case 1505:
					return "幽魂法裤";
				case 1506:
					return "幽魂镐";
				case 1507:
					return "幽魂锤斧";
				case 1508:
					return "外质体";
				case 1509:
					return "哥特式木椅";
				case 1510:
					return "哥特式方桌";
				case 1511:
					return "哥特工作台";
				case 1512:
					return "哥特式书柜";
				case 1513:
					return "圣骑士之锤";
				case 1514:
					return "特警头盔";
				case 1515:
					return "蜂翅";
				case 1516:
					return "女妖羽毛";
				case 1517:
					return "白骨羽毛";
				case 1518:
					return "炽焰羽毛";
				case 1519:
					return "冰晶羽毛";
				case 1520:
					return "破损蝠翼";
				case 1521:
					return "破损蜂翅";
				case 1522:
					return "大紫水晶";
				case 1523:
					return "大黄晶玉";
				case 1524:
					return "大蓝宝石";
				case 1525:
					return "大祖母绿";
				case 1526:
					return "大红宝石";
				case 1527:
					return "大钻石";
				case 1528:
					return "丛林宝箱";
				case 1529:
					return "腐化宝箱";
				case 1530:
					return "血红宝箱";
				case 1531:
					return "神圣宝箱";
				case 1532:
					return "冰霜宝箱";
				case 1533:
					return "丛林钥匙";
				case 1534:
					return "腐化钥匙";
				case 1535:
					return "血腥钥匙";
				case 1536:
					return "神圣钥匙";
				case 1537:
					return "冰霜钥匙";
				case 1538:
					return "火魔精";
				case 1539:
					return "不祥之兆";
				case 1540:
					return "耀月";
				case 1541:
					return "鲜活之血";
				case 1542:
					return "流动的岩浆";
				case 1543:
					return "幽魂涂料刷";
				case 1544:
					return "幽魂涂料滚筒";
				case 1545:
					return "幽魂涂料刮刀";
				case 1546:
					return "蓝光头饰";
				case 1547:
					return "蓝光面具";
				case 1548:
					return "蓝光头盔";
				case 1549:
					return "蓝光胸甲";
				case 1550:
					return "蓝光护腿";
				case 1551:
					return "自动锻造机";
				case 1552:
					return "蘑菇锭";
				case 1553:
					return "S.D.M.G.";
				case 1554:
					return "Cenx的三重冠";
				case 1555:
					return "Cenx的胸甲";
				case 1556:
					return "Cenx的胫甲";
				case 1557:
					return "Crowno的面罩";
				case 1558:
					return "Crowno的胸甲";
				case 1559:
					return "Crowno的胫甲";
				case 1560:
					return "Will的头盔";
				case 1561:
					return "Will的胸甲";
				case 1562:
					return "Will的胫甲";
				case 1563:
					return "Jim的头盔";
				case 1564:
					return "Jim的胸甲";
				case 1565:
					return "Jim的胫甲";
				case 1566:
					return "Aaron的战盔";
				case 1567:
					return "Aaron的胸甲";
				case 1568:
					return "Aaron的胫甲";
				case 1569:
					return "吸血飞刀";
				case 1570:
					return "英雄断剑";
				case 1571:
					return "腐蚀咒怨";
				case 1572:
					return "冰霜龙头杖";
				case 1573:
					return "向导的诞生";
				case 1574:
					return "大商人";
				case 1575:
					return "克罗诺的午餐";
				case 1576:
					return "稀有魔物";
				case 1577:
					return "荣耀之夜";
				case 1578:
					return "甜心项链";
				case 1579:
					return "冰雪之靴";
				case 1580:
					return "D-Town的头盔";
				case 1581:
					return "D-Town的胸甲";
				case 1582:
					return "D-Town的胫甲";
				case 1583:
					return "D-Town的翅膀";
				case 1584:
					return "Will的翅膀";
				case 1585:
					return "Crowno的翅膀";
				case 1586:
					return "Cenx的翅膀";
				case 1587:
					return "Cenx的裙子";
				case 1588:
					return "Cenx的裤子";
				case 1589:
					return "钯金柱";
				case 1590:
					return "钯金墙壁";
				case 1591:
					return "泡泡糖块";
				case 1592:
					return "泡泡糖墙";
				case 1593:
					return "钛金石块";
				case 1594:
					return "钛金墙壁";
				case 1595:
					return "魔法手铐";
				case 1596:
					return "八音盒 (风雪)";
				case 1597:
					return "八音盒 (虚空)";
				case 1598:
					return "八音盒 (血腥之地)";
				case 1599:
					return "八音盒 (石巨人)";
				case 1600:
					return "八音盒 (白天)";
				case 1601:
					return "八音盒 (暴雨)";
				case 1602:
					return "八音盒 (冰原)";
				case 1603:
					return "八音盒 (沙漠)";
				case 1604:
					return "八音盒 (海洋)";
				case 1605:
					return "八音盒 (幽闭地牢)";
				case 1606:
					return "八音盒 (世纪之花)";
				case 1607:
					return "八音盒 (蜂后)";
				case 1608:
					return "八音盒 (丛林神庙)";
				case 1609:
					return "八音盒 (日食)";
				case 1610:
					return "八音盒 (夜光蘑菇园)";
				case 1611:
					return "蝴蝶尘";
				case 1612:
					return "圣十字护符";
				case 1613:
					return "圣十字护盾";
				case 1614:
					return "蓝色信号弹";
				case 1615:
					return "琵琶鱼旗帜";
				case 1616:
					return "愤怒雷云旗帜";
				case 1617:
					return "真菌甲虫旗帜";
				case 1618:
					return "蚁狮旗帜";
				case 1619:
					return "巨骨舌鱼旗帜";
				case 1620:
					return "装甲骷髅旗帜";
				case 1621:
					return "洞穴蝙蝠旗帜";
				case 1622:
					return "小鸟旗帜";
				case 1623:
					return "黑隐者旗帜";
				case 1624:
					return "血腥哺育者旗帜";
				case 1625:
					return "鲜血水母旗帜";
				case 1626:
					return "血腥爬行者旗帜";
				case 1627:
					return "骨蛇旗帜";
				case 1628:
					return "兔子旗帜";
				case 1629:
					return "混沌元素旗帜";
				case 1630:
					return "模仿者旗帜";
				case 1631:
					return "小丑旗帜";
				case 1632:
					return "腐化兔子旗帜";
				case 1633:
					return "腐化金鱼旗帜";
				case 1634:
					return "螃蟹旗帜";
				case 1635:
					return "血肉之虫旗帜";
				case 1636:
					return "血腥之斧旗帜";
				case 1637:
					return "诅咒圣锤旗帜";
				case 1638:
					return "恶魔旗帜";
				case 1639:
					return "恶魔之眼旗帜";
				case 1640:
					return "巨眼虫旗帜";
				case 1641:
					return "灵魂吞噬者旗帜";
				case 1642:
					return "魔化圣剑旗帜";
				case 1643:
					return "爱斯基摩僵尸旗帜";
				case 1644:
					return "巨脸怪旗帜";
				case 1645:
					return "浮空血魂旗帜";
				case 1646:
					return "飞鱼旗帜";
				case 1647:
					return "羽蛇旗帜";
				case 1648:
					return "科学怪人旗帜";
				case 1649:
					return "真菌囊泡旗帜";
				case 1650:
					return "真菌水母旗帜";
				case 1651:
					return "神圣蜗牛旗帜";
				case 1652:
					return "哥布林盗贼旗帜";
				case 1653:
					return "哥布林法师旗帜";
				case 1654:
					return "哥布林苦工旗帜";
				case 1655:
					return "哥布林斥候旗帜";
				case 1656:
					return "哥布林战士旗帜";
				case 1657:
					return "金鱼旗帜";
				case 1658:
					return "鹰身女妖旗帜";
				case 1659:
					return "地狱蝙蝠旗帜";
				case 1660:
					return "鲜血棘虫旗帜";
				case 1661:
					return "毒蜂旗帜";
				case 1662:
					return "冰元素旗帜";
				case 1663:
					return "寒冰鱼人旗帜";
				case 1664:
					return "火魔精旗帜";
				case 1665:
					return "蓝水母旗帜";
				case 1666:
					return "丛林爬行者旗帜";
				case 1667:
					return "蜥蜴旗帜";
				case 1668:
					return "食人花旗帜";
				case 1669:
					return "陨石怪旗帜";
				case 1670:
					return "毒蛾旗帜";
				case 1671:
					return "木乃伊旗帜";
				case 1672:
					return "真菌蜗牛旗帜";
				case 1673:
					return "鹦鹉旗帜";
				case 1674:
					return "剑齿亚龙旗帜";
				case 1675:
					return "食人鱼旗帜";
				case 1676:
					return "海盗水手旗帜";
				case 1677:
					return "小精灵旗帜";
				case 1678:
					return "雨衣僵尸旗帜";
				case 1679:
					return "收割者旗帜";
				case 1680:
					return "鲨鱼旗帜";
				case 1681:
					return "骷髅旗帜";
				case 1682:
					return "黑魔法师旗帜";
				case 1683:
					return "蓝色史莱姆旗帜";
				case 1684:
					return "雪球怪旗帜";
				case 1685:
					return "洞穴蜘蛛旗帜";
				case 1686:
					return "孢子僵尸旗帜";
				case 1687:
					return "沼泽魔怪旗帜";
				case 1688:
					return "巨大乌龟旗帜";
				case 1689:
					return "污泥怪旗帜";
				case 1690:
					return "雨伞史莱姆旗帜";
				case 1691:
					return "独角兽旗帜";
				case 1692:
					return "吸血鬼旗帜";
				case 1693:
					return "秃鹫旗帜";
				case 1694:
					return "染血女神旗帜";
				case 1695:
					return "狼人旗帜";
				case 1696:
					return "雪狼旗帜";
				case 1697:
					return "世界哺育者旗帜";
				case 1698:
					return "巨蠕虫旗帜";
				case 1699:
					return "幽灵旗帜";
				case 1700:
					return "虚空白龙旗帜";
				case 1701:
					return "僵尸旗帜";
				case 1702:
					return "玻璃平台";
				case 1703:
					return "玻璃椅";
				case 1704:
					return "黄金椅";
				case 1705:
					return "黄金马桶";
				case 1706:
					return "酒吧圆凳";
				case 1707:
					return "蜂蜜椅";
				case 1708:
					return "蒸汽朋克椅";
				case 1709:
					return "玻璃门";
				case 1710:
					return "黄金门";
				case 1711:
					return "蜂蜜门";
				case 1712:
					return "蒸汽朋克门";
				case 1713:
					return "玻璃桌";
				case 1714:
					return "宴会桌";
				case 1715:
					return "门闩";
				case 1716:
					return "黄金桌";
				case 1717:
					return "蜂蜜桌";
				case 1718:
					return "蒸汽朋克桌";
				case 1719:
					return "玻璃床";
				case 1720:
					return "黄金床";
				case 1721:
					return "蜂蜜床";
				case 1722:
					return "蒸汽朋克床";
				case 1723:
					return "生命木墙";
				case 1724:
					return "屁瓶";
				case 1725:
					return "南瓜";
				case 1726:
					return "南瓜墙";
				case 1727:
					return "干草";
				case 1728:
					return "干草墙";
				case 1729:
					return "幽灵木";
				case 1730:
					return "幽灵木墙";
				case 1731:
					return "南瓜头盔";
				case 1732:
					return "南瓜胸甲";
				case 1733:
					return "南瓜护胫";
				case 1734:
					return "糖苹果";
				case 1735:
					return "灵魂蛋糕";
				case 1736:
					return "护士帽";
				case 1737:
					return "护士服";
				case 1738:
					return "护士裤";
				case 1739:
					return "魔法师之帽";
				case 1740:
					return "欺诈者面具";
				case 1741:
					return "染料商长袍";
				case 1742:
					return "蒸汽朋克护目镜";
				case 1743:
					return "电子人头盔";
				case 1744:
					return "电子人上衣";
				case 1745:
					return "电子人裤子";
				case 1746:
					return "苦力怕面罩";
				case 1747:
					return "苦力怕外套";
				case 1748:
					return "苦力怕外裤";
				case 1749:
					return "猫面罩";
				case 1750:
					return "猫变装衣";
				case 1751:
					return "猫变装裤";
				case 1752:
					return "幽灵面罩";
				case 1753:
					return "幽灵裤";
				case 1754:
					return "南瓜面罩";
				case 1755:
					return "南瓜衣";
				case 1756:
					return "南瓜裤";
				case 1757:
					return "机器人帽子";
				case 1758:
					return "机器人上衣";
				case 1759:
					return "机器人裤子";
				case 1760:
					return "独角兽面罩";
				case 1761:
					return "独角兽上衣";
				case 1762:
					return "独角兽裤子";
				case 1763:
					return "吸血鬼面罩";
				case 1764:
					return "吸血鬼西服";
				case 1765:
					return "吸血鬼西裤";
				case 1766:
					return "女巫帽";
				case 1767:
					return "妖精帽";
				case 1768:
					return "妖精上衣";
				case 1769:
					return "妖精裤";
				case 1770:
					return "精灵上衣";
				case 1771:
					return "精灵裤子";
				case 1772:
					return "公主帽";
				case 1773:
					return "公主裙";
				case 1774:
					return "福袋";
				case 1775:
					return "女巫连衣裙";
				case 1776:
					return "女巫之靴";
				case 1777:
					return "科学怪人新娘面罩";
				case 1778:
					return "科学怪人新娘婚纱";
				case 1779:
					return "忍者神龟面具";
				case 1780:
					return "忍者神龟龟甲";
				case 1781:
					return "忍者神龟裤子";
				case 1782:
					return "糖豆机枪";
				case 1783:
					return "糖豆";
				case 1784:
					return "杰克爆弹发射器";
				case 1785:
					return "杰克爆弹";
				case 1786:
					return "镰刀";
				case 1787:
					return "南瓜派";
				case 1788:
					return "稻草人帽子";
				case 1789:
					return "稻草人上衣";
				case 1790:
					return "稻草人裤子";
				case 1791:
					return "大烹饪锅";
				case 1792:
					return "南瓜椅";
				case 1793:
					return "南瓜门";
				case 1794:
					return "南瓜桌子";
				case 1795:
					return "南瓜工作台";
				case 1796:
					return "南瓜平台";
				case 1797:
					return "残破精灵之翼";
				case 1798:
					return "蜘蛛卵";
				case 1799:
					return "魔法南瓜种子";
				case 1800:
					return "蝙蝠钩";
				case 1801:
					return "蝙蝠权杖";
				case 1802:
					return "黑鸦法杖";
				case 1803:
					return "丛林钥匙模具";
				case 1804:
					return "腐化钥匙模具";
				case 1805:
					return "血腥钥匙模具";
				case 1806:
					return "神圣钥匙模具";
				case 1807:
					return "冰霜钥匙模具";
				case 1808:
					return "倒吊南瓜杰克";
				case 1809:
					return "腐烂鸡蛋";
				case 1810:
					return "厄运线团";
				case 1811:
					return "黑色精灵尘";
				case 1812:
					return "南瓜吊灯";
				case 1813:
					return "南瓜杰克灯笼";
				case 1814:
					return "幽灵木椅";
				case 1815:
					return "幽灵木门";
				case 1816:
					return "幽灵木桌";
				case 1817:
					return "幽灵木工作台";
				case 1818:
					return "幽灵木平台";
				case 1819:
					return "死神兜帽";
				case 1820:
					return "死神长袍";
				case 1821:
					return "狐狸面罩";
				case 1822:
					return "狐狸皮衣";
				case 1823:
					return "狐狸皮裤";
				case 1824:
					return "猫耳";
				case 1825:
					return "鲜血屠刀";
				case 1826:
					return "无头骑士之刃";
				case 1827:
					return "拳刃";
				case 1828:
					return "南瓜种子";
				case 1829:
					return "幽灵钩爪";
				case 1830:
					return "幽灵之翼";
				case 1831:
					return "幽灵细枝";
				case 1832:
					return "幽灵木头盔";
				case 1833:
					return "幽灵木胸甲";
				case 1834:
					return "幽灵木护胫";
				case 1835:
					return "木桩发射器";
				case 1836:
					return "尖木桩";
				case 1837:
					return "诅咒树苗";
				case 1838:
					return "异形面罩";
				case 1839:
					return "异形上衣";
				case 1840:
					return "异形裤子";
				case 1841:
					return "狼人面罩";
				case 1842:
					return "狼人皮衣";
				case 1843:
					return "狼人皮裤";
				case 1844:
					return "万圣节奖章";
				case 1845:
					return "死灵卷轴";
				case 1846:
					return "南瓜骷髅杰克";
				case 1847:
					return "苦涩的收获";
				case 1848:
					return "血月女伯爵";
				case 1849:
					return "神圣之夜";
				case 1850:
					return "致命好奇心";
				case 1851:
					return "寻宝者上衣";
				case 1852:
					return "寻宝者裤子";
				case 1853:
					return "树妖饰带";
				case 1854:
					return "树妖缠带";
				case 1855:
					return "荣耀之证 (万圣树妖)";
				case 1856:
					return "荣耀之证 (南瓜)";
				case 1857:
					return "南瓜杰克面罩";
				case 1858:
					return "狙击镜";
				case 1859:
					return "心形吊灯";
				case 1860:
					return "水母潜水装置";
				case 1861:
					return "极地潜水装置";
				case 1862:
					return "冰霜火花之靴";
				case 1863:
					return "屁气球";
				case 1864:
					return "圣甲虫卷轴";
				case 1865:
					return "上界之石";
				case 1866:
					return "悬浮飞板";
				case 1867:
					return "棒棒糖";
				case 1868:
					return "甜梅";
				case 1869:
					return "圣诞礼物";
				case 1870:
					return "红色BB枪";
				case 1871:
					return "节日之翼";
				case 1872:
					return "松树块";
				case 1873:
					return "圣诞树";
				case 1874:
					return "圣诞星";
				case 1875:
					return "圣诞星";
				case 1876:
					return "圣诞星";
				case 1877:
					return "蝴蝶结顶花";
				case 1878:
					return "白色花环";
				case 1879:
					return "红白花环";
				case 1880:
					return "红色花环";
				case 1881:
					return "红绿花环";
				case 1882:
					return "绿色花环";
				case 1883:
					return "白绿花环";
				case 1884:
					return "彩色灯泡";
				case 1885:
					return "红色灯泡";
				case 1886:
					return "黄色灯泡";
				case 1887:
					return "绿色灯泡";
				case 1888:
					return "红绿灯泡";
				case 1889:
					return "黄绿灯泡";
				case 1890:
					return "红黄灯泡";
				case 1891:
					return "白色灯泡";
				case 1892:
					return "红白灯泡";
				case 1893:
					return "黄白灯泡";
				case 1894:
					return "白绿灯泡";
				case 1895:
					return "彩色彩灯";
				case 1896:
					return "红色彩灯";
				case 1897:
					return "绿色彩灯";
				case 1898:
					return "蓝色彩灯";
				case 1899:
					return "黄色彩灯";
				case 1900:
					return "红黄彩灯";
				case 1901:
					return "红绿彩灯";
				case 1902:
					return "黄绿彩灯";
				case 1903:
					return "蓝绿彩灯";
				case 1904:
					return "红蓝彩灯";
				case 1905:
					return "蓝黄彩灯";
				case 1906:
					return "蝴蝶结头饰";
				case 1907:
					return "驯鹿角";
				case 1908:
					return "冬青花环";
				case 1909:
					return "棒棒糖剑";
				case 1910:
					return "精灵喷火器";
				case 1911:
					return "圣诞布丁";
				case 1912:
					return "蛋奶酒";
				case 1913:
					return "八角茴香";
				case 1914:
					return "驯鹿铃铛";
				case 1915:
					return "棒棒糖钩";
				case 1916:
					return "圣诞钩爪";
				case 1917:
					return "棒棒糖镐";
				case 1918:
					return "水果蛋糕旋刃";
				case 1919:
					return "甜曲奇";
				case 1920:
					return "姜饼曲奇";
				case 1921:
					return "暖手宝";
				case 1922:
					return "煤";
				case 1923:
					return "工具箱";
				case 1924:
					return "松树木门";
				case 1925:
					return "松树木椅";
				case 1926:
					return "松树木桌";
				case 1927:
					return "狗哨";
				case 1928:
					return "圣诞树剑";
				case 1929:
					return "链条枪";
				case 1930:
					return "松叶快刀";
				case 1931:
					return "暴雪魔杖";
				case 1932:
					return "圣诞女士帽";
				case 1933:
					return "圣诞女士上衣";
				case 1934:
					return "圣诞女士高跟鞋";
				case 1935:
					return "防风兜帽";
				case 1936:
					return "防风外套";
				case 1937:
					return "防风绒裤";
				case 1938:
					return "雪帽";
				case 1939:
					return "难看毛衣";
				case 1940:
					return "圣诞树顶";
				case 1941:
					return "圣诞树叶";
				case 1942:
					return "圣诞树干";
				case 1943:
					return "精灵帽";
				case 1944:
					return "精灵衬衫";
				case 1945:
					return "精灵裤子";
				case 1946:
					return "雪人大炮";
				case 1947:
					return "北极";
				case 1948:
					return "圣诞树墙纸";
				case 1949:
					return "装饰墙纸";
				case 1950:
					return "棒棒糖墙纸";
				case 1951:
					return "节日墙纸";
				case 1952:
					return "星星墙纸";
				case 1953:
					return "波浪墙纸";
				case 1954:
					return "雪花墙纸";
				case 1955:
					return "坎普斯喇叭墙纸";
				case 1956:
					return "蓝绿墙纸";
				case 1957:
					return "圣诞精灵墙纸";
				case 1958:
					return "淘气礼物";
				case 1959:
					return "圣诞精灵宝宝的恶作剧口哨";
				case 1960:
					return "荣耀之证 (冰雪女王)";
				case 1961:
					return "荣耀之证 (圣诞坦克)";
				case 1962:
					return "荣耀之证 (尖叫圣诞树)";
				case 1963:
					return "音乐盒 (南瓜月)";
				case 1964:
					return "音乐盒 (精灵大陆)";
				case 1965:
					return "音乐盒 (霜月)";
				case 1966:
					return "棕色涂料";
				case 1967:
					return "阴影涂料";
				case 1968:
					return "反色涂料";
				case 1969:
					return "组别染料";
				case 1970:
					return "紫水晶砖";
				case 1971:
					return "黄晶玉砖";
				case 1972:
					return "蓝宝石砖";
				case 1973:
					return "绿宝石砖";
				case 1974:
					return "红宝石砖";
				case 1975:
					return "钻石砖";
				case 1976:
					return "琥珀砖";
				case 1977:
					return "生命染发剂";
				case 1978:
					return "法力染发剂";
				case 1979:
					return "深度染发剂";
				case 1980:
					return "土豪染发剂";
				case 1981:
					return "时间染发剂";
				case 1982:
					return "组别染发剂";
				case 1983:
					return "环境染发剂";
				case 1984:
					return "派对染发剂";
				case 1985:
					return "彩虹染发剂";
				case 1986:
					return "速度染发剂";
				case 1987:
					return "天使光环";
				case 1988:
					return "毡帽";
				case 1989:
					return "木质模型 (女)";
				case 1990:
					return "洗发水";
				case 1991:
					return "捕虫网";
				case 1992:
					return "萤火虫";
				case 1993:
					return "瓶中的萤火虫";
				case 1994:
					return "帝王蝶";
				case 1995:
					return "紫色帝王蝶";
				case 1996:
					return "赤蛱蝶";
				case 1997:
					return "天堂凤蝶";
				case 1998:
					return "菜粉蝶";
				case 1999:
					return "树若虫蝴蝶";
				case 2000:
					return "斑马燕尾蝶";
				case 2001:
					return "茱莉亚蝶";
				case 2002:
					return "蠕虫";
				case 2003:
					return "老鼠";
				case 2004:
					return "闪电萤火虫";
				case 2005:
					return "瓶中的闪电萤火虫";
				case 2006:
					return "蜗牛";
				case 2007:
					return "荧光蜗牛";
				case 2008:
					return "灰墙纸";
				case 2009:
					return "浮冰墙纸";
				case 2010:
					return "音乐墙纸";
				case 2011:
					return "紫雨墙纸";
				case 2012:
					return "彩虹墙纸";
				case 2013:
					return "闪光石墙纸";
				case 2014:
					return "星空墙纸";
				case 2015:
					return "鸟";
				case 2016:
					return "蓝鸟";
				case 2017:
					return "红鸟";
				case 2018:
					return "松鼠";
				case 2019:
					return "兔子";
				case 2020:
					return "仙人掌书架";
				case 2021:
					return "乌木书架";
				case 2022:
					return "血肉书架";
				case 2023:
					return "蜂蜜书架";
				case 2024:
					return "蒸汽朋克书架";
				case 2025:
					return "玻璃书架";
				case 2026:
					return "红木书架";
				case 2027:
					return "珍珠木书架";
				case 2028:
					return "幽灵木书架";
				case 2029:
					return "空岛书架";
				case 2030:
					return "神庙书架";
				case 2031:
					return "冰书架";
				case 2032:
					return "仙人掌灯笼";
				case 2033:
					return "乌木灯笼";
				case 2034:
					return "血肉灯笼";
				case 2035:
					return "蜂蜜灯笼";
				case 2036:
					return "蒸汽朋克灯笼";
				case 2037:
					return "玻璃灯笼";
				case 2038:
					return "红木灯笼";
				case 2039:
					return "珍珠木灯笼";
				case 2040:
					return "冰灯笼";
				case 2041:
					return "神庙灯笼";
				case 2042:
					return "空岛灯笼";
				case 2043:
					return "幽灵木灯笼";
				case 2044:
					return "冰门";
				case 2045:
					return "仙人掌蜡烛";
				case 2046:
					return "乌木蜡烛";
				case 2047:
					return "血肉蜡烛";
				case 2048:
					return "玻璃蜡烛";
				case 2049:
					return "冰蜡烛";
				case 2050:
					return "红木蜡烛";
				case 2051:
					return "珍珠木蜡烛";
				case 2052:
					return "神庙蜡烛";
				case 2053:
					return "空岛蜡烛";
				case 2054:
					return "南瓜蜡烛";
				case 2055:
					return "仙人掌吊灯";
				case 2056:
					return "乌木吊灯";
				case 2057:
					return "血肉吊灯";
				case 2058:
					return "蜂蜜吊灯";
				case 2059:
					return "冰吊灯";
				case 2060:
					return "红木吊灯";
				case 2061:
					return "珍珠木吊灯";
				case 2062:
					return "神庙吊灯";
				case 2063:
					return "空岛吊灯";
				case 2064:
					return "幽灵木吊灯";
				case 2065:
					return "玻璃吊灯";
				case 2066:
					return "仙人掌床";
				case 2067:
					return "血肉床";
				case 2068:
					return "冰床";
				case 2069:
					return "神庙床";
				case 2070:
					return "空岛床";
				case 2071:
					return "幽灵木床";
				case 2072:
					return "仙人掌浴缸";
				case 2073:
					return "乌木浴缸";
				case 2074:
					return "血肉浴缸";
				case 2075:
					return "玻璃浴缸";
				case 2076:
					return "冰浴缸";
				case 2077:
					return "红木浴缸";
				case 2078:
					return "珍珠木浴缸";
				case 2079:
					return "神庙浴缸";
				case 2080:
					return "空岛浴缸";
				case 2081:
					return "幽灵木浴缸";
				case 2082:
					return "仙人掌灯";
				case 2083:
					return "乌木灯";
				case 2084:
					return "血肉灯";
				case 2085:
					return "玻璃灯";
				case 2086:
					return "冰灯";
				case 2087:
					return "红木灯";
				case 2088:
					return "珍珠木灯";
				case 2089:
					return "神庙灯";
				case 2090:
					return "空岛灯";
				case 2091:
					return "幽灵木灯";
				case 2092:
					return "仙人掌烛台";
				case 2093:
					return "乌木烛台";
				case 2094:
					return "血肉烛台";
				case 2095:
					return "蜂蜜烛台";
				case 2096:
					return "蒸汽朋克烛台";
				case 2097:
					return "玻璃烛台";
				case 2098:
					return "红木烛台";
				case 2099:
					return "珍珠木烛台";
				case 2100:
					return "冰烛台";
				case 2101:
					return "神庙烛台";
				case 2102:
					return "空岛烛台";
				case 2103:
					return "幽灵木烛台";
				case 2104:
					return "克苏鲁之脑面具";
				case 2105:
					return "血肉之墙面具";
				case 2106:
					return "双子魔眼面具";
				case 2107:
					return "骷髅总理面具";
				case 2108:
					return "蜂后面具";
				case 2109:
					return "世纪之花面具";
				case 2110:
					return "石巨人面具";
				case 2111:
					return "世界吞噬者面具";
				case 2112:
					return "克苏鲁之眼面具";
				case 2113:
					return "钢铁破坏者面具";
				case 2114:
					return "铁匠架子";
				case 2115:
					return "木工架子";
				case 2116:
					return "头盔架子";
				case 2117:
					return "长矛架子";
				case 2118:
					return "宝剑架子";
				case 2119:
					return "石板";
				case 2120:
					return "沙石板";
				case 2121:
					return "青蛙";
				case 2122:
					return "野鸭";
				case 2123:
					return "鸭子";
				case 2124:
					return "蜂蜜浴缸";
				case 2125:
					return "蒸汽朋克浴缸";
				case 2126:
					return "生命之树浴缸";
				case 2127:
					return "阴影木浴缸";
				case 2128:
					return "骸骨浴缸";
				case 2129:
					return "蜂蜜灯";
				case 2130:
					return "蒸汽朋克灯";
				case 2131:
					return "生命之树灯";
				case 2132:
					return "阴影木灯";
				case 2133:
					return "黄金灯";
				case 2134:
					return "骸骨灯";
				case 2135:
					return "生命之树书架";
				case 2136:
					return "阴影木书架";
				case 2137:
					return "黄金书架";
				case 2138:
					return "骸骨书架";
				case 2139:
					return "生命之树床";
				case 2140:
					return "骸骨床";
				case 2141:
					return "生命之树吊灯";
				case 2142:
					return "阴影木吊灯";
				case 2143:
					return "黄金吊灯";
				case 2144:
					return "骸骨吊灯";
				case 2145:
					return "生命之树灯笼";
				case 2146:
					return "阴影木灯笼";
				case 2147:
					return "黄金灯笼";
				case 2148:
					return "骸骨灯笼";
				case 2149:
					return "生命之树烛台";
				case 2150:
					return "阴影木烛台";
				case 2151:
					return "黄金烛台";
				case 2152:
					return "骸骨烛台";
				case 2153:
					return "生命之树蜡烛";
				case 2154:
					return "阴影木蜡烛";
				case 2155:
					return "黄金蜡烛";
				case 2156:
					return "黑蝎子";
				case 2157:
					return "蝎子";
				case 2158:
					return "泡泡墙纸";
				case 2159:
					return "铜管墙纸";
				case 2160:
					return "小黄鸭墙纸";
				case 2161:
					return "冰冻核心";
				case 2162:
					return "兔子笼";
				case 2163:
					return "松鼠笼";
				case 2164:
					return "野鸭笼";
				case 2165:
					return "鸭笼";
				case 2166:
					return "鸟笼";
				case 2167:
					return "蓝鸟笼";
				case 2168:
					return "红鸲笼";
				case 2169:
					return "瀑布墙";
				case 2170:
					return "岩浆瀑布墙";
				case 2171:
					return "血腥种子";
				case 2172:
					return "重型工作台";
				case 2173:
					return "镀铜砖";
				case 2174:
					return "蜗牛箱";
				case 2175:
					return "荧光蜗牛箱";
				case 2176:
					return "蘑菇挖掘爪";
				case 2177:
					return "弹药箱";
				case 2178:
					return "帝王蝶罐";
				case 2179:
					return "紫色帝王蝶罐";
				case 2180:
					return "赤蛱蝶罐";
				case 2181:
					return "天堂凤蝶罐";
				case 2182:
					return "黄粉蝶罐";
				case 2183:
					return "树若虫蝴蝶罐";
				case 2184:
					return "斑纹燕尾蝶罐";
				case 2185:
					return "茱莉亚蝶罐";
				case 2186:
					return "蝎箱";
				case 2187:
					return "黑蝎箱";
				case 2188:
					return "猛毒法杖";
				case 2189:
					return "幽灵面具";
				case 2190:
					return "青蛙箱";
				case 2191:
					return "老鼠箱";
				case 2192:
					return "骸骨焊接机";
				case 2193:
					return "血肉培养基";
				case 2194:
					return "玻璃窑";
				case 2195:
					return "神庙熔炉";
				case 2196:
					return "生命织布机";
				case 2197:
					return "锯云台";
				case 2198:
					return "刨冰机";
				case 2199:
					return "甲虫头盔";
				case 2200:
					return "甲虫胸甲";
				case 2201:
					return "甲虫壳";
				case 2202:
					return "甲虫护胫";
				case 2203:
					return "蒸汽朋克锅炉";
				case 2204:
					return "蜂蜜分选器";
				case 2205:
					return "企鹅";
				case 2206:
					return "装着企鹅的笼子";
				case 2207:
					return "装着蠕虫的笼子";
				case 2208:
					return "空笼子";
				case 2209:
					return "超级法力药剂";
				case 2210:
					return "乌木栅栏";
				case 2211:
					return "红木栅栏";
				case 2212:
					return "珍珠木栅栏";
				case 2213:
					return "阴影木栅栏";
				case 2214:
					return "砖块摆放器";
				case 2215:
					return "加长握爪";
				case 2216:
					return "油漆喷雾器";
				case 2217:
					return "便携式水泥搅拌器";
				case 2218:
					return "甲虫鞘翅";
				case 2219:
					return "星体磁铁";
				case 2220:
					return "星体纹章";
				case 2221:
					return "星体手铐";
				case 2222:
					return "游商的帽子";
				case 2223:
					return "脉冲弓";
				case 2224:
					return "大号皇家木灯笼";
				case 2225:
					return "皇家木灯";
				case 2226:
					return "皇家木灯笼";
				case 2227:
					return "大号皇家木蜡烛";
				case 2228:
					return "皇家木椅子";
				case 2229:
					return "皇家木工作台";
				case 2230:
					return "皇家木箱子";
				case 2231:
					return "皇家木床";
				case 2232:
					return "皇家木浴缸";
				case 2233:
					return "皇家木书架";
				case 2234:
					return "皇家木杯子";
				case 2235:
					return "皇家木碗";
				case 2236:
					return "皇家木蜡烛";
				case 2237:
					return "皇家木老爷钟";
				case 2238:
					return "黄金老爷钟";
				case 2239:
					return "玻璃老爷钟";
				case 2240:
					return "蜂蜜老爷钟";
				case 2241:
					return "蒸汽朋克老爷钟";
				case 2242:
					return "精致的碟子";
				case 2243:
					return "玻璃碗";
				case 2244:
					return "高脚杯";
				case 2245:
					return "生命之树钢琴";
				case 2246:
					return "血肉钢琴";
				case 2247:
					return "冰钢琴";
				case 2248:
					return "冰桌子";
				case 2249:
					return "蜂蜜箱子";
				case 2250:
					return "蒸汽朋克箱子";
				case 2251:
					return "蜂蜜工作台";
				case 2252:
					return "冰工作台";
				case 2253:
					return "蒸汽朋克工作台";
				case 2254:
					return "玻璃钢琴";
				case 2255:
					return "蜂蜜钢琴";
				case 2256:
					return "蒸汽朋克钢琴";
				case 2257:
					return "蜂蜜杯子";
				case 2258:
					return "金杯";
				case 2259:
					return "皇家木桌子";
				case 2260:
					return "皇家木";
				case 2261:
					return "红皇家木瓦片";
				case 2262:
					return "蓝皇家木瓦片";
				case 2263:
					return "白皇家木墙";
				case 2264:
					return "蓝皇家木墙";
				case 2265:
					return "皇家木门";
				case 2266:
					return "清酒";
				case 2267:
					return "泰国河粉";
				case 2268:
					return "河粉";
				case 2269:
					return "左轮手枪";
				case 2270:
					return "鳄鱼枪";
				case 2271:
					return "符文墙";
				case 2272:
					return "水枪";
				case 2273:
					return "武士刀";
				case 2274:
					return "超亮火炬";
				case 2275:
					return "魔术帽";
				case 2276:
					return "钻石镯";
				case 2277:
					return "夜行衣";
				case 2278:
					return "和服";
				case 2279:
					return "吉卜赛长袍";
				case 2280:
					return "甲虫翼";
				case 2281:
					return "虎皮";
				case 2282:
					return "豹皮";
				case 2283:
					return "斑马皮";
				case 2284:
					return "血腥斗篷";
				case 2285:
					return "神秘斗篷";
				case 2286:
					return "红斗篷";
				case 2287:
					return "保暖斗篷";
				case 2288:
					return "冰椅子";
				case 2289:
					return "木质鱼竿";
				case 2290:
					return "鲈鱼";
				case 2291:
					return "强力鱼竿";
				case 2292:
					return "玻璃纤维鱼竿";
				case 2293:
					return "钓魂者";
				case 2294:
					return "黄金鱼竿";
				case 2295:
					return "机械鱼竿";
				case 2296:
					return "愿者上钩";
				case 2297:
					return "鳟鱼";
				case 2298:
					return "大马哈鱼";
				case 2299:
					return "大西洋鳕鱼";
				case 2300:
					return "金枪鱼";
				case 2301:
					return "红鲷";
				case 2302:
					return "霓虹脂鲤";
				case 2303:
					return "装甲洞穴鱼";
				case 2304:
					return "雀鲷";
				case 2305:
					return "深红虎鱼";
				case 2306:
					return "冰霜米诺鱼";
				case 2307:
					return "公主鱼";
				case 2308:
					return "金鲤";
				case 2309:
					return "镜鱼";
				case 2310:
					return "棱鱼";
				case 2311:
					return "斑斓脂鱼";
				case 2312:
					return "闪光锦鲤";
				case 2313:
					return "双头鳕鱼";
				case 2314:
					return "蜂蜜鱼";
				case 2315:
					return "黑曜石鱼";
				case 2316:
					return "小虾";
				case 2317:
					return "混沌鱼";
				case 2318:
					return "黑檀锦鲤";
				case 2319:
					return "血腥食人鱼";
				case 2320:
					return "岩石鱼";
				case 2321:
					return "臭臭鱼";
				case 2322:
					return "采矿药剂";
				case 2323:
					return "心之彼端";
				case 2324:
					return "镇静药剂";
				case 2325:
					return "建筑药剂";
				case 2326:
					return "泰坦药剂";
				case 2327:
					return "脚蹼药剂";
				case 2328:
					return "召唤药剂";
				case 2329:
					return "危险感知药剂";
				case 2330:
					return "紫色棒鱼";
				case 2331:
					return "黑曜石剑鱼";
				case 2332:
					return "剑鱼";
				case 2333:
					return "铁栅栏";
				case 2334:
					return "木制板条箱";
				case 2335:
					return "铁制板条箱";
				case 2336:
					return "金制板条箱";
				case 2337:
					return "旧鞋子";
				case 2338:
					return "海草";
				case 2339:
					return "锡罐";
				case 2340:
					return "矿车轨道";
				case 2341:
					return "掠夺鲨";
				case 2342:
					return "锯齿鲨";
				case 2343:
					return "矿车";
				case 2344:
					return "军火药剂";
				case 2345:
					return "生命之力药剂";
				case 2346:
					return "忍耐药剂";
				case 2347:
					return "狂暴药剂";
				case 2348:
					return "地狱降临药剂";
				case 2349:
					return "暴怒药剂";
				case 2350:
					return "回程药剂";
				case 2351:
					return "随机传送药剂";
				case 2352:
					return "爱情药剂";
				case 2353:
					return "恶臭药剂";
				case 2354:
					return "钓鱼药剂";
				case 2355:
					return "声呐药剂";
				case 2356:
					return "板条箱药剂";
				case 2357:
					return "颤栗荆棘种子";
				case 2358:
					return "颤栗荆棘";
				case 2359:
					return "温暖药剂";
				case 2360:
					return "鱼钩";
				case 2361:
					return "蜜蜂头饰";
				case 2362:
					return "蜜蜂胸甲";
				case 2363:
					return "蜜蜂护胫";
				case 2364:
					return "毒蜂法杖";
				case 2365:
					return "魔精法杖";
				case 2366:
					return "蜘蛛女皇法杖";
				case 2367:
					return "渔人帽";
				case 2368:
					return "渔人背心";
				case 2369:
					return "渔人裤";
				case 2370:
					return "蜘蛛面罩";
				case 2371:
					return "蜘蛛胸甲";
				case 2372:
					return "蜘蛛胫甲";
				case 2373:
					return "高质渔线";
				case 2374:
					return "渔人耳环";
				case 2375:
					return "垂钓装备";
				case 2376:
					return "蓝色地牢钢琴";
				case 2377:
					return "绿色地牢钢琴";
				case 2378:
					return "粉红地牢钢琴";
				case 2379:
					return "黄金钢琴";
				case 2380:
					return "黑曜石钢琴";
				case 2381:
					return "骨质钢琴";
				case 2382:
					return "仙人掌钢琴";
				case 2383:
					return "幽灵木钢琴";
				case 2384:
					return "天空钢琴";
				case 2385:
					return "神庙钢琴";
				case 2386:
					return "蓝色地牢梳妆台";
				case 2387:
					return "绿色地牢梳妆台";
				case 2388:
					return "粉色地牢梳妆台";
				case 2389:
					return "黄金梳妆台";
				case 2390:
					return "黑曜石梳妆台";
				case 2391:
					return "骨质梳妆台";
				case 2392:
					return "仙人掌梳妆台";
				case 2393:
					return "幽灵木梳妆台";
				case 2394:
					return "天空梳妆台";
				case 2395:
					return "蜂蜜梳妆台";
				case 2396:
					return "神庙梳妆台";
				case 2397:
					return "沙发";
				case 2398:
					return "乌木沙发";
				case 2399:
					return "红木沙发";
				case 2400:
					return "珍珠木沙发";
				case 2401:
					return "阴影木沙发";
				case 2402:
					return "蓝色地牢沙发";
				case 2403:
					return "绿色地牢沙发";
				case 2404:
					return "粉色地牢沙发";
				case 2405:
					return "黄金沙发";
				case 2406:
					return "黑曜石沙发";
				case 2407:
					return "骨质沙发";
				case 2408:
					return "仙人掌沙发";
				case 2409:
					return "幽灵木沙发";
				case 2410:
					return "天空沙发";
				case 2411:
					return "蜂蜜沙发";
				case 2412:
					return "蒸汽朋克沙发";
				case 2413:
					return "蘑菇沙发";
				case 2414:
					return "玻璃沙发";
				case 2415:
					return "南瓜沙发";
				case 2416:
					return "神庙沙发";
				case 2417:
					return "贝壳发夹";
				case 2418:
					return "人鱼饰衣";
				case 2419:
					return "人鱼尾巴";
				case 2420:
					return "微风鱼";
				case 2421:
					return "血肉捕获者";
				case 2422:
					return "热线鱼竿";
				case 2423:
					return "蛙腿";
				case 2424:
					return "铁锚";
				case 2425:
					return "红烧鱼";
				case 2426:
					return "油焖虾";
				case 2427:
					return "生鱼片";
				case 2428:
					return "绒毛胡萝卜";
				case 2429:
					return "鳞片松露";
				case 2430:
					return "史莱姆鞍";
				case 2431:
					return "蜜蜡";
				case 2432:
					return "铜板墙";
				case 2433:
					return "石板墙";
				case 2434:
					return "帆布";
				case 2435:
					return "珊瑚块";
				case 2436:
					return "蓝水母";
				case 2437:
					return "绿水母";
				case 2438:
					return "粉水母";
				case 2439:
					return "蓝水母缸";
				case 2440:
					return "绿水母缸";
				case 2441:
					return "粉水母缸";
				case 2442:
					return "救生圈";
				case 2443:
					return "船舵";
				case 2444:
					return "罗经刻度盘";
				case 2445:
					return "墙锚";
				case 2446:
					return "金鱼挂饰";
				case 2447:
					return "兔鱼挂饰";
				case 2448:
					return "剑鱼挂饰";
				case 2449:
					return "荣耀之证 (鲨齿)";
				case 2450:
					return "蝙蝠鱼";
				case 2451:
					return "黄蜂鱼";
				case 2452:
					return "猫鱼";
				case 2453:
					return "白云鱼";
				case 2454:
					return "咒火鱼";
				case 2455:
					return "泥土鱼";
				case 2456:
					return "雷管鱼";
				case 2457:
					return "吞噬鱼";
				case 2458:
					return "落星鱼";
				case 2459:
					return "克苏鲁之鱼";
				case 2460:
					return "骸骨鱼";
				case 2461:
					return "鹰身女妖鱼";
				case 2462:
					return "饥饿鱼";
				case 2463:
					return "脓血鱼";
				case 2464:
					return "水母鱼";
				case 2465:
					return "幻影鱼";
				case 2466:
					return "变种雪球鱼";
				case 2467:
					return "海豚鱼";
				case 2468:
					return "精灵鱼";
				case 2469:
					return "蜘蛛鱼";
				case 2470:
					return "冻土鳟鱼";
				case 2471:
					return "独角兽鱼";
				case 2472:
					return "向导巫毒鱼";
				case 2473:
					return "龙尾鱼";
				case 2474:
					return "僵尸鱼";
				case 2475:
					return "毒菌鱼";
				case 2476:
					return "天使鱼";
				case 2477:
					return "鲜血水母";
				case 2478:
					return "骸骨鱼";
				case 2479:
					return "兔鱼";
				case 2480:
					return "海盗鱼";
				case 2481:
					return "小丑鱼";
				case 2482:
					return "地狱恶魔鱼";
				case 2483:
					return "巨眼鱼";
				case 2484:
					return "猪鲨";
				case 2485:
					return "被感染的带鱼";
				case 2486:
					return "淤泥鱼";
				case 2487:
					return "史莱姆鱼";
				case 2488:
					return "热带梭鱼";
				case 2489:
					return "荣耀之证 (史莱姆王)";
				case 2490:
					return "瓶中船";
				case 2491:
					return "海龟鞍";
				case 2492:
					return "压力板轨道";
				case 2493:
					return "史莱姆王面具";
				case 2494:
					return "鱼鳍翅膀";
				case 2495:
					return "藏宝图";
				case 2496:
					return "海草花坛";
				case 2497:
					return "给我去抢像素";
				case 2498:
					return "鱼面具";
				case 2499:
					return "鱼衬衫";
				case 2500:
					return "鱼鳍裤";
				case 2501:
					return "橙黄胡须";
				case 2502:
					return "蜂蜜护目镜";
				case 2503:
					return "北地之木";
				case 2504:
					return "棕榈木";
				case 2505:
					return "北地木墙";
				case 2506:
					return "棕榈木墙";
				case 2507:
					return "北地木栅栏";
				case 2508:
					return "棕榈木栅栏";
				case 2509:
					return "北地木头盔";
				case 2510:
					return "北地木胸甲";
				case 2511:
					return "北地木护胫";
				case 2512:
					return "棕榈木头盔";
				case 2513:
					return "棕榈木胸甲";
				case 2514:
					return "棕榈木护胫";
				case 2515:
					return "棕榈木弓";
				case 2516:
					return "棕榈木锤";
				case 2517:
					return "棕榈木剑";
				case 2518:
					return "棕榈木平台";
				case 2519:
					return "棕榈木浴缸";
				case 2520:
					return "棕榈木床";
				case 2521:
					return "棕榈木长椅";
				case 2522:
					return "棕榈木烛台";
				case 2523:
					return "棕榈木蜡烛";
				case 2524:
					return "棕榈木椅";
				case 2525:
					return "棕榈木吊灯";
				case 2526:
					return "棕榈木箱";
				case 2527:
					return "棕榈木沙发";
				case 2528:
					return "棕榈木门";
				case 2529:
					return "棕榈木梳妆台";
				case 2530:
					return "棕榈木灯笼";
				case 2531:
					return "棕榈木钢琴";
				case 2532:
					return "棕榈木桌";
				case 2533:
					return "棕榈木路灯";
				case 2534:
					return "棕榈木工作台";
				case 2535:
					return "魔眼法杖";
				case 2536:
					return "棕榈木书柜";
				case 2537:
					return "蘑菇浴缸";
				case 2538:
					return "蘑菇床";
				case 2539:
					return "蘑菇长椅";
				case 2540:
					return "蘑菇书架";
				case 2541:
					return "蘑菇烛台";
				case 2542:
					return "蘑菇蜡烛";
				case 2543:
					return "蘑菇吊灯";
				case 2544:
					return "蘑菇箱";
				case 2545:
					return "蘑菇梳妆台";
				case 2546:
					return "蘑菇灯笼";
				case 2547:
					return "蘑菇路灯";
				case 2548:
					return "蘑菇钢琴";
				case 2549:
					return "蘑菇平台";
				case 2550:
					return "蘑菇桌";
				case 2551:
					return "蜘蛛魔杖";
				case 2552:
					return "北地木浴缸";
				case 2553:
					return "北地木床";
				case 2554:
					return "北地木书柜";
				case 2555:
					return "北地木烛台";
				case 2556:
					return "北地木蜡烛";
				case 2557:
					return "北地木椅";
				case 2558:
					return "北地木吊灯";
				case 2559:
					return "北地木箱";
				case 2560:
					return "北地木时钟";
				case 2561:
					return "北地木门";
				case 2562:
					return "北地木梳妆台";
				case 2563:
					return "北地木路灯";
				case 2564:
					return "北地灯笼";
				case 2565:
					return "北地木钢琴";
				case 2566:
					return "北地木平台";
				case 2567:
					return "史莱姆浴缸";
				case 2568:
					return "史莱姆床";
				case 2569:
					return "史莱姆书架";
				case 2570:
					return "史莱姆烛台";
				case 2571:
					return "史莱姆蜡烛";
				case 2572:
					return "史莱姆椅";
				case 2573:
					return "史莱姆吊灯";
				case 2574:
					return "史莱姆箱";
				case 2575:
					return "史莱姆时钟";
				case 2576:
					return "史莱姆门";
				case 2577:
					return "史莱姆梳妆台";
				case 2578:
					return "史莱姆路灯";
				case 2579:
					return "史莱姆灯笼";
				case 2580:
					return "史莱姆钢琴";
				case 2581:
					return "史莱姆平台";
				case 2582:
					return "史莱姆沙发";
				case 2583:
					return "史莱姆桌子";
				case 2584:
					return "海盗法杖";
				case 2585:
					return "史莱姆";
				case 2586:
					return "粘性手雷";
				case 2587:
					return "鞑靼酱汁";
				case 2588:
					return "猪鲨公爵面具";
				case 2589:
					return "荣耀之证 (猪鲨公爵)";
				case 2590:
					return "莫洛托夫鸡尾酒";
				case 2591:
					return "白骨时钟";
				case 2592:
					return "仙人掌时钟";
				case 2593:
					return "乌木时钟";
				case 2594:
					return "冰霜时钟";
				case 2595:
					return "神庙时钟";
				case 2596:
					return "生命木时钟";
				case 2597:
					return "红木时钟";
				case 2598:
					return "血肉时钟";
				case 2599:
					return "蘑菇时钟";
				case 2600:
					return "黑曜石时钟";
				case 2601:
					return "棕榈木时钟";
				case 2602:
					return "珍珠木时钟";
				case 2603:
					return "南瓜时钟";
				case 2604:
					return "阴影木时钟";
				case 2605:
					return "幽灵木时钟";
				case 2606:
					return "日耀时钟";
				case 2607:
					return "蜘蛛毒牙";
				case 2608:
					return "猎鹰之刃";
				case 2609:
					return "猪鲨翅膀";
				case 2610:
					return "史莱姆枪";
				case 2611:
					return "猪鲨链球";
				case 2612:
					return "绿色地牢箱";
				case 2613:
					return "粉色地牢箱";
				case 2614:
					return "蓝色地牢箱";
				case 2615:
					return "白骨箱";
				case 2616:
					return "仙人掌箱";
				case 2617:
					return "血肉箱";
				case 2618:
					return "黑曜石箱";
				case 2619:
					return "南瓜箱";
				case 2620:
					return "幽灵木箱";
				case 2621:
					return "风暴法杖";
				case 2622:
					return "水刃龙卷";
				case 2623:
					return "泡泡枪";
				case 2624:
					return "海啸";
				case 2625:
					return "贝壳";
				case 2626:
					return "海星";
				case 2627:
					return "蒸汽朋克平台";
				case 2628:
					return "天空平台";
				case 2629:
					return "生命木平台";
				case 2630:
					return "蜂蜜平台";
				case 2631:
					return "天空工作台";
				case 2632:
					return "玻璃工作台";
				case 2633:
					return "生命木工作台";
				case 2634:
					return "血肉沙发";
				case 2635:
					return "冰霜沙发";
				case 2636:
					return "生命木沙发";
				case 2637:
					return "南瓜梳妆台";
				case 2638:
					return "蒸汽朋克梳妆台";
				case 2639:
					return "玻璃梳妆台";
				case 2640:
					return "血肉梳妆台";
				case 2641:
					return "南瓜灯笼";
				case 2642:
					return "黑曜石灯笼";
				case 2643:
					return "南瓜路灯";
				case 2644:
					return "黑曜石路灯";
				case 2645:
					return "蓝色地牢路灯";
				case 2646:
					return "绿色地牢路灯";
				case 2647:
					return "粉色地牢路灯";
				case 2648:
					return "蜂蜜蜡烛";
				case 2649:
					return "蒸汽朋克蜡烛";
				case 2650:
					return "幽灵木蜡烛";
				case 2651:
					return "黑曜石蜡烛";
				case 2652:
					return "蓝色地牢灯笼";
				case 2653:
					return "绿色地牢灯笼";
				case 2654:
					return "粉色地牢灯笼";
				case 2655:
					return "蒸汽朋克灯笼";
				case 2656:
					return "南瓜灯笼";
				case 2657:
					return "黑曜石灯笼";
				case 2658:
					return "蓝色地牢浴缸";
				case 2659:
					return "绿色地牢浴缸";
				case 2660:
					return "粉色地牢浴缸";
				case 2661:
					return "南瓜浴缸";
				case 2662:
					return "黑曜石浴缸";
				case 2663:
					return "黄金浴缸";
				case 2664:
					return "蓝色地牢烛台";
				case 2665:
					return "绿色地牢烛台";
				case 2666:
					return "粉色地牢烛台";
				case 2667:
					return "黑曜石烛台";
				case 2668:
					return "南瓜烛台";
				case 2669:
					return "南瓜床";
				case 2670:
					return "南瓜书架";
				case 2671:
					return "南瓜钢琴";
				case 2672:
					return "鲨鱼雕像";
				case 2673:
					return "松露虫";
				case 2674:
					return "学徒鱼饵";
				case 2675:
					return "旅人鱼饵";
				case 2676:
					return "大师鱼饵";
				case 2677:
					return "琥珀墙";
				case 2678:
					return "暗淡琥珀墙";
				case 2679:
					return "紫水晶墙";
				case 2680:
					return "暗淡紫水晶墙";
				case 2681:
					return "钻石墙";
				case 2682:
					return "暗淡钻石墙";
				case 2683:
					return "祖母绿墙";
				case 2684:
					return "暗淡祖母绿墙";
				case 2685:
					return "红宝石墙";
				case 2686:
					return "暗淡红宝石墙";
				case 2687:
					return "蓝宝石墙";
				case 2688:
					return "暗淡蓝宝石墙";
				case 2689:
					return "黄晶玉墙";
				case 2690:
					return "暗淡黄晶玉墙";
				case 2691:
					return "锡板墙";
				case 2692:
					return "锡板";
				case 2693:
					return "瀑布块";
				case 2694:
					return "岩浆瀑布块";
				case 2695:
					return "彩纸块";
				case 2696:
					return "彩纸墙";
				case 2697:
					return "黑夜彩纸块";
				case 2698:
					return "黑夜彩纸墙";
				case 2699:
					return "武器架";
				case 2700:
					return "焰火盒";
				case 2701:
					return "灵火块";
				case 2702:
					return "雕像'0'";
				case 2703:
					return "雕像'1'";
				case 2704:
					return "雕像'2'";
				case 2705:
					return "雕像'3'";
				case 2706:
					return "雕像'4'";
				case 2707:
					return "雕像'5'";
				case 2708:
					return "雕像'6'";
				case 2709:
					return "雕像'7'";
				case 2710:
					return "雕像'8'";
				case 2711:
					return "雕像'9'";
				case 2712:
					return "雕像'A'";
				case 2713:
					return "雕像'B'";
				case 2714:
					return "雕像'C'";
				case 2715:
					return "雕像'D'";
				case 2716:
					return "雕像'E'";
				case 2717:
					return "雕像'F'";
				case 2718:
					return "雕像'G'";
				case 2719:
					return "雕像'H'";
				case 2720:
					return "雕像'I'";
				case 2721:
					return "雕像'J'";
				case 2722:
					return "雕像'K'";
				case 2723:
					return "雕像'L'";
				case 2724:
					return "雕像'M'";
				case 2725:
					return "雕像'N'";
				case 2726:
					return "雕像'O'";
				case 2727:
					return "雕像'P'";
				case 2728:
					return "雕像'Q'";
				case 2729:
					return "雕像'R'";
				case 2730:
					return "雕像'S'";
				case 2731:
					return "雕像'T'";
				case 2732:
					return "雕像'U'";
				case 2733:
					return "雕像'V'";
				case 2734:
					return "雕像'W'";
				case 2735:
					return "雕像'X'";
				case 2736:
					return "雕像'Y'";
				case 2737:
					return "雕像'Z'";
				case 2738:
					return "焰火喷泉";
				case 2739:
					return "加速轨道";
				case 2740:
					return "蚱蜢";
				case 2741:
					return "蚱蜢笼";
				case 2742:
					return "音乐盒 (血色地底)";
				case 2743:
					return "仙人掌桌";
				case 2744:
					return "仙人掌平台";
				case 2745:
					return "北地木剑";
				case 2746:
					return "北地木锤";
				case 2747:
					return "北地木弓";
				case 2748:
					return "玻璃箱子";
				case 2749:
					return "异星魔杖";
				case 2750:
					return "陨石魔杖";
				case 2751:
					return "诅咒灵火块";
				case 2752:
					return "恶魔灵火块";
				case 2753:
					return "寒霜灵火块";
				case 2754:
					return "脓血灵火块";
				case 2755:
					return "超亮灵火块";
				case 2756:
					return "变性药剂";
				case 2757:
					return "漩涡头盔";
				case 2758:
					return "漩涡胸甲";
				case 2759:
					return "漩涡护胫";
				case 2760:
					return "星云头盔";
				case 2761:
					return "星云胸甲";
				case 2762:
					return "星云护胫";
				case 2763:
					return "日耀头盔";
				case 2764:
					return "日耀胸甲";
				case 2765:
					return "日耀护胫";
				case 2766:
					return "日光石板碎片";
				case 2767:
					return "日光石板";
				case 2768:
					return "钻机控制元件";
				case 2769:
					return "UFO钥匙";
				case 2770:
					return "摩斯拉之翼";
				case 2771:
					return "大脑扰频器";
				case 2772:
					return "漩涡斧头";
				case 2773:
					return "漩涡链锯";
				case 2774:
					return "漩涡钻头";
				case 2775:
					return "漩涡锤子";
				case 2776:
					return "漩涡镐";
				case 2777:
					return "星云斧头";
				case 2778:
					return "星云链锯";
				case 2779:
					return "星云钻头";
				case 2780:
					return "星云锤子";
				case 2781:
					return "星云镐";
				case 2782:
					return "日耀斧头";
				case 2783:
					return "日耀链锯";
				case 2784:
					return "日耀钻头";
				case 2785:
					return "日耀锤子";
				case 2786:
					return "日耀镐";
				case 2787:
					return "蜂蜜瀑布块";
				case 2788:
					return "蜂蜜瀑布墙";
				case 2789:
					return "叶绿砖块墙";
				case 2790:
					return "血腥砖墙";
				case 2791:
					return "蘑菇板墙";
				case 2792:
					return "叶绿砖块";
				case 2793:
					return "血腥砖块";
				case 2794:
					return "蘑菇砖块";
				case 2795:
					return "激光机关枪";
				case 2796:
					return "电子球发射器";
				case 2797:
					return "异星泡泡枪";
				case 2798:
					return "激光钻头";
				case 2799:
					return "机械尺子";
				case 2800:
					return "反重力勾爪";
				case 2801:
					return "月亮面罩";
				case 2802:
					return "太阳面罩";
				case 2803:
					return "火星变装面罩";
				case 2804:
					return "火星变装衬衫";
				case 2805:
					return "火星变装裤子";
				case 2806:
					return "火星制服头盔";
				case 2807:
					return "火星制服上衣";
				case 2808:
					return "火星制服裤子";
				case 2809:
					return "火星航天时钟";
				case 2810:
					return "火星澡盆";
				case 2811:
					return "火星床";
				case 2812:
					return "火星悬浮椅";
				case 2813:
					return "火星吊灯";
				case 2814:
					return "火星箱子";
				case 2815:
					return "火星门";
				case 2816:
					return "火星梳妆台";
				case 2817:
					return "火星全息书架";
				case 2818:
					return "火星悬浮蜡烛";
				case 2819:
					return "火星灯";
				case 2820:
					return "火星灯笼";
				case 2821:
					return "火星钢琴";
				case 2822:
					return "火星平台";
				case 2823:
					return "火星沙发";
				case 2824:
					return "火星桌";
				case 2825:
					return "火星桌灯";
				case 2826:
					return "火星工作台";
				case 2827:
					return "木质水槽";
				case 2828:
					return "黑檀木水槽";
				case 2829:
					return "红木水槽";
				case 2830:
					return "珍珠木水槽";
				case 2831:
					return "白骨水槽";
				case 2832:
					return "血肉水槽";
				case 2833:
					return "生命木水槽";
				case 2834:
					return "天空水槽";
				case 2835:
					return "阴影木水槽";
				case 2836:
					return "蜥蜴水槽";
				case 2837:
					return "蓝色地牢水槽";
				case 2838:
					return "绿色地牢水槽";
				case 2839:
					return "粉色地牢水槽";
				case 2840:
					return "黑曜石水槽";
				case 2841:
					return "金属水槽";
				case 2842:
					return "玻璃水槽";
				case 2843:
					return "黄金水槽";
				case 2844:
					return "蜂蜜水槽";
				case 2845:
					return "蒸汽朋克水槽";
				case 2846:
					return "南瓜水槽";
				case 2847:
					return "阴森水槽";
				case 2848:
					return "冰霜水槽";
				case 2849:
					return "皇家水槽";
				case 2850:
					return "棕榈木水槽";
				case 2851:
					return "蘑菇水槽";
				case 2852:
					return "北地木水槽";
				case 2853:
					return "史莱姆水槽";
				case 2854:
					return "仙人掌水槽";
				case 2855:
					return "火星水槽";
				case 2856:
					return "太阳信徒兜帽";
				case 2857:
					return "月亮信徒兜帽";
				case 2858:
					return "太阳信徒长袍";
				case 2859:
					return "月亮信徒长袍";
				case 2860:
					return "火星合金砖";
				case 2861:
					return "火星合金砖墙";
				case 2862:
					return "高科技太阳镜";
				case 2863:
					return "火星染发剂";
				case 2864:
					return "火星染料";
				case 2865:
					return "马斯伯格城堡";
				case 2866:
					return "火星的蒙娜丽莎";
				case 2867:
					return "真相就在这里";
				case 2868:
					return "烟雾块";
				case 2869:
					return "生命之火染料";
				case 2870:
					return "生命彩虹染料";
				case 2871:
					return "暗影染料";
				case 2872:
					return "反色染料";
				case 2873:
					return "生命海洋染料";
				case 2874:
					return "棕色染料";
				case 2875:
					return "棕黑染料";
				case 2876:
					return "亮棕染料";
				case 2877:
					return "棕银染料";
				case 2878:
					return "瓶中灵染料";
				case 2879:
					return "小精灵染料";
				case 2880:
					return "光流波动剑";
				case 2881:
					return "相位折叠喷射器";
				case 2882:
					return "充能加农炮";
				case 2883:
					return "叶绿染料";
				case 2884:
					return "独角兽精灵染料";
				case 2885:
					return "地狱精灵染料";
				case 2886:
					return "邪恶粉末";
				case 2887:
					return "邪恶蘑菇";
				case 2888:
					return "蜂膝弓";
				case 2889:
					return "黄金鸟";
				case 2890:
					return "黄金兔子";
				case 2891:
					return "黄金蝴蝶";
				case 2892:
					return "黄金青蛙";
				case 2893:
					return "黄金蚱蜢";
				case 2894:
					return "黄金老鼠";
				case 2895:
					return "黄金蠕虫";
				case 2896:
					return "粘性炸药";
				case 2897:
					return "愤怒捕猎者旗帜";
				case 2898:
					return "装甲维京骷髅旗帜";
				case 2899:
					return "黑色史莱姆旗帜";
				case 2900:
					return "蓝色装甲骷髅旗帜";
				case 2901:
					return "蓝色教徒弓手旗帜";
				case 2902:
					return "蓝色教徒法师旗帜";
				case 2903:
					return "蓝色教徒战士旗帜";
				case 2904:
					return "李小髅旗帜";
				case 2905:
					return "黏着者旗帜";
				case 2906:
					return "胭脂甲虫旗帜";
				case 2907:
					return "腐化企鹅旗帜";
				case 2908:
					return "腐化史莱姆旗帜";
				case 2909:
					return "腐化者旗帜";
				case 2910:
					return "血腥史莱姆旗帜";
				case 2911:
					return "被诅咒的骷髅旗帜";
				case 2912:
					return "靛青甲虫旗帜";
				case 2913:
					return "挖掘者旗帜";
				case 2914:
					return "信魔者旗帜";
				case 2915:
					return "骷髅博士旗帜";
				case 2916:
					return "地牢史莱姆旗帜";
				case 2917:
					return "地牢幽魂旗帜";
				case 2918:
					return "妖精弓箭手旗帜";
				case 2919:
					return "妖精直升机旗帜";
				case 2920:
					return "眼魔僵尸旗帜";
				case 2921:
					return "圣诞雪花旗帜";
				case 2922:
					return "鬼魂旗帜";
				case 2923:
					return "巨大蝙蝠旗帜";
				case 2924:
					return "巨大诅咒头骨旗帜";
				case 2925:
					return "巨大飞狐旗帜";
				case 2926:
					return "姜饼人旗帜";
				case 2927:
					return "哥布林弓箭手旗帜";
				case 2928:
					return "绿色史莱姆旗帜";
				case 2929:
					return "无头骑士旗帜";
				case 2930:
					return "地狱装甲骷髅旗帜";
				case 2931:
					return "地狱犬旗帜";
				case 2932:
					return "弹跳杰克旗帜";
				case 2933:
					return "冰霜蝙蝠旗帜";
				case 2934:
					return "冰霜巨人旗帜";
				case 2935:
					return "冰霜史莱姆旗帜";
				case 2936:
					return "脓血乌贼旗帜";
				case 2937:
					return "荧光蝙蝠旗帜";
				case 2938:
					return "荧光史莱姆旗帜";
				case 2939:
					return "丛林蝙蝠旗帜";
				case 2940:
					return "丛林史莱姆旗帜";
				case 2941:
					return "克朗普斯旗帜";
				case 2942:
					return "红色甲虫旗帜";
				case 2943:
					return "岩浆蝙蝠旗帜";
				case 2944:
					return "岩浆史莱姆旗帜";
				case 2945:
					return "大脑操控者旗帜";
				case 2946:
					return "火星无人机旗帜";
				case 2947:
					return "火星工程师旗帜";
				case 2948:
					return "磁暴步兵旗帜";
				case 2949:
					return "灰色火星人旗帜";
				case 2950:
					return "火星军官旗帜";
				case 2951:
					return "激光枪手旗帜";
				case 2952:
					return "火星蛞蝓枪手旗帜";
				case 2953:
					return "特斯拉炮塔旗帜";
				case 2954:
					return "矮胖先生旗帜";
				case 2955:
					return "史莱姆母体旗帜";
				case 2956:
					return "死灵巫师旗帜";
				case 2957:
					return "胡桃夹子旗帜";
				case 2958:
					return "圣骑士旗帜";
				case 2959:
					return "企鹅旗帜";
				case 2960:
					return "粉色史莱姆旗帜";
				case 2961:
					return "邪灵旗帜";
				case 2962:
					return "魔化盔甲旗帜";
				case 2963:
					return "礼物宝箱怪旗帜";
				case 2964:
					return "紫色史莱姆旗帜";
				case 2965:
					return "残袍法师旗帜";
				case 2966:
					return "彩虹史莱姆旗帜";
				case 2967:
					return "乌鸦旗帜";
				case 2968:
					return "红色史莱姆旗帜";
				case 2969:
					return "符文魔法师旗帜";
				case 2970:
					return "锈蚀装甲骷髅旗帜";
				case 2971:
					return "稻草人旗帜";
				case 2972:
					return "火星蛞蝓骑兵旗帜";
				case 2973:
					return "骷髅弓箭手旗帜";
				case 2974:
					return "骷髅司令旗帜";
				case 2975:
					return "骷髅狙击手旗帜";
				case 2976:
					return "飞翔史莱姆旗帜";
				case 2977:
					return "掠夺者旗帜";
				case 2978:
					return "冰雪巴拉旗帜";
				case 2979:
					return "雪人枪手旗帜";
				case 2980:
					return "尖刺冰霜史莱姆旗帜";
				case 2981:
					return "尖刺丛林史莱姆旗帜";
				case 2982:
					return "刺枝怪旗帜";
				case 2983:
					return "章鱼旗帜";
				case 2984:
					return "骷髅突击队员旗帜";
				case 2985:
					return "僵尸新郎旗帜";
				case 2986:
					return "提姆法师旗帜";
				case 2987:
					return "骷髅矿工旗帜";
				case 2988:
					return "维京骷髅旗帜";
				case 2989:
					return "白色教徒弓手旗帜";
				case 2990:
					return "白色教徒弓手旗帜";
				case 2991:
					return "白色教徒弓手旗帜";
				case 2992:
					return "黄色史莱姆旗帜";
				case 2993:
					return "北风雪人旗帜";
				case 2994:
					return "妖精僵尸旗帜";
				case 2995:
					return "火花";
				case 2996:
					return "藤绳";
				case 2997:
					return "虫洞药剂";
				case 2998:
					return "召唤纹章";
				case 2999:
					return "迷人的桌子";
				case 3000:
					return "炼金台";
				case 3001:
					return "奇异的啤酒";
				case 3002:
					return "探险荧光棒";
				case 3003:
					return "白骨箭";
				case 3004:
					return "白骨火把";
				case 3005:
					return "藤绳圈";
				case 3006:
					return "生命汲取";
				case 3007:
					return "飞箭手枪";
				case 3008:
					return "飞箭来复枪";
				case 3009:
					return "水晶飞箭";
				case 3010:
					return "诅咒飞箭";
				case 3011:
					return "脓血飞箭";
				case 3012:
					return "锁链断头台";
				case 3013:
					return "恶臭虎爪";
				case 3014:
					return "黏着者魔杖";
				case 3015:
					return "净化粉末";
				case 3016:
					return "血肉指虎";
				case 3017:
					return "花之靴";
				case 3018:
					return "种子弯刀";
				case 3019:
					return "地狱翼弓";
				case 3020:
					return "肉筋钩爪";
				case 3021:
					return "荆棘钩爪";
				case 3022:
					return "发光钩爪";
				case 3023:
					return "蠕虫钩爪";
				case 3024:
					return "skyph之血";
				case 3025:
					return "紫色渗透染料";
				case 3026:
					return "银色反光染料";
				case 3027:
					return "金色反光染料";
				case 3028:
					return "蓝色酸性染料";
				case 3029:
					return "代达罗斯风暴弓";
				case 3030:
					return "水晶飞刀";
				case 3031:
					return "无尽水桶";
				case 3032:
					return "超级吸水海绵";
				case 3033:
					return "金戒指";
				case 3034:
					return "硬币戒指";
				case 3035:
					return "贪婪指环";
				case 3036:
					return "寻鱼者";
				case 3037:
					return "气象广播";
				case 3038:
					return "冥王染料";
				case 3039:
					return "暮光染料";
				case 3040:
					return "酸性染料";
				case 3041:
					return "荧光蘑菇染料";
				case 3042:
					return "相位染料";
				case 3043:
					return "魔法灯笼";
				case 3044:
					return "音乐盒(月球BOSS)";
				case 3045:
					return "彩虹火把";
				case 3046:
					return "诅咒篝火";
				case 3047:
					return "恶魔篝火";
				case 3048:
					return "冰霜篝火";
				case 3049:
					return "脓血篝火";
				case 3050:
					return "彩虹篝火";
				case 3051:
					return "邪恶水晶碎片";
				case 3052:
					return "影炎弓";
				case 3053:
					return "影炎六角娃娃";
				case 3054:
					return "影炎小刀";
				case 3055:
					return "橡子";
				case 3056:
					return "寒流";
				case 3057:
					return "被诅咒的圣诞老人";
				case 3058:
					return "雪亦有血";
				case 3059:
					return "雪季";
				case 3060:
					return "白骨拨浪鼓";
				case 3061:
					return "建筑工具包";
				case 3062:
					return "血腥之心";
				case 3063:
					return "喵星人之刃";
				case 3064:
					return "魔法日晷";
				case 3065:
					return "星辰之怒";
				case 3066:
					return "光滑大理石块";
				case 3067:
					return "狱炎砖墙";
				case 3068:
					return "植物纤维编绳入门";
				case 3069:
					return "火花魔杖";
				case 3070:
					return "金鸟笼";
				case 3071:
					return "金兔子笼";
				case 3072:
					return "金蝴蝶罐";
				case 3073:
					return "金青蛙笼";
				case 3074:
					return "金蚱蜢笼";
				case 3075:
					return "金老鼠笼";
				case 3076:
					return "金毛虫笼";
				case 3077:
					return "丝质绳子";
				case 3078:
					return "网织绳子";
				case 3079:
					return "丝绳圈";
				case 3080:
					return "蛛网绳圈";
				case 3081:
					return "大理石块";
				case 3082:
					return "大理石墙";
				case 3083:
					return "光滑大理石墙";
				case 3084:
					return "雷达";
				case 3085:
					return "黄金保险箱";
				case 3086:
					return "花岗岩块";
				case 3087:
					return "光滑花岗岩块";
				case 3088:
					return "花岗岩墙";
				case 3089:
					return "光滑花岗岩墙";
				case 3090:
					return "皇家凝胶";
				case 3091:
					return "夜之钥匙";
				case 3092:
					return "光之钥匙";
				case 3093:
					return "草药袋";
				case 3094:
					return "标枪";
				case 3095:
					return "计数器";
				case 3096:
					return "六分仪";
				case 3097:
					return "克苏鲁之盾";
				case 3098:
					return "屠夫的链锯";
				case 3099:
					return "秒表";
				case 3100:
					return "陨铁砖";
				case 3101:
					return "陨铁砖墙";
				case 3102:
					return "金属探测器";
				case 3103:
					return "无限箭袋";
				case 3104:
					return "无限弹药袋";
				case 3105:
					return "毒剂烧瓶";
				case 3106:
					return "疯狂小刀";
				case 3107:
					return "射钉枪";
				case 3108:
					return "钉子";
				case 3109:
					return "夜视头盔";
				case 3110:
					return "上界贝壳";
				case 3111:
					return "粉色凝胶";
				case 3112:
					return "弹性荧光棒";
				case 3113:
					return "粉色史莱姆块";
				case 3114:
					return "粉色火炬";
				case 3115:
					return "弹性炸弹";
				case 3116:
					return "弹性手雷";
				case 3117:
					return "和平蜡烛";
				case 3118:
					return "生命分析仪";
				case 3119:
					return "DPS计量器";
				case 3120:
					return "渔夫袖珍指南";
				case 3121:
					return "哥布林科技";
				case 3122:
					return "R.E.K. 3000";
				case 3123:
					return "PDA";
				case 3124:
					return "手机";
				case 3125:
					return "花岗岩箱";
				case 3126:
					return "陨铁时钟";
				case 3127:
					return "大理石钟";
				case 3128:
					return "花岗岩钟";
				case 3129:
					return "陨铁门";
				case 3130:
					return "大理石门";
				case 3131:
					return "花岗岩门";
				case 3132:
					return "陨铁梳妆台";
				case 3133:
					return "大理石梳妆台";
				case 3134:
					return "花岗岩梳妆台";
				case 3135:
					return "陨铁灯";
				case 3136:
					return "大理石灯";
				case 3137:
					return "花岗岩灯";
				case 3138:
					return "陨铁吊灯";
				case 3139:
					return "大理石吊灯";
				case 3140:
					return "花岗岩吊灯";
				case 3141:
					return "陨铁钢琴";
				case 3142:
					return "大理石钢琴";
				case 3143:
					return "花岗岩钢琴";
				case 3144:
					return "陨铁平台";
				case 3145:
					return "大理石平台";
				case 3146:
					return "花岗岩平台";
				case 3147:
					return "陨铁水槽";
				case 3148:
					return "大理石水槽";
				case 3149:
					return "花岗岩水槽";
				case 3150:
					return "陨铁沙发";
				case 3151:
					return "大理石沙发";
				case 3152:
					return "花岗岩沙发";
				case 3153:
					return "陨铁桌";
				case 3154:
					return "大理石桌";
				case 3155:
					return "花岗岩桌";
				case 3156:
					return "陨铁工作台";
				case 3157:
					return "大理石工作台";
				case 3158:
					return "花岗岩工作台";
				case 3159:
					return "陨铁澡盆";
				case 3160:
					return "大理石澡盆";
				case 3161:
					return "花岗岩澡盆";
				case 3162:
					return "陨铁床";
				case 3163:
					return "大理石床";
				case 3164:
					return "花岗岩床";
				case 3165:
					return "陨铁书架";
				case 3166:
					return "大理石书架";
				case 3167:
					return "花岗岩书架";
				case 3168:
					return "陨铁烛台";
				case 3169:
					return "大理石烛台";
				case 3170:
					return "花岗岩烛台";
				case 3171:
					return "陨铁蜡烛";
				case 3172:
					return "大理石蜡烛";
				case 3173:
					return "花岗岩蜡烛";
				case 3174:
					return "陨铁椅子";
				case 3175:
					return "大理石椅子";
				case 3176:
					return "花岗岩椅子";
				case 3177:
					return "陨铁吊灯";
				case 3178:
					return "大理石吊灯";
				case 3179:
					return "花岗岩吊灯";
				case 3180:
					return "陨铁箱子";
				case 3181:
					return "大理石箱子";
				case 3182:
					return "魔法滴管";
				case 3183:
					return "黄金捕虫网";
				case 3184:
					return "魔法熔岩滴管";
				case 3185:
					return "魔法蜂蜜滴管";
				case 3186:
					return "空滴管";
				case 3187:
					return "角斗士头盔";
				case 3188:
					return "角斗士胸甲";
				case 3189:
					return "角斗士护胫";
				case 3190:
					return "反光染料";
				case 3191:
					return "魔法蠕虫";
				case 3192:
					return "小蛆蛆";
				case 3193:
					return "小鼻涕虫";
				case 3194:
					return "小虫虫";
				case 3195:
					return "蛆虫汤";
				case 3196:
					return "炸弹鱼";
				case 3197:
					return "冰霜短剑鱼";
				case 3198:
					return "磨刀台";
				case 3199:
					return "冰镜";
				case 3200:
					return "旗鱼靴";
				case 3201:
					return "海啸瓶";
				case 3202:
					return "假人标靶";
				case 3203:
					return "腐化板条箱";
				case 3204:
					return "血腥板条箱";
				case 3205:
					return "地牢板条箱";
				case 3206:
					return "天空板条箱";
				case 3207:
					return "神圣板条箱";
				case 3208:
					return "丛林板条箱";
				case 3209:
					return "水晶蛇";
				case 3210:
					return "毒刺鱼";
				case 3211:
					return "舌剑";
				case 3212:
					return "鲨鱼齿项链";
				case 3213:
					return "金钱槽";
				case 3214:
					return "泡泡";
				case 3215:
					return "太阳花种植箱";
				case 3216:
					return "月光草种植箱";
				case 3217:
					return "死亡草种植箱";
				case 3218:
					return "死亡草种植箱";
				case 3219:
					return "闪耀根种植箱";
				case 3220:
					return "波浪叶种植箱";
				case 3221:
					return "颤栗荆棘种植箱";
				case 3222:
					return "火焰花种植箱";
				case 3223:
					return "混乱大脑";
				case 3224:
					return "蠕虫围巾";
				case 3225:
					return "气球河豚";
				case 3226:
					return "拉泽尔的女武神头环";
				case 3227:
					return "拉泽尔的女武神斗篷";
				case 3228:
					return "拉泽尔的防御平台";
				case 3229:
					return "黄金十字墓碑";
				case 3230:
					return "黄金墓石";
				case 3231:
					return "黄金墓碑";
				case 3232:
					return "黄金墓石";
				case 3233:
					return "黄金方碑";
				case 3234:
					return "水晶块";
				case 3235:
					return "音乐盒(疯狂火星)";
				case 3236:
					return "音乐盒(海盗入侵)";
				case 3237:
					return "音乐盒(地狱)";
				case 3238:
					return "水晶块墙";
				case 3239:
					return "陷阱门";
				case 3240:
					return "高大的门";
				case 3241:
					return "猪鲨气球";
				case 3242:
					return "税务官帽子";
				case 3243:
					return "税务官制服";
				case 3244:
					return "税务官裤子";
				case 3245:
					return "骨头手套";
				case 3246:
					return "裁缝的夹克";
				case 3247:
					return "裁缝的裤子";
				case 3248:
					return "染料商的头巾";
				case 3249:
					return "致命之球法杖";
				case 3250:
					return "绿色马掌气球";
				case 3251:
					return "琥珀马掌气球";
				case 3252:
					return "粉色马掌气球";
				case 3253:
					return "熔岩灯";
				case 3254:
					return "魔法蠕虫笼";
				case 3255:
					return "小虫虫笼";
				case 3256:
					return "小蛆蛆笼";
				case 3257:
					return "小鼻涕虫笼";
				case 3258:
					return "拍拍手";
				case 3259:
					return "暮光染发剂";
				case 3260:
					return "祝福苹果";
				case 3261:
					return "幽魂锭";
				case 3262:
					return "代码:1";
				case 3263:
					return "海盗头巾";
				case 3264:
					return "海盗外衣";
				case 3265:
					return "海盗马裤";
				case 3266:
					return "黑曜石罪犯帽";
				case 3267:
					return "黑曜石长外套";
				case 3268:
					return "黑曜石裤子";
				case 3269:
					return "美杜莎之首";
				case 3270:
					return "展示架";
				case 3271:
					return "砂石块";
				case 3272:
					return "硬砂块";
				case 3273:
					return "砂石墙";
				case 3274:
					return "坚硬黑檀砂块";
				case 3275:
					return "坚硬血腥砂块";
				case 3276:
					return "黑檀砂石块";
				case 3277:
					return "血腥砂石块";
				case 3278:
					return "木制悠悠球";
				case 3279:
					return "虚弱";
				case 3280:
					return "动脉";
				case 3281:
					return "亚马逊";
				case 3282:
					return "火瀑";
				case 3283:
					return "雏鸟";
				case 3284:
					return "代码: 2";
				case 3285:
					return "拉力";
				case 3286:
					return "叶列茨悠悠球";
				case 3287:
					return "瑞德之投掷";
				case 3288:
					return "女武神悠悠球";
				case 3289:
					return "狼神";
				case 3290:
					return "地狱火";
				case 3291:
					return "克拉肯";
				case 3292:
					return "克苏鲁之眼";
				case 3293:
					return "红色丝线";
				case 3294:
					return "橙色丝线";
				case 3295:
					return "黄色丝线";
				case 3296:
					return "柠檬色丝线";
				case 3297:
					return "绿色丝线";
				case 3298:
					return "蓝绿色丝线";
				case 3299:
					return "青色丝线";
				case 3300:
					return "天蓝色丝线";
				case 3301:
					return "蓝色丝线";
				case 3302:
					return "紫色丝线";
				case 3303:
					return "紫罗兰丝线";
				case 3304:
					return "粉色丝线";
				case 3305:
					return "棕色丝线";
				case 3306:
					return "白色丝线";
				case 3307:
					return "彩虹丝线";
				case 3308:
					return "黑色丝线";
				case 3309:
					return "黑色配重块";
				case 3310:
					return "蓝色配重块";
				case 3311:
					return "绿色配重块";
				case 3312:
					return "紫色配重块";
				case 3313:
					return "红色配重块";
				case 3314:
					return "黄色配重块";
				case 3315:
					return "格式:C";
				case 3316:
					return "梯度";
				case 3317:
					return "勇气";
				case 3318:
					return "财宝袋";
				case 3319:
					return "财宝袋";
				case 3320:
					return "财宝袋";
				case 3321:
					return "财宝袋";
				case 3322:
					return "财宝袋";
				case 3323:
					return "财宝袋";
				case 3324:
					return "财宝袋";
				case 3325:
					return "财宝袋";
				case 3326:
					return "财宝袋";
				case 3327:
					return "财宝袋";
				case 3328:
					return "财宝袋";
				case 3329:
					return "财宝袋";
				case 3330:
					return "财宝袋";
				case 3331:
					return "财宝袋";
				case 3332:
					return "财宝袋";
				case 3333:
					return "蜂窝袋";
				case 3334:
					return "悠悠球手套";
				case 3335:
					return "恶魔之心";
				case 3336:
					return "孢子囊";
				case 3337:
					return "闪光石";
				case 3338:
					return "坚硬珍珠砂块";
				case 3339:
					return "珍珠砂石块";
				case 3340:
					return "坚硬沙快墙";
				case 3341:
					return "坚硬黑檀沙墙";
				case 3342:
					return "坚硬血腥沙墙";
				case 3343:
					return "坚硬珍珠沙墙";
				case 3344:
					return "黑檀沙枪";
				case 3345:
					return "血腥沙墙";
				case 3346:
					return "珍珠沙墙";
				case 3347:
					return "沙漠化石";
				case 3348:
					return "沙漠化石墙";
				case 3349:
					return "异域弯刀";
				case 3350:
					return "彩弹枪";
				case 3351:
					return "古典手杖";
				case 3352:
					return "时尚剪刀";
				case 3353:
					return "机械矿车";
				case 3354:
					return "机械轮胎碎片";
				case 3355:
					return "机械车体碎片";
				case 3356:
					return "机械电池碎片";
				case 3357:
					return "荣耀之证-远古教徒";
				case 3358:
					return "荣耀之证-火星飞碟";
				case 3359:
					return "荣耀之证-飞翔荷兰人号";
				case 3360:
					return "生命红木魔杖";
				case 3361:
					return "红木叶魔杖";
				case 3362:
					return "堕落燕尾服衬衫";
				case 3363:
					return "堕落燕尾服裤子";
				case 3364:
					return "壁炉";
				case 3365:
					return "烟囱";
				case 3366:
					return "悠悠球袋";
				case 3367:
					return "矮松露";
				case 3368:
					return "弧光剑";
				case 3369:
					return "彩纸大炮";
				case 3370:
					return "音乐盒(四柱)";
				case 3371:
					return "音乐盒(哥布林入侵)";
				case 3372:
					return "远古教徒面罩";
				case 3373:
					return "月之领主面罩";
				case 3374:
					return "化石头盔";
				case 3375:
					return "化石板甲";
				case 3376:
					return "化石护腿";
				case 3377:
					return "琥珀魔杖";
				case 3378:
					return "白骨标枪";
				case 3379:
					return "白骨飞刀";
				case 3380:
					return "坚固化石";
				case 3381:
					return "星尘头盔";
				case 3382:
					return "星尘板甲";
				case 3383:
					return "星尘护胫";
				case 3384:
					return "传送门枪";
				case 3385:
					return "奇异植物";
				case 3386:
					return "奇异植物";
				case 3387:
					return "奇异植物";
				case 3388:
					return "奇异植物";
				case 3389:
					return "泰拉瑞亚悠悠球";
				case 3390:
					return "哥布林召唤师旗帜";
				case 3391:
					return "沙罗曼蛇旗帜";
				case 3392:
					return "巨贝旗帜";
				case 3393:
					return "龙虾旗帜";
				case 3394:
					return "科学小怪人旗帜";
				case 3395:
					return "深渊生物旗帜";
				case 3396:
					return "苍蝇人博士旗帜";
				case 3397:
					return "摩斯拉飞蛾旗帜";
				case 3398:
					return "断手旗帜";
				case 3399:
					return "魔化怪人旗帜";
				case 3400:
					return "屠夫旗帜";
				case 3401:
					return "疯子旗帜";
				case 3402:
					return "致命球体旗帜";
				case 3403:
					return "钉子头旗帜";
				case 3404:
					return "Poisonous Spore旗帜";
				case 3405:
					return "美杜莎旗帜";
				case 3406:
					return "重装步兵旗帜";
				case 3407:
					return "花岗岩元素旗帜";
				case 3408:
					return "花岗岩傀儡旗帜";
				case 3409:
					return "鲜血僵尸旗帜";
				case 3410:
					return "滴血魔眼旗帜";
				case 3411:
					return "掘墓者头颅旗帜";
				case 3412:
					return "沙丘穿行者头颅旗帜";
				case 3413:
					return "飞行蚁狮旗帜";
				case 3414:
					return "冲锋蚁狮旗帜";
				case 3415:
					return "食尸鬼旗帜";
				case 3416:
					return "拉弥亚旗帜";
				case 3417:
					return "沙漠游魂旗帜";
				case 3418:
					return "史前毒蜥旗帜";
				case 3419:
					return "破坏之蝎旗帜";
				case 3420:
					return "观星者旗帜";
				case 3421:
					return "银行穿梭者旗帜";
				case 3422:
					return "激流入侵者旗帜";
				case 3423:
					return "闪光炸弹发射器旗帜";
				case 3424:
					return "小型星尘细胞旗帜";
				case 3425:
					return "星尘细胞旗帜";
				case 3426:
					return "日曜头骨旗帜";
				case 3427:
					return "日曜滚动者旗帜";
				case 3428:
					return "日曜蜈蚣旗帜";
				case 3429:
					return "日曜地龙骑士旗帜";
				case 3430:
					return "日曜地龙旗帜";
				case 3431:
					return "日光住民旗帜";
				case 3432:
					return "星云先知旗帜";
				case 3433:
					return "大脑吸取者旗帜";
				case 3434:
					return "星云浮游者旗帜";
				case 3435:
					return "星云野兽旗帜";
				case 3436:
					return "外星幼虫旗帜";
				case 3437:
					return "外星女皇旗帜";
				case 3438:
					return "外星黄蜂旗帜";
				case 3439:
					return "旋涡士兵旗帜";
				case 3440:
					return "风暴潜兵旗帜";
				case 3441:
					return "海盗船长旗帜";
				case 3442:
					return "独眼海盗旗帜";
				case 3443:
					return "海盗劫掠者旗帜";
				case 3444:
					return "海盗弓弩手旗帜";
				case 3445:
					return "火星漫步者旗帜";
				case 3446:
					return "红恶魔旗帜";
				case 3447:
					return "粉水母旗帜";
				case 3448:
					return "绿水母旗帜";
				case 3449:
					return "黑暗木乃伊旗帜";
				case 3450:
					return "光明木乃伊旗帜";
				case 3451:
					return "愤怒的骷髅旗帜";
				case 3452:
					return "冰霜乌龟旗帜";
				case 3453:
					return "伤害星能";
				case 3454:
					return "生命星能";
				case 3455:
					return "魔力星能";
				case 3456:
					return "漩涡碎片";
				case 3457:
					return "星云碎片";
				case 3458:
					return "日耀碎片";
				case 3459:
					return "星尘碎片";
				case 3460:
					return "夜光矿石";
				case 3461:
					return "月光砖块";
				case 3462:
					return "星尘斧头";
				case 3463:
					return "星尘链锯";
				case 3464:
					return "星尘钻头";
				case 3465:
					return "星尘锤子";
				case 3466:
					return "星尘镐";
				case 3467:
					return "月光锭";
				case 3468:
					return "日耀翅膀";
				case 3469:
					return "漩涡喷射器";
				case 3470:
					return "星云斗篷";
				case 3471:
					return "星尘翅膀";
				case 3472:
					return "月光砖墙";
				case 3473:
					return "日耀链刃";
				case 3474:
					return "星尘细胞魔杖";
				case 3475:
					return "漩涡打击者";
				case 3476:
					return "星云奥秘";
				case 3477:
					return "血水";
				case 3478:
					return "婚纱";
				case 3479:
					return "婚礼服";
				case 3480:
					return "铂金弓";
				case 3481:
					return "铂金锤子";
				case 3482:
					return "铂金斧头";
				case 3483:
					return "铂金短剑";
				case 3484:
					return "铂金宽刃剑";
				case 3485:
					return "铂金镐";
				case 3486:
					return "钨金弓";
				case 3487:
					return "钨金锤子";
				case 3488:
					return "钨金斧头";
				case 3489:
					return "钨金短剑";
				case 3490:
					return "钨金宽刃剑";
				case 3491:
					return "钨金镐";
				case 3492:
					return "铅质弓";
				case 3493:
					return "铅质锤子";
				case 3494:
					return "铅质斧头";
				case 3495:
					return "铅质短剑";
				case 3496:
					return "铅质宽刃剑";
				case 3497:
					return "铅质镐";
				case 3498:
					return "锡质弓";
				case 3499:
					return "锡质锤子";
				case 3500:
					return "锡质斧头";
				case 3501:
					return "锡质短剑";
				case 3502:
					return "锡质宽刃剑";
				case 3503:
					return "锡制镐";
				case 3504:
					return "铜质弓";
				case 3505:
					return "铜质锤子";
				case 3506:
					return "铜质斧头";
				case 3507:
					return "铜质短剑";
				case 3508:
					return "铜质宽刃剑";
				case 3509:
					return "铜质镐";
				case 3510:
					return "白银弓";
				case 3511:
					return "白银锤子";
				case 3512:
					return "白银斧头";
				case 3513:
					return "白银短剑";
				case 3514:
					return "白银宽刃剑";
				case 3515:
					return "白银镐";
				case 3516:
					return "黄金弓";
				case 3517:
					return "黄金锤子";
				case 3518:
					return "黄金斧头";
				case 3519:
					return "黄金短剑";
				case 3520:
					return "黄金宽刃剑";
				case 3521:
					return "黄金镐";
				case 3522:
					return "日耀锤斧";
				case 3523:
					return "漩涡锤斧";
				case 3524:
					return "星云锤斧";
				case 3525:
					return "星尘锤斧";
				case 3526:
					return "日耀染料";
				case 3527:
					return "星云染料";
				case 3528:
					return "漩涡染料";
				case 3529:
					return "星尘染料";
				case 3530:
					return "虚空染料";
				case 3531:
					return "星尘巨龙魔杖";
				case 3532:
					return "培根";
				case 3533:
					return "流动沙染料";
				case 3534:
					return "海市蜃楼染料";
				case 3535:
					return "流动珍珠沙染料";
				case 3536:
					return "漩涡巨石柱";
				case 3537:
					return "星云巨石柱";
				case 3538:
					return "星尘巨石柱";
				case 3539:
					return "日耀巨石柱";
				case 3540:
					return "幻象";
				case 3541:
					return "最终棱镜";
				case 3542:
					return "星云火焰";
				case 3543:
					return "黎明";
				case 3544:
					return "超级治疗药水";
				case 3545:
					return "雷管";
				case 3546:
					return "庆典";
				case 3547:
					return "弹性炸药";
				case 3548:
					return "欢乐手雷";
				case 3549:
					return "远古操纵器";
				case 3550:
					return "银焰染料";
				case 3551:
					return "绿银焰染料";
				case 3552:
					return "蓝银焰染料";
				case 3553:
					return "反光黄铜染料";
				case 3554:
					return "反光黑曜石染料";
				case 3555:
					return "反光金属染料";
				case 3556:
					return "午夜彩虹染料";
				case 3557:
					return "黑白染料";
				case 3558:
					return "亮银染料";
				case 3559:
					return "银黑染料";
				case 3560:
					return "红色酸性染料";
				case 3561:
					return "凝胶染料";
				case 3562:
					return "粉色凝胶染料";
				case 3563:
					return "红色松鼠";
				case 3564:
					return "黄金松鼠";
				case 3565:
					return "红色松鼠笼";
				case 3566:
					return "黄金松鼠笼";
				case 3567:
					return "月光子弹";
				case 3568:
					return "月光箭";
				case 3569:
					return "月球传送法杖";
				case 3570:
					return "月之耀斑";
				case 3571:
					return "彩虹水晶魔杖";
				case 3572:
					return "月球钩爪";
				case 3573:
					return "日耀碎片块";
				case 3574:
					return "漩涡碎片块";
				case 3575:
					return "星云碎片块";
				case 3576:
					return "星尘碎片块";
				case 3577:
					return "可疑的触手";
				case 3578:
					return "Yoraiz0r的制服";
				case 3579:
					return "Yoraiz0r的衬衫";
				case 3580:
					return "Yoraiz0r的咒文";
				case 3581:
					return "Yoraiz0r的怒容";
				case 3582:
					return "Jim的翅膀";
				case 3583:
					return "Yoraiz0r的有色眼镜";
				case 3584:
					return "生命叶墙";
				case 3585:
					return "Skiphs的面罩";
				case 3586:
					return "Skiphs的皮肤";
				case 3587:
					return "Skiphs的熊腿";
				case 3588:
					return "Skiphs的爪子";
				case 3589:
					return "洛基的头盔";
				case 3590:
					return "洛基的胸甲";
				case 3591:
					return "洛基的护腿";
				case 3592:
					return "洛基的翅膀";
				case 3593:
					return "黄沙史莱姆旗帜";
				case 3594:
					return "海蜗牛旗帜";
				case 3595:
					return "荣耀之证-月之领主";
				case 3596:
					return "不是羊羔，也不是乌贼";
				case 3597:
					return "烈焰冥王染料";
				case 3598:
					return "残忍染料";
				case 3599:
					return "洛基的染料";
				case 3600:
					return "暗焰冥王染料";
				case 3601:
					return "天体印记";
				case 3602:
					return "逻辑灯 (关)";
				case 3603:
					return "逻辑门 (与)";
				case 3604:
					return "逻辑门 (或)";
				case 3605:
					return "逻辑门 (与非)";
				case 3606:
					return "逻辑门 (或非)";
				case 3607:
					return "逻辑门 (异或)";
				case 3608:
					return "逻辑门 (同或)";
				case 3609:
					return "传送带 (顺时针)";
				case 3610:
					return "传送带 (逆时针)";
				case 3611:
					return "宏伟蓝图";
				case 3612:
					return "黄色扳手";
				case 3613:
					return "传感器 (白天)";
				case 3614:
					return "传感器 (夜晚)";
				case 3615:
					return "传感器 (玩家)";
				case 3616:
					return "分线盒";
				case 3617:
					return "公告栏";
				case 3618:
					return "逻辑灯 (开)";
				case 3619:
					return "机械眼镜";
				case 3620:
					return "触发杆";
				case 3621:
					return "红队方块";
				case 3622:
					return "红队平台";
				case 3623:
					return "静态勾爪";
				case 3624:
					return "促动安装器";
				case 3625:
					return "多色扳手";
				case 3626:
					return "粉色压力板";
				case 3627:
					return "工程师头盔";
				case 3628:
					return "伙伴方块";
				case 3629:
					return "通电彩灯";
				case 3630:
					return "橙色压力板";
				case 3631:
					return "紫色压力板";
				case 3632:
					return "靛青压力板";
				case 3633:
					return "绿队方块";
				case 3634:
					return "蓝队方块";
				case 3635:
					return "黄队方块";
				case 3636:
					return "粉队方块";
				case 3637:
					return "白队方块";
				case 3638:
					return "绿队平台";
				case 3639:
					return "蓝队平台";
				case 3640:
					return "黄队平台";
				case 3641:
					return "粉队平台";
				case 3642:
					return "白队平台";
				case 3643:
					return "大型琥珀";
				case 3644:
					return "红宝石锁柜";
				case 3645:
					return "蓝宝石锁柜";
				case 3646:
					return "祖母绿锁柜";
				case 3647:
					return "黄晶玉锁柜";
				case 3648:
					return "紫水晶锁柜";
				case 3649:
					return "钻石锁柜";
				case 3650:
					return "琥珀锁柜";
				case 3651:
					return "松鼠雕像";
				case 3652:
					return "蝴蝶雕像";
				case 3653:
					return "蠕虫雕像";
				case 3654:
					return "萤火虫雕像";
				case 3655:
					return "蝎子雕像";
				case 3656:
					return "蜗牛雕像";
				case 3657:
					return "蚱蜢雕像";
				case 3658:
					return "老鼠雕像";
				case 3659:
					return "鸭子雕像";
				case 3660:
					return "企鹅雕像";
				case 3661:
					return "青蛙雕像";
				case 3662:
					return "虫虫雕像";
				case 3663:
					return "逻辑灯(随机)";
				case 3664:
					return "传送枪台";
				case 3665:
					return "陷阱箱子";
				case 3666:
					return "陷阱黄金箱";
				case 3667:
					return "陷阱暗影箱";
				case 3668:
					return "陷阱黑檀木箱";
				case 3669:
					return "陷阱红木箱";
				case 3670:
					return "陷阱珍珠木箱";
				case 3671:
					return "陷阱藤条箱";
				case 3672:
					return "陷阱寒冰箱";
				case 3673:
					return "陷阱生命木箱";
				case 3674:
					return "陷阱天空箱";
				case 3675:
					return "陷阱阴影木箱";
				case 3676:
					return "陷阱蛛网箱";
				case 3677:
					return "陷阱蜥蜴箱";
				case 3678:
					return "陷阱水华箱";
				case 3679:
					return "陷阱丛林箱";
				case 3680:
					return "陷阱腐化箱";
				case 3681:
					return "陷阱血腥箱";
				case 3682:
					return "陷阱神圣箱";
				case 3683:
					return "陷阱冰霜箱";
				case 3684:
					return "陷阱皇家箱";
				case 3685:
					return "陷阱蜂蜜箱";
				case 3686:
					return "陷阱蒸汽朋克箱";
				case 3687:
					return "陷阱棕榈木箱";
				case 3688:
					return "陷阱蘑菇箱";
				case 3689:
					return "陷阱北地木箱";
				case 3690:
					return "陷阱史莱姆箱";
				case 3691:
					return "陷阱绿色地牢箱";
				case 3692:
					return "陷阱粉色地牢箱";
				case 3693:
					return "陷阱蓝色地牢箱";
				case 3694:
					return "陷阱白骨箱";
				case 3695:
					return "陷阱仙人掌箱";
				case 3696:
					return "陷阱血肉箱";
				case 3697:
					return "陷阱黑曜石箱";
				case 3698:
					return "陷阱南瓜箱";
				case 3699:
					return "陷阱阴森箱";
				case 3700:
					return "陷阱玻璃箱";
				case 3701:
					return "陷阱火星箱";
				case 3702:
					return "陷阱陨铁箱";
				case 3703:
					return "陷阱花岗岩箱";
				case 3704:
					return "陷阱大理石箱";
				case 3707:
					return "青色压力板";
				case 3708:
					return "洞穴蜘蛛雕像";
				case 3709:
					return "独角兽雕像";
				case 3710:
					return "滴血魔眼雕像";
				case 3711:
					return "幽灵雕像";
				case 3712:
					return "骷髅雕像";
				case 3713:
					return "维京骷髅雕像";
				case 3714:
					return "美杜莎雕像";
				case 3715:
					return "鹰身女妖雕像";
				case 3716:
					return "剑齿亚龙雕像";
				case 3717:
					return "重装步兵雕像";
				case 3718:
					return "花岗岩傀儡雕像";
				case 3719:
					return "装甲僵尸雕像";
				case 3720:
					return "鲜血僵尸雕像";
				case 3721:
					return "渔具包";
				case 3722:
					return "火焰喷泉";
				case 3723:
					return "超亮篝火";
				case 3724:
					return "白骨篝火";
				case 3725:
					return "像素盒";
				case 3726:
					return "液体感应器 (水)";
				case 3727:
					return "液体感应器 (岩浆)";
				case 3728:
					return "液体感应器 (蜂蜜)";
				case 3729:
					return "液体感应器 (全部)";
				case 3730:
					return "派对气球束";
				case 3731:
					return "气球小兔";
				case 3732:
					return "派对帽子";
				case 3733:
					return "可爱向日葵花瓣";
				case 3734:
					return "可爱向日葵衣服";
				case 3735:
					return "可爱向日葵裤子";
				case 3736:
					return "可爱粉红气球";
				case 3737:
					return "可爱紫色气球";
				case 3738:
					return "可爱绿色气球";
				case 3739:
					return "蓝色彩带";
				case 3740:
					return "绿色彩带";
				case 3741:
					return "粉红彩带";
				case 3742:
					return "可爱气球机";
				case 3743:
					return "可爱粉红系绳气球";
				case 3744:
					return "可爱紫色系绳气球";
				case 3745:
					return "可爱绿色系绳气球";
				case 3746:
					return "彩色猪龙";
				case 3747:
					return "派对焦点";
				case 3748:
					return "可爱系绳气球束";
				case 3749:
					return "派对礼物";
				case 3750:
					return "切片蛋糕";
				case 3751:
					return "齿轮墙";
				case 3752:
					return "流沙墙";
				case 3753:
					return "雪落墙";
				case 3754:
					return "流沙块";
				case 3755:
					return "雪落块";
				case 3756:
					return "雪云";
				case 3757:
					return "企鹅兜帽";
				case 3758:
					return "企鹅夹克";
				case 3759:
					return "企鹅长裤";
				case 3760:
					return "可爱粉气球墙";
				case 3761:
					return "可爱紫气球墙";
				case 3762:
					return "可爱绿气球墙";
				case 3763:
					return "0x33的飞行眼镜";
				case 3764:
					return "蓝相位军刀";
				case 3765:
					return "红相位军刀";
				case 3766:
					return "绿相位军刀";
				case 3767:
					return "紫相位军刀";
				case 3768:
					return "白相位军刀";
				case 3769:
					return "黄相位军刀";
				case 3770:
					return "灯神的诅咒";
				case 3771:
					return "上古之角";
				case 3772:
					return "蚁狮上颚";
				case 3773:
					return "古代头饰";
				case 3774:
					return "古代外套";
				case 3775:
					return "古代裤子";
				case 3776:
					return "禁忌面罩";
				case 3777:
					return "禁忌长袍";
				case 3778:
					return "禁忌腿甲";
				case 3779:
					return "神灵火焰";
				case 3780:
					return "沙元素旗帜";
				case 3781:
					return "化妆镜";
				case 3782:
					return "魔法沙地滴管";
				case 3783:
					return "禁忌碎片";
				case 3784:
					return "拉弥亚之尾";
				case 3785:
					return "拉弥亚外衣";
				case 3786:
					return "拉弥亚面罩";
				case 3787:
					return "裂空";
				case 3788:
					return "黑玛瑙冲击波";
				case 3789:
					return "沙漠鲨鱼旗帜";
				case 3790:
					return "噬骨者旗帜";
				case 3791:
					return "血肉收割者旗帜";
				case 3792:
					return "水晶长尾鲨旗帜";
				case 3793:
					return "愤怒不倒翁旗帜";
				case 3794:
					return "古代布料";
				case 3795:
					return "沙漠神灯";
				case 3796:
					return "八音盒 (沙暴)";
				case 3797:
					return "学徒帽子";
				case 3798:
					return "学徒长袍";
				case 3799:
					return "学徒长裤";
				case 3800:
					return "卫士头盔";
				case 3801:
					return "卫士板甲";
				case 3802:
					return "卫士胫甲";
				case 3803:
					return "女猎手假发";
				case 3804:
					return "女猎手短上衣";
				case 3805:
					return "女猎手裤子";
				case 3806:
					return "僧侣光头";
				case 3807:
					return "僧侣衬衫";
				case 3808:
					return "僧侣裤子";
				case 3809:
					return "学徒围巾";
				case 3810:
					return "卫士盾牌";
				case 3811:
					return "女猎手圆盾";
				case 3812:
					return "僧侣腰带";
				case 3813:
					return "守卫者的熔炉";
				case 3814:
					return "战争沙盘";
				case 3815:
					return "战争沙盘旗帜";
				case 3816:
					return "艾特尼亚水晶台";
				case 3817:
					return "守卫者勋章";
				case 3818:
					return "焰爆手杖";
				case 3819:
					return "焰爆法杖";
				case 3820:
					return "焰爆魔杖";
				case 3821:
					return "麦酒投手";
				case 3822:
					return "艾特尼亚魔力结晶";
				case 3823:
					return "地狱的铭牌";
				case 3824:
					return "弩车手杖";
				case 3825:
					return "弩车法杖";
				case 3826:
					return "弩车魔杖";
				case 3827:
					return "飞龙在天";
				case 3828:
					return "艾特尼亚水晶";
				case 3829:
					return "闪电光环手杖";
				case 3830:
					return "闪电光环法杖";
				case 3831:
					return "闪电光环魔杖";
				case 3832:
					return "爆炸陷阱手杖";
				case 3833:
					return "爆炸陷阱法杖";
				case 3834:
					return "爆炸陷阱魔杖";
				case 3835:
					return "沉睡的八爪怪";
				case 3836:
					return "恐怖长刀";
				case 3837:
					return "艾特尼亚投弹手旗帜";
				case 3838:
					return "艾特尼亚哥布林旗帜";
				case 3839:
					return "旧日骷髅旗帜";
				case 3840:
					return "独头龙旗帜";
				case 3841:
					return "滑翔狗头人旗帜";
				case 3842:
					return "狗头人旗帜";
				case 3843:
					return "凋零野兽旗帜";
				case 3844:
					return "艾特尼亚飞龙旗帜";
				case 3845:
					return "艾特尼亚投枪手旗帜";
				case 3846:
					return "艾特尼亚闪电虫旗帜";
				case 3852:
					return "无尽智慧之书";
				case 3854:
					return "凤凰幻影";
				case 3855:
					return "猫蛋蛋";
				case 3856:
					return "爬行者蛋";
				case 3857:
					return "龙蛋";
				case 3858:
					return "天龙之怒";
				case 3859:
					return "空之灾星";
				case 3860:
					return "财宝袋";
				case 3861:
					return "财宝袋";
				case 3862:
					return "财宝袋";
				case 3863:
					return "贝特西面罩";
				case 3864:
					return "黑魔法师面罩";
				case 3865:
					return "食人魔面罩";
				case 3866:
					return "荣耀之证-贝特西";
				case 3867:
					return "荣耀之证-黑魔法师";
				case 3868:
					return "荣耀之证-食人魔";
				case 3869:
					return "音乐盒 (旧日军团)";
				case 3870:
					return "贝特西之怒";
				case 3871:
					return "瓦尔哈拉骑士头盔";
				case 3872:
					return "瓦尔哈拉骑士胸甲";
				case 3873:
					return "瓦尔哈拉骑士胫甲";
				case 3874:
					return "黑暗艺术家帽子";
				case 3875:
					return "黑暗艺术家长袍";
				case 3876:
					return "黑暗艺术家护胫";
				case 3877:
					return "红色游侠兜帽";
				case 3878:
					return "红色游侠礼服";
				case 3879:
					return "红色游侠裤子";
				case 3880:
					return "潜行忍者头盔";
				case 3881:
					return "潜行忍者上衣";
				case 3882:
					return "潜行忍者裤子";
				case 3883:
					return "贝特西之翼";
				default:
					return string.Empty;
			}
		}

		public static string NpcName(int id)
		{
			switch (id)
			{
				case -65:
					return "毒蜂";
				case -64:
					return "毒蜂";
				case -63:
					return "毒蜂";
				case -62:
					return "毒蜂";
				case -61:
					return "毒蜂";
				case -60:
					return "毒蜂";
				case -59:
					return "毒蜂";
				case -58:
					return "毒蜂";
				case -57:
					return "毒蜂";
				case -56:
					return "毒蜂";
				case -55:
					return "僵尸";
				case -54:
					return "僵尸";
				case -53:
					return "骷髅";
				case -52:
					return "骷髅";
				case -51:
					return "骷髅";
				case -50:
					return "骷髅";
				case -49:
					return "骷髅";
				case -48:
					return "骷髅";
				case -47:
					return "骷髅";
				case -46:
					return "骷髅";
				case -45:
					return "僵尸";
				case -44:
					return "僵尸";
				case -43:
					return "恶魔之眼";
				case -42:
					return "恶魔之眼";
				case -41:
					return "恶魔之眼";
				case -40:
					return "恶魔之眼";
				case -39:
					return "恶魔之眼";
				case -38:
					return "恶魔之眼";
				case -37:
					return "僵尸";
				case -36:
					return "僵尸";
				case -35:
					return "僵尸";
				case -34:
					return "僵尸";
				case -33:
					return "僵尸";
				case -32:
					return "僵尸";
				case -31:
					return "僵尸";
				case -30:
					return "僵尸";
				case -29:
					return "僵尸";
				case -28:
					return "僵尸";
				case -27:
					return "僵尸";
				case -26:
					return "僵尸";
				case -25:
					return "血腥史莱姆";
				case -24:
					return "血腥史莱姆";
				case -23:
					return "血肉之虫";
				case -22:
					return "血肉之虫";
				case -21:
					return "藤蔓毒蜂";
				case -20:
					return "藤蔓毒蜂";
				case -19:
					return "藤蔓毒蜂";
				case -18:
					return "藤蔓毒蜂";
				case -17:
					return "毒蜂";
				case -16:
					return "毒蜂";
				case -15:
					return "装甲骷髅";
				case -14:
					return "愤怒的骷髅";
				case -13:
					return "愤怒的骷髅";
				case -12:
					return "灵魂吞噬者";
				case -11:
					return "灵魂吞噬者";
				case -10:
					return "丛林史莱姆";
				case -9:
					return "黄色史莱姆";
				case -8:
					return "红色史莱姆";
				case -7:
					return "紫色史莱姆";
				case -6:
					return "黑色史莱姆";
				case -5:
					return "史莱姆幼体";
				case -4:
					return "粉色史莱姆";
				case -3:
					return "绿色史莱姆";
				case -2:
					return "飞翔史莱姆";
				case -1:
					return "腐化史莱姆幼体";
				case 1:
					return "蓝色史莱姆";
				case 2:
					return "恶魔之眼";
				case 3:
					return "僵尸";
				case 4:
					return "克苏鲁之眼";
				case 5:
					return "克苏鲁的仆人";
				case 6:
					return "灵魂吞噬者";
				case 7:
					return "挖掘者";
				case 8:
					return "挖掘者";
				case 9:
					return "挖掘者";
				case 10:
					return "巨蠕虫";
				case 11:
					return "巨蠕虫";
				case 12:
					return "巨蠕虫";
				case 13:
					return "世界吞噬者";
				case 14:
					return "世界吞噬者";
				case 15:
					return "世界吞噬者";
				case 16:
					return "史莱姆母体";
				case 17:
					return "商人";
				case 18:
					return "护士";
				case 19:
					return "军火商";
				case 20:
					return "树妖";
				case 21:
					return "骷髅";
				case 22:
					return "向导";
				case 23:
					return "陨石怪";
				case 24:
					return "火魔精";
				case 25:
					return "火魔球";
				case 26:
					return "哥布林苦工";
				case 27:
					return "哥布林盗贼";
				case 28:
					return "哥布林战士";
				case 29:
					return "哥布林法师";
				case 30:
					return "混沌之球";
				case 31:
					return "愤怒的骷髅";
				case 32:
					return "黑魔术师";
				case 33:
					return "水球";
				case 34:
					return "被诅咒的骷髅";
				case 35:
					return "骷髅";
				case 36:
					return "骷髅";
				case 37:
					return "老人";
				case 38:
					return "爆破专家";
				case 39:
					return "骨蛇";
				case 40:
					return "骨蛇";
				case 41:
					return "骨蛇";
				case 42:
					return "毒蜂";
				case 43:
					return "食人花";
				case 44:
					return "骷髅矿工";
				case 45:
					return "提姆法师";
				case 46:
					return "兔子";
				case 47:
					return "腐化兔子";
				case 48:
					return "鹰身女妖";
				case 49:
					return "洞穴蝙蝠";
				case 50:
					return "史莱姆国王";
				case 51:
					return "丛林蝙蝠";
				case 52:
					return "骷髅博士";
				case 53:
					return "僵尸新郎";
				case 54:
					return "裁缝";
				case 55:
					return "金鱼";
				case 56:
					return "掠夺者";
				case 57:
					return "腐化金鱼";
				case 58:
					return "食人鱼";
				case 59:
					return "岩浆史莱姆";
				case 60:
					return "地狱蝙蝠";
				case 61:
					return "秃鹫";
				case 62:
					return "恶魔";
				case 63:
					return "蓝水母";
				case 64:
					return "粉水母";
				case 65:
					return "鲨鱼";
				case 66:
					return "巫毒恶魔";
				case 67:
					return "螃蟹";
				case 68:
					return "地牢守卫者";
				case 69:
					return "蚁狮";
				case 70:
					return "钉球";
				case 71:
					return "地牢史莱姆";
				case 72:
					return "炽热火轮";
				case 73:
					return "哥布林斥候";
				case 74:
					return "小鸟";
				case 75:
					return "小精灵";
				case 77:
					return "装甲骷髅";
				case 78:
					return "木乃伊";
				case 79:
					return "黑暗木乃伊";
				case 80:
					return "光明木乃伊";
				case 81:
					return "腐化史莱姆";
				case 82:
					return "幽灵";
				case 83:
					return "诅咒圣锤";
				case 84:
					return "魔化圣剑";
				case 85:
					return "模仿者";
				case 86:
					return "独角兽";
				case 87:
					return "虚空白龙";
				case 88:
					return "虚空白龙";
				case 89:
					return "虚空白龙";
				case 90:
					return "虚空白龙";
				case 91:
					return "虚空白龙";
				case 92:
					return "虚空白龙";
				case 93:
					return "巨大蝙蝠";
				case 94:
					return "腐化者";
				case 95:
					return "挖掘者";
				case 96:
					return "挖掘者";
				case 97:
					return "挖掘者";
				case 98:
					return "世界哺育者";
				case 99:
					return "世界哺育者";
				case 100:
					return "世界哺育者";
				case 101:
					return "黏着者";
				case 102:
					return "琵琶鱼";
				case 103:
					return "绿水母";
				case 104:
					return "狼人";
				case 105:
					return "被捆绑的哥布林";
				case 106:
					return "被捆绑的魔法师";
				case 107:
					return "哥布林工程师";
				case 108:
					return "魔法师";
				case 109:
					return "小丑";
				case 110:
					return "骷髅弓箭手";
				case 111:
					return "哥布林弓箭手";
				case 112:
					return "腐败唾液";
				case 113:
					return "血肉之墙";
				case 114:
					return "血肉之墙";
				case 115:
					return "暴食";
				case 116:
					return "暴食";
				case 117:
					return "血蛭";
				case 118:
					return "血蛭";
				case 119:
					return "血蛭";
				case 120:
					return "混沌元素";
				case 121:
					return "飞翔史莱姆";
				case 122:
					return "神圣蜗牛";
				case 123:
					return "被捆绑的电工";
				case 124:
					return "电工";
				case 125:
					return "镭射魔眼";
				case 126:
					return "咒焰魔眼";
				case 127:
					return "机械骷髅王";
				case 128:
					return "机械炮";
				case 129:
					return "机械链锯";
				case 130:
					return "原罪";
				case 131:
					return "激光";
				case 132:
					return "僵尸";
				case 133:
					return "徘徊之眼";
				case 134:
					return "钢铁破坏者";
				case 135:
					return "钢铁破坏者";
				case 136:
					return "钢铁破坏者";
				case 137:
					return "荧光蝙蝠";
				case 138:
					return "荧光史莱姆";
				case 139:
					return "探测器";
				case 140:
					return "魔化盔甲";
				case 141:
					return "污泥怪";
				case 142:
					return "圣诞老人";
				case 143:
					return "雪人枪手";
				case 144:
					return "矮胖先生";
				case 145:
					return "冰雪巴拉";
				case 147:
					return "冰霜史莱姆";
				case 148:
					return "企鹅";
				case 149:
					return "企鹅";
				case 150:
					return "冰霜蝙蝠";
				case 151:
					return "岩浆蝙蝠";
				case 152:
					return "巨大飞狐";
				case 153:
					return "巨大乌龟";
				case 154:
					return "冰霜乌龟";
				case 155:
					return "雪狼";
				case 156:
					return "红恶魔";
				case 157:
					return "巨骨舌鱼";
				case 158:
					return "吸血鬼";
				case 159:
					return "吸血鬼";
				case 160:
					return "蘑菇人";
				case 161:
					return "爱斯基摩僵尸";
				case 162:
					return "科学怪人";
				case 163:
					return "黑隐者";
				case 164:
					return "洞穴蜘蛛";
				case 165:
					return "洞穴蜘蛛";
				case 166:
					return "沼泽魔怪";
				case 167:
					return "维京骷髅";
				case 168:
					return "腐化企鹅";
				case 169:
					return "冰元素";
				case 170:
					return "剑齿亚龙";
				case 171:
					return "剑齿亚龙";
				case 172:
					return "符文魔法师";
				case 173:
					return "血肉之虫";
				case 174:
					return "鲜血棘虫";
				case 175:
					return "愤怒捕猎者";
				case 176:
					return "藤蔓毒蜂";
				case 177:
					return "巨眼虫";
				case 178:
					return "蒸汽朋克女孩";
				case 179:
					return "血腥之斧";
				case 180:
					return "剑齿亚龙";
				case 181:
					return "巨脸怪";
				case 182:
					return "浮空血魂";
				case 183:
					return "血腥史莱姆";
				case 184:
					return "尖刺冰霜史莱姆";
				case 185:
					return "雪球怪";
				case 186:
					return "僵尸";
				case 187:
					return "僵尸";
				case 188:
					return "僵尸";
				case 189:
					return "僵尸";
				case 190:
					return "恶魔之眼";
				case 191:
					return "恶魔之眼";
				case 192:
					return "恶魔之眼";
				case 193:
					return "恶魔之眼";
				case 194:
					return "恶魔之眼";
				case 195:
					return "迷失少女";
				case 196:
					return "染血女神";
				case 197:
					return "装甲维京骷髅";
				case 198:
					return "蜥蜴";
				case 199:
					return "蜥蜴";
				case 200:
					return "僵尸";
				case 201:
					return "骷髅";
				case 202:
					return "骷髅";
				case 203:
					return "骷髅";
				case 204:
					return "尖刺丛林史莱姆";
				case 205:
					return "毒蛾";
				case 206:
					return "寒冰鱼人";
				case 207:
					return "染料商";
				case 208:
					return "派对女孩";
				case 209:
					return "电子人";
				case 210:
					return "蜜蜂";
				case 211:
					return "蜜蜂";
				case 212:
					return "海盗水手";
				case 213:
					return "海盗劫掠者";
				case 214:
					return "独眼海盗";
				case 215:
					return "海盗弓弩手";
				case 216:
					return "海盗船长";
				case 217:
					return "胭脂甲虫";
				case 218:
					return "靛青甲虫";
				case 219:
					return "红色甲虫";
				case 220:
					return "海蜗牛";
				case 221:
					return "章鱼";
				case 222:
					return "蜂后";
				case 223:
					return "雨衣僵尸";
				case 224:
					return "飞鱼";
				case 225:
					return "雨伞史莱姆";
				case 226:
					return "羽蛇";
				case 227:
					return "画家";
				case 228:
					return "巫医";
				case 229:
					return "海盗";
				case 230:
					return "金鱼";
				case 231:
					return "毒蜂";
				case 232:
					return "毒蜂";
				case 233:
					return "毒蜂";
				case 234:
					return "毒蜂";
				case 235:
					return "毒蜂";
				case 236:
					return "丛林爬行者";
				case 237:
					return "丛林爬行者";
				case 238:
					return "黑隐士";
				case 239:
					return "血腥爬行者";
				case 240:
					return "血腥爬行者";
				case 241:
					return "血腥哺育者";
				case 242:
					return "鲜血水母";
				case 243:
					return "冰霜巨人";
				case 244:
					return "彩虹史莱姆";
				case 245:
					return "石巨人";
				case 246:
					return "石巨人头颅";
				case 247:
					return "石巨人之拳";
				case 248:
					return "石巨人之拳";
				case 249:
					return "石巨人头颅";
				case 250:
					return "愤怒雷云";
				case 251:
					return "眼魔僵尸";
				case 252:
					return "鹦鹉";
				case 253:
					return "收割者";
				case 254:
					return "孢子僵尸";
				case 255:
					return "孢子僵尸";
				case 256:
					return "真菌水母";
				case 257:
					return "真菌甲虫";
				case 258:
					return "真菌蜗牛";
				case 259:
					return "真菌囊泡";
				case 260:
					return "巨型真菌囊泡";
				case 261:
					return "真菌孢子";
				case 262:
					return "世纪之花";
				case 263:
					return "世纪之花的藤钩";
				case 264:
					return "世纪之花的触须";
				case 265:
					return "孢子";
				case 266:
					return "克苏鲁之脑";
				case 267:
					return "爬行者";
				case 268:
					return "脓血乌贼";
				case 269:
					return "锈蚀装甲骷髅";
				case 270:
					return "锈蚀装甲骷髅";
				case 271:
					return "锈蚀装甲骷髅";
				case 272:
					return "锈蚀装甲骷髅";
				case 273:
					return "蓝色装甲骷髅";
				case 274:
					return "蓝色装甲骷髅";
				case 275:
					return "蓝色装甲骷髅";
				case 276:
					return "蓝色装甲骷髅";
				case 277:
					return "地狱装甲骷髅";
				case 278:
					return "地狱装甲骷髅";
				case 279:
					return "地狱装甲骷髅";
				case 280:
					return "地狱装甲骷髅";
				case 281:
					return "残袍法师";
				case 282:
					return "残袍法师";
				case 283:
					return "死灵巫师";
				case 284:
					return "死灵巫师";
				case 285:
					return "信魔者";
				case 286:
					return "信魔者";
				case 287:
					return "李小髅";
				case 288:
					return "地牢幽魂";
				case 289:
					return "巨大诅咒头骨";
				case 290:
					return "圣骑士";
				case 291:
					return "骷髅狙击手";
				case 292:
					return "骷髅突击队员";
				case 293:
					return "骷髅司令";
				case 294:
					return "愤怒的骷髅";
				case 295:
					return "愤怒的骷髅";
				case 296:
					return "愤怒的骷髅";
				case 297:
					return "蓝鸟";
				case 298:
					return "红雀";
				case 299:
					return "松鼠";
				case 300:
					return "老鼠";
				case 301:
					return "乌鸦";
				case 302:
					return "兔子史莱姆";
				case 303:
					return "史莱姆兔子";
				case 304:
					return "弹跳杰克";
				case 305:
					return "稻草人";
				case 306:
					return "稻草人";
				case 307:
					return "稻草人";
				case 308:
					return "稻草人";
				case 309:
					return "稻草人";
				case 310:
					return "稻草人";
				case 311:
					return "稻草人";
				case 312:
					return "稻草人";
				case 313:
					return "稻草人";
				case 314:
					return "稻草人";
				case 315:
					return "无头骑士";
				case 316:
					return "鬼魂";
				case 317:
					return "猫头鹰魔眼";
				case 318:
					return "哈罗魔眼";
				case 319:
					return "护士僵尸";
				case 320:
					return "超人僵尸";
				case 321:
					return "精灵僵尸";
				case 322:
					return "林肯骷髅";
				case 323:
					return "宇航员骷髅";
				case 324:
					return "外星骷髅";
				case 325:
					return "万圣树妖";
				case 326:
					return "刺枝怪";
				case 327:
					return "南瓜王";
				case 328:
					return "南瓜王";
				case 329:
					return "地狱犬";
				case 330:
					return "邪灵";
				case 331:
					return "圣诞僵尸";
				case 332:
					return "绿装圣诞僵尸";
				case 333:
					return "可爱蓝史莱姆";
				case 334:
					return "可爱绿史莱姆";
				case 335:
					return "可爱红史莱姆";
				case 336:
					return "可爱黄史莱姆";
				case 337:
					return "兔子";
				case 338:
					return "妖精僵尸";
				case 339:
					return "妖精僵尸";
				case 340:
					return "妖精僵尸";
				case 341:
					return "礼物宝箱怪";
				case 342:
					return "姜饼人";
				case 343:
					return "北风雪人";
				case 344:
					return "尖啸圣诞树";
				case 345:
					return "冰霜女皇";
				case 346:
					return "圣诞老人坦克NK-1型";
				case 347:
					return "妖精直升机";
				case 348:
					return "胡桃夹子";
				case 349:
					return "胡桃夹子";
				case 350:
					return "妖精弓箭手";
				case 351:
					return "克朗普斯";
				case 352:
					return "圣诞雪花";
				case 353:
					return "美发师";
				case 354:
					return "被缠住的美发师";
				case 355:
					return "萤火虫";
				case 356:
					return "蝴蝶";
				case 357:
					return "蠕虫";
				case 358:
					return "闪电萤火虫";
				case 359:
					return "蜗牛";
				case 360:
					return "荧光蜗牛";
				case 361:
					return "青蛙";
				case 362:
					return "鸭子";
				case 363:
					return "鸭子";
				case 364:
					return "鸭子";
				case 365:
					return "鸭子";
				case 366:
					return "黑蝎子";
				case 367:
					return "蝎子";
				case 368:
					return "游商";
				case 369:
					return "渔夫";
				case 370:
					return "猪鲨公爵";
				case 371:
					return "爆炸泡泡";
				case 372:
					return "龙卷鲨";
				case 373:
					return "龙卷鲨";
				case 374:
					return "松露虫";
				case 375:
					return "松露虫";
				case 376:
					return "睡着的渔夫";
				case 377:
					return "蟋蟀";
				case 378:
					return "尖牙炸弹";
				case 379:
					return "蓝色教徒弓手";
				case 380:
					return "白色教徒弓手";
				case 381:
					return "大脑操控者";
				case 382:
					return "激光枪手";
				case 383:
					return "火星军官";
				case 384:
					return "泡泡防护罩";
				case 385:
					return "灰色火星人";
				case 386:
					return "火星工程师";
				case 387:
					return "特斯拉炮塔";
				case 388:
					return "火星无人机";
				case 389:
					return "磁暴步兵";
				case 390:
					return "火星蛞蝓枪手";
				case 391:
					return "火星蛞蝓骑兵";
				case 392:
					return "火星飞碟";
				case 393:
					return "火星飞碟炮台";
				case 394:
					return "火星飞碟加农炮";
				case 395:
					return "火星飞碟核心";
				case 396:
					return "月之领主头颅";
				case 397:
					return "月之领主手臂";
				case 398:
					return "月之领主心脏";
				case 399:
					return "火星探测器";
				case 400:
					return "真·克苏鲁之眼";
				case 401:
					return "月之血蛭";
				case 402:
					return "银行穿梭者";
				case 403:
					return "银河穿梭者";
				case 404:
					return "银河穿梭者";
				case 405:
					return "星尘细胞";
				case 406:
					return "星尘细胞";
				case 407:
					return "激流入侵者";
				case 409:
					return "闪光炸弹发射器";
				case 410:
					return "闪光炸弹";
				case 411:
					return "观星者";
				case 412:
					return "日曜蜈蚣";
				case 413:
					return "日曜蜈蚣";
				case 414:
					return "日曜蜈蚣";
				case 415:
					return "日曜地龙";
				case 416:
					return "日曜地龙骑士";
				case 417:
					return "日曜滚动者";
				case 418:
					return "日曜头骨";
				case 419:
					return "日光住民";
				case 420:
					return "星云浮游者";
				case 421:
					return "大脑吸取者";
				case 422:
					return "旋涡之柱";
				case 423:
					return "星云野兽";
				case 424:
					return "星云先知";
				case 425:
					return "风暴潜兵";
				case 426:
					return "外星女皇";
				case 427:
					return "外星黄蜂";
				case 428:
					return "外星幼虫";
				case 429:
					return "旋涡士兵";
				case 430:
					return "僵尸";
				case 431:
					return "爱斯基摩僵尸";
				case 432:
					return "刀刃僵尸";
				case 433:
					return "史莱姆僵尸";
				case 434:
					return "沼泽僵尸";
				case 435:
					return "兽角僵尸";
				case 436:
					return "女性僵尸";
				case 437:
					return "月光石碑";
				case 438:
					return "月光献身者";
				case 439:
					return "远古信徒";
				case 440:
					return "远古信徒";
				case 441:
					return "税务官";
				case 442:
					return "金鸟";
				case 443:
					return "金兔子";
				case 444:
					return "金蝴蝶";
				case 445:
					return "金青蛙";
				case 446:
					return "金蟋蟀";
				case 447:
					return "金老鼠";
				case 448:
					return "金蠕虫";
				case 449:
					return "骷髅";
				case 450:
					return "头痛的骷髅";
				case 451:
					return "头装反的骷髅";
				case 452:
					return "没穿裤子的骷髅";
				case 453:
					return "骷髅商人";
				case 454:
					return "幽灵龙头颅";
				case 455:
					return "幽灵龙躯干";
				case 456:
					return "幽灵龙躯干";
				case 457:
					return "幽灵龙躯干";
				case 458:
					return "幽灵龙躯干";
				case 459:
					return "幽灵龙尾巴";
				case 460:
					return "屠夫";
				case 461:
					return "深渊生物";
				case 462:
					return "科学小怪人";
				case 463:
					return "钉子头";
				case 464:
					return "血腥兔子";
				case 465:
					return "血腥金鱼";
				case 466:
					return "疯子";
				case 467:
					return "致命球体";
				case 468:
					return "苍蝇人博士";
				case 469:
					return "魔化怪人";
				case 470:
					return "邪恶企鹅";
				case 471:
					return "哥布林召唤师";
				case 472:
					return "暗影之炎幽灵";
				case 473:
					return "腐化大宝箱怪";
				case 474:
					return "血腥大宝箱怪";
				case 475:
					return "神圣大宝箱怪";
				case 476:
					return "丛林大宝箱怪";
				case 477:
					return "摩斯拉飞蛾";
				case 478:
					return "摩斯拉的卵";
				case 479:
					return "摩斯拉幼体";
				case 480:
					return "美杜莎";
				case 481:
					return "重装步兵";
				case 482:
					return "花岗岩傀儡";
				case 483:
					return "花岗岩元素";
				case 484:
					return "魔法蠕虫";
				case 485:
					return "小蛆蛆";
				case 486:
					return "小鼻涕虫";
				case 487:
					return "小虫虫";
				case 488:
					return "假人标靶";
				case 489:
					return "鲜血僵尸";
				case 490:
					return "滴血魔眼";
				case 491:
					return "飞翔的荷兰人号";
				case 492:
					return "荷兰人大炮";
				case 493:
					return "星尘之柱";
				case 494:
					return "龙虾";
				case 495:
					return "龙虾";
				case 496:
					return "巨贝";
				case 497:
					return "巨贝";
				case 498:
					return "沙罗曼蛇";
				case 499:
					return "沙罗曼蛇";
				case 500:
					return "沙罗曼蛇";
				case 501:
					return "沙罗曼蛇";
				case 502:
					return "沙罗曼蛇";
				case 503:
					return "沙罗曼蛇";
				case 504:
					return "沙罗曼蛇";
				case 505:
					return "沙罗曼蛇";
				case 506:
					return "沙罗曼蛇";
				case 507:
					return "星云之柱";
				case 508:
					return "冲锋蚁狮";
				case 509:
					return "飞行蚁狮";
				case 510:
					return "沙丘穿行者头颅";
				case 511:
					return "沙丘穿行者躯干";
				case 512:
					return "沙丘穿行者尾巴";
				case 513:
					return "掘墓者头颅";
				case 514:
					return "掘墓者躯干";
				case 515:
					return "掘墓者尾巴";
				case 516:
					return "太阳耀斑";
				case 517:
					return "日曜之柱";
				case 518:
					return "日曜枪兵";
				case 519:
					return "日曜碎片";
				case 520:
					return "火星漫步者";
				case 521:
					return "远古凝视";
				case 522:
					return "远古光芒";
				case 523:
					return "远古毁灭骷髅";
				case 524:
					return "食尸鬼";
				case 525:
					return "邪恶食尸鬼";
				case 526:
					return "腐烂食尸鬼";
				case 527:
					return "梦幻食尸鬼";
				case 528:
					return "拉弥亚";
				case 529:
					return "拉弥亚";
				case 530:
					return "破坏之蝎";
				case 531:
					return "破坏之蝎";
				case 532:
					return "史前毒蜥";
				case 533:
					return "沙漠游魂";
				case 534:
					return "受折磨的灵魂";
				case 535:
					return "尖刺史莱姆";
				case 536:
					return "僵尸新娘";
				case 537:
					return "黄沙史莱姆";
				case 538:
					return "红松鼠";
				case 539:
					return "金松鼠";
				case 540:
					return "兔子";
				case 541:
					return "沙元素";
				case 542:
					return "沙漠鲨鱼";
				case 543:
					return "噬骨者";
				case 544:
					return "血肉收割者";
				case 545:
					return "水晶长尾鲨";
				case 546:
					return "愤怒不倒翁";
				case 547:
					return "???";
				case 548:
					return "艾特尼亚水晶";
				case 549:
					return "神秘的传送门";
				case 550:
					return "酒保";
				case 551:
					return "贝特西";
				case 552:
					return "艾特尼亚哥布林";
				case 553:
					return "艾特尼亚哥布林";
				case 554:
					return "艾特尼亚哥布林";
				case 555:
					return "艾特尼亚投弹手";
				case 556:
					return "艾特尼亚投弹手";
				case 557:
					return "艾特尼亚投弹手";
				case 558:
					return "艾特尼亚飞龙";
				case 559:
					return "艾特尼亚飞龙";
				case 560:
					return "艾特尼亚飞龙";
				case 561:
					return "艾特尼亚投枪手";
				case 562:
					return "艾特尼亚投枪手";
				case 563:
					return "艾特尼亚投枪手";
				case 564:
					return "黑魔法师";
				case 565:
					return "黑魔法师";
				case 566:
					return "旧日骷髅";
				case 567:
					return "旧日骷髅";
				case 568:
					return "凋零野兽";
				case 569:
					return "凋零野兽";
				case 570:
					return "独头龙";
				case 571:
					return "独头龙";
				case 572:
					return "狗头人";
				case 573:
					return "狗头人";
				case 574:
					return "滑翔狗头人";
				case 575:
					return "滑翔狗头人 ";
				case 576:
					return "食人魔";
				case 577:
					return "食人魔";
				case 578:
					return "艾特尼亚闪电虫";
				default:
					return string.Empty;
			}
		}

		public static string ToolTip(int id)
		{
			switch (id)
			{
				case 8:
					return "提供光照";
				case 15:
					return "显示当前时间";
				case 16:
					return "显示当前时间";
				case 17:
					return "显示当前时间";
				case 18:
					return "显示你所在的深度";
				case 23:
					return "'美味又易燃'";
				case 29:
					return "永久增加20点生命上限";
				case 33:
					return "用于熔炼矿物";
				case 35:
					return "用于制造金属制品";
				case 36:
					return "用于基本合成";
				case 43:
					return "召唤克苏鲁之眼";
				case 49:
					return "使你慢慢回复生命";
				case 50:
					return "魔镜魔镜，带我回家！";
				case 53:
					return "赋予持有者二段跳的能力";
				case 54:
					return "穿上后你会跑得飞快";
				case 56:
					return "'涌动着黑暗能量'";
				case 57:
					return "'涌动着黑暗能量'";
				case 64:
					return "召唤一道邪恶荆棘";
				case 65:
					return "召唤从天而降的落星";
				case 66:
					return "净化邪恶的物块";
				case 67:
					return "除去神圣化";
				case 68:
					return "'看起来很好吃!'";
				case 70:
					return "召唤世界吞噬者";
				case 75:
					return "遇光消失";
				case 84:
					return "'忍者飞檐走壁的工具'";
				case 85:
					return "可以爬上去";
				case 88:
					return "戴上后可以提供光照";
				case 98:
					return "33%几率不消耗弹药";
				case 100:
					return "增加7%近战速度";
				case 101:
					return "增加7%近战速度";
				case 102:
					return "增加7%近战速度";
				case 103:
					return "可以挖掘狱岩石";
				case 109:
					return "永久增加20点魔法上限";
				case 111:
					return "增加20点魔法上限";
				case 112:
					return "掷出一枚火球";
				case 113:
					return "射出一枚可以控制的魔法飞弹";
				case 114:
					return "使用魔法移动土块";
				case 115:
					return "召唤出一个散发微弱光芒的暗影魔法球";
				case 117:
					return "'触感温暖'";
				case 118:
					return "有些骷髅会收集这玩意，食人鱼也会用它磨牙";
				case 120:
					return "自动点燃射出的木箭";
				case 121:
					return "'它完全是由火做成的！'";
				case 123:
					return "增加7%魔法伤害";
				case 124:
					return "增加7%魔法伤害";
				case 125:
					return "增加7%魔法伤害";
				case 128:
					return "终于能飞了！不过还请小心摔伤";
				case 148:
					return "拿着这个东西你就开了嘲讽光环";
				case 149:
					return "'上面写满了神秘的符号'";
				case 151:
					return "增加4%远程伤害";
				case 152:
					return "增加4%远程伤害";
				case 153:
					return "增加4%远程伤害";
				case 156:
					return "使你免疫击退";
				case 157:
					return "喷出一道水柱";
				case 158:
					return "你再也不会摔死了";
				case 159:
					return "增加跳跃高度";
				case 165:
					return "射出一道慢慢飞行的水箭";
				case 166:
					return "造成一次能够摧毁物块的小型爆炸";
				case 167:
					return "造成一次能够摧毁物块的大型爆炸";
				case 168:
					return "造成一次不能摧毁物块的小型爆炸";
				case 175:
					return "'太烫了'";
				case 186:
					return "增加呼吸的时间，并允许在水中呼吸，但这玩意就只有这么长";
				case 187:
					return "你终于学会游泳了，可以加入游泳部了";
				case 190:
					return "这可是涂满了剧毒的毒剑";
				case 193:
					return "免疫灼热砖块灼伤";
				case 197:
					return "发射落星";
				case 208:
					return "‘它真漂亮,简直太漂亮了！'";
				case 211:
					return "增加12%近战速度";
				case 212:
					return "增加10%移动速度";
				case 213:
					return "在土块上制造草皮";
				case 215:
					return "'用这个后果自负'";
				case 218:
					return "召唤一枚可以控制的火球";
				case 222:
					return "可以用来种植草药";
				case 223:
					return "减少6%魔法消耗";
				case 227:
					return "减少药水冷却时间";
				case 228:
					return "增加20点魔法上限";
				case 229:
					return "增加20点魔法上限";
				case 230:
					return "增加20点魔法上限";
				case 235:
					return "‘有了粘性涂层这些炸弹终于不会乱滚了'";
				case 237:
					return "‘看我是不是很酷？'";
				case 238:
					return "增加15%魔法伤害";
				case 256:
					return "增加15%的投掷速度";
				case 257:
					return "增加15%的投掷伤害";
				case 258:
					return "增加10%的投掷暴击率";
				case 260:
					return "它闻起来很有趣....";
				case 261:
					return "'它有着一副促进食欲的笑容'";
				case 266:
					return "'这真是个好创意！'";
				case 267:
					return "'你真是个坏人！'";
				case 268:
					return "大大延长了水下呼吸的时间";
				case 272:
					return "射出一把恶魔之镰";
				case 281:
					return "可以收集种子来作为弹药";
				case 282:
					return "可以作为水下工作的光源";
				case 283:
					return "吹管专用";
				case 285:
					return "增加5%移动速度";
				case 288:
					return "使你免疫岩浆伤害";
				case 289:
					return "增加生命回复速度";
				case 290:
					return "增加25%移动速度";
				case 291:
					return "使你能在水中呼吸而不是在空气中";
				case 292:
					return "增加8点防御";
				case 293:
					return "增加魔法回复速度";
				case 294:
					return "增加20%魔法伤害";
				case 295:
					return "减慢坠落的速度";
				case 296:
					return "显示宝物和矿物的位置";
				case 297:
					return "得到隐形能力";
				case 298:
					return "使你发出一团光芒";
				case 299:
					return "增强夜视能力";
				case 300:
					return "增加怪物的刷新概率";
				case 301:
					return "反弹伤害";
				case 302:
					return "使你能在水上行走";
				case 303:
					return "增加弓箭20%的飞行速度和伤害";
				case 304:
					return "显示敌人的位置";
				case 305:
					return "使你能控制重力，刚开始会有点晕";
				case 324:
					return "'在大多数地方是被禁止的'";
				case 327:
					return "用来开启黄金宝箱";
				case 329:
					return "用来开启暗影宝箱";
				case 332:
					return "用来制作丝织品";
				case 352:
					return "用于酿造啤酒";
				case 357:
					return "蘑菇炖金鱼，小幅提升全属性";
				case 361:
					return "召唤一次哥布林入侵";
				case 363:
					return "用来制作高级木制品";
				case 367:
					return "这是一把强大到足以毁灭恶魔祭坛的锤子";
				case 371:
					return "增加40点魔法上限";
				case 372:
					return "增加7%近战速度";
				case 373:
					return "增加10%远程伤害";
				case 376:
					return "增加60点魔法上限";
				case 377:
					return "增加5%近战伤害和暴击率";
				case 378:
					return "增加12%远程伤害";
				case 385:
					return "可以挖掘秘银和山铜";
				case 386:
					return "可以挖掘精金和钛金";
				case 389:
					return "一定几率造成混乱效果，盯着太极图一分钟你就混乱了";
				case 393:
					return "显示你所处的水平坐标";
				case 394:
					return "它带有配套的脚蹼方便游泳";
				case 395:
					return "显示你的位置";
				case 396:
					return "使你不会受到坠落伤害";
				case 397:
					return "使你免疫击退";
				case 398:
					return "可以在这组合一些饰品";
				case 399:
					return "赋予持有者二段跳的能力";
				case 400:
					return "增加80点魔法上限";
				case 401:
					return "增加7%近战伤害和暴击率";
				case 402:
					return "增加14%远程伤害";
				case 403:
					return "增加6%所有伤害";
				case 404:
					return "增加4%暴击率";
				case 405:
					return "提供飞行能力";
				case 407:
					return "增加放置物块的距离";
				case 422:
					return "使一些砖块神圣化";
				case 423:
					return "使一些砖块被腐蚀";
				case 425:
					return "召唤一个散发光芒的魔法精灵";
				case 434:
					return "三连发，突突突";
				case 485:
					return "夜晚的月之力让你变成了狼人";
				case 486:
					return "在屏幕上显示出方便建筑的网格";
				case 489:
					return "增加15%魔法伤害";
				case 490:
					return "增加15%近战伤害";
				case 491:
					return "增加15%远程伤害";
				case 492:
					return "提供飞行和滑翔能力";
				case 493:
					return "提供飞行和滑翔能力";
				case 495:
					return "射出一团可以控制的彩虹";
				case 496:
					return "召唤一块持续一定时间的冰砖";
				case 497:
					return "可以让你在水中变成人鱼，哦，可惜你变成了鱼人";
				case 506:
					return "使用凝胶作为弹药";
				case 509:
					return "设置红色导线";
				case 510:
					return "用来清除导线";
				case 515:
					return "击中后产生四散的魔晶碎片";
				case 516:
					return "击中后引发星辰坠落";
				case 517:
					return "一把能够自动回收的魔法飞刀";
				case 518:
					return "快速地射出魔晶碎片";
				case 519:
					return "召唤诅咒火球";
				case 520:
					return "'光明生物的精魂'";
				case 521:
					return "'黑暗生物的精魂'";
				case 522:
					return "'即使水也无法扑灭这种火焰'";
				case 523:
					return "可以放在水中";
				case 524:
					return "用来熔炼精金和钛金矿";
				case 525:
					return "用来制作秘银，山铜，精金和钛金系列的道具";
				case 526:
					return "'锋利而且蕴含魔力'";
				case 527:
					return "有些黑暗沙漠里的木乃伊会把它带在身上'";
				case 528:
					return "'有些光明沙漠里的木乃伊会把它带在身上'";
				case 529:
					return "踩上去就会产生信号";
				case 531:
					return "这是一本可以写咒语的空白魔法书";
				case 532:
					return "受到伤害时引起星辰坠落";
				case 533:
					return "50%几率不消耗弹药";
				case 534:
					return "射出分散的弹幕";
				case 535:
					return "减少生命药剂的冷却时间";
				case 536:
					return "增强近战攻击的击退效果";
				case 541:
					return "踩上去就会产生信号";
				case 542:
					return "玩家踩上去才会产生信号";
				case 543:
					return "玩家踩上去才会产生信号";
				case 544:
					return "召唤双子魔眼";
				case 547:
					return "'恐惧之王的精魂'";
				case 548:
					return "'机械毁灭者的精魂'";
				case 549:
					return "'全知魔眼的精魂'";
				case 551:
					return "增加7%暴击率";
				case 552:
					return "增加7%全部伤害";
				case 553:
					return "增加15%远程伤害";
				case 554:
					return "神圣的十字架会延长你受到伤害后的无敌时间";
				case 555:
					return "减少8%魔法消耗";
				case 556:
					return "召唤机械毁灭者";
				case 557:
					return "召唤机械骷髅王";
				case 558:
					return "增加100点魔法上限";
				case 559:
					return "增加10%近战伤害和暴击率";
				case 560:
					return "召唤史莱姆王";
				case 561:
					return "可以堆叠5个";
				case 575:
					return "'强大飞行生物的精魂'";
				case 576:
					return "你有机会记录背景音乐了";
				case 579:
					return "'不要觉得一个又是镐又是斧的东西很奇怪啦'";
				case 580:
					return "激活后爆炸";
				case 581:
					return "输送液体至出水泵";
				case 582:
					return "从入水泵输出液体";
				case 583:
					return "每一秒产生一次信号";
				case 584:
					return "每三秒产生一次信号";
				case 585:
					return "每五秒产生一次信号";
				case 599:
					return "右键打开";
				case 600:
					return "右键打开";
				case 601:
					return "右键打开";
				case 602:
					return "召唤雪人军团";
				case 603:
					return "召唤一只宠物兔";
				case 665:
					return "'用来扮演开发者超棒！'";
				case 666:
					return "'用来扮演开发者超棒！'";
				case 667:
					return "'用来扮演开发者超棒！'";
				case 668:
					return "'用来扮演开发者超棒！'";
				case 669:
					return "召唤一只小企鹅";
				case 676:
					return "射出一发冰箭";
				case 678:
					return "仅为有价值的人而生";
				case 683:
					return "召唤恶魔之叉";
				case 684:
					return "增加16%近战和远程伤害";
				case 685:
					return "增加11%近战和远程暴击率";
				case 686:
					return "增加8%移动速度";
				case 707:
					return "显示当前时间";
				case 708:
					return "显示当前时间";
				case 709:
					return "显示当前时间";
				case 716:
					return "用来制造金属制品";
				case 723:
					return "射出一道光刃";
				case 724:
					return "射出一发冰箭";
				case 725:
					return "这把弓上的寒气会让射出的箭都变为冰箭";
				case 726:
					return "射出一团霜冻寒气";
				case 748:
					return "提供飞行和滑翔能力";
				case 749:
					return "提供飞行和滑翔能力";
				case 753:
					return "召唤一只宠物龟";
				case 761:
					return "提供飞行和滑翔能力";
				case 779:
					return "喷洒能够改变生态环境的特种弹药";
				case 780:
					return "环境改造者专用的特种弹药";
				case 781:
					return "环境改造者专用的特种弹药";
				case 782:
					return "环境改造者专用的特种弹药";
				case 783:
					return "环境改造者专用的特种弹药";
				case 784:
					return "环境改造者专用的特种弹药";
				case 785:
					return "提供飞行和滑翔能力";
				case 786:
					return "提供飞行和滑翔能力";
				case 787:
					return "一把强大到足以毁灭恶魔祭坛的锤子";
				case 788:
					return "召唤一根荆棘之矛";
				case 792:
					return "增加2%所有伤害";
				case 793:
					return "增加2%所有伤害";
				case 794:
					return "增加2%所有伤害";
				case 798:
					return "可以挖掘狱岩石了";
				case 821:
					return "提供飞行和滑翔能力";
				case 822:
					return "提供飞行和滑翔能力";
				case 823:
					return "提供飞行和滑翔能力";
				case 832:
					return "可以消耗木材来制造生命之木";
				case 849:
					return "使固体砖块能够通过电路信号切换虚实";
				case 850:
					return "放置蓝色导线";
				case 851:
					return "放置绿色导线";
				case 852:
					return "有玩家踩踏时才会产生信号";
				case 853:
					return "有玩家以外的东西踩踏时才会产生信号";
				case 854:
					return "商店放血跳楼价！";
				case 855:
					return "攻击敌人时可能掉落额外的硬币";
				case 856:
					return "'祝你玩得开心！'";
				case 857:
					return "赋予持有者二段跳的能力，而且跳得更高";
				case 860:
					return "加快生命回复速度并减少生命药水的冷却时间";
				case 861:
					return "晚上你能变狼人，下水你能变鱼人，你已经超出人类范围了";
				case 862:
					return "受到伤害后召唤落星并延长无敌时间";
				case 863:
					return "提供水上行走的能力";
				case 885:
					return "使你免疫出血";
				case 886:
					return "使你免疫破甲";
				case 887:
					return "使你免疫中毒";
				case 888:
					return "使你免疫黑暗";
				case 889:
					return "使你免疫减速";
				case 890:
					return "使你免疫沉默";
				case 891:
					return "使你免疫诅咒";
				case 892:
					return "使你免疫虚弱";
				case 893:
					return "使你免疫混乱";
				case 897:
					return "增强近战击退效果";
				case 898:
					return "提供飞行能力";
				case 899:
					return "在白天会增加你的所有属性";
				case 900:
					return "在夜晚会增加你的所有属性";
				case 901:
					return "使你免疫虚弱和破甲";
				case 902:
					return "使你免疫中毒和出血";
				case 903:
					return "使你免疫减速和混乱";
				case 904:
					return "使你免疫沉默和诅咒";
				case 905:
					return "使用钱币来作为弹药";
				case 906:
					return "使你能在岩浆中安全地呆7秒";
				case 907:
					return "提供水上行走的能力";
				case 908:
					return "提供在水和岩浆上行走的能力";
				case 932:
					return "一把可以让骨头结合成砖块的神奇魔杖";
				case 933:
					return "可以将木材转化成厚厚的树叶";
				case 934:
					return "你能踩在上面飞一段时间";
				case 935:
					return "增加12%所有伤害";
				case 936:
					return "增强近战攻击的击退效果";
				case 937:
					return "不要踩它，会爆炸的";
				case 938:
					return "为队友吸收25%的伤害";
				case 946:
					return "拿着它你的下落速度会减慢";
				case 947:
					return "这种如同植物一样的矿物能对光产生反应";
				case 948:
					return "提供飞行和滑翔能力";
				case 950:
					return "使你在冰面上轻松移动";
				case 951:
					return "高速地射出雪球";
				case 953:
					return "使你能在墙上慢慢滑下来";
				case 956:
					return "增加7%近战速度";
				case 957:
					return "增加7%近战速度";
				case 958:
					return "增加7%近战速度";
				case 959:
					return "增加4%远程伤害.";
				case 960:
					return "增加20点魔法上限";
				case 961:
					return "增加20点魔法上限";
				case 962:
					return "增加20点魔法上限";
				case 963:
					return "使你能像忍者一样闪避受到的攻击";
				case 964:
					return "射出分散的弹幕";
				case 965:
					return "可以让你爬上去";
				case 966:
					return "在篝火附近你的生命恢复速度会加快";
				case 967:
					return "用棍子把它串起来放在篝火上烤吧";
				case 968:
					return "在篝火上烤它！";
				case 969:
					return "小幅提升所有属性";
				case 975:
					return "使你能在墙上慢慢滑下来";
				case 976:
					return "使你能爬墙";
				case 977:
					return "使你能冲刺";
				case 982:
					return "增加20点魔法上限";
				case 983:
					return "赋予持有者二段跳的能力";
				case 984:
					return "使你能爬墙而且能冲刺";
				case 985:
					return "扔出一串能让你爬上去的绳子";
				case 986:
					return "可以收集草籽作为弹药";
				case 987:
					return "赋予持有者二段跳的能力";
				case 989:
					return "射出一把魔法光剑";
				case 990:
					return "'不要觉得一个又是镐又是斧头的东西很奇怪'";
				case 994:
					return "召唤一只小型灵魂吞噬者";
				case 995:
					return "用来制造沥青";
				case 996:
					return "用来制造肉块";
				case 997:
					return "将泥砂和雪砂变成更有用的东西";
				case 998:
					return "用来固化凝胶";
				case 1000:
					return "射出漫天的五彩纸花！";
				case 1001:
					return "增加16%近战伤害";
				case 1002:
					return "增加16%远程伤害";
				case 1003:
					return "增加80点魔法上限并减少17%的魔法消耗";
				case 1004:
					return "增加5%所有伤害";
				case 1005:
					return "增加8%暴击率";
				case 1006:
					return "这种如同植物一样的矿物能对光产生反应";
				case 1071:
					return "用来给砖块刷上各色油漆";
				case 1072:
					return "用来给墙壁刷上各色油漆";
				case 1100:
					return "用来清除油漆";
				case 1107:
					return "可以调制成青色染料";
				case 1108:
					return "可以调制成绿色染料";
				case 1109:
					return "可以调制成天蓝染料";
				case 1110:
					return "可以调制成黄色染料";
				case 1111:
					return "可以调制成蓝色染料";
				case 1112:
					return "可以调制成橙绿染料";
				case 1113:
					return "可以调制成粉色染料";
				case 1114:
					return "可以调制成橙色染料";
				case 1115:
					return "可以调制成红色染料";
				case 1116:
					return "可以调制成靓青染料";
				case 1117:
					return "可以调制成浅紫染料";
				case 1118:
					return "可以调制成紫色染料";
				case 1119:
					return "可以调制成黑色染料";
				case 1120:
					return "用来调制染料";
				case 1121:
					return "射出跟踪敌人的小蜜蜂";
				case 1122:
					return "它会跟踪你的敌人";
				case 1123:
					return "攻击敌人后召唤小蜜蜂";
				case 1129:
					return "用来放置蜂巢砖";
				case 1130:
					return "爆炸后释放一群小蜜蜂";
				case 1131:
					return "使你能够颠倒重力";
				case 1132:
					return "受伤后释放小蜜蜂";
				case 1133:
					return "召唤蜂后";
				case 1141:
					return "可以打开丛林中那座神庙的大门";
				case 1145:
					return "用来合成一些基本的东西";
				case 1151:
					return "有玩家踩踏时才会产生信号";
				case 1156:
					return "它会咬住敌人并造成连续伤害";
				case 1157:
					return "召唤为你而战的小矮人";
				case 1158:
					return "增加最大召唤物数量";
				case 1159:
					return "增加最大召唤物数量";
				case 1160:
					return "增加最大召唤物数量";
				case 1161:
					return "增加最大召唤物数量";
				case 1162:
					return "提供飞行和滑翔能力";
				case 1163:
					return "赋予持有者二段跳的能力";
				case 1164:
					return "赋予持有者四段跳的能力";
				case 1165:
					return "提供飞行和滑翔能力";
				case 1167:
					return "增加15%召唤物伤害";
				case 1169:
					return "召唤一个小骷髅头";
				case 1170:
					return "召唤一只小黄蜂";
				case 1171:
					return "召唤一个提基之灵";
				case 1172:
					return "召唤一只宠物蜥蜴";
				case 1178:
					return "迅速地射出飞叶快刀";
				case 1179:
					return "它会跟踪你的敌人";
				case 1180:
					return "召唤一只宠物鹦鹉";
				case 1181:
					return "召唤一个小蘑菇人";
				case 1182:
					return "召唤一颗宠物树苗";
				case 1183:
					return "召唤瓶子里的小精灵来提供光亮";
				case 1188:
					return "可以挖掘秘银，山铜，精金和钛金";
				case 1189:
					return "可以挖掘秘银，山铜，精金和钛金";
				case 1195:
					return "可以挖掘精金和钛金";
				case 1196:
					return "可以挖掘精金和钛金";
				case 1205:
					return "增加8%近战伤害";
				case 1206:
					return "增加9%远程伤害";
				case 1207:
					return "增加7%魔法伤害和暴击率";
				case 1208:
					return "增加3%所有伤害";
				case 1209:
					return "增加2%所有伤害";
				case 1210:
					return "增加7%近战伤害";
				case 1211:
					return "增加15%远程暴击率";
				case 1212:
					return "增加18%魔法暴击率";
				case 1213:
					return "增加6%暴击率";
				case 1214:
					return "增加11%移动速度";
				case 1215:
					return "增加8%近战伤害和暴击率";
				case 1216:
					return "增加16%远程伤害";
				case 1217:
					return "增加16%魔法伤害并增加7%魔法暴击率";
				case 1218:
					return "增加4%所有伤害";
				case 1219:
					return "增加3%所有伤害和暴击率";
				case 1220:
					return "用来制作秘银，山铜，精金和钛金系列的物品";
				case 1221:
					return "用来熔炼精金和钛金矿";
				case 1226:
					return "挥动时会射出一枚强力光球";
				case 1227:
					return "挥动时会带出一片孢子毒云";
				case 1228:
					return "挥动时会带出一片孢子毒云";
				case 1235:
					return "击中墙后会弹回";
				case 1242:
					return "召唤一只小恐龙";
				case 1244:
					return "召唤一朵雷云在你的敌人上空下雨";
				case 1247:
					return "受到伤害时召唤落星和小蜜蜂";
				case 1248:
					return "增加10%暴击率";
				case 1249:
					return "增加跳跃高度";
				case 1250:
					return "赋予持有者二段跳的能力";
				case 1251:
					return "赋予持有者二段跳的能力";
				case 1252:
					return "赋予持有者二段跳的能力";
				case 1253:
					return "生命值低于25%时召唤一个能阻挡伤害的护盾";
				case 1254:
					return "射出强大而且高速的子弹";
				case 1255:
					return "射出强大而且高速的子弹";
				case 1256:
					return "召唤一朵血云在你的敌人上空降下血雨";
				case 1258:
					return "射出一支会爆炸的钉刺";
				case 1259:
					return "向四周的敌人射出锋利的花瓣";
				case 1260:
					return "射出一道能造成持续伤害的魔法彩虹";
				case 1261:
					return "爆炸后还会射出致命的碎片";
				case 1264:
					return "射出一个冰霜法球";
				case 1265:
					return "射出强大而且高速的子弹";
				case 1282:
					return "增加20点魔法上限";
				case 1283:
					return "增加40点魔法上限";
				case 1284:
					return "增加40点魔法上限";
				case 1285:
					return "增加60点魔法上限";
				case 1286:
					return "增加60点魔法上限";
				case 1287:
					return "增加80点魔法上限";
				case 1290:
					return "受到伤害后增加移动速度";
				case 1291:
					return "永久增加5点生命上限";
				case 1293:
					return "请在神庙祭坛上使用";
				case 1294:
					return "可以挖掘神庙砖块";
				case 1295:
					return "射出一道穿透性的热能射线";
				case 1296:
					return "召唤一枚强大的巨石";
				case 1297:
					return "以石巨人的力量出拳！";
				case 1299:
					return "拿着的时候会增加视野";
				case 1300:
					return "增加枪械的瞄准视野";
				case 1301:
					return "增加10%所有伤害";
				case 1303:
					return "在水下提供光照";
				case 1306:
					return "射出一把旋转的冰之镰";
				case 1307:
					return "'你真是个吝啬鬼！'";
				case 1308:
					return "射出数枚能穿透多个敌人的毒牙";
				case 1309:
					return "召唤一只小史莱姆为你而战";
				case 1310:
					return "攻击时会造成毒素伤害";
				case 1311:
					return "召唤一只弹簧眼球";
				case 1312:
					return "召唤一个小雪人";
				case 1313:
					return "射出一个骷髅头";
				case 1314:
					return "射出一个拳击手套";
				case 1315:
					return "召唤海盗入侵，其实没人知道宝藏到底在哪";
				case 1316:
					return "增加6%近战伤害";
				case 1317:
					return "增加8%近战伤害和暴击率";
				case 1318:
					return "增加4%近战暴击率";
				case 1321:
					return "增加弓箭10%的飞行速度和伤害";
				case 1322:
					return "攻击时会造成火焰伤害";
				case 1323:
					return "减少你接触岩浆时受到的伤害";
				case 1326:
					return "传送到鼠标所在的地方，长时间使用可能会使人脱离物质世界";
				case 1327:
					return "射出一把旋转的死亡之镰";
				case 1331:
					return "召唤克苏鲁之脑";
				case 1332:
					return "'你就当这是神之血'";
				case 1333:
					return "可以放置在水中";
				case 1334:
					return "减少目标的防御";
				case 1335:
					return "减少目标的防御";
				case 1336:
					return "喷出黄金脓血";
				case 1343:
					return "提高近战攻击的击退效果并造成火焰伤害";
				case 1372:
					return "'W. Garner'";
				case 1373:
					return "'W. Garner'";
				case 1374:
					return "'W. Garner'";
				case 1375:
					return "'W. Garner'";
				case 1419:
					return "'W. Garner'";
				case 1420:
					return "'W. Garner'";
				case 1421:
					return "'W. Garner'";
				case 1422:
					return "'R. Moosdijk'";
				case 1423:
					return "'R. Moosdijk'";
				case 1424:
					return "'V. Costa Moura'";
				case 1425:
					return "'W. Garner'";
				case 1426:
					return "'W. Garner'";
				case 1427:
					return "'W. Garner'";
				case 1428:
					return "'W. Garner'";
				case 1430:
					return "用来制作给武器附魔的药剂";
				case 1432:
					return "用来制作各种类型的弹药";
				case 1433:
					return "'K. Wright'";
				case 1434:
					return "'C. J. Ness'";
				case 1435:
					return "'R. Moosdijk'";
				case 1436:
					return "'V. Costa Moura'";
				case 1437:
					return "'V. Costa Moura'";
				case 1438:
					return "'V. Costa Moura'";
				case 1439:
					return "'V. Costa Moura'";
				case 1440:
					return "'V. Costa Moura'";
				case 1441:
					return "'A. G. Kolf'";
				case 1442:
					return "'V. Costa Moura'";
				case 1443:
					return "'W. Garner'";
				case 1444:
					return "发射一道会反射的暗影射线";
				case 1445:
					return "发射一枚爆裂火球";
				case 1446:
					return "召唤一个迷失的灵魂追踪敌人";
				case 1449:
					return "会产生很多泡泡";
				case 1450:
					return "泡泡~泡泡~泡泡~泡泡";
				case 1476:
					return "'J. T. Myhre'";
				case 1477:
					return "'J. T. Myhre'";
				case 1478:
					return "'J. T. Myhre'";
				case 1479:
					return "'J. T. Myhre'";
				case 1480:
					return "'J. T. Myhre'";
				case 1481:
					return "'V. Costa Moura'";
				case 1482:
					return "'V. Costa Moura'";
				case 1483:
					return "'V. Costa Moura'";
				case 1484:
					return "'V. Costa Moura'";
				case 1485:
					return "'V. Costa Moura'";
				case 1486:
					return "'V. Costa Moura'";
				case 1487:
					return "'V. Costa Moura'";
				case 1488:
					return "'V. Costa Moura'";
				case 1489:
					return "'V. Costa Moura'";
				case 1490:
					return "'V. Costa Moura'";
				case 1491:
					return "'V. Costa Moura'";
				case 1492:
					return "'V. Costa Moura'";
				case 1493:
					return "'V. Costa Moura'";
				case 1494:
					return "'V. Costa Moura'";
				case 1495:
					return "'A. G. Kolf'";
				case 1496:
					return "'J. T. Myhre'";
				case 1497:
					return "'J. T. Myhre'";
				case 1498:
					return "'J. T. Myhre'";
				case 1499:
					return "'J. T. Myhre'";
				case 1500:
					return "'A. G. Kolf'";
				case 1501:
					return "'W. Garner'";
				case 1502:
					return "'C. Burczyk'";
				case 1503:
					return "减少40%魔力伤害";
				case 1504:
					return "增加7%的魔法伤害和暴击率";
				case 1505:
					return "增加8%魔法伤害";
				case 1513:
					return "一把强大的回旋飞锤";
				case 1515:
					return "提供飞行和滑翔能力";
				case 1522:
					return "可以用来玩争夺宝石之类游戏活动，死亡后掉落";
				case 1523:
					return "可以用来玩争夺宝石之类游戏活动，死亡后掉落";
				case 1524:
					return "可以用来玩争夺宝石之类游戏活动，死亡后掉落";
				case 1525:
					return "可以用来玩争夺宝石之类游戏活动，死亡后掉落";
				case 1526:
					return "可以用来玩争夺宝石之类游戏活动，死亡后掉落";
				case 1527:
					return "可以用来玩争夺宝石之类游戏活动，死亡后掉落";
				case 1533:
					return "打开一个地牢里的丛林宝箱";
				case 1534:
					return "打开一个地牢里的腐化宝箱";
				case 1535:
					return "打开一个地牢里的血腥宝箱";
				case 1536:
					return "打开一个地牢里的神圣宝箱";
				case 1537:
					return "打开一个地牢里的冰霜宝箱";
				case 1538:
					return "'J. T. Myhre'";
				case 1539:
					return "'A. Craig'";
				case 1540:
					return "'A. Craig'";
				case 1541:
					return "'A. Craig'";
				case 1542:
					return "'A. Craig'";
				case 1543:
					return "用来给砖块刷上各色油漆";
				case 1544:
					return "用来给墙壁刷上各色油漆";
				case 1545:
					return "用来消除油漆";
				case 1546:
					return "增加15%的弓箭伤害";
				case 1547:
					return "增加15%的子弹伤害";
				case 1548:
					return "增加15%的火箭弹伤害";
				case 1549:
					return "增加13%远程暴击率";
				case 1550:
					return "增加7%远程暴击率";
				case 1551:
					return "将叶绿锭转换成蘑菇锭";
				case 1553:
					return "50%概率不消耗弹药";
				case 1554:
					return "'用来扮演开发者超棒！'";
				case 1555:
					return "'用来扮演开发者超棒！'";
				case 1556:
					return "'用来扮演开发者超棒！'";
				case 1557:
					return "'用来扮演开发者超棒！'";
				case 1558:
					return "'用来扮演开发者超棒！'";
				case 1559:
					return "'用来扮演开发者超棒！'";
				case 1560:
					return "'用来扮演开发者超棒！'";
				case 1561:
					return "'用来扮演开发者超棒！'";
				case 1562:
					return "'用来扮演开发者超棒！'";
				case 1563:
					return "'用来扮演开发者超棒！'";
				case 1564:
					return "'用来扮演开发者超棒！'";
				case 1565:
					return "'用来扮演开发者超棒！'";
				case 1566:
					return "'用来扮演开发者超棒！'";
				case 1567:
					return "'用来扮演开发者超棒！'";
				case 1568:
					return "'用来扮演开发者超棒！'";
				case 1569:
					return "迅速扔出多枚吸血飞刀";
				case 1571:
					return "一杆强大的，能够释放很多吞噬者的投枪";
				case 1572:
					return "召唤一只强大的冰霜九头蛇向敌人吐出冰晶";
				case 1573:
					return "'W. Garner'";
				case 1574:
					return "'W. Garner'";
				case 1575:
					return "'W. Garner'";
				case 1576:
					return "'D. Phelps'";
				case 1577:
					return "'M. J. Duncan'";
				case 1578:
					return "受到伤害后释放小蜜蜂并加快移动速度";
				case 1579:
					return "穿上后能跑得飞快";
				case 1580:
					return "'用来扮演开发者超棒！'";
				case 1581:
					return "'用来扮演开发者超棒！'";
				case 1582:
					return "'用来扮演开发者超棒！'";
				case 1583:
					return "'用来扮演开发者超棒！'";
				case 1584:
					return "'用来扮演开发者超棒！'";
				case 1585:
					return "'用来扮演开发者超棒！'";
				case 1586:
					return "'用来扮演开发者超棒！'";
				case 1587:
					return "'用来扮演开发者超棒！'";
				case 1588:
					return "'用来扮演开发者超棒！'";
				case 1595:
					return "增加20点魔法上限";
				case 1612:
					return "使你免疫大多数负面效果";
				case 1613:
					return "使你免疫击退和灼烧砖块的伤害";
				case 1615:
					return "旗帜附近玩家对抗下列怪物时获得加成: 琵琶鱼";
				case 1616:
					return "旗帜附近玩家对抗下列怪物时获得加成: 愤怒雷云";
				case 1617:
					return "旗帜附近玩家对抗下列怪物时获得加成: 真菌甲虫";
				case 1618:
					return "旗帜附近玩家对抗下列怪物时获得加成: 蚁狮";
				case 1619:
					return "旗帜附近玩家对抗下列怪物时获得加成: 巨骨舌鱼";
				case 1620:
					return "旗帜附近玩家对抗下列怪物时获得加成: 装甲骷髅";
				case 1621:
					return "旗帜附近玩家对抗下列怪物时获得加成: 洞穴蝙蝠";
				case 1622:
					return "旗帜附近玩家对抗下列怪物时获得加成: 小鸟";
				case 1623:
					return "旗帜附近玩家对抗下列怪物时获得加成: 黑隐者";
				case 1624:
					return "旗帜附近玩家对抗下列怪物时获得加成: 血腥哺育者";
				case 1625:
					return "旗帜附近玩家对抗下列怪物时获得加成: 鲜血水母";
				case 1626:
					return "旗帜附近玩家对抗下列怪物时获得加成: 血腥爬行者";
				case 1627:
					return "旗帜附近玩家对抗下列怪物时获得加成: 骨蛇";
				case 1628:
					return "旗帜附近玩家对抗下列怪物时获得加成: 兔子";
				case 1629:
					return "旗帜附近玩家对抗下列怪物时获得加成: 混沌元素";
				case 1630:
					return "旗帜附近玩家对抗下列怪物时获得加成: 模仿者";
				case 1631:
					return "旗帜附近玩家对抗下列怪物时获得加成: 小丑";
				case 1632:
					return "旗帜附近玩家对抗下列怪物时获得加成: 腐化兔子";
				case 1633:
					return "旗帜附近玩家对抗下列怪物时获得加成: 腐化金鱼";
				case 1634:
					return "旗帜附近玩家对抗下列怪物时获得加成: 螃蟹";
				case 1635:
					return "旗帜附近玩家对抗下列怪物时获得加成: 血肉之虫";
				case 1636:
					return "旗帜附近玩家对抗下列怪物时获得加成: 血腥之斧";
				case 1637:
					return "旗帜附近玩家对抗下列怪物时获得加成: 诅咒圣锤";
				case 1638:
					return "旗帜附近玩家对抗下列怪物时获得加成: 恶魔";
				case 1639:
					return "旗帜附近玩家对抗下列怪物时获得加成: 恶魔之眼";
				case 1640:
					return "旗帜附近玩家对抗下列怪物时获得加成: 巨眼虫";
				case 1641:
					return "旗帜附近玩家对抗下列怪物时获得加成: 灵魂吞噬者";
				case 1642:
					return "旗帜附近玩家对抗下列怪物时获得加成: 魔化圣剑";
				case 1643:
					return "旗帜附近玩家对抗下列怪物时获得加成: 爱斯基摩僵尸";
				case 1644:
					return "旗帜附近玩家对抗下列怪物时获得加成: 巨脸怪";
				case 1645:
					return "旗帜附近玩家对抗下列怪物时获得加成: 浮空血魂";
				case 1646:
					return "旗帜附近玩家对抗下列怪物时获得加成: 飞鱼";
				case 1647:
					return "旗帜附近玩家对抗下列怪物时获得加成: 羽蛇";
				case 1648:
					return "旗帜附近玩家对抗下列怪物时获得加成: 科学怪人";
				case 1649:
					return "旗帜附近玩家对抗下列怪物时获得加成: 真菌囊泡";
				case 1650:
					return "旗帜附近玩家对抗下列怪物时获得加成: 真菌水母";
				case 1651:
					return "旗帜附近玩家对抗下列怪物时获得加成: 神圣蜗牛";
				case 1652:
					return "旗帜附近玩家对抗下列怪物时获得加成: 哥布林盗贼";
				case 1653:
					return "旗帜附近玩家对抗下列怪物时获得加成: 哥布林法师";
				case 1654:
					return "旗帜附近玩家对抗下列怪物时获得加成: 哥布林苦工";
				case 1655:
					return "旗帜附近玩家对抗下列怪物时获得加成: 哥布林斥候";
				case 1656:
					return "旗帜附近玩家对抗下列怪物时获得加成: 哥布林战士";
				case 1657:
					return "旗帜附近玩家对抗下列怪物时获得加成: 金鱼";
				case 1658:
					return "旗帜附近玩家对抗下列怪物时获得加成: 鹰身女妖";
				case 1659:
					return "旗帜附近玩家对抗下列怪物时获得加成: 地狱蝙蝠";
				case 1660:
					return "旗帜附近玩家对抗下列怪物时获得加成: 鲜血棘虫";
				case 1661:
					return "旗帜附近玩家对抗下列怪物时获得加成: 毒蜂";
				case 1662:
					return "旗帜附近玩家对抗下列怪物时获得加成: 冰元素";
				case 1663:
					return "旗帜附近玩家对抗下列怪物时获得加成: 寒冰鱼人";
				case 1664:
					return "旗帜附近玩家对抗下列怪物时获得加成: 火魔精";
				case 1665:
					return "旗帜附近玩家对抗下列怪物时获得加成: 蓝水母";
				case 1666:
					return "旗帜附近玩家对抗下列怪物时获得加成: 丛林爬行者";
				case 1667:
					return "旗帜附近玩家对抗下列怪物时获得加成: 蜥蜴";
				case 1668:
					return "旗帜附近玩家对抗下列怪物时获得加成: 食人花";
				case 1669:
					return "旗帜附近玩家对抗下列怪物时获得加成: 陨石怪";
				case 1670:
					return "旗帜附近玩家对抗下列怪物时获得加成: 毒蛾";
				case 1671:
					return "旗帜附近玩家对抗下列怪物时获得加成: 木乃伊";
				case 1672:
					return "旗帜附近玩家对抗下列怪物时获得加成: 真菌蜗牛";
				case 1673:
					return "旗帜附近玩家对抗下列怪物时获得加成: 鹦鹉";
				case 1674:
					return "旗帜附近玩家对抗下列怪物时获得加成: 剑齿亚龙";
				case 1675:
					return "旗帜附近玩家对抗下列怪物时获得加成: 食人鱼";
				case 1676:
					return "旗帜附近玩家对抗下列怪物时获得加成: 海盗水手";
				case 1677:
					return "旗帜附近玩家对抗下列怪物时获得加成: 小精灵";
				case 1678:
					return "旗帜附近玩家对抗下列怪物时获得加成: 雨衣僵尸";
				case 1679:
					return "旗帜附近玩家对抗下列怪物时获得加成: 收割者";
				case 1680:
					return "旗帜附近玩家对抗下列怪物时获得加成: 鲨鱼";
				case 1681:
					return "旗帜附近玩家对抗下列怪物时获得加成: 骷髅";
				case 1682:
					return "旗帜附近玩家对抗下列怪物时获得加成: 黑魔术师";
				case 1683:
					return "旗帜附近玩家对抗下列怪物时获得加成: 蓝色史莱姆";
				case 1684:
					return "旗帜附近玩家对抗下列怪物时获得加成: 雪球怪";
				case 1685:
					return "旗帜附近玩家对抗下列怪物时获得加成: 洞穴蜘蛛";
				case 1686:
					return "旗帜附近玩家对抗下列怪物时获得加成: 孢子僵尸";
				case 1687:
					return "旗帜附近玩家对抗下列怪物时获得加成: 沼泽魔怪";
				case 1688:
					return "旗帜附近玩家对抗下列怪物时获得加成: 巨大乌龟";
				case 1689:
					return "旗帜附近玩家对抗下列怪物时获得加成: 污泥怪";
				case 1690:
					return "旗帜附近玩家对抗下列怪物时获得加成: 雨伞史莱姆";
				case 1691:
					return "旗帜附近玩家对抗下列怪物时获得加成: 独角兽";
				case 1692:
					return "旗帜附近玩家对抗下列怪物时获得加成: 吸血鬼";
				case 1693:
					return "旗帜附近玩家对抗下列怪物时获得加成: 秃鹫";
				case 1694:
					return "旗帜附近玩家对抗下列怪物时获得加成: 染血女神";
				case 1695:
					return "旗帜附近玩家对抗下列怪物时获得加成: 狼人";
				case 1696:
					return "旗帜附近玩家对抗下列怪物时获得加成: 雪狼";
				case 1697:
					return "旗帜附近玩家对抗下列怪物时获得加成: 世界哺育者";
				case 1698:
					return "旗帜附近玩家对抗下列怪物时获得加成: 巨蠕虫";
				case 1699:
					return "旗帜附近玩家对抗下列怪物时获得加成: 幽灵";
				case 1700:
					return "旗帜附近玩家对抗下列怪物时获得加成: 虚空白龙";
				case 1701:
					return "旗帜附近玩家对抗下列怪物时获得加成: 僵尸";
				case 1724:
					return "赋予持有者二段跳的能力";
				case 1767:
					return "对我来说它看起来就像一只小妖精呢！";
				case 1768:
					return "我只想知道哪里有金子！";
				case 1769:
					return "我要金子，我要金子，我要金子，给我金子啊！";
				case 1774:
					return "右键打开";
				case 1782:
					return "33%几率不消耗弹药";
				case 1786:
					return "让你能从草地上割干草";
				case 1787:
					return "特制南瓜派，小幅提高全属性";
				case 1797:
					return "提供飞行和滑翔能力";
				case 1798:
					return "召唤一只宠物蜘蛛";
				case 1799:
					return "召唤一个宠物南瓜娃娃";
				case 1801:
					return "召唤一群蝙蝠攻击敌人";
				case 1802:
					return "召唤为你而战的黑鸦";
				case 1803:
					return "用来制作丛林钥匙";
				case 1804:
					return "用来制作腐化钥匙";
				case 1805:
					return "用来制作血红钥匙";
				case 1806:
					return "用来制作神圣钥匙";
				case 1807:
					return "用来制作冰霜钥匙";
				case 1809:
					return "最好用来给你的房客们一个惊喜";
				case 1810:
					return "召唤一只黑色小猫咪";
				case 1826:
					return "召唤南瓜头攻击敌人";
				case 1830:
					return "提供飞行和滑翔能力";
				case 1832:
					return "增加最大召唤物数量";
				case 1833:
					return "增加最大召唤物数量";
				case 1834:
					return "增加最大召唤物数量";
				case 1837:
					return "召唤一只会跟着你的万圣小树妖";
				case 1844:
					return "召唤万圣狂欢夜";
				case 1845:
					return "增加你的召唤物数量";
				case 1846:
					return "'V. Costa Moura'";
				case 1847:
					return "'J. Hayes'";
				case 1848:
					return "'J. Hayes'";
				case 1849:
					return "'J. Hayes'";
				case 1850:
					return "'J. Hayes'";
				case 1858:
					return "增加枪械类视野 (右键放大)";
				case 1860:
					return "能够游泳并且大大增长水下呼吸的时间";
				case 1861:
					return "能够游泳并且大大增长水下呼吸的时间";
				case 1862:
					return "可以飞行和高速移动，并能让你在冰上轻松自如";
				case 1863:
					return "赋予持有者二段跳的能力";
				case 1864:
					return "增大召唤物数量";
				case 1865:
					return "小幅度增加攻击力，攻击速度及暴击率";
				case 1866:
					return "提供飞行和滑翔能力";
				case 1869:
					return "右键打开";
				case 1870:
					return "'别把你的眼珠子给射掉了！'";
				case 1871:
					return "提供飞行和滑翔能力";
				case 1874:
					return "可以放在圣诞树上";
				case 1875:
					return "可以放在圣诞树上";
				case 1876:
					return "可以放在圣诞树上";
				case 1877:
					return "可以放在圣诞树上";
				case 1878:
					return "可以放在圣诞树上";
				case 1879:
					return "可以放在圣诞树上";
				case 1880:
					return "可以放在圣诞树上";
				case 1881:
					return "可以放在圣诞树上";
				case 1882:
					return "可以放在圣诞树上";
				case 1883:
					return "可以放在圣诞树上";
				case 1884:
					return "可以放在圣诞树上";
				case 1885:
					return "可以放在圣诞树上";
				case 1886:
					return "可以放在圣诞树上";
				case 1887:
					return "可以放在圣诞树上";
				case 1888:
					return "可以放在圣诞树上";
				case 1889:
					return "可以放在圣诞树上";
				case 1890:
					return "可以放在圣诞树上";
				case 1891:
					return "可以放在圣诞树上";
				case 1892:
					return "可以放在圣诞树上";
				case 1893:
					return "可以放在圣诞树上";
				case 1894:
					return "可以放在圣诞树上";
				case 1895:
					return "可以放在圣诞树上";
				case 1896:
					return "可以放在圣诞树上";
				case 1897:
					return "可以放在圣诞树上";
				case 1898:
					return "可以放在圣诞树上";
				case 1899:
					return "可以放在圣诞树上";
				case 1900:
					return "可以放在圣诞树上";
				case 1901:
					return "可以放在圣诞树上";
				case 1902:
					return "可以放在圣诞树上";
				case 1903:
					return "可以放在圣诞树上";
				case 1904:
					return "可以放在圣诞树上";
				case 1905:
					return "可以放在圣诞树上";
				case 1910:
					return "使用凝胶作为弹药";
				case 1911:
					return "所有属性提升";
				case 1914:
					return "召唤一只骑乘的驯鹿";
				case 1917:
					return "能开采陨石";
				case 1919:
					return "所有属性略微提升";
				case 1920:
					return "所有属性略微提升";
				case 1921:
					return "冷冻效果免疫";
				case 1922:
					return "'你这一年实在太淘气了！'";
				case 1923:
					return "增加物块范围1格";
				case 1927:
					return "召唤一只小狗";
				case 1928:
					return "射出圣诞装饰";
				case 1929:
					return "50%的机会不消耗弹药";
				case 1930:
					return "射出针叶快刀";
				case 1931:
					return "召唤暴风雪";
				case 1946:
					return "发射追踪导弹";
				case 1947:
					return "射出飞雪的冰霜之矛";
				case 1958:
					return "召唤冰霜之月";
				case 1959:
					return "召唤一个圣诞怪杰宠物";
				case 1988:
					return "'毡帽很酷'";
				case 2172:
					return "用于制作高级物品的合成";
				case 2177:
					return "减少20%弹药消耗";
				case 2188:
					return "射出穿透敌人的毒牙";
				case 2189:
					return "增加60最大法力值，减少13%魔法消耗";
				case 2192:
					return "用于制造特殊物品";
				case 2193:
					return "用于制造特殊物品";
				case 2194:
					return "用于制造特殊物品";
				case 2195:
					return "用于制造特殊物品";
				case 2196:
					return "用于制造特殊物品";
				case 2197:
					return "用于制造特殊物品";
				case 2198:
					return "用于制造特殊物品";
				case 2199:
					return "增加6%近战伤害 ";
				case 2200:
					return "增加8%近战伤害和暴击率";
				case 2201:
					return "增加5%近战伤害和暴击率";
				case 2202:
					return "提升6%移动速度和近战攻速";
				case 2203:
					return "用于制造特殊物品";
				case 2204:
					return "用于制造特殊物品";
				case 2214:
					return "增加物块放置速度";
				case 2215:
					return "增加物块放置范围";
				case 2216:
					return "自动对放置物体上色";
				case 2217:
					return "增加铺墙速度";
				case 2219:
					return "增加落星收集范围";
				case 2220:
					return "增加落星收集范围";
				case 2221:
					return "增加落星收集范围";
				case 2223:
					return "发射充能的箭矢";
				case 2267:
					return "微弱增加全属性";
				case 2268:
					return "微弱增加全属性";
				case 2270:
					return "50% 几率不消耗弹药";
				case 2272:
					return "射出一道无害的水流";
				case 2275:
					return "增加7%魔法伤害和暴击率";
				case 2277:
					return "增加5%伤害和暴击率";
				case 2279:
					return "增加6%魔法伤害和暴击率";
				case 2280:
					return "提供飞行和滑翔能力";
				case 2302:
					return "'它那多彩的鳞片将卖得不错’";
				case 2308:
					return "十分闪耀，这应该能卖个好价钱";
				case 2322:
					return "采矿速度加快25%";
				case 2323:
					return "增加吸引生命之心的范围";
				case 2324:
					return "降低敌人的攻击性";
				case 2325:
					return "增加物块的放置速度和距离";
				case 2326:
					return "增强击退效果";
				case 2327:
					return "使你能在水中快速地移动";
				case 2328:
					return "增加你的召唤物数量上限";
				case 2329:
					return "使你能看到附近的危机之源";
				case 2334:
					return "右键打开";
				case 2335:
					return "右键打开";
				case 2336:
					return "右键打开";
				case 2340:
					return "可以用锤子更改制动器的类型";
				case 2343:
					return "来玩过山车吧";
				case 2344:
					return "20%概率不消耗弹药";
				case 2345:
					return "增加20%生命上限";
				case 2346:
					return "减少10%受到的伤害";
				case 2347:
					return "增加10%的暴击率";
				case 2348:
					return "点燃附近的敌人";
				case 2349:
					return "增加10%的伤害";
				case 2350:
					return "送你回家";
				case 2351:
					return "将你传送至一个随机的地点";
				case 2352:
					return "用这个砸别人能让他们坠入爱河";
				case 2353:
					return "用这个砸别人能让他们变得难闻";
				case 2354:
					return "提升你的钓技";
				case 2355:
					return "侦测上钩的鱼";
				case 2356:
					return "增加钓到板条箱的概率";
				case 2359:
					return "减少寒冷伤害";
				case 2361:
					return "增加4%召唤物伤害";
				case 2362:
					return "增加4%召唤物伤害";
				case 2363:
					return "增加5%召唤物伤害";
				case 2364:
					return "召唤一只毒蜂为你而战";
				case 2365:
					return "召唤一只魔精为你而战";
				case 2366:
					return "召唤一只蜘蛛女皇向敌人吐蜘蛛卵";
				case 2367:
					return "提升你的钓技";
				case 2368:
					return "提升你的钓技";
				case 2369:
					return "提升你的钓技";
				case 2370:
					return "增加你的召唤物数量上限";
				case 2371:
					return "增加你的召唤物数量上限";
				case 2372:
					return "增加你的召唤物数量上限";
				case 2373:
					return "渔线再也不会断掉了";
				case 2374:
					return "提升你的钓技";
				case 2375:
					return "减少消耗鱼饵的概率";
				case 2420:
					return "召唤一条宠物飞鱼";
				case 2423:
					return "增加跳跃速度并允许自动跳";
				case 2425:
					return "略微提升所有属性";
				case 2426:
					return "略微提升所有属性";
				case 2427:
					return "略微提升所有属性";
				case 2428:
					return "召唤一只兔子坐骑";
				case 2429:
					return "召唤一只猪鲨坐骑";
				case 2430:
					return "召唤一只史莱姆坐骑";
				case 2491:
					return "召唤出一只海龟坐骑";
				case 2492:
					return "不能在斜坡上使用";
				case 2494:
					return "提供飞行和漂浮的能力";
				case 2497:
					return "'J. Hayes'";
				case 2502:
					return "召唤出一只蜜蜂坐骑";
				case 2535:
					return "召唤双子邪眼为你而战";
				case 2551:
					return "召唤蜘蛛为你而战";
				case 2584:
					return "召唤海盗们为你而战";
				case 2586:
					return "造成一次不会破坏物块的小范围爆炸";
				case 2587:
					return "召唤一只迷你牛头人";
				case 2590:
					return "造成一次能让敌人着火的小范围爆炸";
				case 2609:
					return "提供飞行和漂浮的能力";
				case 2610:
					return "喷射一股没有伤害的粘液";
				case 2611:
					return "会吐出许多跟踪泡泡哦";
				case 2621:
					return "召唤龙卷鲨为你而战";
				case 2622:
					return "发射高速的轮刃";
				case 2623:
					return "快速地射出强力的泡泡";
				case 2624:
					return "一次射出五只箭";
				case 2699:
					return "右键把武器放上去";
				case 2739:
					return "用锤子敲它可以改变加速的方向";
				case 2749:
					return "召唤一架UFO为你而战";
				case 2750:
					return "陨星雨落";
				case 2757:
					return "提升16%的远程伤害";
				case 2758:
					return "提升12%的远程伤害和暴击率";
				case 2759:
					return "提升8%的远程伤害和暴击率";
				case 2760:
					return "提升60点最大法力值以及减少15%的法力消耗";
				case 2761:
					return "提升9%的魔法伤害和暴击率";
				case 2762:
					return "提升10%的魔法伤害";
				case 2763:
					return "提升17%的近战伤害和暴击率";
				case 2764:
					return "提升22%的近战伤害";
				case 2765:
					return "提升15%的移动和近战速度";
				case 2767:
					return "召唤日食";
				case 2768:
					return "召唤一个可骑乘的钻机";
				case 2769:
					return "召唤一个可骑乘的UFO坐骑";
				case 2770:
					return "提供飞行和滑翔能力";
				case 2771:
					return "召唤一个可骑乘的火星念力虫坐骑";
				case 2799:
					return "在屏幕上显示出方便建筑的网格";
				case 2865:
					return "'J. Hayes'";
				case 2866:
					return "'J. Hayes'";
				case 2867:
					return "'J. Hayes'";
				case 2886:
					return "驱逐神圣";
				case 2888:
					return "木箭射出时将变做群蜂";
				case 2896:
					return "'丢起来可能会更加困难。'";
				case 2897:
					return "旗帜附近玩家对抗下列怪物时获得加成: 愤怒捕猎者";
				case 2898:
					return "旗帜附近玩家对抗下列怪物时获得加成: 装甲维京骷髅";
				case 2899:
					return "旗帜附近玩家对抗下列怪物时获得加成: 黑色史莱姆";
				case 2900:
					return "旗帜附近玩家对抗下列怪物时获得加成: 蓝色装甲骷髅";
				case 2901:
					return "旗帜附近玩家对抗下列怪物时获得加成: 蓝色教徒弓手";
				case 2902:
					return "旗帜附近玩家对抗下列怪物时获得加成: 蓝色教徒法师";
				case 2903:
					return "旗帜附近玩家对抗下列怪物时获得加成: 蓝色教徒战士";
				case 2904:
					return "旗帜附近玩家对抗下列怪物时获得加成: 李小髅";
				case 2905:
					return "旗帜附近玩家对抗下列怪物时获得加成: 黏着者";
				case 2906:
					return "旗帜附近玩家对抗下列怪物时获得加成: 胭脂甲虫";
				case 2907:
					return "旗帜附近玩家对抗下列怪物时获得加成: 腐化企鹅";
				case 2908:
					return "旗帜附近玩家对抗下列怪物时获得加成: 腐化史莱姆";
				case 2909:
					return "旗帜附近玩家对抗下列怪物时获得加成: 腐化者";
				case 2910:
					return "旗帜附近玩家对抗下列怪物时获得加成: 血腥史莱姆";
				case 2911:
					return "旗帜附近玩家对抗下列怪物时获得加成: 被诅咒的骷髅";
				case 2912:
					return "旗帜附近玩家对抗下列怪物时获得加成: 靛青甲虫";
				case 2913:
					return "旗帜附近玩家对抗下列怪物时获得加成: 挖掘者";
				case 2914:
					return "旗帜附近玩家对抗下列怪物时获得加成: 信魔者";
				case 2915:
					return "旗帜附近玩家对抗下列怪物时获得加成: 骷髅博士";
				case 2916:
					return "旗帜附近玩家对抗下列怪物时获得加成: 地牢史莱姆";
				case 2917:
					return "旗帜附近玩家对抗下列怪物时获得加成: 地牢幽魂";
				case 2918:
					return "旗帜附近玩家对抗下列怪物时获得加成: 妖精弓箭手";
				case 2919:
					return "旗帜附近玩家对抗下列怪物时获得加成: 妖精直升机";
				case 2920:
					return "旗帜附近玩家对抗下列怪物时获得加成: 眼魔僵尸";
				case 2921:
					return "旗帜附近玩家对抗下列怪物时获得加成: 圣诞雪花";
				case 2922:
					return "旗帜附近玩家对抗下列怪物时获得加成: 鬼魂";
				case 2923:
					return "旗帜附近玩家对抗下列怪物时获得加成: 巨大蝙蝠";
				case 2924:
					return "旗帜附近玩家对抗下列怪物时获得加成: 巨大诅咒头骨";
				case 2925:
					return "旗帜附近玩家对抗下列怪物时获得加成: 巨大飞狐";
				case 2926:
					return "旗帜附近玩家对抗下列怪物时获得加成: 姜饼人";
				case 2927:
					return "旗帜附近玩家对抗下列怪物时获得加成: 哥布林弓箭手";
				case 2928:
					return "旗帜附近玩家对抗下列怪物时获得加成: 绿色史莱姆";
				case 2929:
					return "旗帜附近玩家对抗下列怪物时获得加成: 无头骑士";
				case 2930:
					return "旗帜附近玩家对抗下列怪物时获得加成: 地狱装甲骷髅";
				case 2931:
					return "旗帜附近玩家对抗下列怪物时获得加成: 地狱犬";
				case 2932:
					return "旗帜附近玩家对抗下列怪物时获得加成: 弹跳杰克";
				case 2933:
					return "旗帜附近玩家对抗下列怪物时获得加成: 冰霜蝙蝠";
				case 2934:
					return "旗帜附近玩家对抗下列怪物时获得加成: 冰霜巨人";
				case 2935:
					return "旗帜附近玩家对抗下列怪物时获得加成: 冰霜史莱姆";
				case 2936:
					return "旗帜附近玩家对抗下列怪物时获得加成: 脓血乌贼";
				case 2937:
					return "旗帜附近玩家对抗下列怪物时获得加成: 荧光蝙蝠";
				case 2938:
					return "旗帜附近玩家对抗下列怪物时获得加成: 荧光史莱姆";
				case 2939:
					return "旗帜附近玩家对抗下列怪物时获得加成: 丛林蝙蝠";
				case 2940:
					return "旗帜附近玩家对抗下列怪物时获得加成: 丛林史莱姆";
				case 2941:
					return "旗帜附近玩家对抗下列怪物时获得加成: 克朗普斯";
				case 2942:
					return "旗帜附近玩家对抗下列怪物时获得加成: 红色甲虫";
				case 2943:
					return "旗帜附近玩家对抗下列怪物时获得加成: 岩浆蝙蝠";
				case 2944:
					return "旗帜附近玩家对抗下列怪物时获得加成: 岩浆史莱姆";
				case 2945:
					return "旗帜附近玩家对抗下列怪物时获得加成: 大脑操控者";
				case 2946:
					return "旗帜附近玩家对抗下列怪物时获得加成: 火星无人机";
				case 2947:
					return "旗帜附近玩家对抗下列怪物时获得加成: 火星工程师";
				case 2948:
					return "旗帜附近玩家对抗下列怪物时获得加成: 磁暴步兵";
				case 2949:
					return "旗帜附近玩家对抗下列怪物时获得加成: 灰色火星人";
				case 2950:
					return "旗帜附近玩家对抗下列怪物时获得加成: 火星军官";
				case 2951:
					return "旗帜附近玩家对抗下列怪物时获得加成: 激光枪手";
				case 2952:
					return "旗帜附近玩家对抗下列怪物时获得加成: 火星蛞蝓枪手";
				case 2953:
					return "旗帜附近玩家对抗下列怪物时获得加成: 特斯拉炮塔";
				case 2954:
					return "旗帜附近玩家对抗下列怪物时获得加成: 矮胖先生";
				case 2955:
					return "旗帜附近玩家对抗下列怪物时获得加成: 史莱姆母体";
				case 2956:
					return "旗帜附近玩家对抗下列怪物时获得加成: 死灵巫师";
				case 2957:
					return "旗帜附近玩家对抗下列怪物时获得加成: 胡桃夹子";
				case 2958:
					return "旗帜附近玩家对抗下列怪物时获得加成: 圣骑士";
				case 2959:
					return "旗帜附近玩家对抗下列怪物时获得加成: 企鹅";
				case 2960:
					return "旗帜附近玩家对抗下列怪物时获得加成: 粉色史莱姆";
				case 2961:
					return "旗帜附近玩家对抗下列怪物时获得加成: 邪灵";
				case 2962:
					return "旗帜附近玩家对抗下列怪物时获得加成: 魔化盔甲";
				case 2963:
					return "旗帜附近玩家对抗下列怪物时获得加成: 礼物宝箱怪";
				case 2964:
					return "旗帜附近玩家对抗下列怪物时获得加成: 紫色史莱姆";
				case 2965:
					return "旗帜附近玩家对抗下列怪物时获得加成: 残袍法师";
				case 2966:
					return "旗帜附近玩家对抗下列怪物时获得加成: 彩虹史莱姆";
				case 2967:
					return "旗帜附近玩家对抗下列怪物时获得加成: 乌鸦";
				case 2968:
					return "旗帜附近玩家对抗下列怪物时获得加成: 红色史莱姆";
				case 2969:
					return "旗帜附近玩家对抗下列怪物时获得加成: 符文魔法师";
				case 2970:
					return "旗帜附近玩家对抗下列怪物时获得加成: 锈蚀装甲骷髅";
				case 2971:
					return "旗帜附近玩家对抗下列怪物时获得加成: 稻草人";
				case 2972:
					return "旗帜附近玩家对抗下列怪物时获得加成: 火星蛞蝓骑兵";
				case 2973:
					return "旗帜附近玩家对抗下列怪物时获得加成: 骷髅弓箭手";
				case 2974:
					return "旗帜附近玩家对抗下列怪物时获得加成: 骷髅司令";
				case 2975:
					return "旗帜附近玩家对抗下列怪物时获得加成: 骷髅狙击手";
				case 2976:
					return "旗帜附近玩家对抗下列怪物时获得加成: 飞翔史莱姆";
				case 2977:
					return "旗帜附近玩家对抗下列怪物时获得加成: 掠夺者";
				case 2978:
					return "旗帜附近玩家对抗下列怪物时获得加成: 冰雪巴拉";
				case 2979:
					return "旗帜附近玩家对抗下列怪物时获得加成: 雪人枪手";
				case 2980:
					return "旗帜附近玩家对抗下列怪物时获得加成: 尖刺冰霜史莱姆";
				case 2981:
					return "旗帜附近玩家对抗下列怪物时获得加成: 尖刺丛林史莱姆";
				case 2982:
					return "旗帜附近玩家对抗下列怪物时获得加成: 刺枝怪";
				case 2983:
					return "旗帜附近玩家对抗下列怪物时获得加成: 章鱼";
				case 2984:
					return "旗帜附近玩家对抗下列怪物时获得加成: 骷髅突击队员";
				case 2985:
					return "旗帜附近玩家对抗下列怪物时获得加成: 僵尸新郎";
				case 2986:
					return "旗帜附近玩家对抗下列怪物时获得加成: 提姆法师";
				case 2987:
					return "旗帜附近玩家对抗下列怪物时获得加成: 骷髅矿工";
				case 2988:
					return "旗帜附近玩家对抗下列怪物时获得加成: 维京骷髅";
				case 2989:
					return "旗帜附近玩家对抗下列怪物时获得加成: 白色教徒弓手";
				case 2990:
					return "旗帜附近玩家对抗下列怪物时获得加成: 白色教徒法师";
				case 2991:
					return "旗帜附近玩家对抗下列怪物时获得加成: 白色教徒战士";
				case 2992:
					return "旗帜附近玩家对抗下列怪物时获得加成: 黄色史莱姆";
				case 2993:
					return "旗帜附近玩家对抗下列怪物时获得加成: 北风雪人";
				case 2994:
					return "旗帜附近玩家对抗下列怪物时获得加成: 妖精僵尸";
				case 2995:
					return "'V. Costa Moura'";
				case 2997:
					return "把你传送到一位队友身边";
				case 2998:
					return "提升15%的召唤伤害";
				case 2999:
					return "右键来获得召唤更多召唤物的魔力";
				case 3000:
					return "有33%的几率不消耗材料进行药水合成";
				case 3001:
					return "'它无论是看起来还是闻起来都一团糟'";
				case 3002:
					return "让周围的宝藏显形";
				case 3004:
					return "'发出让人联想到死亡的光芒'";
				case 3005:
					return "通过投掷来挂起一条能够攀爬的长绳";
				case 3006:
					return "从敌人身上摄取生命力";
				case 3014:
					return "召唤一道咒焰之墙";
				case 3015:
					return "你会像半透明一样不太吸引怪物注意力";
				case 3016:
					return "你会像开了嘲讽一样吸引怪物的注意力";
				case 3017:
					return "足之所过，鲜花所沃";
				case 3019:
					return "木箭射出时化作火蝠";
				case 3024:
					return "'用来扮演开发者超棒！'";
				case 3029:
					return "从天空召唤箭矢";
				case 3030:
					return "投掷一枚能控制的飞刀";
				case 3031:
					return "容纳着一个无尽的泽国";
				case 3032:
					return "能够吸收无穷无尽的水";
				case 3033:
					return "提升拾取硬币的范围";
				case 3034:
					return "提升拾取硬币的范围";
				case 3035:
					return "增加拾取硬币的范围和降低商店的价格";
				case 3036:
					return "显示天气，月相和钓鱼信息";
				case 3037:
					return "显示天气";
				case 3043:
					return "召唤一个能照出周围宝藏的魔法灯笼";
				case 3046:
					return "在篝火附近你的生命恢复速度会加快";
				case 3047:
					return "在篝火附近你的生命恢复速度会加快";
				case 3048:
					return "在篝火附近你的生命恢复速度会加快";
				case 3049:
					return "在篝火附近你的生命恢复速度会加快";
				case 3050:
					return "在篝火附近你的生命恢复速度会加快";
				case 3051:
					return "召唤一大簇魔晶刺";
				case 3052:
					return "发射带有暗影之炎的箭矢";
				case 3053:
					return "召唤暗影之炎触手来攻击敌人";
				case 3054:
					return "击中时让敌人燃起暗影之炎";
				case 3055:
					return "'J. Hayes'";
				case 3056:
					return "'J. Hayes'";
				case 3057:
					return "'J. Hayes'";
				case 3058:
					return "'J. Hayes'";
				case 3059:
					return "'J. Hayes'";
				case 3060:
					return "召唤一个巨脸怪幼体";
				case 3061:
					return "增加物块和墙的放置速度和距离";
				case 3062:
					return "召唤一颗心脏来提供光源";
				case 3064:
					return "可以让你一周快进时间一次";
				case 3068:
					return "可以从藤蔓上收集藤绳";
				case 3069:
					return "射出一个小火花";
				case 3084:
					return "探测你周围的敌人";
				case 3085:
					return "右键打开";
				case 3090:
					return "将史莱姆变成友好生物";
				case 3091:
					return "'充满了许多精魂的能量'";
				case 3092:
					return "'充满了许多精魂的能量'";
				case 3093:
					return "右键打开";
				case 3095:
					return "显示有多少怪物被击杀";
				case 3096:
					return "显示月相";
				case 3097:
					return "让你可以向敌人发起冲锋";
				case 3098:
					return "击中敌人时链锯迸出炽热的火花";
				case 3099:
					return "显示玩家的实时行进速度";
				case 3102:
					return "显示你周围最稀有矿石的名字";
				case 3106:
					return "可以让你进入潜行状态";
				case 3109:
					return "帮助提升你的夜视能力";
				case 3110:
					return "在满月时将穿戴者变成狼人而在进入水中时变成鱼人";
				case 3111:
					return "'弹弹又甜甜！'";
				case 3112:
					return "在水下生效";
				case 3113:
					return "非常有弹性";
				case 3115:
					return "造成一次能够摧毁物块的小型爆炸";
				case 3116:
					return "造成一次不会摧毁物块的小型爆炸";
				case 3117:
					return "减少怪物的刷新概率";
				case 3118:
					return "显示你周围的稀有生物";
				case 3119:
					return "显示你的每秒伤害（DPS）";
				case 3120:
					return "显示钓鱼信息";
				case 3121:
					return "显示行进速度，每秒伤害（DPS）和有价值的矿石";
				case 3122:
					return "显示附近的怪物数量，你的杀敌量和稀有生物";
				case 3123:
					return "显示所有数据";
				case 3124:
					return "显示所有数据";
				case 3195:
					return "微弱提高全属性";
				case 3196:
					return "造成一次能够摧毁物块的小型爆炸";
				case 3198:
					return "提升你近战武器的护甲穿透能力";
				case 3199:
					return "'寒冰寒冰，归家随心'";
				case 3200:
					return "穿戴者可以跑得非常快";
				case 3201:
					return "赋予持有者二段跳的能力";
				case 3203:
					return "右键打开";
				case 3204:
					return "右键打开";
				case 3205:
					return "右键打开";
				case 3206:
					return "右键打开";
				case 3207:
					return "右键打开";
				case 3208:
					return "右键打开";
				case 3209:
					return "射出一枚魔晶爆弹";
				case 3210:
					return "射出有毒的泡泡";
				case 3211:
					return "砍中时吐出一股脓液流";
				case 3212:
					return "提升5点护甲穿透";
				case 3213:
					return "召唤一个飞猪储蓄罐来储存你的物品";
				case 3223:
					return "受到攻击时有几率迷惑周围的敌人";
				case 3224:
					return "受到的伤害减少17%";
				case 3225:
					return "提升跳跃高度";
				case 3226:
					return "'用来扮演开发者超棒！'";
				case 3227:
					return "'用来扮演开发者超棒！'";
				case 3228:
					return "'用来扮演开发者超棒！'";
				case 3241:
					return "增加跳跃高度";
				case 3245:
					return "扔出强力的骨头";
				case 3250:
					return "赋予持有者二段跳的能力";
				case 3251:
					return "受伤时释放蜂群";
				case 3252:
					return "赋予持有者二段跳的能力";
				case 3260:
					return "召唤一个可骑乘的独角兽坐骑";
				case 3287:
					return "'用来扮演开发者超棒！'";
				case 3288:
					return "'用来扮演开发者超棒！'";
				case 3293:
					return "增加悠悠球线的长度";
				case 3294:
					return "增加悠悠球线的长度";
				case 3295:
					return "增加悠悠球线的长度";
				case 3296:
					return "增加悠悠球线的长度";
				case 3297:
					return "增加悠悠球线的长度";
				case 3298:
					return "增加悠悠球线的长度";
				case 3299:
					return "增加悠悠球线的长度";
				case 3300:
					return "增加悠悠球线的长度";
				case 3301:
					return "增加悠悠球线的长度";
				case 3302:
					return "增加悠悠球线的长度";
				case 3303:
					return "增加悠悠球线的长度";
				case 3304:
					return "增加悠悠球线的长度";
				case 3305:
					return "增加悠悠球线的长度";
				case 3306:
					return "增加悠悠球线的长度";
				case 3307:
					return "增加悠悠球线的长度";
				case 3308:
					return "增加悠悠球线的长度";
				case 3309:
					return "当悠悠球击中敌人的时候甩出重锤";
				case 3310:
					return "当悠悠球击中敌人的时候甩出重锤";
				case 3311:
					return "当悠悠球击中敌人的时候甩出重锤";
				case 3312:
					return "当悠悠球击中敌人的时候甩出重锤";
				case 3313:
					return "当悠悠球击中敌人的时候甩出重锤";
				case 3314:
					return "当悠悠球击中敌人的时候甩出重锤";
				case 3318:
					return "右键打开";
				case 3319:
					return "右键打开";
				case 3320:
					return "右键打开";
				case 3321:
					return "右键打开";
				case 3322:
					return "右键打开";
				case 3323:
					return "右键打开";
				case 3324:
					return "右键打开";
				case 3325:
					return "右键打开";
				case 3326:
					return "右键打开";
				case 3327:
					return "右键打开";
				case 3328:
					return "右键打开";
				case 3329:
					return "右键打开";
				case 3330:
					return "右键打开";
				case 3331:
					return "右键打开";
				case 3332:
					return "右键打开";
				case 3333:
					return "增加友方蜂群的力量";
				case 3334:
					return "使你一次能控制两个悠悠球";
				case 3335:
					return "永久提升饰品栏的数量";
				case 3336:
					return "随时在周围召唤孢子来伤害敌人";
				case 3337:
					return "在静止不动时极大地提升生命恢复速度";
				case 3360:
					return "放置生命红木";
				case 3361:
					return "放置生命红木叶";
				case 3366:
					return "让穿戴者拥有大师级悠悠技巧";
				case 3367:
					return "吸引一个在水中十分强大并精于战斗的传说生物前来";
				case 3374:
					return "提升20%的投掷速度";
				case 3375:
					return "提升20%的投掷伤害";
				case 3376:
					return "提升15的投掷暴击率";
				case 3381:
					return "提升你的最大召唤物数量";
				case 3382:
					return "提升你的最大召唤物数量";
				case 3383:
					return "提升你的最大召唤物数量";
				case 3385:
					return "可以拿来交换稀有染料";
				case 3386:
					return "可以拿来交换稀有染料";
				case 3387:
					return "可以拿来交换稀有染料";
				case 3388:
					return "可以拿来交换稀有染料";
				case 3390:
					return "旗帜附近玩家对抗下列怪物时获得加成: 哥布林召唤师";
				case 3391:
					return "旗帜附近玩家对抗下列怪物时获得加成: 沙罗曼蛇";
				case 3392:
					return "旗帜附近玩家对抗下列怪物时获得加成: 巨贝";
				case 3393:
					return "旗帜附近玩家对抗下列怪物时获得加成: 龙虾";
				case 3394:
					return "旗帜附近玩家对抗下列怪物时获得加成: 科学小怪人";
				case 3395:
					return "旗帜附近玩家对抗下列怪物时获得加成: 深渊生物";
				case 3396:
					return "旗帜附近玩家对抗下列怪物时获得加成: 苍蝇人博士";
				case 3397:
					return "旗帜附近玩家对抗下列怪物时获得加成: 摩斯拉飞蛾";
				case 3398:
					return "旗帜附近玩家对抗下列怪物时获得加成: 断手";
				case 3399:
					return "旗帜附近玩家对抗下列怪物时获得加成: 魔化怪人";
				case 3400:
					return "旗帜附近玩家对抗下列怪物时获得加成: 屠夫";
				case 3401:
					return "旗帜附近玩家对抗下列怪物时获得加成: 疯子";
				case 3402:
					return "旗帜附近玩家对抗下列怪物时获得加成: 致命球体";
				case 3403:
					return "旗帜附近玩家对抗下列怪物时获得加成: 钉子头";
				case 3404:
					return "旗帜附近玩家对抗下列怪物时获得加成: 剧毒孢子";
				case 3405:
					return "旗帜附近玩家对抗下列怪物时获得加成: 美杜莎";
				case 3406:
					return "旗帜附近玩家对抗下列怪物时获得加成: 重装步兵";
				case 3407:
					return "旗帜附近玩家对抗下列怪物时获得加成: 花岗岩元素";
				case 3408:
					return "旗帜附近玩家对抗下列怪物时获得加成: 花岗岩傀儡";
				case 3409:
					return "旗帜附近玩家对抗下列怪物时获得加成: 鲜血僵尸";
				case 3410:
					return "旗帜附近玩家对抗下列怪物时获得加成: 滴血魔眼";
				case 3411:
					return "旗帜附近玩家对抗下列怪物时获得加成: 掘墓者头颅";
				case 3412:
					return "旗帜附近玩家对抗下列怪物时获得加成: 沙丘穿行者头颅";
				case 3413:
					return "旗帜附近玩家对抗下列怪物时获得加成: 飞行蚁狮";
				case 3414:
					return "旗帜附近玩家对抗下列怪物时获得加成: 冲锋蚁狮";
				case 3415:
					return "旗帜附近玩家对抗下列怪物时获得加成: 食尸鬼";
				case 3416:
					return "旗帜附近玩家对抗下列怪物时获得加成: 拉弥亚";
				case 3417:
					return "旗帜附近玩家对抗下列怪物时获得加成: 沙漠游魂";
				case 3418:
					return "旗帜附近玩家对抗下列怪物时获得加成: 史前毒蜥";
				case 3419:
					return "旗帜附近玩家对抗下列怪物时获得加成: 破坏之蝎";
				case 3420:
					return "旗帜附近玩家对抗下列怪物时获得加成: 观星者";
				case 3421:
					return "旗帜附近玩家对抗下列怪物时获得加成: 银行穿梭者";
				case 3422:
					return "旗帜附近玩家对抗下列怪物时获得加成: 激流入侵者";
				case 3423:
					return "旗帜附近玩家对抗下列怪物时获得加成: 闪光炸弹发射器";
				case 3424:
					return "旗帜附近玩家对抗下列怪物时获得加成: 小型星尘细胞";
				case 3425:
					return "旗帜附近玩家对抗下列怪物时获得加成: 星尘细胞";
				case 3426:
					return "旗帜附近玩家对抗下列怪物时获得加成: 日曜头骨";
				case 3427:
					return "旗帜附近玩家对抗下列怪物时获得加成: 日曜滚动者";
				case 3428:
					return "旗帜附近玩家对抗下列怪物时获得加成: 日曜蜈蚣";
				case 3429:
					return "旗帜附近玩家对抗下列怪物时获得加成: 日曜地龙骑士";
				case 3430:
					return "旗帜附近玩家对抗下列怪物时获得加成: 日曜地龙";
				case 3431:
					return "旗帜附近玩家对抗下列怪物时获得加成: 日光住民";
				case 3432:
					return "旗帜附近玩家对抗下列怪物时获得加成: 星云先知";
				case 3433:
					return "旗帜附近玩家对抗下列怪物时获得加成: 大脑吸取者";
				case 3434:
					return "旗帜附近玩家对抗下列怪物时获得加成: 星云浮游者";
				case 3435:
					return "旗帜附近玩家对抗下列怪物时获得加成: 星云野兽";
				case 3436:
					return "旗帜附近玩家对抗下列怪物时获得加成: 外星幼虫";
				case 3437:
					return "旗帜附近玩家对抗下列怪物时获得加成: 外星女皇";
				case 3438:
					return "旗帜附近玩家对抗下列怪物时获得加成: 外星黄蜂";
				case 3439:
					return "旗帜附近玩家对抗下列怪物时获得加成: 旋涡士兵";
				case 3440:
					return "旗帜附近玩家对抗下列怪物时获得加成: 风暴潜兵";
				case 3441:
					return "旗帜附近玩家对抗下列怪物时获得加成: 海盗船长";
				case 3442:
					return "旗帜附近玩家对抗下列怪物时获得加成: 独眼海盗";
				case 3443:
					return "旗帜附近玩家对抗下列怪物时获得加成: 海盗劫掠者";
				case 3444:
					return "旗帜附近玩家对抗下列怪物时获得加成: 海盗弓弩手";
				case 3445:
					return "旗帜附近玩家对抗下列怪物时获得加成: 火星漫步者";
				case 3446:
					return "旗帜附近玩家对抗下列怪物时获得加成: 红恶魔";
				case 3447:
					return "旗帜附近玩家对抗下列怪物时获得加成: 粉水母";
				case 3448:
					return "旗帜附近玩家对抗下列怪物时获得加成: 绿水母";
				case 3449:
					return "旗帜附近玩家对抗下列怪物时获得加成: 黑暗木乃伊";
				case 3450:
					return "旗帜附近玩家对抗下列怪物时获得加成: 光明木乃伊";
				case 3451:
					return "旗帜附近玩家对抗下列怪物时获得加成: 愤怒的骷髅";
				case 3452:
					return "旗帜附近玩家对抗下列怪物时获得加成: 冰霜乌龟";
				case 3456:
					return "'能量螺旋着从这碎片上散出'";
				case 3457:
					return "'银河的伟力居于此碎片之中'";
				case 3458:
					return "'宇宙的暴戾驻于此碎片之内'";
				case 3459:
					return "'迷魂的粒子环绕在碎片四周'";
				case 3460:
					return "'来自天堂的宝石'";
				case 3467:
					return "'它因来自天空的能量而震动发光'";
				case 3468:
					return "提供飞行和滑翔能力";
				case 3469:
					return "提供飞行和滑翔能力";
				case 3470:
					return "提供飞行和滑翔能力";
				case 3471:
					return "提供飞行和滑翔能力";
				case 3473:
					return "'把控炽阳之力进行攻击'";
				case 3474:
					return "召唤一个星尘细胞来为你战斗";
				case 3475:
					return "有66%的几率不消耗弹药";
				case 3476:
					return "'变幻出大量的星体能量来追逐你的敌人'";
				case 3477:
					return "把血腥传播到一些物块上";
				case 3478:
					return "'Wuv... twue wuv...'";
				case 3479:
					return "'Mawwiage...'";
				case 3485:
					return "能够挖掘陨石矿";
				case 3491:
					return "能够挖掘陨石矿";
				case 3521:
					return "能够挖掘陨石矿";
				case 3531:
					return "召唤一条星尘龙来为你战斗";
				case 3532:
					return "微弱的提升全属性";
				case 3536:
					return "'从旋涡之柱上窃取一小部分威能'";
				case 3537:
					return "'从星云之柱上窃取一小部分威能'";
				case 3538:
					return "'从星尘之柱上窃取一小部分威能'";
				case 3539:
					return "'从太阳之柱上窃取一小部分威能'";
				case 3540:
					return "有66%的几率不消耗弹药";
				case 3541:
					return "'折射能够裂解生命的彩虹'";
				case 3542:
					return "'从猎户座星云而来，最终掌握在你的手心'";
				case 3543:
					return "'把你的敌人用光芒之枪撕成碎片！'";
				case 3545:
					return "'贪婪....然后是鲜血！'";
				case 3547:
					return "'这一定会被证实是一个糟糕透顶的主意'";
				case 3548:
					return "制造一次不会摧毁物块的小型爆炸";
				case 3549:
					return "用来制作由月之碎片和月光石合成的物品";
				case 3567:
					return "'把他们串成串儿然后打成两半儿....'";
				case 3568:
					return "'以音速打击敌人！'";
				case 3569:
					return "召唤一个涌出月光的大门来攻击敌人";
				case 3570:
					return "月炎之雨从天而降";
				case 3571:
					return "召唤一个照耀四周的水晶来惩戒你的敌人";
				case 3572:
					return "'你想摘月亮吗？把钩爪丢上去抓住它，然后拽下来就可以了！'";
				case 3577:
					return "召唤一个可疑的眼球来提供光源";
				case 3578:
					return "'用来扮演开发者超棒！'";
				case 3579:
					return "'用来扮演开发者超棒！'";
				case 3580:
					return "'用来扮演开发者超棒！'";
				case 3581:
					return "'用来扮演开发者超棒！'";
				case 3582:
					return "'用来扮演开发者超棒！'";
				case 3583:
					return "'用来扮演开发者超棒！'";
				case 3585:
					return "'用来扮演开发者超棒！'";
				case 3586:
					return "'用来扮演开发者超棒！'";
				case 3587:
					return "'用来扮演开发者超棒！'";
				case 3588:
					return "'用来扮演开发者超棒！'";
				case 3589:
					return "'用来扮演开发者超棒！'";
				case 3590:
					return "'用来扮演开发者超棒！'";
				case 3591:
					return "'用来扮演开发者超棒！'";
				case 3592:
					return "'用来扮演开发者超棒！'";
				case 3593:
					return "旗帜附近玩家对抗下列怪物时获得加成: 黄沙史莱姆";
				case 3594:
					return "旗帜附近玩家对抗下列怪物时获得加成: 海蜗牛";
				case 3596:
					return "'V. Costa Moura'";
				case 3599:
					return "'用来扮演开发者超棒！'";
				case 3601:
					return "召唤即将到来的灾厄";
				case 3602:
					return "放置在逻辑门上控制其开关";
				case 3603:
					return "通过上方的逻辑灯决定其开关状态";
				case 3604:
					return "通过上方的逻辑灯决定其开关状态";
				case 3605:
					return "通过上方的逻辑灯决定其开关状态";
				case 3606:
					return "通过上方的逻辑灯决定其开关状态";
				case 3607:
					return "通过上方的逻辑灯决定其开关状态";
				case 3608:
					return "通过上方的逻辑灯决定其开关状态";
				case 3611:
					return "掌握搭建电路的奥义!";
				case 3612:
					return "放置黄色导线";
				case 3613:
					return "到白天就输出一个信号";
				case 3614:
					return "到晚上就输出一个信号";
				case 3615:
					return "只在玩家站上去时输出一个信号";
				case 3616:
					return "分开同色导线的路径锤击改变其方向！";
				case 3618:
					return "放置在逻辑门上控制其开关";
				case 3619:
					return "让你更清楚的分辨导线";
				case 3620:
					return "激活促动器";
				case 3624:
					return "自动给放置的物块添加促动器";
				case 3625:
					return "选中时通过按右键来设置该工具的作用";
				case 3626:
					return "在玩家踏上或者离开时各输出一个信号";
				case 3628:
					return "甚至不怕岩浆！";
				case 3629:
					return "不同颜色的导线将点亮不同颜色的灯泡";
				case 3630:
					return "在玩家踏上或者离开时各输出一个信号";
				case 3631:
					return "在玩家踏上或者离开时各输出一个信号";
				case 3632:
					return "在玩家踏上或者离开时各输出一个信号";
				case 3643:
					return "可以用来玩钻石夺宝一类的游戏。死亡时掉落";
				case 3644:
					return "右键来放置或移除大型红宝石";
				case 3645:
					return "右键来放置或移除大型蓝宝石";
				case 3646:
					return "右键来放置或移除大型祖母绿";
				case 3647:
					return "右键来放置或移除大型黄晶玉";
				case 3648:
					return "右键来放置或移除大型紫水晶";
				case 3649:
					return "右键来放置或移除大型钻石";
				case 3650:
					return "右键来放置或移除大型琥珀";
				case 3663:
					return "放置在逻辑门上输出一个随机信号";
				case 3707:
					return "当有物体触碰的时候输出一个信号";
				case 3721:
					return "钓线将不再断开，减少鱼饵消耗的概率，并提升你的钓技";
				case 3723:
					return "在篝火附近你的生命恢复速度会加快";
				case 3724:
					return "在篝火附近你的生命恢复速度会加快";
				case 3725:
					return "分开同色导线的路径收到横向信号输入时关闭收到交叉信号时点亮";
				case 3726:
					return "只在接触水时输出一个信号";
				case 3727:
					return "只在接触岩浆时输出一个信号";
				case 3728:
					return "只在接触蜂蜜时输出一个信号";
				case 3729:
					return "在接触任何液体时激活，其他时候休眠";
				case 3736:
					return "'闻起来像泡泡糖和快乐'";
				case 3737:
					return "'闻起来像薰衣草和热情'";
				case 3738:
					return "'闻起来像薄荷和幸福'";
				case 3739:
					return "超乎寻常的坚固，足以进行攀爬！";
				case 3740:
					return "超乎寻常的坚固，足以进行攀爬！";
				case 3741:
					return "超乎寻常的坚固，足以进行攀爬！";
				case 3742:
					return "庆祝永不结束！";
				case 3746:
					return "击爆彩带四溅！";
				case 3747:
					return "'一波气球将从天而降'";
				case 3748:
					return "'为每个人的欢乐而扎起'";
				case 3749:
					return "想知道里面有什么吗？";
				case 3750:
					return "甩向你的脸。甩向别人的脸。管他呢";
				case 3751:
					return "提升200%的运行速度";
				case 3752:
					return "你可以安全观看的沙流";
				case 3753:
					return "这可比雪球仪酷多了";
				case 3754:
					return "你可以安全观看的流沙";
				case 3755:
					return "这可比雪球仪酷多了";
				case 3756:
					return "这里很冷";
				case 3757:
					return "扮演企鹅!";
				case 3758:
					return "扮演企鹅!";
				case 3759:
					return "扮演企鹅!";
				case 3763:
					return "激起你心中隐藏的飞行梦想！";
				case 3770:
					return "用你的双腿来换取缓慢降落的能力";
				case 3771:
					return "召唤一个可骑乘的巨蜥坐骑";
				case 3776:
					return "提升15%的魔法和召唤伤害";
				case 3777:
					return "提升80点最大法力值";
				case 3778:
					return "增加最大召唤物数量";
				case 3780:
					return "旗帜附近玩家对抗下列怪物时获得加成: 沙元素";
				case 3781:
					return "使你免疫石化";
				case 3789:
					return "旗帜附近玩家对抗下列怪物时获得加成: 沙漠鲨鱼";
				case 3790:
					return "旗帜附近玩家对抗下列怪物时获得加成: 噬骨者";
				case 3791:
					return "旗帜附近玩家对抗下列怪物时获得加成: 血肉收割者";
				case 3792:
					return "旗帜附近玩家对抗下列怪物时获得加成: 水晶长尾鲨";
				case 3793:
					return "旗帜附近玩家对抗下列怪物时获得加成: 愤怒不倒翁";
				case 3797:
					return "提升你的最大炮台数量并减少10%的法力消耗";
				case 3798:
					return "提升20%的召唤伤害和10的魔法伤害";
				case 3799:
					return "提升10%的召唤物伤害和20%的移动速度";
				case 3800:
					return "提升你的最大炮台数量和生命回复速度";
				case 3801:
					return "提升15%的召唤和近战伤害";
				case 3802:
					return "提升15%的召唤伤害，20%的近战暴击率和移动速度";
				case 3803:
					return "提升你的最大炮台数量并提升10%的远程暴击率";
				case 3804:
					return "提升20%的召唤和远程伤害";
				case 3805:
					return "提升10%的召唤伤害和20%的移动速度";
				case 3806:
					return "提升你的最大炮台数量和20%的近战攻击速度";
				case 3807:
					return "提升20%的召唤和近战伤害";
				case 3808:
					return "提升10%的召唤伤害，暴击率和20%的移动速度";
				case 3809:
					return "提升你的最大炮台数量";
				case 3810:
					return "提升你的最大炮台数量";
				case 3811:
					return "提升你的最大炮台数量";
				case 3812:
					return "提升你的最大炮台数量";
				case 3816:
					return "托起你的艾特尼亚水晶....";
				case 3817:
					return "与酒保交易的货币";
				case 3818:
					return "召唤一个射速稳定的爆裂火球炮台";
				case 3819:
					return "召唤一个射速稳定的爆裂火球炮台";
				case 3820:
					return "召唤一个射速稳定的爆裂火球炮台";
				case 3822:
					return "通常用来把人的意念转化为一种真正用来抵御敌人的武器";
				case 3823:
					return "右键来使用身上的盾牌进行格挡";
				case 3824:
					return "召唤一个射击极具穿透力的强大箭矢但射速较慢的防御塔";
				case 3825:
					return "召唤一个射击极具穿透力的强大箭矢但射速较慢的防御塔";
				case 3826:
					return "召唤一个射击极具穿透力的强大箭矢但射速较慢的防御塔";
				case 3827:
					return "爆发出心中的能量！";
				case 3828:
					return "放置在艾特尼亚水晶台上来召来艾特尼亚的传送门";
				case 3829:
					return "召唤一个电击进入敌人的光环";
				case 3830:
					return "召唤一个电击进入敌人的光环";
				case 3831:
					return "召唤一个电击进入敌人的光环";
				case 3832:
					return "召唤一个会在敌人靠近时突然爆炸的陷阱";
				case 3833:
					return "召唤一个会在敌人靠近时突然爆炸的陷阱";
				case 3834:
					return "召唤一个会在敌人靠近时突然爆炸的陷阱";
				case 3835:
					return "摇动来积蓄能量，碾碎敌人";
				case 3836:
					return "召唤龙魂伤害敌人";
				case 3852:
					return "想知道是谁会把一根法杖上粘上蕴含无穷智慧的书籍....";
				case 3854:
					return "弓上有不死之焱的力量";
				case 3855:
					return "召唤一只宠物喵";
				case 3856:
					return "召唤一宠物摇曳烛芯来提供光源";
				case 3857:
					return "召唤一只宠物小龙";
				case 3858:
					return "右键来转换攻击模式！";
				case 3859:
					return "射出爆裂子母箭，并对空中的敌人造成额外的伤害";
				case 3860:
					return "右键打开";
				case 3861:
					return "右键打开";
				case 3862:
					return "右键打开";
				case 3870:
					return "喷出能够减少防御的龙息！";
				case 3871:
					return "提升你的最大守卫数量和10%的召唤伤害";
				case 3872:
					return "提升30%的召唤伤害和大幅度提升生命回复速度";
				case 3873:
					return "提升20%的召唤伤害，暴击率和30%的移动速度";
				case 3874:
					return "提升你的最大守卫数量，并提升召唤和魔法伤害";
				case 3875:
					return "提升30%的召唤伤害和15%的魔法伤害";
				case 3876:
					return "提升20%的召唤伤害和25%的魔法暴击率";
				case 3877:
					return "提升你的最大守卫数量和10%的召唤伤害以及远程暴击率";
				case 3878:
					return "提升25%的召唤和远程伤害";
				case 3879:
					return "提升25%的召唤伤害和20%的移动速度";
				case 3880:
					return "提升你的最大守卫数量和20%的近战及召唤伤害";
				case 3881:
					return "提升20%的召唤伤害和近战攻击速度";
				case 3882:
					return "提升20%的召唤伤害，移动速度和近战暴击率";
				default:
					return string.Empty;
			}
		}

		public static string ToolTip2(int id)
		{
			switch (id)
			{
				case 65:
					return "'这是来自天堂的审判！'";
				case 98:
					return "'一半是鲨鱼一半是机枪，简直帅爆了！'";
				case 213:
					return "用来采集炼金植物可提升采集数";
				case 228:
					return "增加4%魔法暴击";
				case 229:
					return "增加4%魔法暴击";
				case 230:
					return "增加4%魔法暴击";
				case 371:
					return "增加9%魔法暴击";
				case 372:
					return "增加12%近战速度";
				case 373:
					return "增加6%远程暴击率";
				case 374:
					return "增加3%暴击率";
				case 375:
					return "增加10%移动速度";
				case 376:
					return "增加15%魔法伤害";
				case 377:
					return "增加10%近战伤害";
				case 378:
					return "增加7%远程暴击率";
				case 379:
					return "增加5%所有伤害";
				case 380:
					return "增加3%暴击率";
				case 389:
					return "'心如止水'";
				case 394:
					return "大大延长了水下呼吸的时间";
				case 395:
					return "以及当前时间";
				case 396:
					return "并免疫灼热砖块伤害";
				case 397:
					return "并免疫灼热砖块伤害";
				case 399:
					return "而且能跳得更高";
				case 400:
					return "增加11%魔法伤害和暴击率";
				case 401:
					return "增加14%近战伤害";
				case 402:
					return "增加8%远程暴击率";
				case 404:
					return "增加5%移动速度";
				case 405:
					return "穿上后跑的飞快";
				case 434:
					return "但只消耗一发子弹";
				case 533:
					return "'迷你鲨失散多年的兄弟'";
				case 552:
					return "增加8%移动速度";
				case 553:
					return "增加8%远程暴击率";
				case 555:
					return "当需要的时候就会自动使用魔法药剂";
				case 558:
					return "增加12%魔法伤害和暴击率";
				case 559:
					return "增加10%挥动速度";
				case 686:
					return "增加7%挥动速度";
				case 748:
					return "按住上键能飞得更快";
				case 771:
					return "造成小范围爆炸，不会摧毁物块";
				case 772:
					return "造成小范围爆炸，会摧毁物块";
				case 773:
					return "造成大范围爆炸，不会摧毁物块";
				case 774:
					return "造成大范围爆炸，会摧毁物块";
				case 775:
					return "增加奔跑的速度";
				case 776:
					return "可以挖掘秘银和山铜";
				case 777:
					return "可以挖掘精金和钛金";
				case 779:
					return "它能让世界变得五彩缤纷";
				case 780:
					return "它能将世界还原成最初的样子，好吧也就是森林和丛林";
				case 781:
					return "它能将世界变成神圣之地";
				case 782:
					return "它能将世界变成腐蚀之地";
				case 783:
					return "它能让世界种满蘑菇";
				case 784:
					return "它能将世界变成血腥之地";
				case 897:
					return "增加12%挥动速度";
				case 898:
					return "穿上后你会比迅雷还快";
				case 905:
					return "价值越高的钱币伤害越高";
				case 907:
					return "并免疫灼热砖块伤害";
				case 908:
					return "并免疫灼热砖块伤害而且能使你在岩浆中安全地呆7秒";
				case 929:
					return "塞进大炮里，注意轻拿轻放";
				case 936:
					return "增加10%所有伤害和近战速度";
				case 938:
					return "只会在生命高于25%时生效";
				case 950:
					return "独特的减震设计让你落在冰上也不会直接砸个洞掉进去";
				case 953:
					return "与鞋钉合成后会有更好的效果";
				case 960:
					return "增加4%魔法暴击率";
				case 961:
					return "增加4%魔法暴击率";
				case 962:
					return "增加4%魔法暴击率";
				case 975:
					return "与攀爬爪合成后会有更好的效果";
				case 977:
					return "用法是按两次同一个方向键";
				case 982:
					return "增加魔力回复速度";
				case 983:
					return "增加跳跃高度";
				case 984:
					return "使你能像忍者一样闪避受到的攻击";
				case 997:
					return "'用法：把泥砂和雪砂塞进来'";
				case 1001:
					return "增加6%近战暴击率";
				case 1002:
					return "20%几率不消耗弹药";
				case 1003:
					return "增加16%魔法伤害";
				case 1004:
					return "增加7%暴击率";
				case 1005:
					return "增加5%移动速度";
				case 1123:
					return "小几率造成混乱";
				case 1131:
					return "按“上”键来改变重力";
				case 1159:
					return "增加10%召唤物的伤害";
				case 1160:
					return "增加10%召唤物的伤害";
				case 1161:
					return "增加10%召唤物的伤害";
				case 1163:
					return "增加跳跃高度";
				case 1164:
					return "增加跳跃高度";
				case 1167:
					return "增加召唤物的击退效果";
				case 1205:
					return "增加12%近战速度";
				case 1206:
					return "增加9%远程暴击率";
				case 1207:
					return "增加60点魔法上限";
				case 1208:
					return "增加2%暴击率";
				case 1209:
					return "增加1%暴击率";
				case 1210:
					return "增加7%移动速度和近战速度";
				case 1211:
					return "增加8%移动速度";
				case 1212:
					return "增加80点魔法上限";
				case 1215:
					return "增加8%近战速度";
				case 1216:
					return "增加7%远程暴击率";
				case 1217:
					return "增加100点魔法上限";
				case 1218:
					return "增加3%暴击率";
				case 1219:
					return "增加6%移动速度";
				case 1249:
					return "受到伤害后释放小蜜蜂";
				case 1250:
					return "并能跳得更高而且免疫摔落伤害";
				case 1251:
					return "并能跳得更高而且免疫摔落伤害";
				case 1252:
					return "并能跳得更高而且免疫摔落伤害";
				case 1254:
					return "右键瞄准";
				case 1282:
					return "减少5%魔力消耗";
				case 1283:
					return "减少7%魔力消耗";
				case 1284:
					return "减少9%魔力消耗";
				case 1285:
					return "减少11%魔力消耗";
				case 1286:
					return "减少13%魔力消耗";
				case 1287:
					return "减少15%魔力消耗";
				case 1295:
					return "'啊啊啊啊~~！！！！！！'";
				case 1300:
					return "右键瞄准";
				case 1301:
					return "增加8%暴击率";
				case 1316:
					return "你会像开了嘲讽一样吸引怪物的注意力";
				case 1317:
					return "你会像开了嘲讽一样吸引怪物的注意力";
				case 1318:
					return "你会像开了嘲讽一样吸引怪物的注意力";
				case 1321:
					return "20%几率不消耗弓箭";
				case 1336:
					return "并能减少目标的防御";
				case 1338:
					return "这只危险的小动物请小心地塞进兔子大炮里";
				case 1339:
					return "'内有剧毒，小心食用'";
				case 1340:
					return "近战攻击会对敌人造成剧毒效果";
				case 1341:
					return "可对目标造成剧毒效果";
				case 1342:
					return "可对目标造成剧毒效果";
				case 1343:
					return "增加10%近战伤害和速度";
				case 1349:
					return "击中后会释放各色彩纸";
				case 1350:
					return "能够造成混乱效果";
				case 1351:
					return "击中后爆炸";
				case 1352:
					return "杀死敌人后会掉落更多钱币";
				case 1353:
					return "近战攻击会使敌人被诅咒之炎灼烧";
				case 1354:
					return "近战攻击会使敌人着火";
				case 1355:
					return "近战攻击会使敌人掉落更多钱币";
				case 1356:
					return "近战攻击会减少敌人的防御";
				case 1357:
					return "近战攻击会使敌人混乱";
				case 1358:
					return "近战攻击会带有四散的彩纸";
				case 1359:
					return "近战攻击会使敌人中毒";
				case 1505:
					return "增加8%移动速度";
				case 1546:
					return "增加5%远程暴击率";
				case 1547:
					return "增加5%远程暴击率";
				case 1548:
					return "增加5%远程暴击率";
				case 1549:
					return "20%几率不消耗弹药";
				case 1550:
					return "增加12%移动速度";
				case 1553:
					return "'它来自深邃的太空，好吧它只是来自edge of space'";
				case 1595:
					return "受到伤害后回复魔力";
				case 1613:
					return "免疫大多数负面效果";
				case 1832:
					return "增加11%召唤物的伤害";
				case 1833:
					return "增加11%召唤物的伤害";
				case 1834:
					return "增加11%召唤物的伤害";
				case 1845:
					return "增加10%召唤物的伤害";
				case 1858:
					return "增加10%的远程伤害和暴击率";
				case 1860:
					return "在水下提供光源";
				case 1861:
					return "提高冰上的灵活性，并在水下提供光源";
				case 1862:
					return "增加7%的速度";
				case 1863:
					return "增大跳跃高度";
				case 1864:
					return "增加召唤物的伤害和击退";
				case 1865:
					return "生命回复速度，防御力，挖掘速度和召唤物击退";
				case 1866:
					return "按住“下”和“跳跃”键可以盘旋";
				case 2189:
					return "提升5%魔法伤害和暴击几率";
				case 2199:
					return "自带嘲讽";
				case 2200:
					return "增加6%移动和近战速度";
				case 2201:
					return "自带嘲讽";
				case 2202:
					return "自带嘲讽";
				case 2220:
					return "增加15％魔法伤害";
				case 2221:
					return "受伤时恢复魔法值";
				case 2270:
					return "非常不准确";
				case 2277:
					return "增加10%近战和移动速度";
				case 2279:
					return "减少10%法力消耗";
				case 2340:
					return "也可以用锤子敲轨道的交叉点来更改方向";
				case 2361:
					return "增加你的召唤物数量上限";
				case 2362:
					return "增加你的召唤物数量上限";
				case 2370:
					return "增加6%召唤物伤害";
				case 2371:
					return "增加6%召唤物伤害";
				case 2372:
					return "增加6%召唤物伤害";
				case 2423:
					return "增强对摔伤抗性";
				case 2586:
					return "“想让它滚动是很难的”";
				case 2590:
					return "照亮附近区域一段时间";
				case 2609:
					return "而且能让你在水中也快速移动";
				case 2757:
					return "提高7%的远程暴击率";
				case 2758:
					return "25%的几率不消耗子弹";
				case 2759:
					return "提高10%的移动速度";
				case 2760:
					return "增加7%魔法伤害和暴击率";
				case 2762:
					return "提高10%移动速度";
				case 2763:
					return "敌人更容易攻击你";
				case 2764:
					return "敌人更容易攻击你";
				case 2765:
					return "敌人更容易攻击你";
				case 2995:
					return "'在甜蜜的回忆里'";
				case 2997:
					return "在大地图上点击他们的头像";
				case 3015:
					return "增加5%的伤害和暴击率";
				case 3034:
					return "攻击敌人一定几率会掉落更多的金币";
				case 3035:
					return "攻击敌人一定几率会掉落更多的金币";
				case 3061:
					return "自动给放置的物体上色";
				case 3085:
					return "需要一把金钥匙";
				case 3097:
					return "双击方向键";
				case 3110:
					return "略微提升全部能力值";
				case 3115:
					return "弹性十足";
				case 3116:
					return "弹性十足";
				case 3124:
					return "想回家，就回家！";
				case 3226:
					return "化身成风，驾驭雷霆";
				case 3227:
					return "妆点着宝石，飞过雷云密布的苍穹。";
				case 3228:
					return "绝大多数情况下，女武神卫星防御平台都是安全的。";
				case 3241:
					return "装备上你就可以二段跳了";
				case 3245:
					return "33%的概率不消耗骨头";
				case 3250:
					return "增加跳跃高度并抵消掉落伤害";
				case 3251:
					return "增加跳跃高度并抵消掉落伤害";
				case 3252:
					return "增加跳跃高度并抵消掉落伤害";
				case 3368:
					return "'我不是作弊得到的'";
				case 3381:
					return "提高召唤物22%的伤害";
				case 3382:
					return "提高召唤物22%的伤害";
				case 3383:
					return "提高召唤物22%的伤害";
				case 3474:
					return "'培养出最好看的细胞'";
				case 3475:
					return "'电磁和爆炸的灾难性结合'";
				case 3531:
					return "'有了一条巨龙谁还需要一堆小喽啰？'";
				case 3532:
					return "'培根？培根。'";
				case 3571:
					return "'看看这颜色，兄弟，看看这颜色！'";
				case 3577:
					return "'我知道你在想什么....'";
				case 3580:
					return "不管这个饰品改变了你什么都不是bug！";
				case 3581:
					return "当你看到这个的时候，赶紧跑...";
				case 3589:
					return "秩序滋生混沌, 害怕源于勇气, 懦弱来自强大";
				case 3590:
					return "知己知彼，百战不殆...";
				case 3591:
					return "正义也许会迟到,但绝不会缺席";
				case 3592:
					return "静若子夜，动如响雷";
				case 3603:
					return "所有灯亮起则激活, 否则关闭";
				case 3604:
					return "任意灯亮起则激活, 否则关闭";
				case 3605:
					return "任意灯不亮则激活, 否则关闭";
				case 3606:
					return "所有灯不亮则激活, 否则关闭";
				case 3607:
					return "只有一个灯亮则激活, 否则关闭";
				case 3608:
					return "亮灯数不等于一则激活, 否则关闭";
				case 3611:
					return "按住鼠标右键来编辑线路";
				case 3746:
					return "内藏惊喜！";
				case 3757:
					return "'假装你是只企鹅！'";
				case 3758:
					return "'假装你是只企鹅！'";
				case 3759:
					return "'假装你是只企鹅！'";
				case 3763:
					return "'假装你是只企鹅！'";
				case 3809:
					return "增强召唤物伤害10%";
				case 3810:
					return "增强召唤物伤害10%";
				case 3811:
					return "增强召唤物伤害10%";
				case 3812:
					return "增强召唤物伤害10%";
				case 3818:
					return "使用10点艾特尼亚魔力来再次召唤";
				case 3819:
					return "使用10点艾特尼亚魔力来再次召唤";
				case 3820:
					return "使用10点艾特尼亚魔力来再次召唤";
				case 3824:
					return "使用10点艾特尼亚魔力来再次召唤";
				case 3825:
					return "使用10点艾特尼亚魔力来再次召唤";
				case 3826:
					return "使用10点艾特尼亚魔力来再次召唤";
				case 3829:
					return "使用10点艾特尼亚魔力来再次召唤";
				case 3830:
					return "使用10点艾特尼亚魔力来再次召唤";
				case 3831:
					return "使用10点艾特尼亚魔力来再次召唤";
				case 3832:
					return "使用10点艾特尼亚魔力来再次召唤";
				case 3833:
					return "使用10点艾特尼亚魔力来再次召唤";
				case 3834:
					return "使用10点艾特尼亚魔力来再次召唤";
				case 3852:
					return "按鼠标右键来制造一股强大的旋风";
				case 3883:
					return "按住向下和跳跃以悬浮";
				default:
					return string.Empty;
			}
		}

		public static string Title()
		{
			var id = Main.rand.Next(56);
			switch (id)
			{
				case 0:
					return "Terraria: 挖, 苦工! 快挖!";
				case 1:
					return "Terraria: 壮观的泥土堆";
				case 2:
					return "Terraria: \"紧\"金!";
				case 3:
					return "Terraria: 无敌的沙块";
				case 4:
					return "Terraria 第三章: 向导的回归";
				case 5:
					return "Terraria: 圣战兔子";
				case 6:
					return "Terraria: 僵尸博士的血月魔宫传奇";
				case 7:
					return "Terraria: 史莱姆公园";
				case 8:
					return "Terraria: 这山独比那山高";
				case 9:
					return "Terraria: 内含小砖块，不适合五岁以下儿童使用";
				case 10:
					return "Terraria: 砖块挖掘机";
				case 11:
					return "Terraria: 这里没有奶牛层, 也没有奶牛关!";
				case 12:
					return "Terraria: 可疑的眼球";
				case 13:
					return "Terraria: 紫色草地!";
				case 14:
					return "Terraria: 寸土不留!";
				case 15:
					return "Terraria: 半砖下的瀑布";
				case 16:
					return "Terraria: 地球冒险";
				case 17:
					return "Terraria: 挖矿什么的我才不关心";
				case 18:
					return "Terraria: 矿石好一切都好";
				case 19:
					return "Terraria: 终结者2: 审判粘土";
				case 20:
					return "Terraria: 惊魂泰拉镇";
				case 21:
					return "Terraria: 强迫探索症";
				case 22:
					return "Terraria: 开发者大镖客";
				case 23:
					return "Terraria: 史莱姆的崛起";
				case 24:
					return "Terraria: 更多敌人会干掉你了!";
				case 25:
					return "Terraria: 向导死亡的谣言被夸大了";
				case 26:
					return "Terraria: 我同情那个工具...";
				case 27:
					return "Terraria: 洞窟探险者: \"什么?\"";
				case 28:
					return "Terraria: 所以当我说起1.2版本要更新的时候..";
				case 29:
					return "Terraria: 愿砖块与你同在";
				case 30:
					return "Terraria: 药物引发的副作用的副作用是使你更加坚硬";
				case 31:
					return "Terraria: Terraria: Terraria: (标题没有出问题!)";
				case 32:
					return "Terraria: 1D重制版";
				case 33:
					return "Terraria: 即将在你身边的电脑上上映";
				case 34:
					return "Terraria: 我要除以0!!!";
				case 35:
					return "Terraria: 现在有声音了";
				case 36:
					return "Terraria: 快按 Alt + F4";
				case 37:
					return "Terraria: 我同情那个工具";
				case 38:
					return "Terraria: 兄弟, 你\"傻\"块呢?";
				case 39:
					return "Terraria: 龙胆虎威5: 择日开挖";
				case 40:
					return "Terraria: 你能Re-Dig-It吗?";
				case 41:
					return "Terraria: 我不知道-- 啊啊啊啊!";
				case 42:
					return "Terraria: 这个长着紫色的刺的是什么东西?";
				case 43:
					return "Terraria: I wanna be the guide";
				case 44:
					return "Terraria: 克苏鲁疯了... 他还缺了一只眼球!";
				case 45:
					return "Terraria: 又是蜜蜂!!!";
				case 46:
					return "Terraria: Maxx的传说";
				case 47:
					return "Terraria: Cenx的信徒";
				case 48:
					return "Terraria 2: 机械舞";
				case 49:
					return "Terraria: 来玩Minecraft吧!";
				case 50:
					return "Terraria: 来玩太空边缘吧!";
				case 51:
					return "Terraria: 我只想知道黄金在哪里..";
				case 52:
					return "Terraria: 更多鸭子会围着你了!";
				case 53:
					return "Terraria: 9 + 1 = 11";
				case 54:
					return "Terraria: 使命召唤: 无限世纪花";
				case 55:
					return "Terraria: 来玩地牢守护者2吧!";
				case 56:
					return "Terraria: 闭嘴，开挖!";
				default:
					return string.Empty;
			}
		}

		public static string SetBonus(int id)
		{
			switch (id)
			{
				case 0:
					return "增加2防御";
				case 1:
					return "增加3防御";
				case 2:
					return "增加15%的移动速度";
				case 3:
					return "空间枪不再消耗魔力";
				case 4:
					return "20%几率不消耗弹药";
				case 5:
					return "降低16%魔力消耗";
				case 6:
					return "增加17%近战伤害";
				case 7:
					return "增加30%采矿速度";
				case 8:
					return "降低14%魔力消耗";
				case 9:
					return "增加15%近战速度";
				case 10:
					return "20%几率不消耗弹药";
				case 11:
					return "降低17%魔力消耗";
				case 12:
					return "增加5%暴击率";
				case 13:
					return "20%几率不消耗弹药";
				case 14:
					return "降低19%魔力消耗";
				case 15:
					return "增加18%的近战速度和移动速度";
				case 16:
					return "25%的几率不消耗弹药";
				case 17:
					return "降低20%魔力消耗";
				case 18:
					return "增加19%的近战速度和移动速度";
				case 19:
					return "25%的几率不消耗弹药";
				case 20:
					return "增加1防御";
				case 21:
					return "生命快速回复";
				case 22:
					return "近战或远程攻击会造成冰焰伤害";
				case 23:
					return "增加最大召唤物数量";
				case 24:
					return "攻击敌人后大量增加生命回复速度";
				case 25:
					return "花瓣将落在你的敌人身上并造成伤害";
				case 26:
					return "攻击敌人后短暂无敌";
				case 27:
					return "召唤叶绿晶体攻击敌人";
				case 28:
					return "增加10%魔法暴击率";
				case 29:
					return "反弹对方的伤害";
				case 30:
					return "法术伤害可以吸取敌人生命";
				case 31:
					return "不移动将让你潜行，增加远程攻击力，并更不易被敌人发现";
				case 32:
					return "增加4防御";
				case 33:
					return "增加10%伤害";
				case 34:
					return "增加25%召唤物伤害";
				case 35:
					return "魔法造成额外溅射伤害";
				case 36:
					return "增加60最大法力值";
				case 37:
					return "甲虫保护你免受伤害";
				case 38:
					return "甲虫增加你的近战伤害和攻速";
				case 39:
					return "增加10%召唤物伤害";
				case 40:
					return "增加12%召唤物伤害";
				case 41:
					return "33%的几率不消耗投掷物";
				case 42:
					return "50%的几率不消耗投掷物";
				case 43:
					return "一段时间后会生成日耀盾牌保护你,可以消耗盾牌能量进行冲锋，对敌人造成伤害";
				case 44:
					return $"按两次{(Main.ReversedUpDownArmorSetBonuses ? "上" : "下")}方向键进入潜行模式,增加远程能力，更不易被敌人发现，但会降低移动速度";
				case 45:
					return "对敌人造成伤害有几率掉落加成物品,捡起加成物品获得增益状态";
				case 46:
					return $"按两次{(Main.ReversedUpDownArmorSetBonuses ? "上" : "下")}方向键指定守卫者的攻击目标";
				case 47:
					return $"按两次{(Main.ReversedUpDownArmorSetBonuses ? "上" : "下")}方向键在鼠标指向处召唤古代风暴";
				case 48:
					return "增加最大守卫者数量大幅度增强弩车的效果";
				case 49:
					return "增加最大守卫者数量大幅度增强焰爆炮塔的效果";
				case 50:
					return "增加最大守卫者数量大幅度增强爆炸陷阱的效果";
				case 51:
					return "增加最大守卫者数量大幅度增强闪电光环的效果";
				case 52:
					return "增加最大守卫者数量弩车能够发射穿透更多敌人的子弹，并在你受伤时触发“弩车危机”的效果";
				case 53:
					return "增加最大守卫者数量焰爆炮塔的视野和射击范围显著增强";
				default:
					return string.Empty;
			}
		}

		public static string DyeTraderQuestChat(bool gotDye)
		{
			var str = NPC.firstNPCName(207);
			if (gotDye)
				switch (Main.rand.Next(3))
				{
					case 0:
						return "亲爱的, 棒极了! 如此精致的样本, 你给我带来了这个世界最美的色彩和芬芳. 作为交换, 现在这小瓶特别的染料就归你了.";
					case 1:
						return "你给我带来了这个美丽又罕见的花... 把这瓶染料拿走吧,就当是你的劳务费咯, 朋友!";
					case 2:
						return $"妙极了! 棒极了伙计耶！看看这朵纤细的宝贝东西, 有了它我能调制出在{Main.worldName}里最令人惊叹的, 你从未见到过的颜料！快拿上这瓶染料吧!";
				}
			else
				switch (Main.rand.Next(3))
				{
					case 0:
						return "哦, 不不不, 这可行不通. 这些钱可不管用, 你必须给我带一个稀有植物的样本回来才行！";
					case 1:
						return $"看来你觉得你可以耍点小把戏就可以在{str}这里蹭点好处, 我 可 不 这 么 认 为! 我只把最最稀有的植物放进这些调制染料的瓶子里!";
					case 2:
						return "喜欢这些颜料瓶么? 抱歉了小可爱, 这些小玩意儿每一个可都是无价的. 你把那些宝贝般的植物样本拿来换吧, 这是我唯一接受的交换了!";
				}

			return string.Empty;
		}

		public static string Dialog(int id)
		{
			var npc18 = NPC.firstNPCName(18);
			var npc17 = NPC.firstNPCName(17);
			var npc19 = NPC.firstNPCName(19);
			var npc20 = NPC.firstNPCName(20);
			var npc38 = NPC.firstNPCName(38);
			var npc54 = NPC.firstNPCName(54);
			var npc22 = NPC.firstNPCName(22);
			NPC.firstNPCName(108);
			var npc107 = NPC.firstNPCName(107);
			var npc124 = NPC.firstNPCName(124);
			var npc160 = NPC.firstNPCName(160);
			NPC.firstNPCName(178);
			NPC.firstNPCName(207);
			var npc208 = NPC.firstNPCName(208);
			var npc209 = NPC.firstNPCName(209);
			NPC.firstNPCName(227);
			NPC.firstNPCName(228);
			var npc229 = NPC.firstNPCName(229);
			var npc353 = NPC.firstNPCName(353);
			NPC.firstNPCName(368);
			var npc369 = NPC.firstNPCName(369);

			switch (id)
			{
				case 1:
					return "我希望站在我们和克苏鲁之眼之间的人不是只有你这一个瘦小孩.";
				case 2:
					return "看看你这身破烂装甲，赶快来买几瓶治疗药水吧！";
				case 3:
					return "似乎有种邪恶的目光注视着我……喂，你！别看了！";
				case 4:
					return "剑赢了布！你最好今天弄到一把.";
				case 5:
					return "你想要苹果？想要胡萝卜？想要菠萝？玩蛋去！我们只需要火把.";
				case 6:
					return SocialAPI.Mode == SocialMode.Steam
						? "当你喝过药水觉得自己很坚硬怎么办? 还是来问我吧!"
						: "如果你喜欢本游戏，请购买正版。很便宜的噢，直接在Steam上用支付宝购买。";
				case 7:
					return "夜晚即将来临，朋友，选择一件吧……如果你可以的话.";
				case 8:
					return "你永远不会知道在海的另一边一块土卖到多少钱——但在这里，它们一文不值.";
				case 9:
					return $"哦，某天他们终将谈论起{Main.player[Main.myPlayer].name}的传奇……我确定.";
				case 10:
					return "看看我的这些土块，它们可真脏！";
				case 11:
					return "孩子，这天气真热啊！我有上好的通风透气的铠甲你要不要？";
				case 12:
					return "你看太阳都升得这么高，可我的价格却一点也不高.";
				case 13:
					return $"哦，好极了！我可以听到{npc124}和{npc18}在吵架呢.";
				case 14:
					return "你见过克祖……克斯……克……那个大眼睛么？";
				case 15:
					return $"喂，这个房间很安全，不是吗？不是吗？{Main.player[Main.myPlayer].name}?";
				case 16:
					return "即使血月也不能阻止我。让我们做点生意吧！";
				case 17:
					return "看看这价钱，买一个晶状体吧！";
				case 18:
					return "Kosh, kapleck Mog. 哦不好意思，这句话的意思是'不买东西就去死.'";
				case 19:
					return $"{Main.player[Main.myPlayer].name}是吗？我听说你有好东西，勇者！";
				case 20:
					return "我听说曾经有一座财宝……哦我啥也没说.";
				case 21:
					return "你说天使雕像？不好意思我不是个收破烂的.";
				case 22:
					return "最后一个离开这里的人留给了我一些垃圾……哦，我是说，财宝！";
				case 23:
					return "我想知道月亮是不是奶酪做的……哦，是的，要点什么？";
				case 24:
					return "你说金子？我会把它从你那里抢走的.";
				case 25:
					return "你最好别把血溅在我身上.";
				case 26:
					return "快点，别流血了！";
				case 27:
					return "如果你想死的话，死外面去.";
				case 28:
					return "这意味着什么？";
				case 29:
					return "我不喜欢你五音不全的喊叫声.";
				case 30:
					return "你在这里干嘛？你没流血的话就不必在这里.出去.";
				case 31:
					return "什么？！";
				case 32:
					return "你看到过地牢旁边的老人吗？他似乎有点麻烦事.";
				case 33:
					return $"我希望{npc38}注意一下.  我已经厌倦了每天都要把他的胳膊缝起来的日子.";
				case 34:
					return $"嘿，{npc19}没提过他需要看医生之类的话么？我只是好奇啦.";
				case 35:
					return $"我必须和{npc22}.  严肃地谈一谈。一个人究竟可以在一个星期内被岩浆烧伤多少次？";
				case 36:
					return "嗯...你这样更好看.";
				case 37:
					return "呃……你的脸怎么肿了？";
				case 38:
					return "哦天啊！我很好，但不是“这样”好.";
				case 39:
					return "亲爱的朋友们，我们今天聚集在这里悼念...哦，没事，没说你。";
				case 40:
					return "你把你的胳膊忘在那里了。让我给你拿过来...";
				case 41:
					return "别跟小孩一样怕疼！我见过更糟的伤。";
				case 42:
					return "这得缝针了！";
				case 43:
					return "这次又惹着谁了？给打成这熊样...";
				case 44:
					return "嘿，最近我搞到了一些卡通绷带。可爱吧？";
				case 45:
					return $" 多运动运动,{Main.player[Main.myPlayer].name},你会好起来的! ";
				case 46:
					return "你这样做真不疼吗？别再出去乱惹事了！";
				case 47:
					return "你看上去似乎被消化了一半。你又被史莱姆追了？";
				case 48:
					return "别对着我打喷嚏！头扭过去！";
				case 49:
					return "这是我见过的最严重的...不，我曾经看到了比这更要命的伤口。";
				case 50:
					return "你喜欢棒棒糖吗？";
				case 51:
					return "告诉我哪疼。";
				case 52:
					return "真对不起，但你付不起这费用。";
				case 53:
					return "买这玩意得花更多的钱。";
				case 54:
					return "我不干没有酬劳的工作。你懂。";
				case 55:
					return "没钱的话, 我也不能免费送你东西...";
				case 56:
					return "我不能再为你做什么了，除非你想被“整容”。";
				case 57:
					return "别浪费我的时间。";
				case 58:
					return $"我在地下看到个小娃娃，长得和{npc22}很像。 我还朝他顺手开了几枪。";
				case 59:
					return $"别耽误我时间！ 一个小时后我得和{npc18}约会。";
				case 60:
					return $"我要的是{npc18} 卖的东西……你说什么，她什么也不卖？";
				case 61:
					return $"{npc20}可真漂亮。但她的这种拘谨真是太糟糕了。";
				case 62:
					return $"别去打扰{npc38}了。我这里有所有你需要的全部东西！";
				case 63:
					return $"{npc38}脑袋出什么毛病了？他难道没有意识到我们卖的东西完全不同吗？";
				case 64:
					return $"哥们，这是一个不用和任何人说话的美好的夜晚，不是吗？{Main.player[Main.myPlayer].name}?";
				case 65:
					return "我爱像今晚这样的日子。满地跑的都是能杀的东西！";
				case 66:
					return "别盯着那个迷你鲨看了，你不会想知道它是怎么做的。";
				case 67:
					return "嘿，这不是演电影。子弹不是无限的。";
				case 68:
					return "把你的手从我的枪上拿开！伙计！";
				case 69:
					return "你有没有尝试在邪恶之地上撒净化粉？";
				case 70:
					return $"我希望{npc19}别再打扰我了。难道他不知道我已经500岁了？";
				case 71:
					return $"为什么{npc17} 总是试图向我推销一个天使雕像？每个人都知道，它没有任何用处。";
				case 72:
					return "你见过在地牢附近的老人吗？他看起来很似乎有麻烦。";
				case 73:
					return "我卖的东西都是我喜欢的！如果你不喜欢它，那真是太糟糕了。";
				case 74:
					return "为什么你非要在这种时候对我充满敌意？";
				case 75:
					return "我不仅仅希望你买我的东西。我要你整天盼着买我的东西。";
				case 76:
					return "哥们，我听错了还是说外面真有不少僵尸？";
				case 77:
					return "你必须净化这个邪恶的世界。";
				case 78:
					return "继续努力。泰拉瑞亚的世界需要你！";
				case 79:
					return "在时之沙的流淌中，你并没有优雅地老去。";
				case 80:
					return "你想咬我吗? 或者叫两声?";
				case 81:
					return "所以两个哥布林走进一家酒吧，其中一个对另一个说：你想要一杯酒么？";
				case 82:
					return "我不能让你进入，除非你解除我的诅咒。";
				case 83:
					return "晚上再来，如果你想进入的话。";
				case 84:
					return "我的主人不能在白天被召唤。";
				case 85:
					return "你太弱了, 根本没法对付我的主人. 等你不那么弱了再来找我吧.";
				case 86:
					return "可怜的孩子啊。你连面对我主人的希望都没有。";
				case 87:
					return "我希望你能多叫几个人来。你这是在自杀。";
				case 88:
					return "请不要这样做，陌生人。你这样只会杀死自己。";
				case 89:
					return "你也许勉强能将我从诅咒中得以释放......希望你能。";
				case 90:
					return "陌生人啊，你现在有实力击败我的主人了吗？";
				case 91:
					return "求你了！击败俘虏我的人，并释放我！我求求你了！";
				case 92:
					return "击败我的主人，我就让你进入地牢。";
				case 93:
					return "想通过黑檀石？嗯？把'炸药先生'介绍给他认识一下吧. ";
				case 94:
					return "嘿，你有在周围看到过小丑吗？";
				case 95:
					return "我刚点了个炸弹，但是现在我似乎找不到了......";
				case 96:
					return "我有一些好东西给外面的僵尸们玩！";
				case 97:
					return $"即使是{npc19}也想要我卖的东西！";
				case 98:
					return "你想要一个弹孔，还是手榴弹坑？这是我的想法。";
				case 99:
					return $"我敢肯定，{npc18}将帮助你，如果你不小心把你的某些肢体弄丢了的话。";
				case 100:
					return "为什么要费力去净化这个世界？你明明可以炸干净它！";
				case 101:
					return "如果你扔把这个在浴缸里，并关掉屋里所有的窗户，它会让你七窍流血！";
				case 102:
					return "想玩玩保险栓吗？";
				case 103:
					return "嘿，你能签署这个恶意破坏免责书吗？";
				case 104:
					return "这里禁止吸烟！";
				case 105:
					return "在这些天里，炸药是比太阳还火热的产品。现在就买一些吧！";
				case 106:
					return "今天是去死的好日子！";
				case 107:
					return "嗯如果我这么弄...（轰!）...啊, 对不起，你需要那条腿吗？";
				case 108:
					return "炸药,包治百病。";
				case 109:
					return "看看我的商品,惊“爆”价!";
				case 110:
					return "我总是迷迷糊糊能想起绑了一个女人并把她扔在一个地牢里的事情...";
				case 111:
					return "...我们有麻烦了！血月来了！";
				case 112:
					return $"当我年轻的时候，我一定会约{npc18}出去的。我曾经是一个少女杀手。";
				case 113:
					return "你的红帽看起来为什么这么熟悉呢……。";
				case 114:
					return "再次感谢您让我从我的诅咒中解脱出来...感觉就好像有东西跳出来咬了我一口一样。";
				case 115:
					return "我妈妈说我将来一定会成为一位伟大的裁缝。";
				case 116:
					return "人生就像一箱衣服，你永远不知道你要穿什么！";
				case 117:
					return "当裁缝是很不容易的！如果它不需要努力，没人会做到的！这就是为什么它很伟大。";
				case 118:
					return "没有人比我更了解服装业务了。";
				case 119:
					return "被诅咒是孤独的，所以我曾经用皮革做了一个娃娃。我叫他威尔士。";
				case 120:
					return "谢谢你释放我，人类。我被其他哥布林捆起来扔在这里。如你所见，我们似乎相处得并不好。";
				case 121:
					return "我简直不敢相信，他们把我绑起来，离开我仅仅和我说他们不会向东走！（这是2D游戏，对吧。）";
				case 122:
					return "现在，我是一个被抛弃的人，我可以扔掉这些钉刺球了么？我的口袋都嫌疼。";
				case 123:
					return "寻找一个工具专家吗？我是你的首选！";
				case 124:
					return "感谢您的帮助。现在，我要到处活动活动。我敢肯定，我们会再见面的。";
				case 125:
					return "啊,我以为你人挺高的。也没高到哪啊。";
				case 126:
					return $"嘿……{npc124}最近如何？你和她最近说过话没？";
				case 127:
					return "嘿，你的帽子需要发动机吗？我想我有一个发动机能刚好嵌到你的帽子里。";
				case 128:
					return "yooooo，我听说你喜欢火箭和跑靴，所以我把火箭放在你的跑靴里了。";
				case 129:
					return "沉默是金。胶带是银。";
				case 130:
					return "是的，黄金是比铁强。它们对现在的人有什么启示吗？";
				case 131:
					return "你知道，采矿头盔和脚蹼组合在一起理论上是一个更好的主意。";
				case 132:
					return "哥布林是非常易怒的。事实上，他们可以为了一块破布而发动一场战争！";
				case 133:
					return "说句实话，大多数的哥布林不是科学家，好吧，有的哥布林是。";
				case 134:
					return "你知道为什么我总是随身携带这些钉刺球吗？其实我也不知道。";
				case 135:
					return "这是我刚完成的杰作！这次这玩意在你深呼吸时不会随便爆炸了。";
				case 136:
					return "哥布林盗贼一点都不行嘛。他们甚至不能从一个没上锁的箱子里偷东西！";
				case 137:
					return "谢谢你救了我，朋友。有人恼羞成怒把我捆了起来。";
				case 138:
					return "哦，我的英雄！";
				case 139:
					return "哦，多么英勇！谢谢你救了我，小姐！";
				case 140:
					return "哦，多么英勇！谢谢你救了我，小伙子！";
				case 141:
					return "现在我们互相了解了，我可以住你那边的房子里了吧？";
				case 142:
					return $"嗯，您好，{npc22}！我可以为你做什么呢？";
				case 143:
					return $"嗯，您好，{npc38}！我可以为你做什么呢？";
				case 144:
					return $"嗯，您好，{npc107}！我可以为你做什么呢？";
				case 145:
					return $"嗯，您好，{npc18}！我可以为你做什么呢？";
				case 146:
					return $"嗯，您好，{npc124}！我可以为你做什么呢？";
				case 147:
					return $"嗯，您好，{npc20}！我可以为你做什么呢？";
				case 148:
					return "想要我从你耳朵后面掏个硬币出来吗？不？好吧。";
				case 149:
					return "你想要一些神奇的糖果吗？不要？好吧。";
				case 150:
					return "我做了一个相当美味的热巧克力，如果你把...不要？好吧。";
				case 151:
					return "你是专程来看我的水晶球的吗？";
				case 152:
					return "想不想要一个被施了魔法的指环，能把岩石变成史莱姆？好吧其实我也不想。";
				case 153:
					return "曾经有人告诉我友谊是神奇的魔法。但这是可笑的。你不能用友谊把人变成青蛙。";
				case 154:
					return "现在我可以看到你的未来......你会从我这买很多东西！";
				case 155:
					return "我曾经试图给天使雕像通电。结果它什么也没发生。";
				case 156:
					return "谢谢! 其实我知道, 我迟早会像那边的骷髅一样安静地卧在角落里。";
				case 157:
					return "嘿，记得你刚才去的的地方不? 刚才我还在那里！";
				case 158:
					return "等一下，我在这下面几乎就要搞到wifi信号了。";
				case 159:
					return "...我马上就能完成这闪光灯的安装工作了！";
				case 160:
					return "别，动。我wifi掉线了。";
				case 161:
					return "所有我想要的是用开关开启……什么！？";
				case 162:
					return "哦，让我猜猜看。你肯定没有买够电线。白痴。";
				case 163:
					return "你能, 能...好吗？好吧。唉。";
				case 164:
					return "我很介意你盯着我看的方式。我正忙工作呢。";
				case 165:
					return $"{Main.player[Main.myPlayer].name}嘿，你刚刚从{npc107}那里出来？他有没有说什么关于我的事呢？";
				case 166:
					return $"{npc19}一直在谈论我的压力板怎么用。我跟他说好几遍了是用脚踩! ";
				case 167:
					return "记住, 需要电线时, 要多买一些备用！";
				case 168:
					return "你确定你的设备通上电了? ";
				case 169:
					return "哦，你知道这房子需要什么？更多的灯！";
				case 170:
					return "我可以告诉你当血月出现时，天空会变成红色。外面就会莫名其妙地怪物成群。";
				case 171:
					return "嘿，哥们，你知道在哪里有食人花么？哦，没事，我只是好奇。就这些。";
				case 172:
					return "现在如果你向上看，你会看到月亮是红色的。";
				case 173:
					return "你应该留在室内。这时在外面乱跑是非常危险的! ";
				case 174:
					return SocialAPI.Mode == SocialMode.Steam
						? "当你喝过药水觉得自己很坚硬怎么办? 还是来问我吧!"
						: "如果你喜欢本游戏，请购买正版。很便宜的噢，直接在Steam上用支付宝购买.";
				case 175:
					return "我在这里能给你一些建议, 比如下一步要干什么。你感到迷茫的时候, 可以找我谈谈。";
				case 176:
					return "上帝说，有一个人会告诉你如何在这片土地上生存...其实那人就是我。";
				case 177:
					return "你可以使用你的锄头挖泥土，用你的斧头砍倒树木。只需将鼠标放置在砖块上，然后按住鼠标！";
				case 178:
					return "如果你想生存，你将需要打造武器并安置住所。要致富，先砍树。";
				case 179:
					return "按ESC键来访问背包。当你有足够的木材，创建一个工作台。这将允许你合成更复杂的物品，只要你站在接近它的地方。";
				case 180:
					return "你可以建立一个庇护所，放置在地面或其他物块上。不要忘了给房子做墙壁。";
				case 181:
					return "如果你有一把木剑的话，你就可以尝试着杀史莱姆来收集一些凝胶,木材和凝胶可以合成火把.";
				case 182:
					return "你要是想撤销背景墙或者放在地上的物品的话，那就用锤子吧!";
				case 183:
					return "你可以挖一挖地下,寻找金属矿。矿物能做出很多有用的东西。";
				case 184:
					return "现在你有一些矿石，要是你想熔炼金属矿，那你需要一个熔炉!";
				case 185:
					return "站在你的工作台附近, 用火把木材和石头可以合成一个熔炉.";
				case 186:
					return "金属锭可以制造武器和装备,但你需要个铁砧.";
				case 187:
					return "铁砧可以用铁块合成，也可以从商人那里购买.";
				case 188:
					return "地底下的生命水晶可以增加你的生命最大值，不过你需要一个镐才能敲掉他们.";
				case 189:
					return "你可以用5个星星合成一个魔法水晶,使你的最大魔法值增加10点.";
				case 190:
					return "星星会在夜晚坠落，他们能用来合成很多有用的东西。如果说你看到了一个，请务必把他拾起来，因为他们在太阳升起时就会消失.";
				case 191:
					return "有很多不同的方法吸引别的NPC到你的小镇里住。当然，他们需要一个房子来居住.";
				case 192:
					return "一个有门，有桌子，有椅子或者床，有光源和墙壁的房间才是一个NPC能住的房间. 房子也不能太小. ";
				case 193:
					return "两个人不会在同一个房间内居住，如果他们的房间被摧毁了的话，那他们就会去找一个新家.";
				case 194:
					return "打开你的背包，然后按一下房子的图标。可以用这个面板来安排NPC住房. ";
				case 195:
					return "如果说你想吸引商人过来的话，那你需要有金子。最少你要有50银币.";
				case 196:
					return "增加你的生命最大值，护士才会来.";
				case 197:
					return "如果你有一支枪，那么军火商肯定会过来向你出售一些弹药.";
				case 198:
					return "你想引起树精的重视的话，那么你需要击败一个强大的怪物来证明你自己有能力除掉邪恶.";
				case 199:
					return "请一定要仔细探索地牢，因为有人被关押在那里.";
				case 200:
					return "如果在地牢的老人的诅咒被解除，那他应该很乐意加入我们的队伍.";
				case 201:
					return "假如你有一些炸弹的话，那么爆破专家应该会来看看他们.";
				case 202:
					return "哥布林的确与我们不同，但这不说明我们不能和平相处.";
				case 203:
					return "我听说有一个强大的魔法师居住在这附近，所以你下次去地下的时候请睁大你的眼睛留意他的位置.";
				case 204:
					return "你在恶魔祭坛处合成的东西可以用来召唤一些强大的怪物。当然，你只有晚上才能够使用它.";
				case 205:
					return "你可以用那些腐烂的肉块和邪恶粉来制作一个蠕虫boss的诱饵，不过在使用他之前你要确定你是在一片腐化的区域.";
				case 206:
					return "有恶魔祭坛的地方一般都会有腐化，但是为了合成一些特别的东西所以你不得不靠近他.";
				case 207:
					return "你可以用铁锭做出3条铁链之后,从地底深处的骷髅身上获得钩子,合成一个钩爪.";
				case 208:
					return "如果说你看到一个陶罐，那你一定要把他打破。因为里面可能含有很多有用的东西.";
				case 209:
					return "泰拉瑞拉藏有有各式各样的宝箱. 这些宝箱遍布地下世界!";
				case 210:
					return "在腐败之地的裂缝深处通常会有暗影球或者恶魔心脏，打碎这个往往能发现很多有用的东西.";
				case 211:
					return "你应该更专注的收集生命水晶来增加你的生命最大值.";
				case 212:
					return "你现在身上的装备糟透了，你应该去合成一些更好的盔甲.";
				case 213:
					return "从恶魔之眼那里收集到一些晶状体之后带他们到恶魔祭坛那里，然后你就可以准备你的第一次重大战役了.";
				case 214:
					return "你需要来增加你的生命来应对下一波的挑战，300点生命值就应该足够了.";
				case 215:
					return "腐败之地是可以被净化的,你可以从树精那里收集一些净化粉, 或者用炸药.";
				case 216:
					return "你的下一步行动应该是去腐败之地探索那里的裂缝，尽可能寻找并摧毁所有你所找到的暗影之球";
				case 217:
					return "离这里不远你可以看到一个地牢，现在是探索地牢的最佳时机! ";
				case 218:
					return "你应该让你的生命最大值达到400点的上限.";
				case 219:
					return "在丛林深处往往有很多的宝藏，只要你愿意往深处前进.";
				case 220:
					return "在地狱有一种叫狱岩石的东西，它十分适合用来制作盔甲和武器.";
				case 221:
					return "当你觉得你准备好了,你就可以去尝试挑战地狱的守护者了. 召唤他必须牺牲一个人....挑战守护者所需要的东西, 就在地狱里. ";
				case 222:
					return "砸碎任何你可以找到的恶魔祭坛。好运会降临的！";
				case 223:
					return "只有在腐蚀之地和神圣之地的深处你才能够获得光明之魂和暗影之魂.";
				case 224:
					return "嗬嗬嗬，一瓶...蛋奶酒！";
				case 225:
					return "为我烤一些饼干怎么样?";
				case 226:
					return "什么？你认为我不可能存在?";
				case 227:
					return "我想尽办法把你的脸缝上了。下次可要小心一点。";
				case 228:
					return "这样可能会在你身上留下疤痕.";
				case 229:
					return "这就已经很好了，我不希望你再去尝试跳任何悬崖.";
				case 230:
					return "伤势并不严重……现在感觉如何?";
				case 231:
					return "好像生活在地下还不算太糟糕。像你一样的家伙趁我睡觉时闯进来想偷我的孩子.";
				case 232:
					return $"{npc20}是唯一一个我信任的人。她是唯一一个没有试着咬我一口或者用我制作药剂的人。";
				case 233:
					return "有一天我试着舔了下自己... 然后我就开始泛蓝光了。";
				case 234:
					return "每次我看到蓝色，我就会感到抑郁和惆怅.";
				case 235:
					return "你没见过这附近有猪吧? 我哥哥的一条腿就是被它吃了.";
				case 236:
					return "在这个地方所有人似乎都有点不对劲。我今天醒来发现裁缝在嚼我的脚。";
				case 237:
					return $"如果你能说服{npc160}来量量尺寸，我就给你打折";
				case 238:
					return $"我觉得{npc160}有点被人误解，他其实真的是一个有趣的家伙。";
				case 240:
					return "我不知道“松露洗牌'，所以不要不停地问我！";
				case 241:
					return "有这样一个关于我的谣言：'如果你不能打败他，那就吃了他！'";
				case 242:
					return "哦，你的屋子里都有什么？";
				case 243:
					return "我该成为一个空中海盗吗？我正在考虑成为一名空中海盗。";
				case 244:
					return "无论如何，一个喷气背包最适合你！";
				case 245:
					return "我感觉有点暴躁，因此骂你这矮丑挫也别觉得奇怪！";
				case 246:
					return $"我挺好奇{npc209}是通过什么方式使他拥有那样的移动能力？";
				case 247:
					return "那看起来像船长的人，对我来说，是“相当不错的海湾”，你知道这是什么意思！";
				case 248:
					return "让我看看你的装备！";
				case 249:
					return "我喜欢你的....齿轮，嗯..他是黄铜做的吗?";
				case 250:
					return "你进入神圣之地后可以看到一个美丽的彩虹，如果你想把他描绘下来，那我可以帮你.";
				case 251:
					return $"离{npc208}远点。她是一个可以'血洗'这个城镇的女孩!";
				case 252:
					return "我知道松绿和蓝绿的区别。但我不会告诉你。";
				case 253:
					return "我没有钛白色了，所以别来找我要白色染料。";
				case 254:
					return "你可以尝试把粉红色和紫色合成...我发誓这可以合成！";
				case 255:
					return "不,不,不...有上千种灰色!别让我开始数这些颜色...";
				case 256:
					return "我希望待会不会下雨，直到这种涂料干燥下来。否则这将是一场灾难！";
				case 257:
					return "我用最绚丽的色彩，来换取你的财富！";
				case 258:
					return "亲爱的，你穿得太单调。你必须吸取教训，给你的服装染色！";
				case 259:
					return "只有一种木材值得我染色，那就是丛林的红木。染色其他任何木材都是浪费。 ";
				case 260:
					return $"我求你阻止{npc229}来我这。每次他来这里我身上至少一周都有奇怪的味道！";
				case 261:
					return "你要个大夫? 我是个巫医, 差不多.";
				case 262:
					return "魔法的本质是自然，自然的本质是魔法.";
				case 263:
					return $"{npc18}可以帮助治愈你的身体，但我可以让你的身体自愈。";
				case 264:
					return $"作出明智的选择吧，{Main.player[Main.myPlayer].name}. 我的商品都是神秘的艺术。";
				case 265:
					return "我们得谈谈。这是...这是有关聚会的事。";
				case 266:
					return "除了聚会和聚会,我没有其他爱好了! ";
				case 267:
					return "我们应该在闪耀根聚会后再设立一个聚会后聚会。";
				case 268:
					return $"哇，{Main.player[Main.myPlayer].name}见到像你这样的冒险家，我想开个聚会庆祝一下！";
				case 269:
					return "在房子放一个镭射球灯，然后让我来告诉你什么是真正的聚会。";
				case 270:
					return "我有一次去瑞典的时候，他们正在疯狂地开派对。你不希望试试吗？";
				case 271:
					return $"我的名字叫{npc208}，但大家叫我扫把星。是的，听起来很酷，虽然有点奇怪...";
				case 272:
					return "你经常开聚会吗？偶尔开? 那我们就有话题可聊了...";
				case 273:
					return "我不是个新手.你知道，尝试过总比没试过好.";
				case 274:
					return " 啊哈哈哈哈..看看这满满一瓶闪耀根！";
				case 275:
					return "啊哈! 令人发笑的是我们该提到鹦鹉因为……呃……我们底都在说些什么？";
				case 276:
					return $"{Main.player[Main.myPlayer].name}你是这里船长见过的最漂亮的少女！不含'之一' ! ";
				case 277:
					return "离我的战利品远一点，你这个饭桶!";
				case 278:
					return "你他妈到底在瞎说什么？<白鲸记>明明是我写的!";
				case 279:
					return "*呀啊啊-布啦-哈哒啊啊啊*";
				case 280:
					return "然后492-8的住户说：“你认为我是谁，472-6的住户？” 哈，哈，哈.";
				case 281:
					return "我以前也是一个冒险者，直到我的动力系统中了一箭。";
				case 282:
					return "这句话是对的，或是错的? ";
				case 283:
					return "所以, 那个看起来不像样的人是个发明家?! 我可以跟他谈谈我的发明! ";
				case 284:
					return $"当然，我和{npc229}曾是好朋友，但他的鹦鹉替他买东西时, 那小家伙太毒舌了, 所以后来我不愿卖给他东西了...";
				case 285:
					return "我给我自己添加了味觉模块，这样我就能尝到传说中那啤酒的美味了!";
				case 286:
					return "有时候我有点……明白了吗？只有一点点？";
				case 287:
					return "'马桶盖发型' 对不?";
				case 288:
					return "这些能亮瞎你!";
				case 289:
					return "我手上黏黏糊糊的都是... 蜡.";
				case 290:
					return "茶？咖啡？或者再来一杯橙汁吗？";
				case 291:
					return "小娃娃，我们得认真对待发梢分叉的问题";
				case 292:
					return "姑娘——！说到你的闲话永远说不完。";
				case 293:
					return "先生，今天用哪个牌子的须后水?";
				case 294:
					return "在这坐一会，我去换剃刀。";
				case 295:
					return "换个发型还是换个发型？";
				case 296:
					return "你觉得我们会做什么... 稍稍做个护理？";
				case 297:
					return "我试过用染料商的产品. 一团糟.. 灾难啊.";
				case 298:
					return "噢你这可...可怜的家伙. 坐...坐在这. 马上就好.嘘...";
				case 299:
					return "看看我的新发型！";
				case 300:
					return $"先生你好，我是{npc353}, 我是您今天的理发师.";
				case 301:
					return "头顶也都剪掉么?  那不好玩...";
				case 302:
					return $"我希望你喜欢{npc208}的发型，是我做的!";
				case 303:
					return $"对于{npc38}的烧焦的头发我无能为力，他是个失败的例子.";
				case 304:
					return "小费请“随意”，别忘了我有剪刀，和你的脑袋";
				case 305:
					return "顺便一提，这把是割喉用的刀片。";
				case 306:
					return "你最好别碰我的头发!我刚磨过剃刀，还不知道怎么用呢！";
				case 307:
					return $"嗯, 我从{npc208}那听说{npc124}的朋友{npc18}把她男朋友的钱都花了买鞋。";
				case 308:
					return $"有一次我给{npc209}戴上假发，因为这样我才能给他理发. 我觉得他会喜欢!";
				case 309:
					return $"我试着去拜访{npc353}，她只是看着我说 '不行.'";
				case 310:
					return "弄好我的头发只是个时间问题!";
				case 311:
					return "你今天梳头了么?";
				case 312:
					return "精灵发型，还是淑女一点的?";
				case 313:
					return "修理耳毛和眉毛都行，但是我绝不接触鼻毛.";
				case 314:
					return "好了, 你坐在这泡一会. 我25分钟后回来给你染...";
				case 315:
					return "谢谢你，哈! 现在我终于能弄我自己的头发了.";
				case 316:
					return "你早点来我就免费给你理发了.";
				case 317:
					return "剪刀不能用于探险, 他们说的. 你不可能被蜘蛛网困住, 他们说的!";
				case 318:
					return "呃, 我的头发, 上面全是蜘蛛网!";
				case 319:
					return $"3个小时后在{npc22}的房子后面跟我见面, 我想你会发现我这儿有什么吸引人的东西.";
				case 320:
					return $"{npc17},他除了好买卖，没什么好相处的.";
				case 321:
					return $"我只卖我有的.{npc54}总是模仿我的风格.";
				case 322:
					return "嗯, 看起来你会用天使雕像! 他们切片，切丁，让生活更美好!";
				case 323:
					return "我不退换 \"买家的后悔\" 就算真的有什么理由.";
				case 324:
					return "现在购买免费送货!";
				case 325:
					return "世上有的我都卖!";
				case 326:
					return "你想要个自行车!?做一个我就买.";
				case 327:
					return "组合水烟和咖啡壶！ 还能切薯条!";
				case 328:
					return "瞧一瞧看一看! 一整磅鱼!非常新鲜!一整磅鱼!";
				case 329:
					return "找垃圾么？你来对了.";
				case 330:
					return "一个旧货店?  不，我只是卖一些稀有货.";
				case 331:
					return "砸心脏会导致陨石降临，心脏通常在裂痕里.";
				case 332:
					return "你尝试过对着猩红之地用净化粉末了么？";
				case 333:
					return "你必须净化这个红色的世界。";
				case 334:
					return "小子！我给你找了一份工作，别想不要！";
				case 335:
					return "我要一条鱼，快去给我钓一个！";
				case 336:
					return "嘿！快来牺牲自己……呃，我的意思是你骨骼惊奇，是成为垂钓大师的天才！ ";
				case 337:
					return $"{npc369}想要你成为{Main.worldName}的官方差役!";
				case 338:
					return "什么!!??你居然看不到我正在缠钓鱼线？?!";
				case 339:
					return "我有足够的鱼！我现在不需要你的帮助了！";
				case 340:
					return $"在{Main.worldName}, 里没有厨师，所以我只好自己烧鱼了！";
				case 341:
					return "嘿！当心！我正在设置我最大的恶作剧陷阱！没人会注意到的！你敢告诉别人你就完蛋了！";
				case 342:
					return "我来给你一些建议。别舔寒冰！等等，忘了我刚才说的吧，我真想看到你这么做啊！";
				case 343:
					return "你听到过鱼叫么？我没有，我只是想知道你有没有！";
				case 344:
					return $"{Main.worldName}绝对被很多鱼，甚至包括最稀奇的鱼，给装满了！";
				case 345:
					return "我太失望了！有些鱼在我出世前就灭绝了！这不公平！！";
				case 346:
					return "我虽然没有父母，但是我有超级多的鱼！这就足够了！";
				case 347:
					return $"呵呵，你应该看到了当我把食人鱼的牙往椅子上刺的时候，{npc20}的表情了吧！";
				case 348:
					return "我有个任务给你！不，我才不关心外边所谓的‘僵尸启示录’！";
				case 349:
					return "快来！听好！我需要你来为我抓一些东西！";
				case 350:
					return "我恨血月！那些可怕的声音吵得我整晚睡不着觉！";
				case 351:
					return "钓鱼的最差时间是血月！鱼咬钩了，可僵尸也咬你了！";
				case 352:
					return "现在有百万亿的怪物在外面呢！";
				case 353:
					return "谢谢，我想，为了报答你的救命之恩，你就给这样伟大的我当一个仆人吧！";
				case 354:
					return "哈？你是谁？我绝对没醉！";
				case 355:
					return "你救了我！你……是个好人，我可以利用你……呃，我的意思是，雇用你来为我做一件超级棒的事！";
				case 356:
					return "你有不用的骨头出售吗？我...又来寻找可以用来替换我的髋关节的东西了。";
				case 357:
					return "完美！终于有人来把我手上的蛆虫弄走了。";
				case 358:
					return "看一看瞧一瞧，我手上的史莱姆油包治百病！不灵不要钱！走过路过不要错过！";
				case 359:
					return "你拿到了一个掉在这儿的，真的脊椎——我说，为什么不买些东西呢？";
				case 360:
					return "你不会想知道那些人扔给我的东西的... 要买一些吗？";
				case 361:
					return "我会帮你一把手的，不过我上次这么做，手已经一个月没拿回来了。";
				case 362:
					return "离那些蜘蛛远点。它们会吸干你的内脏把你变成一具空壳。这一点请相信我。";
				case 363:
					return "这世界上唯二不变的真理就是死亡和税收, 我两者都有！";
				case 364:
					return "又是你？又来找我拿钱了！？";
				case 365:
					return "你们这些人开关门就不能动静小点吗？！";
				case 366:
					return "你这次又是一如既往地闲，你到底是做什么工作的啊？";
				case 367:
					return "好的，好的，好的！你的报酬我等会会给你的，在此之前你能不能有点耐心？";
				case 368:
					return "一个人被独自留在这应该做些什么? 去帮助忙碌的人啊！";
				case 369:
					return "...两桶糖浆，加上-- 啊，别介意，这儿，这是你的钱。";
				case 370:
					return "这话我只跟你讲... 我不知道他们为什么会对付清租金感到烦恼。";
				case 371:
					return $"有一次我叫{npc20}用他最喜欢的东西来当作房租， 结果他给了我一些生长在奇怪地方的蘑菇。";
				case 372:
					return $"告诉{npc19}不要用弹药来偿还我。 我连把枪都没有。";
				case 373:
					return $"你为什么不挑战挑战如何在不被{npc38}炸断手脚的情况下索要租金呢...";
				case 374:
					return $"我刚从{npc17}那儿回来，他想知道我有没有拿着信用卡。";
				case 380:
					return "这是你的税款，从居民那儿收到的。";
				case 381:
					return "我知道你又要来拿走我所有的硬币了！拿去，马上在我面前消失！";
				case 382:
					return "呸！拿走你的钱并且马上消失在我面前！";
				case 383:
					return "这就是你应得的！一分钱也没多了！拿去省着点花...";
				case 390:
					return "...居然还有人认为我贪婪？！我全部家当都给你了啊。";
				case 391:
					return "所以你是把我当存钱罐了吗？因为你每次看到我都问我要钱。";
				case 392:
					return "你甚至都懒得停下来跟我打声招呼？'";
				case 393:
					return "呸！你又来了？你不久前才在我这里拿了钱，等会再来吧！";
				case 394:
					return "我五分钟之前不是给了你半克朗了吗？滚！";
				case 395:
					return "你的手又伸到我钱包里了！？ 你还好意思说，我，贪，婪？";
				case 396:
					return "薪水你已经得到了，我不会再给你一分钱了！出去！";
				case 397:
					return "钱又不会在树上长出来，所以把手从我的果实上拿开！呸！ ";
				case 398:
					return "你有好好地使用我给你的每一分钱了吗！？呸，我又不是什么慈善机构，杀你的史莱姆去吧！";
				case 399:
					return "不带这么快的！ 你刚刚已经拿走了你的钱，现在先走开吧！ ";
				case 400:
					return "又来讨钱？不要这样看着我，我可不是会心软的人！ ";
				case 401:
					return "敲掉每一个你所能找到的血腥祭坛，敲掉之后有好事发生哦！";
				case 402:
					return "血腥祭坛一般可以在血腥之地找到。站在祭坛旁边可以制造一些特殊物品。";
				default:
					return string.Empty;
			}
		}

		public static void SetLang()
		{
			Lang.chestType[0] = "箱子";
			Lang.chestType[1] = "黄金箱子";
			Lang.chestType[2] = "锁住的黄金箱子";
			Lang.chestType[3] = "暗影箱子";
			Lang.chestType[4] = "锁住的暗影箱子";
			Lang.chestType[5] = "木桶";
			Lang.chestType[6] = "垃圾箱";
			Lang.chestType[7] = "黑檀木箱子";
			Lang.chestType[8] = "红木箱子";
			Lang.chestType[9] = "珍珠木箱子";
			Lang.chestType[10] = "藤条箱子";
			Lang.chestType[11] = "寒冰箱子";
			Lang.chestType[12] = "生命木箱子";
			Lang.chestType[13] = "天空箱子";
			Lang.chestType[14] = "阴影木箱子";
			Lang.chestType[15] = "蛛网箱子";
			Lang.chestType[16] = "蜥蜴箱子";
			Lang.chestType[17] = "水华箱子";
			Lang.chestType[18] = "丛林箱子";
			Lang.chestType[19] = "腐化箱子";
			Lang.chestType[20] = "血腥箱子";
			Lang.chestType[21] = "神圣箱子";
			Lang.chestType[22] = "寒冰箱子";
			Lang.chestType[23] = "锁住的丛林箱子";
			Lang.chestType[24] = "锁住的腐化箱子";
			Lang.chestType[25] = "锁住的血腥箱子";
			Lang.chestType[26] = "锁住的神圣箱子";
			Lang.chestType[27] = "锁住的寒冰箱子";
			Lang.chestType[28] = "皇家箱子";
			Lang.chestType[29] = "蜂蜜箱子";
			Lang.chestType[30] = "蒸汽朋克箱子";
			Lang.chestType[31] = "棕榈木箱子";
			Lang.chestType[32] = "蘑菇箱子";
			Lang.chestType[33] = "北地木箱子";
			Lang.chestType[34] = "史莱姆箱子";
			Lang.chestType[35] = "绿色地牢箱子";
			Lang.chestType[36] = "锁住的绿色地牢箱子";
			Lang.chestType[37] = "粉色地牢箱子";
			Lang.chestType[38] = "锁住的粉色地牢箱子";
			Lang.chestType[39] = "蓝色地牢箱子";
			Lang.chestType[40] = "锁住的蓝色地牢箱子";
			Lang.chestType[41] = "白骨箱子";
			Lang.chestType[42] = "仙人掌箱子";
			Lang.chestType[43] = "血肉箱子";
			Lang.chestType[44] = "黑曜石箱子";
			Lang.chestType[45] = "南瓜箱子";
			Lang.chestType[46] = "阴森箱子";
			Lang.chestType[47] = "玻璃箱子";
			Lang.chestType[48] = "火星箱子";
			Lang.chestType[49] = "陨铁箱子";
			Lang.chestType[50] = "花岗岩箱子";
			Lang.chestType[51] = "大理石箱子";

			Lang.dresserType[0] = "梳妆台";
			Lang.dresserType[1] = "黑檀木梳妆台";
			Lang.dresserType[2] = "红木梳妆台";
			Lang.dresserType[3] = "珍珠木梳妆台";
			Lang.dresserType[4] = "阴影木梳妆台";
			Lang.dresserType[5] = "蓝色地牢梳妆台";
			Lang.dresserType[6] = "绿色地牢梳妆台";
			Lang.dresserType[7] = "粉色地牢梳妆台";
			Lang.dresserType[8] = "黄金梳妆台";
			Lang.dresserType[9] = "黑曜石梳妆台";
			Lang.dresserType[10] = "白骨梳妆台";
			Lang.dresserType[11] = "仙人掌梳妆台";
			Lang.dresserType[12] = "阴森梳妆台";
			Lang.dresserType[13] = "天空梳妆台";
			Lang.dresserType[14] = "蜂蜜梳妆台";
			Lang.dresserType[15] = "蜥蜴梳妆台";
			Lang.dresserType[16] = "棕榈木梳妆台";
			Lang.dresserType[17] = "蘑菇梳妆台";
			Lang.dresserType[18] = "北地木梳妆台";
			Lang.dresserType[19] = "史莱姆梳妆台";
			Lang.dresserType[20] = "南瓜梳妆台";
			Lang.dresserType[21] = "蒸汽朋克梳妆台";
			Lang.dresserType[22] = "玻璃梳妆台";
			Lang.dresserType[23] = "血肉梳妆台";
			Lang.dresserType[24] = "火星梳妆台";
			Lang.dresserType[25] = "陨铁梳妆台";
			Lang.dresserType[26] = "花岗岩梳妆台";
			Lang.dresserType[27] = "大理石梳妆台";

			Lang.dt[0] = "找不到解毒剂.";
			Lang.dt[1] = "无法扑灭火焰.";
			Lang.dt[2] = "不能呼吸.";
			Lang.dt[3] = "无法容纳这么多电量.";

			Lang.gen[0] = "生成世界地形";
			Lang.gen[1] = "加入沙子";
			Lang.gen[2] = "生成山丘";
			Lang.gen[3] = "生成泥土";
			Lang.gen[4] = "把岩石放进泥土里";
			Lang.gen[5] = "把泥土放进岩石里";
			Lang.gen[6] = "加入粘土";
			Lang.gen[7] = "随机打洞";
			Lang.gen[8] = "生成小型洞穴";
			Lang.gen[9] = "生成大型洞穴";
			Lang.gen[10] = "生成地表洞穴";
			Lang.gen[11] = "生成丛林";
			Lang.gen[12] = "生成浮空岛";
			Lang.gen[13] = "添加蘑菇丛";
			Lang.gen[14] = "添加黏土";
			Lang.gen[15] = "添加淤泥";
			Lang.gen[16] = "添加光亮";
			Lang.gen[17] = "添加蛛网";
			Lang.gen[18] = "建造地下世界";
			Lang.gen[19] = "生成水体";
			Lang.gen[20] = "正在使世界邪恶化";
			Lang.gen[21] = "生成山洞";
			Lang.gen[22] = "生成海滩";
			Lang.gen[23] = "添加宝石";
			Lang.gen[24] = "使沙子下落";
			Lang.gen[25] = "清理泥土";
			Lang.gen[26] = "放置祭坛";
			Lang.gen[27] = "平衡液体";
			Lang.gen[28] = "放置生命水晶";
			Lang.gen[29] = "放置雕像";
			Lang.gen[30] = "掩埋宝物";
			Lang.gen[31] = "放更多的宝藏";
			Lang.gen[32] = "藏好丛林宝藏";
			Lang.gen[33] = "藏好水下宝藏";
			Lang.gen[34] = "布置陷阱";
			Lang.gen[35] = "放置易碎品";
			Lang.gen[36] = "放置地狱熔炉";
			Lang.gen[37] = "散播草种";
			Lang.gen[38] = "培育仙人掌";
			Lang.gen[39] = "种植太阳花";
			Lang.gen[40] = "种植树林";
			Lang.gen[41] = "种植药草";
			Lang.gen[42] = "种植杂草";
			Lang.gen[43] = "种植藤蔓";
			Lang.gen[44] = "种植鲜花";
			Lang.gen[45] = "种植蘑菇";
			Lang.gen[46] = "释放多余资源";
			Lang.gen[47] = "重置游戏对象";
			Lang.gen[48] = "设置困难模式";
			Lang.gen[49] = "保存世界数据:";
			Lang.gen[50] = "备份世界文件";
			Lang.gen[51] = "正在载入世界:";
			Lang.gen[52] = "检查物块边界:";
			Lang.gen[53] = "载入失败!";
			Lang.gen[54] = "未找到备份文件.";
			Lang.gen[55] = "寻找物块边框:";
			Lang.gen[56] = "加入雪块";
			Lang.gen[57] = "世界";
			Lang.gen[58] = "建造地牢";
			Lang.gen[59] = "一颗陨石已经降落!";
			Lang.gen[60] = "平滑地表";
			Lang.gen[61] = "生长苔藓";
			Lang.gen[62] = "生成宝石";
			Lang.gen[63] = "生成洞穴墙壁";
			Lang.gen[64] = "生成蜘蛛洞";
			Lang.gen[65] = "正在清除地图数据:";
			Lang.gen[66] = "正在保存地图数据:";
			Lang.gen[67] = "载入世界中:";
			Lang.gen[68] = "绘制地图:";
			Lang.gen[69] = "建造瀑布";
			Lang.gen[70] = "建造丛林废墟";
			Lang.gen[71] = "建造蜂巢";
			Lang.gen[72] = "正在使世界血腥化";
			Lang.gen[73] = "验证世界文件保存:";
			Lang.gen[74] = "史莱姆雨从天而降!";
			Lang.gen[75] = "史莱姆停止了降落.";
			Lang.gen[76] = "生成结构.";
			Lang.gen[77] = "添加更多的草丛";
			Lang.gen[78] = "沙漠化";
			Lang.gen[79] = "点缀墙壁";
			Lang.gen[80] = "凿取大理石";
			Lang.gen[81] = "生成花岗岩";

			Lang.inter[0] = "生命:";
			Lang.inter[1] = "呼吸";
			Lang.inter[2] = "魔力";
			Lang.inter[3] = "垃圾桶";
			Lang.inter[4] = "背包";
			Lang.inter[5] = "快捷栏已解锁";
			Lang.inter[6] = "快捷栏已上锁";
			Lang.inter[7] = "住房";
			Lang.inter[8] = "房屋查询";
			Lang.inter[9] = "饰品";
			Lang.inter[10] = "防御";
			Lang.inter[11] = "时装";
			Lang.inter[12] = "头盔";
			Lang.inter[13] = "上衣";
			Lang.inter[14] = "裤子";
			Lang.inter[15] = "铂金币";
			Lang.inter[16] = "金币";
			Lang.inter[17] = "银币";
			Lang.inter[18] = "铜币";
			Lang.inter[19] = "重铸";
			Lang.inter[20] = "在这里放置物品以重铸";
			Lang.inter[21] = "显示配方";
			Lang.inter[22] = "需要物件:";
			Lang.inter[23] = "无";
			Lang.inter[24] = "在这里放置材料";
			Lang.inter[25] = "制造";
			Lang.inter[26] = "金钱";
			Lang.inter[27] = "弹药";
			Lang.inter[28] = "商店";
			Lang.inter[29] = "全部取出";
			Lang.inter[30] = "全部放入";
			Lang.inter[31] = "快速堆叠";
			Lang.inter[32] = "猪猪储蓄罐";
			Lang.inter[33] = "保险箱";
			Lang.inter[34] = "时间";
			Lang.inter[35] = "保存并退出";
			Lang.inter[36] = "断开连接";
			Lang.inter[37] = "物品";
			Lang.inter[38] = "你死了...";
			Lang.inter[39] = "这间房子可以住人.";
			Lang.inter[40] = "这间房子不合格.";
			Lang.inter[41] = "这间房子已经有人住了.";
			Lang.inter[42] = "这间房子被污染了.";
			Lang.inter[43] = "连接超时";
			Lang.inter[44] = "接收物块数据";
			Lang.inter[45] = "装备";
			Lang.inter[46] = "花费";
			Lang.inter[47] = "保存";
			Lang.inter[48] = "编辑";
			Lang.inter[49] = "状态";
			Lang.inter[50] = "诅咒";
			Lang.inter[51] = "帮助";
			Lang.inter[52] = "关闭";
			Lang.inter[53] = "水";
			Lang.inter[54] = "治疗";
			Lang.inter[55] = "这间房子缺少";
			Lang.inter[56] = "岩浆";
			Lang.inter[57] = "染料";
			Lang.inter[58] = "蜂蜜";
			Lang.inter[59] = "饰品可见";
			Lang.inter[60] = "饰品被隐藏";
			Lang.inter[61] = "重命名";
			Lang.inter[62] = "设置";
			Lang.inter[63] = "取消";
			Lang.inter[64] = "任务";
			Lang.inter[65] = "任务物品";
			Lang.inter[66] = "储蓄";
			Lang.inter[67] = "获取截图";
			Lang.inter[68] = "设定";
			Lang.inter[69] = "选点设定范围";
			Lang.inter[70] = "调整范围大小";
			Lang.inter[71] = "关闭";
			Lang.inter[72] = "开启";
			Lang.inter[73] = "关闭";
			Lang.inter[74] = "图片打包";
			Lang.inter[75] = "显示单位";
			Lang.inter[76] = "显示背景";
			Lang.inter[77] = "生态选择";
			Lang.inter[78] = "重设范围";
			Lang.inter[79] = "装备";
			Lang.inter[80] = "住房";
			Lang.inter[81] = "相机模式";
			Lang.inter[82] = "快速拿取";
			Lang.inter[83] = "冰霜之月";
			Lang.inter[84] = "南瓜之月";
			Lang.inter[85] = "火星暴乱";
			Lang.inter[86] = "海盗入侵";
			Lang.inter[87] = "雪人军团";
			Lang.inter[88] = "哥布林军团";
			Lang.inter[89] = "收集";
			Lang.inter[90] = "钩爪";
			Lang.inter[91] = "坐骑";
			Lang.inter[92] = "宠物";
			Lang.inter[93] = "矿车";
			Lang.inter[94] = "照明宠物";
			Lang.inter[95] = "时间";
			Lang.inter[96] = "天气";
			Lang.inter[97] = "垂钓";
			Lang.inter[98] = "位置";
			Lang.inter[99] = "深度";
			Lang.inter[100] = "生物数量";
			Lang.inter[101] = "杀怪数量";
			Lang.inter[102] = "月相";
			Lang.inter[103] = "移动速度";
			Lang.inter[104] = "宝藏";
			Lang.inter[105] = "稀有生物";
			Lang.inter[106] = "每秒伤害量";
			Lang.inter[107] = "奇异植物";
			Lang.inter[108] = "打开地图";
			Lang.inter[109] = "关闭地图";
			Lang.inter[110] = "打开文件夹";
			Lang.inter[111] = "截图屏幕";
			Lang.inter[112] = "你必须先设置范围";
			Lang.inter[113] = "只在窗口模式下可用";
			Lang.inter[114] = "当地图打开时可用";
			Lang.inter[115] = "禁用相机模式";
			Lang.inter[116] = "禁用高亮新物品";
			Lang.inter[117] = "开启高亮新物品";
			Lang.inter[118] = "拉近镜头";
			Lang.inter[119] = "推远镜头";
			Lang.inter[120] = "传送至队友";
			Lang.inter[121] = "掉落物品";
			Lang.inter[122] = "整理物品";
			Lang.inter[123] = "寒冷天气";

			Lang.menu[0] = "开启一个新游戏!";
			Lang.menu[1] = "端口运行";
			Lang.menu[2] = "断开连接";
			Lang.menu[3] = "服务器密码";
			Lang.menu[4] = "完成";
			Lang.menu[5] = "返回";
			Lang.menu[6] = "取消";
			Lang.menu[7] = "输入服务器密码:";
			Lang.menu[8] = "启动服务器...";
			Lang.menu[9] = "读取失败!";
			Lang.menu[10] = "读取备份文件...";
			Lang.menu[11] = "未找到备份文件!";
			Lang.menu[12] = "单人游戏";
			Lang.menu[13] = "多人游戏";
			Lang.menu[14] = "游戏设置";
			Lang.menu[15] = "退出游戏";
			Lang.menu[16] = "创建角色";
			Lang.menu[17] = "删除";
			Lang.menu[18] = "头发";
			Lang.menu[19] = "眼睛";
			Lang.menu[20] = "皮肤";
			Lang.menu[21] = "衣服";
			Lang.menu[22] = "男性";
			Lang.menu[23] = "女性";
			Lang.menu[24] = "困难";
			Lang.menu[25] = "中等";
			Lang.menu[26] = "简单";
			Lang.menu[27] = "随机";
			Lang.menu[28] = "创建";
			Lang.menu[29] = "困难难度下角色不能复活";
			Lang.menu[30] = "中等难度角色死亡掉落所有物品";
			Lang.menu[31] = "简单难度角色死亡掉落钱币";
			Lang.menu[32] = "难度选择";
			Lang.menu[33] = "上衣";
			Lang.menu[34] = "内衣";
			Lang.menu[35] = "裤子";
			Lang.menu[36] = "鞋子";
			Lang.menu[37] = "头发";
			Lang.menu[38] = "头发颜色";
			Lang.menu[39] = "眼睛颜色";
			Lang.menu[40] = "皮肤颜色";
			Lang.menu[41] = "上衣颜色";
			Lang.menu[42] = "内衣颜色";
			Lang.menu[43] = "裤子颜色";
			Lang.menu[44] = "鞋子颜色";
			Lang.menu[45] = "输入角色名称:";
			Lang.menu[46] = "删除";
			Lang.menu[47] = "创建地图";
			Lang.menu[48] = "输入地图名称:";
			Lang.menu[49] = "窗口模式";
			Lang.menu[50] = "全屏模式";
			Lang.menu[51] = "分辨率";
			Lang.menu[52] = "视差效果";
			Lang.menu[53] = "自动跳帧 关（不推荐）";
			Lang.menu[54] = "自动跳帧 开（推荐）";
			Lang.menu[55] = "光效：彩色";
			Lang.menu[56] = "光效：白色";
			Lang.menu[57] = "光效：复古（最低配置）";
			Lang.menu[58] = "光效：梦幻";
			Lang.menu[59] = "图像质量：自动";
			Lang.menu[60] = "图像质量：高";
			Lang.menu[61] = "图像质量：中";
			Lang.menu[62] = "图像质量：低";
			Lang.menu[63] = "图像";
			Lang.menu[64] = "指针颜色";
			Lang.menu[65] = "音量";
			Lang.menu[66] = "控制";
			Lang.menu[67] = "自动保存 开";
			Lang.menu[68] = "自动保存 关";
			Lang.menu[69] = "自动暂停 开";
			Lang.menu[70] = "自动暂停 关";
			Lang.menu[71] = "拾取文字 开";
			Lang.menu[72] = "拾取文字 关";
			Lang.menu[73] = "全屏分辨率";
			Lang.menu[74] = "向上                ";
			Lang.menu[75] = "向下             ";
			Lang.menu[76] = "向左               ";
			Lang.menu[77] = "向右             ";
			Lang.menu[78] = "跳跃             ";
			Lang.menu[79] = "丢弃            ";
			Lang.menu[80] = "物品栏        ";
			Lang.menu[81] = "快捷回复体力       ";
			Lang.menu[82] = "快捷回复法力      ";
			Lang.menu[83] = "快捷增益       ";
			Lang.menu[84] = "钩爪           ";
			Lang.menu[85] = "自动选择       ";
			Lang.menu[86] = "重置回默认";
			Lang.menu[87] = "加入游戏";
			Lang.menu[88] = "创建游戏";
			Lang.menu[89] = "输入IP地址:";
			Lang.menu[90] = "输入端口:";
			Lang.menu[91] = "选择地图尺寸:";
			Lang.menu[92] = "小型";
			Lang.menu[93] = "中型";
			Lang.menu[94] = "大型";
			Lang.menu[95] = "红:";
			Lang.menu[96] = "绿:";
			Lang.menu[97] = "蓝:";
			Lang.menu[98] = "音效:";
			Lang.menu[99] = "音乐:";
			Lang.menu[100] = "背景 开";
			Lang.menu[101] = "背景 关";
			Lang.menu[102] = "选择语言";
			Lang.menu[103] = "语言";
			Lang.menu[104] = "是";
			Lang.menu[105] = "否";
			Lang.menu[106] = "切换地图风格           ";
			Lang.menu[107] = "切换全屏地图          ";
			Lang.menu[108] = "放大                      ";
			Lang.menu[109] = "缩小                    ";
			Lang.menu[110] = "减少透明度     ";
			Lang.menu[111] = "增加透明度      ";
			Lang.menu[112] = "小地图 开启";
			Lang.menu[113] = "小地图 关闭";
			Lang.menu[114] = "普通";
			Lang.menu[115] = "地图控制";
			Lang.menu[116] = "多核照明:";
			Lang.menu[117] = "关闭";
			Lang.menu[118] = "关闭菜单";
			Lang.menu[119] = "环境";
			Lang.menu[120] = "智能鼠标    ";
			Lang.menu[121] = "智能鼠标模式: 开关";
			Lang.menu[122] = "智能鼠标模式: 按键";
			Lang.menu[123] = "入侵进度";
			Lang.menu[124] = "关闭";
			Lang.menu[125] = "自动";
			Lang.menu[126] = "打开";
			Lang.menu[127] = "风格";
			Lang.menu[128] = "放置预览 开启";
			Lang.menu[129] = "放置预览 关闭";
			Lang.menu[130] = "坐骑             ";
			Lang.menu[131] = "游戏成就";
			Lang.menu[132] = "血腥效果 开启";
			Lang.menu[133] = "血腥效果 关闭";
			Lang.menu[134] = "接受";
			Lang.menu[135] = "服务器设置";
			Lang.menu[136] = "Steam多人: 关闭";
			Lang.menu[137] = "Steam多人: 开启";
			Lang.menu[138] = "允许的玩家: 仅被邀请的好友";
			Lang.menu[139] = "允许的玩家: 全部好友";
			Lang.menu[140] = "好友可邀请: 关闭";
			Lang.menu[141] = "好友可邀请: 开启";
			Lang.menu[142] = "允许好友的好友加入: 关闭";
			Lang.menu[143] = "允许好友的好友加入: 打开";
			Lang.menu[144] = "启动";
			Lang.menu[145] = "通过Steam加入";
			Lang.menu[146] = "通过IP加入";
			Lang.menu[147] = "邀请好友";
			Lang.menu[148] = "向上";
			Lang.menu[149] = "向下";
			Lang.menu[150] = "向左";
			Lang.menu[151] = "向右";
			Lang.menu[152] = "跳跃";
			Lang.menu[153] = "丢弃";
			Lang.menu[154] = "物品栏";
			Lang.menu[155] = "钩爪";
			Lang.menu[156] = "快捷回复魔法";
			Lang.menu[157] = "快捷增益";
			Lang.menu[158] = "快捷骑乘";
			Lang.menu[159] = "快捷回复生命";
			Lang.menu[160] = "自动选择";
			Lang.menu[161] = "智能鼠标";
			Lang.menu[162] = "使用道具";
			Lang.menu[163] = "互动";
			Lang.menu[164] = "游戏控制";
			Lang.menu[165] = "小地图控制";
			Lang.menu[166] = "快捷栏控制";
			Lang.menu[167] = "手柄设置";
			Lang.menu[168] = "放大";
			Lang.menu[169] = "缩小";
			Lang.menu[170] = "增加透明度";
			Lang.menu[171] = "降低透明度";
			Lang.menu[172] = "切换地图风格";
			Lang.menu[173] = "切换全屏全图";
			Lang.menu[174] = "左移";
			Lang.menu[175] = "右移";
			Lang.menu[176] = "快捷栏1号";
			Lang.menu[177] = "快捷栏2号";
			Lang.menu[178] = "快捷栏3号";
			Lang.menu[179] = "快捷栏4号";
			Lang.menu[180] = "快捷栏5号";
			Lang.menu[181] = "快捷栏6号";
			Lang.menu[182] = "快捷栏7号";
			Lang.menu[183] = "快捷栏8号";
			Lang.menu[184] = "快捷栏9号";
			Lang.menu[185] = "快捷栏10号";
			Lang.menu[186] = "快捷标记1号";
			Lang.menu[187] = "快捷标记2号";
			Lang.menu[188] = "快捷标记3号";
			Lang.menu[189] = "快捷标记4号";
			Lang.menu[190] = "水平快捷栏";
			Lang.menu[191] = "光标捕捉上移";
			Lang.menu[192] = "光标捕捉右移";
			Lang.menu[193] = "光标捕捉下移";
			Lang.menu[194] = "光标捕捉左移";
			Lang.menu[195] = "<未设置>";
			Lang.menu[196] = "十字键光标捕捉";
			Lang.menu[197] = "十字键快捷栏";
			Lang.menu[198] = "手柄高级设置";
			Lang.menu[199] = "扳机盲区";
			Lang.menu[200] = "滑块盲区";
			Lang.menu[201] = "左摇杆水平盲区";
			Lang.menu[202] = "左摇杆垂直盲区";
			Lang.menu[203] = "右摇杆水平盲区";
			Lang.menu[204] = "右摇杆垂直盲区";
			Lang.menu[205] = "左摇杆水平翻转";
			Lang.menu[206] = "左摇杆垂直翻转";
			Lang.menu[207] = "右摇杆水平翻转";
			Lang.menu[208] = "右摇杆垂直翻转";
			Lang.menu[209] = "使用";
			Lang.menu[210] = "界面";
			Lang.menu[211] = "密码: 可见";
			Lang.menu[212] = "密码: 隐藏";
			Lang.menu[213] = "智能光标优先级: 镐 -> 斧";
			Lang.menu[214] = "智能光标优先级: 斧 -> 镐";
			Lang.menu[215] = "智能光标放置: 到光标";
			Lang.menu[216] = "智能光标放置: 填充";
			Lang.menu[217] = "边框颜色";
			Lang.menu[218] = "鼠标";
			Lang.menu[219] = "控制";
			Lang.menu[220] = "激活套装效果: 按上方向键";
			Lang.menu[221] = "激活套装效果: 按下方向键";
			Lang.menu[222] = "按键设置";
			Lang.menu[223] = "左Shift快捷垃圾桶: 开启";
			Lang.menu[224] = "左Shift快捷垃圾桶: 关闭";
			Lang.menu[225] = "快捷更换墙壁: 关闭";
			Lang.menu[226] = "快捷更换墙壁: 开启";
			Lang.menu[227] = "水平快捷栏滚动时间: 打开";
			Lang.menu[228] = "水平快捷栏滚动时间: 关闭";
			Lang.menu[229] = "方块网格 打开";
			Lang.menu[230] = "方块网格 关闭";
			Lang.menu[231] = "目标锁定";
			Lang.menu[232] = "目标锁定优先级: 手动锁定的目标";
			Lang.menu[233] = "目标锁定优先级: 最近目标";
			Lang.menu[234] = "目标锁定优先级: 最清晰路径";
			Lang.menu[235] = "abc / ABC / !@#";
			Lang.menu[236] = "退格键";
			Lang.menu[237] = "完成";
			Lang.menu[238] = "空格键";
			Lang.menu[239] = "<-";
			Lang.menu[240] = "->";
			Lang.menu[241] = "手柄提示 关闭";
			Lang.menu[242] = "手柄提示 打开";
			Lang.menu[243] = "菜单控制";
			Lang.menu[244] = "横向快捷栏";
			Lang.menu[245] = "无边框窗口: 开启";
			Lang.menu[246] = "无边框窗口: 关闭";
			Lang.menu[247] = "自动跳帧 关闭";
			Lang.menu[248] = "自动跳帧 打开";
			Lang.menu[249] = "自动跳帧 平滑";
			Lang.menu[250] = "打碎方块效果: 开启";
			Lang.menu[251] = "打碎方块效果: 关闭";
			Lang.menu[252] = "界面移动延迟";

			Lang.misc[0] = "哥布林军队被击败!";
			Lang.misc[1] = "哥布林军队正在从西边接近!";
			Lang.misc[2] = "哥布林军队正在从东边接近!";
			Lang.misc[3] = "哥布林军队已经抵达!";
			Lang.misc[4] = "雪人军团被打败了!";
			Lang.misc[5] = "雪人军团正在从西边接近!";
			Lang.misc[6] = "雪人军团正在从东边接近!";
			Lang.misc[7] = "雪人军团已经抵达!";
			Lang.misc[8] = "血色之月正在升起...";
			Lang.misc[9] = "你感受到一个邪恶的存在正注视着你...";
			Lang.misc[10] = "寒气顺着你的脊骨流下...";
			Lang.misc[11] = "尖叫声回响在你的耳旁...";
			Lang.misc[12] = "你的世界被赋予了钴蓝矿!";
			Lang.misc[13] = "你的世界被赋予了秘银矿!";
			Lang.misc[14] = "你的世界被赋予了精金矿!";
			Lang.misc[15] = "古老的光暗之灵被释放了.";
			Lang.misc[16] = "苏醒了!";
			Lang.misc[17] = "被击败!";
			Lang.misc[18] = "已抵达!";
			Lang.misc[19] = " 被杀害...";
			Lang.misc[20] = "发生了日蚀!";
			Lang.misc[21] = "你的世界被赋予了钯金矿!";
			Lang.misc[22] = "你的世界被赋予了山铜矿!";
			Lang.misc[23] = "你的世界被赋予了钛金矿!";
			Lang.misc[24] = "海盗被击败了!";
			Lang.misc[25] = "海盗正在从东边接近!";
			Lang.misc[26] = "海盗军队正在从东边接近!";
			Lang.misc[27] = "海盗已经抵达!";
			Lang.misc[28] = "你感受到了深处的震动...";
			Lang.misc[29] = "这将会是个糟糕的夜晚...";
			Lang.misc[30] = "你周围的空气变冷了...";
			Lang.misc[31] = "南瓜之月正在升起...";
			Lang.misc[32] = "丛林变得不安宁了...";
			Lang.misc[33] = "尖叫声在地牢里回响...";
			Lang.misc[34] = "冰霜之月正在升起...";
			Lang.misc[35] = "离开了!";
			Lang.misc[36] = " 离开了!";
			Lang.misc[37] = "任意";
			Lang.misc[38] = "压力板";
			Lang.misc[39] = " 增加生命恢复";
			Lang.misc[40] = "增加生命恢复";
			Lang.misc[41] = "火星人正在入侵!";
			Lang.misc[42] = "火星人被击败了!";
			Lang.misc[43] = "天体生物正在入侵!";
			Lang.misc[44] = "你的头脑开始发麻...";
			Lang.misc[45] = "疼痛要压垮你了...";
			Lang.misc[46] = "超脱尘世的声响流连在你身边...";
			Lang.misc[47] = "月之领主苏醒了!";
			Lang.misc[48] = "双子魔眼苏醒了!";
			Lang.misc[49] = "你从一个古怪的梦中醒来...";
			Lang.misc[50] = "被击败!";
			Lang.misc[51] = "月之碎片";
			Lang.misc[52] = "灾难接近了...";
			Lang.misc[53] = "选择";
			Lang.misc[54] = "拿取";
			Lang.misc[55] = "拿取一个";
			Lang.misc[56] = "关闭";
			Lang.misc[57] = "钩爪";
			Lang.misc[58] = "跳跃";
			Lang.misc[59] = "圆环快捷栏";
			Lang.misc[60] = "攻击";
			Lang.misc[61] = "建造";
			Lang.misc[62] = "喝";
			Lang.misc[63] = "动作";
			Lang.misc[64] = "切换菜单";
			Lang.misc[65] = "放置";
			Lang.misc[66] = "交换";
			Lang.misc[67] = "装备";
			Lang.misc[68] = "卸下装备";
			Lang.misc[69] = "显示房子旗帜";
			Lang.misc[70] = "检查房屋";
			Lang.misc[71] = "快速制造";
			Lang.misc[72] = "制造";
			Lang.misc[73] = "选择";
			Lang.misc[74] = "丢弃";
			Lang.misc[75] = "卖出";
			Lang.misc[76] = "转出";
			Lang.misc[77] = "显示";
			Lang.misc[78] = "隐藏";
			Lang.misc[79] = "使用";
			Lang.misc[80] = "谈话";
			Lang.misc[81] = "阅读";
			Lang.misc[82] = "后退";
			Lang.misc[83] = "收藏";
			Lang.misc[84] = "你无法在你队伍方块区域内更换队伍!";
			Lang.misc[85] = "虫";
			Lang.misc[86] = "鸭子";
			Lang.misc[87] = "蝴蝶";
			Lang.misc[88] = "萤火虫";
			Lang.misc[89] = "电路选项";
			Lang.misc[90] = "购买";
			Lang.misc[91] = "购买更多";
			Lang.misc[92] = "卖出";
			Lang.misc[93] = "制造更多";
			Lang.misc[94] = "试图移除";
			Lang.misc[95] = "蜗牛";
			Lang.misc[96] = "看起来 ";
			Lang.misc[97] = " 开始举办派对";
			Lang.misc[98] = " 开始举办派对";
			Lang.misc[99] = "派对时间结束!";
			Lang.misc[100] = "选择世界邪恶种类";
			Lang.misc[101] = "腐化";
			Lang.misc[102] = "血腥";
			Lang.misc[103] = "随机";
			Lang.misc[104] = "没有艾特尼亚魔力时, 无法使用; 艾特尼亚水晶被保卫后, 方可使用";

			Lang.mp[0] = "接收:";
			Lang.mp[1] = "密码不正确.";
			Lang.mp[2] = "操作在当前状态下无效.";
			Lang.mp[3] = "你被封禁, 无法进入本服务器.";
			Lang.mp[4] = "游戏版本与服务器不符.";
			Lang.mp[5] = "已经在服务器上.";
			Lang.mp[6] = "/playing";
			Lang.mp[7] = "当前玩家:";
			Lang.mp[8] = "/roll";
			Lang.mp[9] = "rolls a";
			Lang.mp[10] = "你没有在队伍中!";
			Lang.mp[11] = "开启了 PvP 模式!";
			Lang.mp[12] = "关闭了 PvP 模式!";
			Lang.mp[13] = "退出了队伍.";
			Lang.mp[14] = "加入了红队.";
			Lang.mp[15] = "加入了绿队.";
			Lang.mp[16] = "加入了蓝队.";
			Lang.mp[17] = "加入了黄队.";
			Lang.mp[18] = "欢迎来到";
			Lang.mp[19] = "加入游戏.";
			Lang.mp[20] = "离开游戏.";
			Lang.mp[21] = "/players";
			Lang.mp[22] = "加入了粉队.";

			Lang.prefix[1] = "大号";
			Lang.prefix[2] = "巨大";
			Lang.prefix[3] = "危险";
			Lang.prefix[4] = "狂野";
			Lang.prefix[5] = "锋利";
			Lang.prefix[6] = "尖锐";
			Lang.prefix[7] = "微小";
			Lang.prefix[8] = "糟糕";
			Lang.prefix[9] = "小号";
			Lang.prefix[10] = "平庸";
			Lang.prefix[11] = "悲哀";
			Lang.prefix[12] = "笨重";
			Lang.prefix[13] = "猥琐";
			Lang.prefix[14] = "重型";
			Lang.prefix[15] = "轻型";
			Lang.prefix[16] = "视野";
			Lang.prefix[17] = "迅捷";
			Lang.prefix[18] = "急速";
			Lang.prefix[19] = "威慑";
			Lang.prefix[20] = "致命";
			Lang.prefix[21] = "坚硬";
			Lang.prefix[22] = "可怕";
			Lang.prefix[23] = "昏沉";
			Lang.prefix[24] = "笨拙";
			Lang.prefix[25] = "强力";
			Lang.prefix[58] = "狂乱";
			Lang.prefix[26] = "神秘";
			Lang.prefix[27] = "顺手";
			Lang.prefix[28] = "熟练";
			Lang.prefix[29] = "无能";
			Lang.prefix[30] = "愚昧";
			Lang.prefix[31] = "着魔";
			Lang.prefix[32] = "热烈";
			Lang.prefix[33] = "禁忌";
			Lang.prefix[34] = "精妙";
			Lang.prefix[35] = "暴怒";
			Lang.prefix[52] = "狂躁";
			Lang.prefix[36] = "敏锐";
			Lang.prefix[37] = "优良";
			Lang.prefix[38] = "有力";
			Lang.prefix[53] = "伤害";
			Lang.prefix[54] = "强壮";
			Lang.prefix[55] = "讨厌";
			Lang.prefix[39] = "坏掉";
			Lang.prefix[40] = "损坏";
			Lang.prefix[56] = "弱小";
			Lang.prefix[41] = "仿冒";
			Lang.prefix[57] = "无情";
			Lang.prefix[42] = "快速";
			Lang.prefix[43] = "致死";
			Lang.prefix[44] = "敏捷";
			Lang.prefix[45] = "迅捷";
			Lang.prefix[46] = "杀意";
			Lang.prefix[47] = "缓慢";
			Lang.prefix[48] = "迟缓";
			Lang.prefix[49] = "慵懒";
			Lang.prefix[50] = "讨厌";
			Lang.prefix[51] = "污秽";
			Lang.prefix[59] = "超神";
			Lang.prefix[60] = "恶魔";
			Lang.prefix[61] = "强击";
			Lang.prefix[62] = "坚硬";
			Lang.prefix[63] = "护卫";
			Lang.prefix[64] = "装甲";
			Lang.prefix[65] = "守御";
			Lang.prefix[66] = "奥术";
			Lang.prefix[67] = "精确";
			Lang.prefix[68] = "幸运";
			Lang.prefix[69] = "铁血";
			Lang.prefix[70] = "尖刺";
			Lang.prefix[71] = "愤怒";
			Lang.prefix[72] = "险恶";
			Lang.prefix[73] = "活跃";
			Lang.prefix[74] = "急速";
			Lang.prefix[75] = "草率";
			Lang.prefix[76] = "快速";
			Lang.prefix[77] = "野蛮";
			Lang.prefix[78] = "鲁莽";
			Lang.prefix[79] = "勇敢";
			Lang.prefix[80] = "暴力";
			Lang.prefix[81] = "传说";
			Lang.prefix[82] = "虚幻";
			Lang.prefix[83] = "神话";

			Lang.tip[0] = "装备在饰品槽";
			Lang.tip[1] = "不会获得任何属性";
			Lang.tip[2] = " 近战伤害";
			Lang.tip[3] = " 远程伤害";
			Lang.tip[4] = " 魔法伤害";
			Lang.tip[5] = "% 暴击率";
			Lang.tip[6] = "疯狂的攻击速度";
			Lang.tip[7] = "极快的攻击速度";
			Lang.tip[8] = "快速的攻击速度";
			Lang.tip[9] = "普通的攻击速度";
			Lang.tip[10] = "缓慢的攻击速度";
			Lang.tip[11] = "很慢的攻击速度";
			Lang.tip[12] = "极慢的攻击速度";
			Lang.tip[13] = "蜗牛般的攻击速度";
			Lang.tip[14] = "无击退";
			Lang.tip[15] = "极弱的击退";
			Lang.tip[16] = "很弱的击退";
			Lang.tip[17] = "较弱的击退";
			Lang.tip[18] = "一般的击退";
			Lang.tip[19] = "强力的击退";
			Lang.tip[20] = "很强的击退";
			Lang.tip[21] = "极强的击退";
			Lang.tip[22] = "疯狂的击退";
			Lang.tip[23] = "可装备";
			Lang.tip[24] = "时装";
			Lang.tip[25] = " 防御";
			Lang.tip[26] = "% 挖掘力量";
			Lang.tip[27] = "% 砍伐力量";
			Lang.tip[28] = "% 锤击力量";
			Lang.tip[29] = "恢复";
			Lang.tip[30] = "生命";
			Lang.tip[31] = "魔法";
			Lang.tip[32] = "使用";
			Lang.tip[33] = "可放置";
			Lang.tip[34] = "弹药";
			Lang.tip[35] = "消耗品";
			Lang.tip[36] = "材料";
			Lang.tip[37] = " 分钟持续时间";
			Lang.tip[38] = " 秒持续时间";
			Lang.tip[39] = "% 伤害";
			Lang.tip[40] = "%速度";
			Lang.tip[41] = "% 暴击率";
			Lang.tip[42] = "% 魔法消耗";
			Lang.tip[43] = "% 尺寸";
			Lang.tip[44] = "% 速率";
			Lang.tip[45] = "% 击退";
			Lang.tip[46] = "% 移动速度";
			Lang.tip[47] = "% 近战速度";
			Lang.tip[48] = "套装加成:";
			Lang.tip[49] = "出售价格:";
			Lang.tip[50] = "购买价格:";
			Lang.tip[51] = "无价值";
			Lang.tip[52] = "消耗 ";
			Lang.tip[53] = " 召唤伤害";
			Lang.tip[54] = " 范围";
			Lang.tip[55] = " 伤害";
			Lang.tip[56] = "标记为喜爱";
			Lang.tip[57] = "快速删除，堆叠和出售会被锁定";
			Lang.tip[58] = " 投掷伤害";
			Lang.tip[59] = "它被一个强大的丛林生物诅咒了";

			Main.buffName[1] = "黑曜石皮肤";
			Main.buffName[2] = "再生";
			Main.buffName[3] = "迅捷";
			Main.buffName[4] = "鱼鳃";
			Main.buffName[5] = "铁皮";
			Main.buffName[6] = "法力再生";
			Main.buffName[7] = "魔力强化";
			Main.buffName[8] = "羽落";
			Main.buffName[9] = "探索者";
			Main.buffName[10] = "隐身";
			Main.buffName[11] = "闪光";
			Main.buffName[12] = "猫头鹰";
			Main.buffName[13] = "战斗吧";
			Main.buffName[14] = "荆刺";
			Main.buffName[15] = "水上行走";
			Main.buffName[16] = "箭术精通";
			Main.buffName[17] = "猎人";
			Main.buffName[18] = "重力";
			Main.buffName[19] = "光球";
			Main.buffName[20] = "中毒";
			Main.buffName[21] = "抗药性";
			Main.buffName[22] = "黑暗";
			Main.buffName[23] = "诅咒";
			Main.buffName[24] = "着火了！";
			Main.buffName[25] = "酒劲";
			Main.buffName[26] = "吃饱喝足";
			Main.buffName[27] = "精灵";
			Main.buffName[28] = "狼人";
			Main.buffName[29] = "智慧";
			Main.buffName[30] = "流血";
			Main.buffName[31] = "迷乱";
			Main.buffName[32] = "缓速";
			Main.buffName[33] = "虚弱";
			Main.buffName[34] = "人鱼";
			Main.buffName[35] = "沉默";
			Main.buffName[36] = "破甲";
			Main.buffName[37] = "威慑";
			Main.buffName[38] = "舌";
			Main.buffName[39] = "诅咒之炎";
			Main.buffName[40] = "宠物小兔";
			Main.buffName[41] = "小企鹅";
			Main.buffName[42] = "宠物海龟";
			Main.buffName[43] = "圣骑士之盾";
			Main.buffName[44] = "寒焰";
			Main.buffName[45] = "小噬魂";
			Main.buffName[46] = "寒冷";
			Main.buffName[47] = "冻结";
			Main.buffName[48] = "甜蜜";
			Main.buffName[49] = "俾格米首领";
			Main.buffName[50] = "小骷髅头";
			Main.buffName[51] = "小黄蜂";
			Main.buffName[52] = "提基之灵";
			Main.buffName[53] = "宠物蜥蜴";
			Main.buffName[54] = "宠物鹦鹉";
			Main.buffName[55] = "小蘑菇";
			Main.buffName[56] = "宠物树苗";
			Main.buffName[57] = "小精灵";
			Main.buffName[58] = "快速治疗";
			Main.buffName[59] = "影分身";
			Main.buffName[60] = "叶绿水晶";
			Main.buffName[61] = "小恐龙";
			Main.buffName[62] = "冰霜护盾";
			Main.buffName[63] = "恐慌";
			Main.buffName[64] = "小史莱姆";
			Main.buffName[65] = "弹簧眼球";
			Main.buffName[66] = "小雪人";
			Main.buffName[67] = "燃烧";
			Main.buffName[68] = "窒息";
			Main.buffName[69] = "脓水腐蚀";
			Main.buffName[70] = "毒液";
			Main.buffName[72] = "点金术";
			Main.buffName[80] = "致盲";
			Main.buffName[81] = "宠物蜘蛛";
			Main.buffName[82] = "南瓜";
			Main.buffName[83] = "黑鸦";
			Main.buffName[84] = "黑猫";
			Main.buffName[85] = "诅咒树苗";
			Main.buffName[86] = "水蜡烛";
			Main.buffName[157] = "和平蜡烛";
			Main.buffName[87] = "篝火";
			Main.buffName[88] = "混沌";
			Main.buffName[89] = "心形吊灯";
			Main.buffName[90] = "鲁道夫";
			Main.buffName[91] = "狗狗";
			Main.buffName[92] = "小圣诞怪杰";
			Main.buffName[93] = "弹药箱";
			Main.buffName[94] = "法力病";
			Main.buffName[95] = "耐力甲虫";
			Main.buffName[96] = "耐力甲虫";
			Main.buffName[97] = "耐力甲虫";
			Main.buffName[98] = "力量甲虫";
			Main.buffName[99] = "力量甲虫";
			Main.buffName[100] = "力量甲虫";
			Main.buffName[101] = "仙女";
			Main.buffName[102] = "仙女";
			Main.buffName[103] = "潮湿";
			Main.buffName[104] = "矿工之力";
			Main.buffName[105] = "心灵链接";
			Main.buffName[106] = "心如止水";
			Main.buffName[107] = "建筑党";
			Main.buffName[108] = "泰坦之力";
			Main.buffName[109] = "脚蹼";
			Main.buffName[110] = "召唤增幅";
			Main.buffName[111] = "危机感知";
			Main.buffName[112] = "弹药狂人";
			Main.buffName[113] = "生命之力";
			Main.buffName[114] = "坚韧不拔";
			Main.buffName[115] = "狂暴";
			Main.buffName[116] = "熔岩领域";
			Main.buffName[117] = "怒火中烧";
			Main.buffName[118] = "矿车";
			Main.buffName[138] = "矿车";
			Main.buffName[119] = "爱情冲击";
			Main.buffName[120] = "恶臭";
			Main.buffName[121] = "钓技";
			Main.buffName[122] = "声呐";
			Main.buffName[123] = "板条箱";
			Main.buffName[124] = "温暖";
			Main.buffName[125] = "蜜蜂";
			Main.buffName[126] = "魔精";
			Main.buffName[127] = "微风鱼";
			Main.buffName[128] = "兔子坐骑";
			Main.buffName[129] = "猪龙坐骑";
			Main.buffName[130] = "史莱姆坐骑";
			Main.buffName[131] = "乌龟坐骑";
			Main.buffName[132] = "蜜蜂坐骑";
			Main.buffName[133] = "蜘蛛";
			Main.buffName[134] = "双子魔眼";
			Main.buffName[135] = "海盗";
			Main.buffName[136] = "迷你牛头人";
			Main.buffName[137] = "黏糊";
			Main.buffName[139] = "鲨龙卷";
			Main.buffName[140] = "UFO";
			Main.buffName[141] = "幽浮坐骑";
			Main.buffName[142] = "挖掘机";
			Main.buffName[143] = "火星蛞蝓";
			Main.buffName[144] = "触电";
			Main.buffName[145] = "月之咬伤";
			Main.buffName[146] = "开心!";
			Main.buffName[147] = "旗帜";
			Main.buffName[148] = "荒咬";
			Main.buffName[149] = "缠住";
			Main.buffName[150] = "迷人";
			Main.buffName[151] = "吸血";
			Main.buffName[152] = "魔力灯笼";
			Main.buffName[153] = "暗影火焰";
			Main.buffName[155] = "血腥之心";
			Main.buffName[154] = "大脸怪幼体";
			Main.buffName[169] = "被刺穿";
			Main.buffName[182] = "星辰细胞";
			Main.buffName[183] = "细胞吞噬";
			Main.buffName[186] = "树妖的驱逐";
			Main.buffName[187] = "星辰护卫";
			Main.buffName[188] = "星辰龙";
			Main.buffName[189] = "破晓";
			Main.buffName[190] = "可疑的眼球";
			Main.buffName[191] = "伙伴方块";
			Main.buffName[200] = "螺旋猫";
			Main.buffName[201] = "摇曳烛芯";
			Main.buffName[202] = "霍尔龙";
			Main.buffName[203] = "贝特西的诅咒";
			Main.buffName[204] = "浸油";
			Main.buffName[156] = "石化";
			Main.buffName[158] = "瓶中星";
			Main.buffName[159] = "磨锐";
			Main.buffName[160] = "迷乱";
			Main.buffName[161] = "致命球体";
			Main.buffName[163] = "被蒙眼";
			Main.buffName[164] = "扭曲";
			Main.buffName[165] = "树妖的庇护";
			Main.buffName[194] = "强风";
			Main.buffName[195] = "朽甲";
			Main.buffName[196] = "钝刃";
			Main.buffName[197] = "融化";
			Main.buffName[198] = "就是现在！";
			Main.buffName[205] = "弩车危机!";
			Main.buffName[166] = "矿车";
			Main.buffName[167] = "矿车";
			Main.buffName[185] = "矿车";
			Main.buffName[184] = "矿车";
			Main.buffName[170] = "日曜";
			Main.buffName[171] = "日曜";
			Main.buffName[172] = "日曜";
			Main.buffName[179] = "伤害星云";
			Main.buffName[180] = "伤害星云";
			Main.buffName[181] = "伤害星云";
			Main.buffName[173] = "生命星云";
			Main.buffName[174] = "生命星云";
			Main.buffName[175] = "生命星云";
			Main.buffName[176] = "魔力星云";
			Main.buffName[177] = "魔力星云";
			Main.buffName[178] = "魔力星云";
			Main.buffName[162] = "独角兽坐骑";
			Main.buffName[168] = "可爱猪鲨坐骑";
			Main.buffName[193] = "毒蜥坐骑";
			Main.buffName[199] = "创造受阻";
			Main.buffName[71] = "武器附魔：毒液";
			Main.buffName[73] = "武器附魔：咒火";
			Main.buffName[74] = "武器附魔：火焰";
			Main.buffName[75] = "武器附魔：黄金";
			Main.buffName[76] = "武器附魔：脓水";
			Main.buffName[77] = "武器附魔：纳米机器人";
			Main.buffName[78] = "武器附魔：彩纸";
			Main.buffName[79] = "武器附魔：毒药";

			Main.buffTip[1] = "免疫熔岩烫伤";
			Main.buffTip[2] = "加强生命回复";
			Main.buffTip[3] = "增加25%移动速度";
			Main.buffTip[4] = "在水中呼吸";
			Main.buffTip[5] = "增加8点防御";
			Main.buffTip[6] = "加速法力回复";
			Main.buffTip[7] = "增加20%魔法伤害";
			Main.buffTip[8] = "按“上”键或“下”键来控制下降速度";
			Main.buffTip[9] = "显示的宝藏和矿石的位置";
			Main.buffTip[10] = "别人看不到你了";
			Main.buffTip[11] = "自身发出亮光";
			Main.buffTip[12] = "强化夜视能力";
			Main.buffTip[13] = "增加怪物刷新的速率";
			Main.buffTip[14] = "反弹伤害";
			Main.buffTip[15] = "按“下”键进入水下";
			Main.buffTip[16] = "增加20%的弓箭伤害和速度";
			Main.buffTip[17] = "显示怪物的位置";
			Main.buffTip[18] = "按“上”键来转换重力的方向";
			Main.buffTip[19] = "一个发出微光的魔法小球";
			Main.buffTip[20] = "逐渐失去生命值";
			Main.buffTip[21] = "不能使用恢复生命类的药剂";
			Main.buffTip[22] = "好黑好黑！";
			Main.buffTip[23] = "不能使用任何物品";
			Main.buffTip[24] = "缓慢失去生命值";
			Main.buffTip[25] = "增加近战能力，降低防御";
			Main.buffTip[26] = "全部能力都稍微提升了";
			Main.buffTip[27] = "召唤一个小精灵跟着你";
			Main.buffTip[28] = "身体能力提升了";
			Main.buffTip[29] = "魔法能力提升了";
			Main.buffTip[30] = "停止了生命再生";
			Main.buffTip[31] = "倒转了方向感";
			Main.buffTip[32] = "移动速度降低了";
			Main.buffTip[33] = "身体能力降低了";
			Main.buffTip[34] = "在水下自由行动";
			Main.buffTip[35] = "不能使用魔法物品";
			Main.buffTip[36] = "防御减半";
			Main.buffTip[37] = "你看到了污浊之物，不能逃脱.";
			Main.buffTip[38] = "你被吞进了嘴里";
			Main.buffTip[39] = "失去生命";
			Main.buffTip[40] = "它像是想吃你手上的胡萝卜？";
			Main.buffTip[41] = "我认为它想吃掉这条鱼";
			Main.buffTip[42] = "快乐的小海龟!";
			Main.buffTip[43] = "为队友吸收25%伤害";
			Main.buffTip[44] = "你也不知道它是热还是冷，反正就是疼";
			Main.buffTip[45] = "噬魂与你同在";
			Main.buffTip[46] = "你的移动速度已经降低";
			Main.buffTip[47] = "冻住！不许走！";
			Main.buffTip[48] = "生命回复速度提升";
			Main.buffTip[49] = "俾格米人会为你而战";
			Main.buffTip[50] = "啥都别问...";
			Main.buffTip[51] = "它把你当妈了";
			Main.buffTip[52] = "友好地跟着你";
			Main.buffTip[53] = "它在慢慢爬...";
			Main.buffTip[54] = "波莉想要饼干";
			Main.buffTip[55] = "这货不也是蛮可爱的嘛？";
			Main.buffTip[56] = "不要把它种下地";
			Main.buffTip[57] = "它随着你飘动";
			Main.buffTip[58] = "生命回复速度大大增加";
			Main.buffTip[59] = "你能闪避下次攻击";
			Main.buffTip[60] = "它会射出水晶叶子攻击敌人";
			Main.buffTip[61] = "它想吃掉里面的蚊子";
			Main.buffTip[62] = "防御增加30";
			Main.buffTip[63] = "移动速度加快";
			Main.buffTip[64] = "其实是团子";
			Main.buffTip[65] = "蹦蹦跳跳地移动";
			Main.buffTip[66] = "自带雪橇";
			Main.buffTip[67] = "失去生命并减慢速度";
			Main.buffTip[68] = "失去生命";
			Main.buffTip[69] = "减少防御";
			Main.buffTip[70] = "失去生命";
			Main.buffTip[72] = "击杀目标会得到更多钱";
			Main.buffTip[80] = "世界都变暗了";
			Main.buffTip[81] = "爬墙结网";
			Main.buffTip[82] = "这南瓜会动啊";
			Main.buffTip[83] = "有只乌鸦为你战斗";
			Main.buffTip[84] = "果然还是黑喵最萌了";
			Main.buffTip[85] = "它会告诉你什么叫圆周运动";
			Main.buffTip[86] = "增加怪物刷新率";
			Main.buffTip[157] = "减少怪物刷新率";
			Main.buffTip[87] = "略微增加生命回复速度";
			Main.buffTip[88] = "继续使用传送法杖将造成伤害";
			Main.buffTip[89] = "增加生命回复速度";
			Main.buffTip[90] = "骑着红鼻子的驯鹿";
			Main.buffTip[91] = "粘着你的狗狗";
			Main.buffTip[92] = "粘着你的小圣诞怪杰";
			Main.buffTip[93] = "20%的机会不消耗弹药";
			Main.buffTip[94] = "魔法伤害减少 ";
			Main.buffTip[95] = "减少15%的伤害";
			Main.buffTip[96] = "减少30%的伤害";
			Main.buffTip[97] = "减少45%的伤害";
			Main.buffTip[98] = "增加10%的近战伤害和攻速";
			Main.buffTip[99] = "增加20%的近战伤害和攻速";
			Main.buffTip[100] = "增加30%的近战伤害和攻速";
			Main.buffTip[101] = "精灵跟随你";
			Main.buffTip[102] = "精灵跟随你";
			Main.buffTip[103] = "你掉进水里了！";
			Main.buffTip[104] = "提升25%的挖掘速度";
			Main.buffTip[105] = "提升红心的拾取范围";
			Main.buffTip[106] = "减少怪物出现的几率";
			Main.buffTip[107] = "增加物块放置速度及距离";
			Main.buffTip[108] = "增加你的击退";
			Main.buffTip[109] = "获得在水里游泳的能力";
			Main.buffTip[110] = "增加你的最大召唤数量";
			Main.buffTip[111] = "你将能感知到附近的危险";
			Main.buffTip[112] = "减少20%的子弹消耗";
			Main.buffTip[113] = "提升你20%的生命上限";
			Main.buffTip[114] = "减少10%受到的伤害";
			Main.buffTip[115] = "提升10%的暴击率";
			Main.buffTip[116] = "附近的敌人将被你点燃";
			Main.buffTip[117] = "提升你10%的所有伤害";
			Main.buffTip[118] = "坐在矿车上";
			Main.buffTip[138] = "坐在矿车上";
			Main.buffTip[119] = "你被浓浓的爱意包围了！";
			Main.buffTip[120] = "你闻起来真臭";
			Main.buffTip[121] = "提升你15%的钓鱼能力";
			Main.buffTip[122] = "你可以看到你钓到了什么";
			Main.buffTip[123] = "大幅度提升钓到板条箱的概率";
			Main.buffTip[124] = "减少寒冷伤害";
			Main.buffTip[125] = "蜜蜂将为你而战";
			Main.buffTip[126] = "魔精将为你而战";
			Main.buffTip[127] = "它喜欢在你周围游泳";
			Main.buffTip[128] = "你正拿着胡萝卜呐.....";
			Main.buffTip[129] = "现在看我的....";
			Main.buffTip[130] = "弹起来吧！";
			Main.buffTip[131] = "在岸上缓慢爬行，在海里飞速前进";
			Main.buffTip[132] = "嗡嗡嗡";
			Main.buffTip[133] = "蜘蛛将为你而战";
			Main.buffTip[134] = "双子魔眼将为你而战";
			Main.buffTip[135] = "海盗将为你而战";
			Main.buffTip[136] = "你是怎么折服这只小牛头人的？";
			Main.buffTip[137] = "身上不停滴落粘液";
			Main.buffTip[139] = "鲨龙卷将为你而战";
			Main.buffTip[140] = "UFO将为你而战";
			Main.buffTip[141] = "有一台UFO真是太棒了！";
			Main.buffTip[142] = "坐在飞行的挖掘机上";
			Main.buffTip[143] = "发射激光 Biu Biu Biu!";
			Main.buffTip[144] = "无法移动";
			Main.buffTip[145] = "无法使用吸血效果";
			Main.buffTip[146] = "增加移动速度，降低怪物刷新率";
			Main.buffTip[147] = "跟下列怪物战斗会增加攻击和防御：";
			Main.buffTip[148] = "增加伤害，减少生命恢复速度，引起异常状态";
			Main.buffTip[149] = "你被粘住了";
			Main.buffTip[150] = "增加1召唤物上限";
			Main.buffTip[151] = "增加生命回复速度";
			Main.buffTip[152] = "具有魔力的灯笼将照亮你的前路";
			Main.buffTip[153] = "逐渐失去生命";
			Main.buffTip[155] = "具有魔力的心脏，能够提供光芒";
			Main.buffTip[154] = "巨脸怪幼体跟随着你";
			Main.buffTip[169] = "血流不止";
			Main.buffTip[182] = "星辰细胞将为你而战";
			Main.buffTip[183] = "逐渐被细胞蚕食";
			Main.buffTip[186] = "自然之力庇佑你";
			Main.buffTip[187] = "星辰守护者将保护你";
			Main.buffTip[188] = "星辰巨龙将保护你";
			Main.buffTip[189] = "被太阳射线焚烧殆尽";
			Main.buffTip[190] = "一个可疑的眼球，能够提供光芒";
			Main.buffTip[191] = "它绝对不会刺你（才怪），也不会说话";
			Main.buffTip[200] = "螺旋猫跟随着你";
			Main.buffTip[201] = "摇曳烛芯跟随着你";
			Main.buffTip[202] = "霍尔龙跟随着你";
			Main.buffTip[203] = "防御降低了";
			Main.buffTip[204] = "着火的时候承受更多伤害";
			Main.buffTip[156] = "你完全被吓傻了！";
			Main.buffTip[158] = "增加魔力恢复速度";
			Main.buffTip[159] = "近战武器拥有破甲效果";
			Main.buffTip[160] = "移动速度大大降低";
			Main.buffTip[161] = "致命球体将为你而战";
			Main.buffTip[163] = "你看不见了！";
			Main.buffTip[164] = "你周围的重力被扭曲";
			Main.buffTip[165] = "自然之力庇佑你";
			Main.buffTip[194] = "狂风在你身边呼啸！";
			Main.buffTip[195] = "你的护甲破损了！";
			Main.buffTip[196] = "你的攻击减弱了！";
			Main.buffTip[197] = "移动速度明显降低";
			Main.buffTip[198] = "下一次近战攻击增加500%威力";
			Main.buffTip[205] = "你的弩车正因为恐慌而在快速射击";
			Main.buffTip[166] = "坐在矿车上";
			Main.buffTip[167] = "坐在矿车上";
			Main.buffTip[185] = "坐在矿车上";
			Main.buffTip[184] = "坐在矿车上";
			Main.buffTip[170] = "减少30%受到的伤害，在受到伤害时击退敌人";
			Main.buffTip[171] = "减少30%受到的伤害，在受到伤害时击退敌人";
			Main.buffTip[172] = "减少30%受到的伤害，在受到伤害时击退敌人";
			Main.buffTip[179] = "提升15%伤害";
			Main.buffTip[180] = "提升30%伤害";
			Main.buffTip[181] = "提升45%伤害";
			Main.buffTip[173] = "增加生命恢复速度";
			Main.buffTip[174] = "增加生命恢复速度";
			Main.buffTip[175] = "增加生命恢复速度";
			Main.buffTip[176] = "增加魔力恢复速度";
			Main.buffTip[177] = "增加魔力恢复速度";
			Main.buffTip[178] = "增加魔力恢复速度";
			Main.buffTip[162] = "冲过去...干得漂亮！";
			Main.buffTip[168] = "只要别让它在地上爬就行.";
			Main.buffTip[193] = "撞飞所有挡路者...所有！";
			Main.buffTip[199] = "你失去了创造的能力！";
			Main.buffTip[71] = "近战攻击能使敌人中毒";
			Main.buffTip[73] = "近战攻击能使敌人带上咒火";
			Main.buffTip[74] = "近战攻击能使敌人着火";
			Main.buffTip[75] = "近战攻击获得更多金币";
			Main.buffTip[76] = "近战攻击能减少敌人防御";
			Main.buffTip[77] = "近战攻击能使敌人混乱";
			Main.buffTip[78] = "近战攻击会带出各色彩纸";
			Main.buffTip[79] = "近战攻击能使敌人中毒";


			Lang.prefix[1] = "大号";
			Lang.prefix[2] = "巨大";
			Lang.prefix[3] = "危险";
			Lang.prefix[4] = "狂野";
			Lang.prefix[5] = "锋利";
			Lang.prefix[6] = "尖锐";
			Lang.prefix[7] = "微小";
			Lang.prefix[8] = "糟糕";
			Lang.prefix[9] = "小号";
			Lang.prefix[10] = "平庸";
			Lang.prefix[11] = "悲哀";
			Lang.prefix[12] = "笨重";
			Lang.prefix[13] = "猥琐";
			Lang.prefix[14] = "重型";
			Lang.prefix[15] = "轻型";
			Lang.prefix[16] = "视野";
			Lang.prefix[17] = "迅捷";
			Lang.prefix[18] = "急速";
			Lang.prefix[19] = "威慑";
			Lang.prefix[20] = "致命";
			Lang.prefix[21] = "坚硬";
			Lang.prefix[22] = "可怕";
			Lang.prefix[23] = "昏沉";
			Lang.prefix[24] = "笨拙";
			Lang.prefix[25] = "强力";
			Lang.prefix[58] = "狂乱";
			Lang.prefix[26] = "神秘";
			Lang.prefix[27] = "顺手";
			Lang.prefix[28] = "熟练";
			Lang.prefix[29] = "无能";
			Lang.prefix[30] = "愚昧";
			Lang.prefix[31] = "着魔";
			Lang.prefix[32] = "热烈";
			Lang.prefix[33] = "禁忌";
			Lang.prefix[34] = "精妙";
			Lang.prefix[35] = "暴怒";
			Lang.prefix[52] = "狂躁";
			Lang.prefix[36] = "敏锐";
			Lang.prefix[37] = "优良";
			Lang.prefix[38] = "有力";
			Lang.prefix[53] = "伤害";
			Lang.prefix[54] = "强壮";
			Lang.prefix[55] = "讨厌";
			Lang.prefix[39] = "坏掉";
			Lang.prefix[40] = "损坏";
			Lang.prefix[56] = "弱小";
			Lang.prefix[41] = "仿冒";
			Lang.prefix[57] = "无情";
			Lang.prefix[42] = "快速";
			Lang.prefix[43] = "致死";
			Lang.prefix[44] = "敏捷";
			Lang.prefix[45] = "迅捷";
			Lang.prefix[46] = "杀意";
			Lang.prefix[47] = "缓慢";
			Lang.prefix[48] = "迟缓";
			Lang.prefix[49] = "慵懒";
			Lang.prefix[50] = "讨厌";
			Lang.prefix[51] = "污秽";
			Lang.prefix[59] = "超神";
			Lang.prefix[60] = "恶魔";
			Lang.prefix[61] = "强击";
			Lang.prefix[62] = "坚硬";
			Lang.prefix[63] = "护卫";
			Lang.prefix[64] = "装甲";
			Lang.prefix[65] = "守御";
			Lang.prefix[66] = "奥术";
			Lang.prefix[67] = "精确";
			Lang.prefix[68] = "幸运";
			Lang.prefix[69] = "铁血";
			Lang.prefix[70] = "尖刺";
			Lang.prefix[71] = "愤怒";
			Lang.prefix[72] = "险恶";
			Lang.prefix[73] = "活跃";
			Lang.prefix[74] = "急速";
			Lang.prefix[75] = "草率";
			Lang.prefix[76] = "快速";
			Lang.prefix[77] = "野蛮";
			Lang.prefix[78] = "鲁莽";
			Lang.prefix[79] = "勇敢";
			Lang.prefix[80] = "暴力";
			Lang.prefix[81] = "传说";
			Lang.prefix[82] = "虚幻";
			Lang.prefix[83] = "神话";


			for (var index = 0; index < Main.maxItemTypes; index++)
				CnItemName[index] = ItemName(index); // 会引起商店不显示问题

			if (Main.netMode == 2)
				return;
#if !TML
			if (Lang.mapLegend == null)
				Lang.mapLegend = new string[MapHelper.LookupCount()];
#else
			if(Lang.mapLegend == null)
				Lang.mapLegend = new MapLegend(MapHelper.LookupCount());
#endif

			Lang.mapLegend[MapHelper.TileToLookup(4, 0)] = "火把";
			Lang.mapLegend[MapHelper.TileToLookup(4, 1)] = "火把";
			Lang.mapLegend[MapHelper.TileToLookup(5, 0)] = "树";
			Lang.mapLegend[MapHelper.TileToLookup(6, 0)] = "铁矿石";
			Lang.mapLegend[MapHelper.TileToLookup(7, 0)] = "铜矿石";
			Lang.mapLegend[MapHelper.TileToLookup(8, 0)] = "金矿石";
			Lang.mapLegend[MapHelper.TileToLookup(9, 0)] = "银矿石";
			Lang.mapLegend[MapHelper.TileToLookup(10, 0)] = "门";
			Lang.mapLegend[MapHelper.TileToLookup(11, 0)] = "门";
			Lang.mapLegend[MapHelper.TileToLookup(12, 0)] = "生命水晶";
			Lang.mapLegend[MapHelper.TileToLookup(13, 0)] = "瓶子";
			Lang.mapLegend[MapHelper.TileToLookup(14, 0)] = "桌子";
			Lang.mapLegend[MapHelper.TileToLookup(15, 0)] = "椅子";
			Lang.mapLegend[MapHelper.TileToLookup(16, 0)] = "铁砧";
			Lang.mapLegend[MapHelper.TileToLookup(17, 0)] = "熔炉";
			Lang.mapLegend[MapHelper.TileToLookup(18, 0)] = "工作台";
			Lang.mapLegend[MapHelper.TileToLookup(20, 0)] = "树苗";
			Lang.mapLegend[MapHelper.TileToLookup(21, 0)] = "箱子";
			Lang.mapLegend[MapHelper.TileToLookup(22, 0)] = "恶魔矿";
			Lang.mapLegend[MapHelper.TileToLookup(26, 0)] = "恶魔祭坛";
			Lang.mapLegend[MapHelper.TileToLookup(26, 1)] = "血腥祭坛";
			Lang.mapLegend[MapHelper.TileToLookup(27, 0)] = CnItemName[63];
			Lang.mapLegend[MapHelper.TileToLookup(407, 0)] = "化石";
			Lang.mapLegend[MapHelper.TileToLookup(412, 0)] = "远古操纵器";
			Lang.mapLegend[MapHelper.TileToLookup(441, 0)] = "箱子";
			for (int i = 0; i < 9; i++)
				Lang.mapLegend[MapHelper.TileToLookup(28, i)] = "罐子";
			Lang.mapLegend[MapHelper.TileToLookup(37, 0)] = "陨铁矿";
			Lang.mapLegend[MapHelper.TileToLookup(29, 0)] = CnItemName[87];
			Lang.mapLegend[MapHelper.TileToLookup(31, 0)] = "暗影之球";
			Lang.mapLegend[MapHelper.TileToLookup(31, 1)] = "血腥心脏";
			Lang.mapLegend[MapHelper.TileToLookup(32, 0)] = "荆棘";
			Lang.mapLegend[MapHelper.TileToLookup(33, 0)] = "蜡烛";
			Lang.mapLegend[MapHelper.TileToLookup(34, 0)] = "烛台";
			Lang.mapLegend[MapHelper.TileToLookup(35, 0)] = "杰克灯笼";
			Lang.mapLegend[MapHelper.TileToLookup(36, 0)] = "礼物";
			Lang.mapLegend[MapHelper.TileToLookup(42, 0)] = "灯笼";
			Lang.mapLegend[MapHelper.TileToLookup(48, 0)] = "尖刺";
			Lang.mapLegend[MapHelper.TileToLookup(49, 0)] = CnItemName[148];
			Lang.mapLegend[MapHelper.TileToLookup(50, 0)] = "书";
			Lang.mapLegend[MapHelper.TileToLookup(51, 0)] = "蛛网";
			Lang.mapLegend[MapHelper.TileToLookup(55, 0)] = "标志";
			Lang.mapLegend[MapHelper.TileToLookup(454, 0)] = CnItemName[3746];
			Lang.mapLegend[MapHelper.TileToLookup(455, 0)] = CnItemName[3747];
			Lang.mapLegend[MapHelper.TileToLookup(452, 0)] = CnItemName[3742];
			Lang.mapLegend[MapHelper.TileToLookup(456, 0)] = CnItemName[3748];
			Lang.mapLegend[MapHelper.TileToLookup(453, 0)] = CnItemName[3744];
			Lang.mapLegend[MapHelper.TileToLookup(453, 1)] = CnItemName[3745];
			Lang.mapLegend[MapHelper.TileToLookup(453, 2)] = CnItemName[3743];
			Lang.mapLegend[MapHelper.TileToLookup(63, 0)] = "蓝宝石";
			Lang.mapLegend[MapHelper.TileToLookup(64, 0)] = "红宝石";
			Lang.mapLegend[MapHelper.TileToLookup(65, 0)] = "祖母绿";
			Lang.mapLegend[MapHelper.TileToLookup(66, 0)] = "黄晶玉";
			Lang.mapLegend[MapHelper.TileToLookup(67, 0)] = "紫水晶";
			Lang.mapLegend[MapHelper.TileToLookup(68, 0)] = "钻石";
			Lang.mapLegend[MapHelper.TileToLookup(69, 0)] = "荆棘";
			Lang.mapLegend[MapHelper.TileToLookup(72, 0)] = "巨大蘑菇";
			Lang.mapLegend[MapHelper.TileToLookup(77, 0)] = "地狱熔炉";
			Lang.mapLegend[MapHelper.TileToLookup(78, 0)] = "陶罐";
			Lang.mapLegend[MapHelper.TileToLookup(79, 0)] = "床";
			Lang.mapLegend[MapHelper.TileToLookup(80, 0)] = "仙人掌";
			Lang.mapLegend[MapHelper.TileToLookup(81, 0)] = "珊瑚";
			Lang.mapLegend[MapHelper.TileToLookup(82, 0)] = CnItemName[313];
			Lang.mapLegend[MapHelper.TileToLookup(82, 1)] = CnItemName[314];
			Lang.mapLegend[MapHelper.TileToLookup(82, 2)] = CnItemName[315];
			Lang.mapLegend[MapHelper.TileToLookup(82, 3)] = CnItemName[316];
			Lang.mapLegend[MapHelper.TileToLookup(82, 4)] = CnItemName[317];
			Lang.mapLegend[MapHelper.TileToLookup(82, 5)] = CnItemName[318];
			Lang.mapLegend[MapHelper.TileToLookup(82, 6)] = CnItemName[2358];
			Lang.mapLegend[MapHelper.TileToLookup(83, 0)] = CnItemName[313];
			Lang.mapLegend[MapHelper.TileToLookup(83, 1)] = CnItemName[314];
			Lang.mapLegend[MapHelper.TileToLookup(83, 2)] = CnItemName[315];
			Lang.mapLegend[MapHelper.TileToLookup(83, 3)] = CnItemName[316];
			Lang.mapLegend[MapHelper.TileToLookup(83, 4)] = CnItemName[317];
			Lang.mapLegend[MapHelper.TileToLookup(83, 5)] = CnItemName[318];
			Lang.mapLegend[MapHelper.TileToLookup(83, 6)] = CnItemName[2358];
			Lang.mapLegend[MapHelper.TileToLookup(84, 0)] = CnItemName[313];
			Lang.mapLegend[MapHelper.TileToLookup(84, 1)] = CnItemName[314];
			Lang.mapLegend[MapHelper.TileToLookup(84, 2)] = CnItemName[315];
			Lang.mapLegend[MapHelper.TileToLookup(84, 3)] = CnItemName[316];
			Lang.mapLegend[MapHelper.TileToLookup(84, 4)] = CnItemName[317];
			Lang.mapLegend[MapHelper.TileToLookup(84, 5)] = CnItemName[318];
			Lang.mapLegend[MapHelper.TileToLookup(84, 6)] = CnItemName[2358];
			Lang.mapLegend[MapHelper.TileToLookup(85, 0)] = "墓碑";
			Lang.mapLegend[MapHelper.TileToLookup(86, 0)] = "织布机";
			Lang.mapLegend[MapHelper.TileToLookup(87, 0)] = "钢琴";
			Lang.mapLegend[MapHelper.TileToLookup(88, 0)] = "梳妆台";
			Lang.mapLegend[MapHelper.TileToLookup(89, 0)] = "长椅";
			Lang.mapLegend[MapHelper.TileToLookup(90, 0)] = "澡盆";
			Lang.mapLegend[MapHelper.TileToLookup(91, 0)] = "旗帜";
			Lang.mapLegend[MapHelper.TileToLookup(92, 0)] = "路灯";
			Lang.mapLegend[MapHelper.TileToLookup(93, 0)] = "落地灯";
			Lang.mapLegend[MapHelper.TileToLookup(94, 0)] = "酒杯";
			Lang.mapLegend[MapHelper.TileToLookup(95, 0)] = "中国灯笼";
			Lang.mapLegend[MapHelper.TileToLookup(96, 0)] = "烹饪锅";
			Lang.mapLegend[MapHelper.TileToLookup(97, 0)] = "保险柜";
			Lang.mapLegend[MapHelper.TileToLookup(98, 0)] = "颅骨灯笼";
			Lang.mapLegend[MapHelper.TileToLookup(100, 0)] = "烛台";
			Lang.mapLegend[MapHelper.TileToLookup(101, 0)] = "书柜";
			Lang.mapLegend[MapHelper.TileToLookup(102, 0)] = "王座";
			Lang.mapLegend[MapHelper.TileToLookup(103, 0)] = "碗";
			Lang.mapLegend[MapHelper.TileToLookup(104, 0)] = "落地钟";
			Lang.mapLegend[MapHelper.TileToLookup(105, 0)] = "雕像";
			Lang.mapLegend[MapHelper.TileToLookup(105, 2)] = "花瓶";
			Lang.mapLegend[MapHelper.TileToLookup(106, 0)] = "锯木台";
			Lang.mapLegend[MapHelper.TileToLookup(107, 0)] = "钴蓝矿";
			Lang.mapLegend[MapHelper.TileToLookup(108, 0)] = "秘银矿";
			Lang.mapLegend[MapHelper.TileToLookup(111, 0)] = "精金矿";
			Lang.mapLegend[MapHelper.TileToLookup(114, 0)] = "工匠作坊";
			Lang.mapLegend[MapHelper.TileToLookup(125, 0)] = "水晶球";
			Lang.mapLegend[MapHelper.TileToLookup(128, 0)] = "木质假人";
			Lang.mapLegend[MapHelper.TileToLookup(129, 0)] = "碎魔晶";
			Lang.mapLegend[MapHelper.TileToLookup(132, 0)] = "拉杆";
			Lang.mapLegend[MapHelper.TileToLookup(411, 0)] = "雷管";
			Lang.mapLegend[MapHelper.TileToLookup(133, 0)] = "精金熔炉";
			Lang.mapLegend[MapHelper.TileToLookup(133, 1)] = "钛金熔炉";
			Lang.mapLegend[MapHelper.TileToLookup(134, 0)] = "秘银砧";
			Lang.mapLegend[MapHelper.TileToLookup(134, 1)] = "山铜砧";
			Lang.mapLegend[MapHelper.TileToLookup(136, 0)] = "开关";
			Lang.mapLegend[MapHelper.TileToLookup(137, 0)] = "陷阱";
			Lang.mapLegend[MapHelper.TileToLookup(138, 0)] = "巨石";
			Lang.mapLegend[MapHelper.TileToLookup(139, 0)] = "音乐盒";
			Lang.mapLegend[MapHelper.TileToLookup(142, 0)] = "入水泵";
			Lang.mapLegend[MapHelper.TileToLookup(143, 0)] = "出水泵";
			Lang.mapLegend[MapHelper.TileToLookup(144, 0)] = "计时器";
			Lang.mapLegend[MapHelper.TileToLookup(149, 0)] = "圣诞节灯";
			Lang.mapLegend[MapHelper.TileToLookup(166, 0)] = "锡矿石";
			Lang.mapLegend[MapHelper.TileToLookup(167, 0)] = "铅矿石";
			Lang.mapLegend[MapHelper.TileToLookup(168, 0)] = "钨矿石";
			Lang.mapLegend[MapHelper.TileToLookup(169, 0)] = "铂金矿石";
			Lang.mapLegend[MapHelper.TileToLookup(170, 0)] = "松树";
			Lang.mapLegend[MapHelper.TileToLookup(171, 0)] = "圣诞树";
			Lang.mapLegend[MapHelper.TileToLookup(172, 0)] = "水槽";
			Lang.mapLegend[MapHelper.TileToLookup(173, 0)] = "烛台";
			Lang.mapLegend[MapHelper.TileToLookup(174, 0)] = "铂金蜡烛";
			Lang.mapLegend[MapHelper.TileToLookup(178, 0)] = CnItemName[181];
			Lang.mapLegend[MapHelper.TileToLookup(178, 1)] = CnItemName[180];
			Lang.mapLegend[MapHelper.TileToLookup(178, 2)] = CnItemName[177];
			Lang.mapLegend[MapHelper.TileToLookup(178, 3)] = CnItemName[179];
			Lang.mapLegend[MapHelper.TileToLookup(178, 4)] = CnItemName[178];
			Lang.mapLegend[MapHelper.TileToLookup(178, 5)] = CnItemName[182];
			Lang.mapLegend[MapHelper.TileToLookup(178, 6)] = CnItemName[999];
			Lang.mapLegend[MapHelper.TileToLookup(191, 0)] = "生命木";
			Lang.mapLegend[MapHelper.TileToLookup(204, 0)] = "血腥矿";
			Lang.mapLegend[MapHelper.TileToLookup(207, 0)] = "喷泉";
			Lang.mapLegend[MapHelper.TileToLookup(209, 0)] = "加农炮";
			Lang.mapLegend[MapHelper.TileToLookup(211, 0)] = "叶绿矿";
			Lang.mapLegend[MapHelper.TileToLookup(212, 0)] = "炮塔";
			Lang.mapLegend[MapHelper.TileToLookup(213, 0)] = "绳子";
			Lang.mapLegend[MapHelper.TileToLookup(214, 0)] = "链条";
			Lang.mapLegend[MapHelper.TileToLookup(215, 0)] = "篝火";
			Lang.mapLegend[MapHelper.TileToLookup(216, 0)] = "火箭";
			Lang.mapLegend[MapHelper.TileToLookup(217, 0)] = "自动搅拌机";
			Lang.mapLegend[MapHelper.TileToLookup(218, 0)] = "绞肉机";
			Lang.mapLegend[MapHelper.TileToLookup(219, 0)] = "精炼机";
			Lang.mapLegend[MapHelper.TileToLookup(220, 0)] = "凝固机";
			Lang.mapLegend[MapHelper.TileToLookup(221, 0)] = "钯金矿";
			Lang.mapLegend[MapHelper.TileToLookup(222, 0)] = "山铜矿";
			Lang.mapLegend[MapHelper.TileToLookup(223, 0)] = "钛金矿";
			Lang.mapLegend[MapHelper.TileToLookup(227, 0)] = CnItemName[1107];
			Lang.mapLegend[MapHelper.TileToLookup(227, 1)] = CnItemName[1108];
			Lang.mapLegend[MapHelper.TileToLookup(227, 2)] = CnItemName[1109];
			Lang.mapLegend[MapHelper.TileToLookup(227, 3)] = CnItemName[1110];
			Lang.mapLegend[MapHelper.TileToLookup(227, 4)] = CnItemName[1111];
			Lang.mapLegend[MapHelper.TileToLookup(227, 5)] = CnItemName[1112];
			Lang.mapLegend[MapHelper.TileToLookup(227, 6)] = CnItemName[1113];
			Lang.mapLegend[MapHelper.TileToLookup(227, 7)] = CnItemName[1114];
			Lang.mapLegend[MapHelper.TileToLookup(227, 8)] = CnItemName[3385];
			Lang.mapLegend[MapHelper.TileToLookup(227, 9)] = CnItemName[3386];
			Lang.mapLegend[MapHelper.TileToLookup(227, 10)] = CnItemName[3387];
			Lang.mapLegend[MapHelper.TileToLookup(227, 11)] = CnItemName[3388];
			Lang.mapLegend[MapHelper.TileToLookup(228, 0)] = "染缸";
			Lang.mapLegend[MapHelper.TileToLookup(231, 0)] = "蜂后幼虫";
			Lang.mapLegend[MapHelper.TileToLookup(232, 0)] = "木质尖刺";
			Lang.mapLegend[MapHelper.TileToLookup(235, 0)] = "传送器";
			Lang.mapLegend[MapHelper.TileToLookup(236, 0)] = "生命之果";
			Lang.mapLegend[MapHelper.TileToLookup(237, 0)] = "蜥蜴祭坛";
			Lang.mapLegend[MapHelper.TileToLookup(238, 0)] = "世纪之花的花苞";
			Lang.mapLegend[MapHelper.TileToLookup(239, 0)] = "金属锭";
			Lang.mapLegend[MapHelper.TileToLookup(240, 0)] = "荣耀之证";
			Lang.mapLegend[MapHelper.TileToLookup(240, 2)] = Main.npcName[21];
			Lang.mapLegend[MapHelper.TileToLookup(240, 3)] = "展示架";
			Lang.mapLegend[MapHelper.TileToLookup(240, 4)] = CnItemName[2442];
			Lang.mapLegend[MapHelper.TileToLookup(241, 0)] = CnItemName[1417];
			Lang.mapLegend[MapHelper.TileToLookup(242, 0)] = "画";
			Lang.mapLegend[MapHelper.TileToLookup(242, 1)] = "动物毛皮";
			Lang.mapLegend[MapHelper.TileToLookup(243, 0)] = "药水灌输器";
			Lang.mapLegend[MapHelper.TileToLookup(244, 0)] = "气泡机";
			Lang.mapLegend[MapHelper.TileToLookup(245, 0)] = "图片";
			Lang.mapLegend[MapHelper.TileToLookup(246, 0)] = "图片";
			Lang.mapLegend[MapHelper.TileToLookup(247, 0)] = "自动锻造机";
			Lang.mapLegend[MapHelper.TileToLookup(254, 0)] = "南瓜";
			Lang.mapLegend[MapHelper.TileToLookup(269, 0)] = "木质模型 (女)";
			Lang.mapLegend[MapHelper.TileToLookup(270, 0)] = "萤火虫瓶";
			Lang.mapLegend[MapHelper.TileToLookup(271, 0)] = "闪电萤火虫瓶";
			Lang.mapLegend[MapHelper.TileToLookup(275, 0)] = "兔子箱";
			Lang.mapLegend[MapHelper.TileToLookup(276, 0)] = "松鼠箱";
			Lang.mapLegend[MapHelper.TileToLookup(277, 0)] = "野鸭箱";
			Lang.mapLegend[MapHelper.TileToLookup(278, 0)] = "鸭子箱";
			Lang.mapLegend[MapHelper.TileToLookup(279, 0)] = "鸟箱";
			Lang.mapLegend[MapHelper.TileToLookup(280, 0)] = "蓝鸟箱";
			Lang.mapLegend[MapHelper.TileToLookup(281, 0)] = "红雀箱";
			Lang.mapLegend[MapHelper.TileToLookup(282, 0)] = "鱼缸";
			Lang.mapLegend[MapHelper.TileToLookup(413, 0)] = "橙色松树箱";
			Lang.mapLegend[MapHelper.TileToLookup(283, 0)] = "重装工作台";
			Lang.mapLegend[MapHelper.TileToLookup(285, 0)] = "蜗牛箱";
			Lang.mapLegend[MapHelper.TileToLookup(286, 0)] = "荧光蜗牛箱";
			Lang.mapLegend[MapHelper.TileToLookup(287, 0)] = "弹药箱";
			Lang.mapLegend[MapHelper.TileToLookup(288, 0)] = "帝王蝶罐";
			Lang.mapLegend[MapHelper.TileToLookup(289, 0)] = "紫色帝王蝶罐";
			Lang.mapLegend[MapHelper.TileToLookup(290, 0)] = "赤蛱蝶罐";
			Lang.mapLegend[MapHelper.TileToLookup(291, 0)] = "天堂凤蝶罐";
			Lang.mapLegend[MapHelper.TileToLookup(292, 0)] = "菜粉蝶罐";
			Lang.mapLegend[MapHelper.TileToLookup(293, 0)] = "树若虫蝴蝶罐";
			Lang.mapLegend[MapHelper.TileToLookup(294, 0)] = "斑马燕尾蝶罐";
			Lang.mapLegend[MapHelper.TileToLookup(295, 0)] = "茱莉亚蝶罐";
			Lang.mapLegend[MapHelper.TileToLookup(296, 0)] = "蝎箱";
			Lang.mapLegend[MapHelper.TileToLookup(297, 0)] = "黑蝎子箱";
			Lang.mapLegend[MapHelper.TileToLookup(298, 0)] = "青蛙箱";
			Lang.mapLegend[MapHelper.TileToLookup(299, 0)] = "老鼠箱";
			Lang.mapLegend[MapHelper.TileToLookup(300, 0)] = "骸骨焊接机";
			Lang.mapLegend[MapHelper.TileToLookup(301, 0)] = "血肉培养基";
			Lang.mapLegend[MapHelper.TileToLookup(302, 0)] = "玻璃窑";
			Lang.mapLegend[MapHelper.TileToLookup(303, 0)] = "蜥蜴熔炉";
			Lang.mapLegend[MapHelper.TileToLookup(304, 0)] = "生命木织布机";
			Lang.mapLegend[MapHelper.TileToLookup(305, 0)] = "锯云台";
			Lang.mapLegend[MapHelper.TileToLookup(306, 0)] = "刨冰机";
			Lang.mapLegend[MapHelper.TileToLookup(307, 0)] = "蒸汽朋克锅炉";
			Lang.mapLegend[MapHelper.TileToLookup(308, 0)] = "蜂蜜分选器";
			Lang.mapLegend[MapHelper.TileToLookup(309, 0)] = "企鹅箱";
			Lang.mapLegend[MapHelper.TileToLookup(310, 0)] = "蠕虫箱";
			Lang.mapLegend[MapHelper.TileToLookup(316, 0)] = "蓝色水母缸";
			Lang.mapLegend[MapHelper.TileToLookup(317, 0)] = "绿色水母缸";
			Lang.mapLegend[MapHelper.TileToLookup(318, 0)] = "粉色水母缸";
			Lang.mapLegend[MapHelper.TileToLookup(319, 0)] = "船模瓶子";
			Lang.mapLegend[MapHelper.TileToLookup(320, 0)] = "海草花坛";
			Lang.mapLegend[MapHelper.TileToLookup(323, 0)] = "棕榈树";
			Lang.mapLegend[MapHelper.TileToLookup(314, 0)] = "矿车轨道";
			Lang.mapLegend[MapHelper.TileToLookup(353, 0)] = "藤绳";
			Lang.mapLegend[MapHelper.TileToLookup(354, 0)] = "迷人的桌子";
			Lang.mapLegend[MapHelper.TileToLookup(355, 0)] = "炼金台";
			Lang.mapLegend[MapHelper.TileToLookup(356, 0)] = "魔法日晷";
			Lang.mapLegend[MapHelper.TileToLookup(365, 0)] = "丝质绳索";
			Lang.mapLegend[MapHelper.TileToLookup(366, 0)] = "蛛网绳索";
			Lang.mapLegend[MapHelper.TileToLookup(373, 0)] = "滴落的水";
			Lang.mapLegend[MapHelper.TileToLookup(374, 0)] = "滴落的岩浆";
			Lang.mapLegend[MapHelper.TileToLookup(375, 0)] = "滴落的蜂蜜";
			Lang.mapLegend[MapHelper.TileToLookup(461, 0)] = "流沙";
			Lang.mapLegend[MapHelper.TileToLookup(377, 0)] = "磨刀台";
			Lang.mapLegend[MapHelper.TileToLookup(372, 0)] = CnItemName[3117];
			Lang.mapLegend[MapHelper.TileToLookup(425, 0)] = "公告栏";
			Lang.mapLegend[MapHelper.TileToLookup(420, 0)] = CnItemName[3603];
			Lang.mapLegend[MapHelper.TileToLookup(420, 1)] = CnItemName[3604];
			Lang.mapLegend[MapHelper.TileToLookup(420, 2)] = CnItemName[3605];
			Lang.mapLegend[MapHelper.TileToLookup(420, 3)] = CnItemName[3606];
			Lang.mapLegend[MapHelper.TileToLookup(420, 4)] = CnItemName[3607];
			Lang.mapLegend[MapHelper.TileToLookup(420, 5)] = CnItemName[3608];
			Lang.mapLegend[MapHelper.TileToLookup(423, 0)] = CnItemName[3613];
			Lang.mapLegend[MapHelper.TileToLookup(423, 1)] = CnItemName[3614];
			Lang.mapLegend[MapHelper.TileToLookup(423, 2)] = CnItemName[3615];
			Lang.mapLegend[MapHelper.TileToLookup(423, 3)] = CnItemName[3726];
			Lang.mapLegend[MapHelper.TileToLookup(423, 4)] = CnItemName[3727];
			Lang.mapLegend[MapHelper.TileToLookup(423, 5)] = CnItemName[3728];
			Lang.mapLegend[MapHelper.TileToLookup(423, 6)] = CnItemName[3729];
			Lang.mapLegend[MapHelper.TileToLookup(440, 0)] = CnItemName[3644];
			Lang.mapLegend[MapHelper.TileToLookup(440, 1)] = CnItemName[3645];
			Lang.mapLegend[MapHelper.TileToLookup(440, 2)] = CnItemName[3646];
			Lang.mapLegend[MapHelper.TileToLookup(440, 3)] = CnItemName[3647];
			Lang.mapLegend[MapHelper.TileToLookup(440, 4)] = CnItemName[3648];
			Lang.mapLegend[MapHelper.TileToLookup(440, 5)] = CnItemName[3649];
			Lang.mapLegend[MapHelper.TileToLookup(440, 6)] = CnItemName[3650];
			Lang.mapLegend[MapHelper.TileToLookup(424, 0)] = CnItemName[3616];
			Lang.mapLegend[MapHelper.TileToLookup(444, 0)] = "蜂房";
			Lang.mapLegend[MapHelper.TileToLookup(466, 0)] = CnItemName[3816];
			Lang.mapLegend[MapHelper.TileToLookup(463, 0)] = CnItemName[3813];


			for (var j = 0; j < Lang.mapLegend.Length; j++)
				if (Lang.mapLegend[j] == null)
					Lang.mapLegend[j] = string.Empty;
		}
	}
}
