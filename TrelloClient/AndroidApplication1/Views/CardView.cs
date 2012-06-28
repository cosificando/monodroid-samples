namespace AndroidApplication1.Views
{
    using System;

    using AndroidApplication1.Model;

    public class CardView
    {
        public CardView(string name, Card card, Type screen)
        {
            Name = name;
            Screen = screen;
            Card = card;
        }

        public string Name { get; set; }

        public Type Screen { get; set; }

        public Card Card { get; set; }

    }
}