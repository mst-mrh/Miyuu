using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using NLog;
using NLog.Fluent;

namespace Miyuu.Patcher.Engine.Modifications
{
	public abstract class ModificationBase
	{
		public ModuleDefMD SourceModuleDef { get; internal set; }

		public Importer Importer { get; internal set; }

		public string Name { get; }

		public abstract IEnumerable<string> TargetAssemblys { get; }

		protected NLog.ILogger Logger { get; }

		protected ModificationBase(string name)
		{
			Name = name;
			Logger = LogManager.GetLogger(name);
		}

		public virtual void Run()
		{
			var kvps = new List<KeyValuePair<int, MethodInfo>>();

			foreach (var m in GetType().GetMethods())
			{
				if (m.GetCustomAttribute<ModApplyToAttribute>()?.AssemblyNames.Contains(SourceModuleDef.Assembly.FullName) == true)
				{
					kvps.Add(new KeyValuePair<int, MethodInfo>(m.GetCustomAttribute<ModOrderAttribute>()?.Order ?? 0, m));
				}
			}

			foreach (var kvp in kvps.OrderBy(k => k.Key))
			{
				Logger.Info("正在运行: {0}() .. ", kvp.Value.Name);
				kvp.Value.Invoke(this, new object[] { });
			}
		}

		protected void Info(string message, [CallerMemberName] string previousMethodName = null)
		{
			Logger.Info($"{previousMethodName}() {message}");
		}
	}
}
