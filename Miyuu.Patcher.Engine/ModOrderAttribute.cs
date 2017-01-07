using System;

namespace Miyuu.Patcher.Engine
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
	public class ModOrderAttribute : Attribute
	{
		public int Order { get; }

		public ModOrderAttribute(int order)
		{
			Order = order;
		}

		public ModOrderAttribute() : this(0) { }
	}
}

