using Microsoft.Xna.Framework.Graphics;
using System.Reflection;

namespace Terraria.TerraCustom
{
	class TerraCustomUtils
	{
		internal static Texture2D GetEmbeddedTexture2D(string name)
		{
			return Texture2D.FromStream(Main.instance.GraphicsDevice, Assembly.GetExecutingAssembly().GetManifestResourceStream(name));
		}
	}
}
