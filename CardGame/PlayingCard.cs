using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public enum CardColors
    {
        Spader,
        Klöver,
        Hjärter,
        Ruter
    }

public enum CardNumber
    {
     två, tre, fyra, fem, sex, sju, åtta, nio, tio, knekt, dam, kung, äss
    }
    class PlayingCard
    {
        public PlayingCard()
        {
          
        }
        public CardColors CardColor { get; set; }
        public CardNumber CardNumber { get; set; }

        public string CardName { get; set; }
    }
}
