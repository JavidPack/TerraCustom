using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader.IO;
using Terraria.UI;
using Terraria.GameContent.UI.States;
using Newtonsoft.Json;
using Terraria.ModLoader.UI;

namespace Terraria.TerraCustom.UI
{
	internal class UISettingsView : UIState
	{
		private UIList settingsItemList;
		internal static string settingsSaveDirectory = Main.SettingPath;
		internal static TmodFile[] mods;

		public override void OnInitialize()
		{
			UIElement uIElement = new UIElement();
			uIElement.Width.Set(0f, 0.8f);
			uIElement.MaxWidth.Set(600f, 0f);
			uIElement.Top.Set(220f, 0f);
			uIElement.Height.Set(-220f, 1f);
			uIElement.HAlign = 0.5f;

			UIPanel scrollPanel = new UIPanel();
			scrollPanel.Width.Set(0f, 1f);
			scrollPanel.Height.Set(-65f, 1f);
			scrollPanel.BackgroundColor = new Color(33, 43, 79) * 0.8f;
			uIElement.Append(scrollPanel);

			settingsItemList = new UIList();
			settingsItemList.Width.Set(-25f, 1f);
			settingsItemList.Height.Set(0f, 1f);
			settingsItemList.ListPadding = 5f;
			scrollPanel.Append(settingsItemList);

			UIScrollbar uIScrollbar = new UIScrollbar();
			uIScrollbar.SetView(100f, 1000f);
			uIScrollbar.Height.Set(0f, 1f);
			uIScrollbar.HAlign = 1f;
			scrollPanel.Append(uIScrollbar);
			settingsItemList.SetScrollbar(uIScrollbar);

			UITextPanel<string> titleTextPanel = new UITextPanel<string>(TerraCustomUtils.TCText("SavedSetings"), 0.8f, true);
			titleTextPanel.HAlign = 0.5f;
			titleTextPanel.Top.Set(-35f, 0f);
			titleTextPanel.SetPadding(15f);
			titleTextPanel.BackgroundColor = new Color(73, 94, 171);
			uIElement.Append(titleTextPanel);

			UITextPanel<string> backButton = new UITextPanel<string>(Localization.Language.GetTextValue("UI.Back"), 1f, false);
			backButton.Width.Set(-10f, 1f / 2f);
			backButton.Height.Set(25f, 0f);
			backButton.VAlign = 1f;
			backButton.Top.Set(-20f, 0f);
			backButton.OnMouseOver += new UIElement.MouseEvent(FadedMouseOver);
			backButton.OnMouseOut += new UIElement.MouseEvent(FadedMouseOut);
			backButton.OnClick += new UIElement.MouseEvent(BackClick);
			uIElement.Append(backButton);

			UIColorTextPanel saveNewButton = new UIColorTextPanel(TerraCustomUtils.TCText("SaveCurrentSettingsAsNew"), Color.Green, 1f, false);
			saveNewButton.CopyStyle(backButton);
			saveNewButton.HAlign = 1f;
			saveNewButton.OnMouseOver += new UIElement.MouseEvent(FadedMouseOver);
			saveNewButton.OnMouseOut += new UIElement.MouseEvent(FadedMouseOut);
			saveNewButton.OnClick += new UIElement.MouseEvent(SaveNewSettings);
			uIElement.Append(saveNewButton);

			base.Append(uIElement);
		}

		private static void SaveNewSettings(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(11, -1, -1, 1);
			Main.MenuUI.SetState(new UIVirtualKeyboard(TerraCustomUtils.TCText("EnterSettingsName"), "", new UIVirtualKeyboard.KeyboardSubmitEvent(SaveSetting), () => Main.menuMode = (int)MenuModes.SettingsView, 0));
			Main.menuMode = 888;
		}

		public static void SaveSetting(string filename)
		{
			Main.settingSaver.saveSetting(filename);
			Main.menuMode = (int)MenuModes.SettingsView; // should reload
		}

		private static void BackClick(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(11, -1, -1, 1);
			Main.menuMode = (int)MenuModes.Settings;
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

		public override void OnActivate()
		{
			Directory.CreateDirectory(settingsSaveDirectory);
			string[] files = Directory.GetFiles(settingsSaveDirectory, "*.json", SearchOption.TopDirectoryOnly);

			settingsItemList.Clear();
			foreach (string filename in files)
			{
				if (File.Exists(filename))
				{
					UISettingsItem modItem = new UISettingsItem(Path.GetFileNameWithoutExtension(filename));
					settingsItemList.Add(modItem);
				}
			}
		}
	}
}
