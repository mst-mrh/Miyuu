using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Miyuu.Cns
{
	public class SpriteFontCn
	{
		public Vector2 MeasureString(string str)
		{
			return Vector2.One;
		}

		public int LineSpacing => 15;
	}
}
