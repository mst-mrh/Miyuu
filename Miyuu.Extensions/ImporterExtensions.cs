using System;
using dnlib.DotNet;

namespace Miyuu.Extensions
{
	public static class ImporterExtensions
	{
		public static IMethod Import(this Importer importer, Type type, string methodName)
		{
			var method = type.GetMethod(methodName);

			return importer.Import(method);
		}
	}
}
