using System;
using System.IO;
using System.Xml.Serialization;

namespace Terraria
{
	internal class SettingSaver
	{
		private const string Extension = ".xml";
		public const int MaxLoadSetting = 1000;
		public static string[] settings = new string[1000];
		public static string[] settingPaths = new string[1000];
		public static int numSettingsLoad = 0;

		public void saveSetting(string settingName = "setting1")
		{
			Directory.CreateDirectory(Main.SettingPath);
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Setting));
			string path = string.Concat(new object[]
				{
					Main.SettingPath,
					Path.DirectorySeparatorChar,
					settingName,
					".xml"
				});
			FileStream fileStream = new FileStream(path, FileMode.Create);
			xmlSerializer.Serialize(fileStream, Main.setting);
			fileStream.Close();
		}

		public void loadSetting(string settingName)
		{
			Directory.CreateDirectory(Main.SettingPath);
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Setting));
			string path = Main.SettingPath + settingName + ".xml";
			FileStream fileStream = new FileStream(path, FileMode.Open);
			Main.setting = (Setting)xmlSerializer.Deserialize(fileStream);
			fileStream.Close();
		}

		public int getSettings()
		{
			Directory.CreateDirectory(Main.SettingPath);
			string[] files = Directory.GetFiles(Main.SettingPath, "*.xml");
			SettingSaver.numSettingsLoad = files.Length;
			if (!Main.dedServ && SettingSaver.numSettingsLoad > 1000)
			{
				SettingSaver.numSettingsLoad = 1000;
			}
			for (int i = 0; i < SettingSaver.numSettingsLoad; i++)
			{
				SettingSaver.settingPaths[i] = files[i];
				SettingSaver.settings[i] = SettingSaver.GetSettingName(SettingSaver.settingPaths[i]);
			}
			return SettingSaver.numSettingsLoad;
		}

		public static string GetSettingName(string path)
		{
			if (path == null)
			{
				return string.Empty;
			}
			path = path.Substring(Main.SettingPath.Length + 1);
			path = path.Remove(path.Length - ".xml".Length);
			return path;
		}
	}
}
