using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Miyuu.TextWrapper
{
	public class Reader
	{
		public string FileName { get; }

		public Reader(string fileName)
		{
			if (string.IsNullOrWhiteSpace(fileName))
				throw new ArgumentException("Value cannot be null or whitespace.", nameof(fileName));

			if(!File.Exists(fileName))
				throw new FileNotFoundException("Value cannot be null or whitespace.", fileName);

			FileName = fileName;
		}

		public List<TextItem> GetTextItems()
		{
			using (var fs = new FileStream(FileName, FileMode.Open))
			{
				using (var sr = new StreamReader(fs, Encoding.UTF8))
				{
					return JsonConvert.DeserializeObject<List<TextItem>>(sr.ReadToEnd());
				}
			}
		}
	}
}
