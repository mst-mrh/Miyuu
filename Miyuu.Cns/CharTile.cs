using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Miyuu.Cns
{
	internal class CharTile
	{
		public CharTile(Texture2D t, Rectangle r)
		{
			Texture = t;
			Rectangle = r;
		}

		public readonly Texture2D Texture;

		public readonly Rectangle Rectangle;
	}
}
