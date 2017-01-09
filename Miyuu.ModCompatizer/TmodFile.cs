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
		public readonly string Path;

		private readonly IDictionary<string, byte[]> _files = new Dictionary<string, byte[]>();

		public Version ModLoaderVersion {
			get; private set;
		}

		public string Name { get; internal set; }

		public Version Version {
			get; internal set;
		}

		public byte[] Hash {
			get; private set;
		}

		internal byte[] Signature { get; private set; } = new byte[256];

		private Exception _readException;

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
			byte[] data;
			_files.TryGetValue(fileName.Replace('\\', '/'), out data);
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

		public IEnumerator<KeyValuePair<string, byte[]>> GetEnumerator()
		{
			return _files.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		internal void Save()
		{
			Backup();

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

			using (var writer = new BinaryWriter(File.Create(Path)))
			{
				writer.Write(Encoding.ASCII.GetBytes("TMOD"));
				writer.Write(new Version(0, 9, 0, 2).ToString()); // ??
				writer.Write(Hash);
				writer.Write(Signature);
				writer.Write(data.Length);
				writer.Write(data);
			}
		}

		internal void Read()
		{
			try
			{
				byte[] data;
				using (var reader = new BinaryReader(File.OpenRead(Path)))
				{
					if (Encoding.ASCII.GetString(reader.ReadBytes(4)) != "TMOD")
						throw new Exception("Magic Header != \"TMOD\"");

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
			}
			catch (Exception e)
			{
				_readException = e;
			}
		}

		internal Exception ValidMod()
		{
			if (_readException != null)
				return _readException;

			if (!HasFile("Info"))
				return new Exception("Missing Info file");

			if (!HasFile("All.dll") && !(HasFile("Windows.dll") && HasFile("Mono.dll")))
				return new Exception("Missing All.dll or Windows.dll and Mono.dll");

			return null;
		}

		public byte[] GetMainAssembly(bool windows = true)
		{
			return HasFile("All.dll") ? GetFile("All.dll") : windows ? GetFile("Windows.dll") : GetFile("Mono.dll");
		}

		public byte[] GetMainPdb(bool windows = true)
		{
			return HasFile("All.pdb") ? GetFile("All.pdb") : windows ? GetFile("Windows.pdb") : GetFile("Mono.pdb");
		}

		public string GetTempMainAssembly(bool windows = true)
		{
			return HasFile("All.dll") ? GetTempFilePath("All.dll") : windows ? GetTempFilePath("Windows.dll") : GetTempFilePath("Mono.dll");
		}

		public string GetTempMainPdb(bool windows = true)
		{
			return HasFile("All.pdb") ? GetTempFilePath("All.pdb") : windows ? GetTempFilePath("Windows.pdb") : GetTempFilePath("Mono.pdb");
		}

		public void Backup()
		{
			File.Copy(Path, Path + ".bak", true);
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
	}
}
