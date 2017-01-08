using System;
using System.Collections.Generic;

namespace Miyuu.TextWrapper
{
	internal interface IText
	{
		List<ITextItem> GetTextList();

		int Count { get; }

		string Name { get; }
	}

	internal interface IMethodText : IText
	{
		Type Type { get; }

		int StartIndex { get; }

		int EndIndex { get; }
	}

	internal interface IMemberText : IText
	{
		string MemberName { get; }
	}

	internal interface ITextItem
	{
		string Content { get; }

		int Id { get; }
	}
}
