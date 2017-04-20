using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Miyuu.TextWrapper
{
	public class Converter
	{
		private const string Terraria = "Terraria, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null";

		private const string ItemFile = "Terraria.Localization.Content.zh-Hans.Items.json";

		public string LanguageFileFolder { get; }

		public string OldFileFolder { get; }

		private Module _module;

		public Converter(string newPath, string oldPath)
		{
			LanguageFileFolder = Path.GetFullPath(newPath);
			OldFileFolder = Path.GetFullPath(oldPath);
		}

		public void Run()
		{
			_module = Assembly.Load(Terraria).Modules.Single();

			ReplaceItem();
		}

		private void ReplaceItem()
		{
			var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(File.ReadAllText(Path.Combine(LanguageFileFolder, ItemFile)));

			Work("prefix.json", "Prefix", "Terraria.ID.PrefixID", typeof(int), data);
			Work("itemName.json", "ItemName", "Terraria.ID.ItemID", typeof(short), data);

			MergeTooltip(data);

			File.WriteAllText("test", JsonConvert.SerializeObject(data, Formatting.Indented));

		}

		private void Work(string old, string category, string typeName, Type constType, IDictionary<string, Dictionary<string, string>> data)
		{
			var oldTexts = JsonConvert.DeserializeObject<List<TextItem>>(File.ReadAllText(Path.Combine(OldFileFolder, old)));

			var type = _module.GetType(typeName);
			var texts = data[category];
			
			foreach (var fieldInfo in type.GetFields().Where(t => t.IsLiteral && t.FieldType.Name == constType.Name && t.Name != "Count"))
			{
				var value = fieldInfo.GetValue(null);

				if (oldTexts.Any(o => o.Id.ToString().Equals(value.ToString())))
				{
					texts[fieldInfo.Name] = oldTexts.Single(t => t.Id.ToString().Equals(value.ToString())).Content;
				}
				else
				{
					Console.WriteLine("NOT VALID: {0}, {1}", category, value);
				}
			}
		}

		private void MergeTooltip(IDictionary<string, Dictionary<string, string>> data)
		{
			var type = _module.GetType("Terraria.ID.ItemID");

			var t1 = JsonConvert.DeserializeObject<List<TextItem>>(File.ReadAllText(Path.Combine(OldFileFolder, "toolTip.json")));
			var t2 = JsonConvert.DeserializeObject<List<TextItem>>(File.ReadAllText(Path.Combine(OldFileFolder, "toolTip2.json")));

			var cat = data["ItemTooltip"];

			var keys = cat.Keys.Select(t => t.ToString()).ToList();

			foreach (var key in keys)
			{
				var field = type.GetField(key);

				var id = field.GetValue(null).ToString();

				var tooltip = "";

				var value = cat[key];

				if (value.StartsWith("{$") && value.EndsWith("}"))
					continue;

				if (value.StartsWith("{$") && !value.EndsWith("}") && !value.Contains("<"))
				{
					var l = value.Split('}').ToList();
					l.RemoveAll(string.IsNullOrWhiteSpace);

					if (t2.Exists(t => t.Id.ToString() == id))
					{
						tooltip += "\n" + t2.Single(t => t.Id.ToString() == id).Content;
					}

					if (!string.IsNullOrWhiteSpace(tooltip))
					{
						data["ItemTooltip"][key] = l[0] + "}" + tooltip;
					}

					continue;
				}

				if (value.Contains("{$") || value.Contains("<"))
				{
					Console.WriteLine("WARN: NOT MODIFIED! {0}: {1}", key, value);
					continue;
				}

				if (t1.Exists(t => t.Id.ToString() == id))
				{
					tooltip += t1.Single(t => t.Id.ToString() == id).Content;
				}

				if (t2.Exists(t => t.Id.ToString() == id))
				{
					tooltip += (tooltip == "" ? "" : "\n") + t2.Single(t => t.Id.ToString() == id).Content;
				}

				if (!string.IsNullOrWhiteSpace(tooltip))
				{
					data["ItemTooltip"][key] = tooltip;
				}
			}
		}
	}
}
