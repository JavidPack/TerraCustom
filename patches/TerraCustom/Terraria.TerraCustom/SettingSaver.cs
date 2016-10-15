using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml;
using Newtonsoft.Json;
using Terraria.ModLoader;

namespace Terraria.TerraCustom
{
	public class SettingSaver
	{
		public void saveSetting(string settingName)
		{
			Directory.CreateDirectory(Main.SettingPath);
			string path = string.Concat(new object[]
				{
					Main.SettingPath,
					Path.DirectorySeparatorChar,
					settingName,
					".json"
				});
			string json = JsonConvert.SerializeObject(
				Main.setting, 
				Newtonsoft.Json.Formatting.Indented,
				new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore }
				//Ignore members where the member value is the same as the member's default value when serializing objects so that is is not written to JSON. This option will ignore all default values (e.g. null for objects and nullable types; 0 for integers, decimals and floating point numbers; and false for booleans). The default value ignored can be changed by placing the DefaultValueAttribute on the property.
				);
			File.WriteAllText(path, json);
		}

		public void loadSetting(string settingName)
		{
			Directory.CreateDirectory(Main.SettingPath);
			string path = string.Concat(new object[]
				{
					Main.SettingPath,
					Path.DirectorySeparatorChar,
					settingName,
					".json"
				});
			if (File.Exists(path))
			{
				using (StreamReader r = new StreamReader(path))
				{
					string json = r.ReadToEnd();
					//ErrorLogger.Log("1 Main.setting.PercCopp" + Main.setting.PercCopp);
					Main.setting = JsonConvert.DeserializeObject<Setting>(
						json, 
						new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate }
						);

					// "Members with a default value but no JSON will be set to their default value when deserializing."
				}
			}
		}

		public void deleteSetting(string settingName)
		{
			Directory.CreateDirectory(Main.SettingPath);
			string path = string.Concat(new object[]
				{
					Main.SettingPath,
					Path.DirectorySeparatorChar,
					settingName,
					".json"
				});
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}
	}
}
