using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Ionic.Zlib;

namespace Miyuu.ModCompatizer
{
	public class TmodFile : IEnumerable<KeyValuePair<string, byte[]>>
	{
		private const string MagicHeader = "TMOD";

		private static readonly Version CurrentModLoaderVersion = new Version(0, 9, 2, 3);

		public readonly string Path;

		private readonly IDictionary<string, byte[]> _files = new Dictionary<string, byte[]>();

		public Version ModLoaderVersion { get; private set; }

		public string Name { get; private set; }

		public Version Version { get; private set; }

		public byte[] Hash { get; private set; }

		internal byte[] Signature { get; private set; } = new byte[256];

		internal TmodFile(string path)
		{
			Path = path;
		}

		public bool HasFile(string fileName)
		{
			return _files.ContainsKey(fileName.Replace('\\', '/'));
		}

		public byte[] GetFile(string fileName)
		{
			_files.TryGetValue(fileName.Replace('\\', '/'), out byte[] data);
			return data;
		}

		internal void AddFile(string fileName, byte[] data)
		{
			var dataCopy = new byte[data.Length];
			data.CopyTo(dataCopy, 0);
			_files[fileName.Replace('\\', '/')] = dataCopy;
		}

		internal void RemoveFile(string fileName)
		{
			_files.Remove(fileName.Replace('\\', '/'));
		}

		internal void SetFile(string fileName, byte[] data)
		{
			_files[fileName] = data;
		}

		internal void Save(string path = null)
		{
			var dataStream = new MemoryStream();
			using (var writer = new BinaryWriter(new DeflateStream(dataStream, CompressionMode.Compress)))
			{
				writer.Write(Name);
				writer.Write(Version.ToString());

				writer.Write(_files.Count);
				foreach (var entry in _files)
				{
					writer.Write(entry.Key);
					writer.Write(entry.Value.Length);
					writer.Write(entry.Value);
				}
			}
			var data = dataStream.ToArray();
			Hash = SHA1.Create().ComputeHash(data);

			using (var writer = new BinaryWriter(File.Create(path ?? Path)))
			{
				writer.Write(Encoding.ASCII.GetBytes(MagicHeader));
				writer.Write(ModLoaderVersion.ToString());
				writer.Write(Hash);
				writer.Write(Signature);
				writer.Write(data.Length);
				writer.Write(data);
			}
		}

		internal void Read()
		{
			byte[] data;
			using (var reader = new BinaryReader(File.OpenRead(Path)))
			{
				if (Encoding.ASCII.GetString(reader.ReadBytes(4)) != MagicHeader)
					throw new Exception($"Magic Header != \"{MagicHeader}\"");

				ModLoaderVersion = new Version(reader.ReadString());
				Hash = reader.ReadBytes(20);
				Signature = reader.ReadBytes(256);
				data = reader.ReadBytes(reader.ReadInt32());
				var verifyHash = SHA1.Create().ComputeHash(data);
				if (!verifyHash.SequenceEqual(Hash))
					throw new Exception("Hash mismatch, data blob has been modified or corrupted");
			}

			using (var reader = new BinaryReader(new DeflateStream(new MemoryStream(data), CompressionMode.Decompress)))
			{
				Name = reader.ReadString();
				Version = new Version(reader.ReadString());

				var count = reader.ReadInt32();
				for (var i = 0; i < count; i++)
					AddFile(reader.ReadString(), reader.ReadBytes(reader.ReadInt32()));
			}

			ValidMod();
		}

		private void ValidMod()
		{
			if (!HasFile("Info"))
				throw new Exception("Missing Info file");

			if (!HasFile("All.dll") && !(HasFile("Windows.dll") && HasFile("Mono.dll")))
				throw new Exception("Missing All.dll or Windows.dll and Mono.dll");

			if (ModLoaderVersion != CurrentModLoaderVersion)
				Console.WriteLine("Mod with different version: {0}", ModLoaderVersion);
		}

		public string GetTempFilePath(string fileName)
		{
			var data = GetFile(fileName);

			if (data == null)
				return string.Empty;

			var tmpPath = System.IO.Path.GetTempFileName();

			File.WriteAllBytes(tmpPath, GetFile(fileName));

			return tmpPath;
		}

		public string GetMainAssemblyPath()
		{
			var files = new[]
			{
				"Windows.dll",
				"All.dll",
				"Mono.dll"
			};

			foreach (var file in files)
			{
				if (HasFile(file))
					return GetTempFilePath(file);
			}

			throw new FileNotFoundException("Missing All.dll, Windows.dll and Mono.dll");
		}

		public void SetMainAssembly(byte[] data)
		{
			var files = new[]
			{
				"Windows.dll",
				"All.dll",
				"Mono.dll"
			};

			foreach (var file in files)
			{
				if (HasFile(file))
				{
					SetFile(file, data);
					break;
				}
			}
		}

		public IEnumerator<KeyValuePair<string, byte[]>> GetEnumerator()
		{
			return _files.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}