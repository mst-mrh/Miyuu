namespace Miyuu.TextWrapper
{
	public struct TextItem : ITextItem
	{
		public string Content { get; set; }

		public int Id { get; set; }
	}

	public struct TextItemWith2Argument : ITextItem
	{
		public string Content { get; set; }

		public int Id { get; set; }

		public int Id2 { get; set; }
	}
}
