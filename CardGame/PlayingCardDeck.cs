using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
   
    class PlayingCardDeck
    {
        public PlayingCardDeck()
        {
            CardDeck = new PlayingCard[52];
            int k = 0;
                for (CardNumber i = 0; i < CardNumber.äss + 1; i++)
            {

                for (CardColors j = 0; j < CardColors.Ruter + 1; j++)
                {
                    CardDeck[k++] = new PlayingCard { CardColor = j, CardNumber = i, CardName = $"{j} {i}"
                };
                }
            }

        }
        public PlayingCard[] CardDeck { get; set; }

       
    }
}
