namespace AndroidApplication1.Views
{
    using System;

    public class BoardView
    {
        public BoardView(string name, string id, Type screen)
        {
            Name = name;
            Screen = screen;
			Id = id;
        }

		public string Name  { get; set; }

		public Type Screen { get; set; }

		public string Id { get; set; }

    }
}