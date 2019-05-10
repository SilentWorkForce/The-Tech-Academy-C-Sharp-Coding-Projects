using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
            
            for(int i = 0; i < 13; i++)
            {
                for(int y = 0; y < 4; y++)
                {
                    Card card = new Card();
                    card.Face = (Face)i;
                    card.Suit = (Suit)y;
                    Cards.Add(card);
                }
            }
        }

        public Deck Shuffle(out int timesShuffled, int times = 1)
        {
            timesShuffled = 0;
            for (int i = 0; i < times; i++)
            {
                timesShuffled++;
                List<Card> TempList = new List<Card>();
                Random random = new Random();


                while (this.Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, this.Cards.Count);
                    TempList.Add(this.Cards[randomIndex]);
                    this.Cards.RemoveAt(randomIndex);
                }
                this.Cards = TempList;
            }

            return this;
        }
    }
}
