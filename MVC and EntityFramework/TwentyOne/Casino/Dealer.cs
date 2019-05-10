using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace Casino
{
    public class Dealer
    {
        public string Name { get; set; }
        public Deck deck { get; set; }
        public int Balance { get; set; }

        public void Deal(List<Card> Hand)
        {
            Hand.Add(deck.Cards.First());
            string card = string.Format(deck.Cards.First().ToString());
            Console.WriteLine(card);
            using (StreamWriter file = new StreamWriter("Log", true))
            {
                file.WriteLine(DateTime.Now);
                file.WriteLine(card);
            }
            deck.Cards.RemoveAt(0);
        }
    }
}
