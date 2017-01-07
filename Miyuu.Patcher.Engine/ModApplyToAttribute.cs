using System;
using System.Linq;

namespace Miyuu.Patcher.Engine
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
	public class ModApplyToAttribute : Attribute
	{
		public string[] AssemblyNames { get; }

		public ModApplyToAttribute(params string[] names)
		{
			AssemblyNames = names.ToArray();
		}
	}
}
