using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public void ReplaceTexts()
		{
			
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
