using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;
using Terraria.Graphics;
using Terraria.ModLoader.IO;
using Terraria.UI;
using System.Linq;

namespace Terraria.TerraCustom.UI
{
	internal class UISettingsItem : UIPanel
	{
		private Texture2D dividerTexture;
		private Texture2D innerPanelTexture;
		private UIText listName;
		UITextPanel<string> loadThisSettingButton;
		UITextPanel<string> deleteThisSettingButton;
		internal string fileName;

		public UISettingsItem(string name)
		{
			fileName = name;
			this.BorderColor = new Color(89, 116, 213) * 0.7f;
			this.dividerTexture = TextureManager.Load("Images/UI/Divider");
			this.innerPanelTexture = TextureManager.Load("Images/UI/InnerPanelBackground");
			this.Height.Set(90f, 0f);
			this.Width.Set(0f, 1f);
			base.SetPadding(6f);

			this.listName = new UIText(name, 1f, false);
			this.listName.Left.Set(10f, 0f);
			this.listName.Top.Set(5f, 0f);
			base.Append(this.listName);

			loadThisSettingButton = new UITextPanel<string>(TerraCustomUtils.TCText("EnableThisList"), 1f, false);
			loadThisSettingButton.Width.Set(100f, 0f);
			loadThisSettingButton.Height.Set(30f, 0f);
			loadThisSettingButton.Left.Set(75f, 0f);
			loadThisSettingButton.Top.Set(40f, 0f);
			loadThisSettingButton.PaddingTop -= 2f;
			loadThisSettingButton.PaddingBottom -= 2f;
			loadThisSettingButton.OnMouseOver += new UIElement.MouseEvent(FadedMouseOver);
			loadThisSettingButton.OnMouseOut += new UIElement.MouseEvent(FadedMouseOut);
			loadThisSettingButton.OnClick += new UIElement.MouseEvent(LoadThisSetting);
			base.Append(loadThisSettingButton);

			deleteThisSettingButton = new UITextPanel<string>(TerraCustomUtils.TCText("DeleteThisList"), 1f, false);
			deleteThisSettingButton.Width.Set(100f, 0f);
			deleteThisSettingButton.Height.Set(30f, 0f);
			deleteThisSettingButton.Left.Set(275f, 0f);
			deleteThisSettingButton.Top.Set(40f, 0f);
			deleteThisSettingButton.PaddingTop -= 2f;
			deleteThisSettingButton.PaddingBottom -= 2f;
			deleteThisSettingButton.OnMouseOver += new UIElement.MouseEvent(FadedMouseOver);
			deleteThisSettingButton.OnMouseOut += new UIElement.MouseEvent(FadedMouseOut);
			deleteThisSettingButton.OnClick += new UIElement.MouseEvent(DeleteThisSetting);
			base.Append(deleteThisSettingButton);
		}

		//private void DrawPanel(SpriteBatch spriteBatch, Vector2 position, float width)
		//{
		//	spriteBatch.Draw(this.innerPanelTexture, position, new Rectangle?(new Rectangle(0, 0, 8, this.innerPanelTexture.Height)), Color.White);
		//	spriteBatch.Draw(this.innerPanelTexture, new Vector2(position.X + 8f, position.Y), new Rectangle?(new Rectangle(8, 0, 8, this.innerPanelTexture.Height)), Color.White, 0f, Vector2.Zero, new Vector2((width - 16f) / 8f, 1f), SpriteEffects.None, 0f);
		//	spriteBatch.Draw(this.innerPanelTexture, new Vector2(position.X + width - 8f, position.Y), new Rectangle?(new Rectangle(16, 0, 8, this.innerPanelTexture.Height)), Color.White);
		//}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);
			CalculatedStyle innerDimensions = base.GetInnerDimensions();
			Vector2 drawPos = new Vector2(innerDimensions.X + 5f, innerDimensions.Y + 30f);
			spriteBatch.Draw(this.dividerTexture, drawPos, null, Color.White, 0f, Vector2.Zero, new Vector2((innerDimensions.Width - 10f) / 8f, 1f), SpriteEffects.None, 0f);
			drawPos = new Vector2(innerDimensions.X + innerDimensions.Width - 355, innerDimensions.Y);
			//this.DrawPanel(spriteBatch, drawPos, 350f);
		}

		public override void MouseOver(UIMouseEvent evt)
		{
			base.MouseOver(evt);
			this.BackgroundColor = new Color(73, 94, 171);
			this.BorderColor = new Color(89, 116, 213);
		}

		public override void MouseOut(UIMouseEvent evt)
		{
			base.MouseOut(evt);
			this.BackgroundColor = new Color(63, 82, 151) * 0.7f;
			this.BorderColor = new Color(89, 116, 213) * 0.7f;
		}

		private static void FadedMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(12, -1, -1, 1);
			((UIPanel)evt.Target).BackgroundColor = new Color(73, 94, 171);
		}

		private static void FadedMouseOut(UIMouseEvent evt, UIElement listeningElement)
		{
			((UIPanel)evt.Target).BackgroundColor = new Color(63, 82, 151) * 0.7f;
		}

		private static void LoadThisSetting(UIMouseEvent evt, UIElement listeningElement)
		{
			UISettingsItem settingsItem = ((UISettingsItem)listeningElement.Parent);

			Main.settingSaver.loadSetting(settingsItem.fileName);
			Main.menuMode = (int)MenuModes.SettingsView; // should reload
		}

		private static void DeleteThisSetting(UIMouseEvent evt, UIElement listeningElement)
		{
			UISettingsItem settingsItem = ((UISettingsItem)listeningElement.Parent);

			Main.settingSaver.deleteSetting(settingsItem.fileName);
			Main.menuMode = (int)MenuModes.SettingsView; // should reload
		}
	}
}
