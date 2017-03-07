#if !OTAPI
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endif

namespace Miyuu.Cns
{
	public static class SpriteBatchCn
	{
#if !OTAPI
		public static readonly Vector2 MaxBound = new Vector2(float.MaxValue, float.MaxValue);

		public static void DrawString(this SpriteBatch sb, SpriteFontCn spriteFont, string text, Vector2 position, Color color)
		{
			spriteFont.Draw(sb, text, position, color);
		}

		public static void DrawString(this SpriteBatch sb, SpriteFontCn spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
		{
			spriteFont.Draw(sb, text, position - origin * scale, MaxBound, new Vector2(scale, scale), color);
		}

		public static void DrawString(this SpriteBatch sb, SpriteFontCn spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
		{
			spriteFont.Draw(sb, text, position - origin * scale, MaxBound, scale, color);
		}
#endif
	}
}
