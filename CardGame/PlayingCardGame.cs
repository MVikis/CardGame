using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{


    static class PlayingCardGame
    {
        static List<PlayingCard> Shuffled;
        static List<PlayingCard> EnemyShuffled = new List<PlayingCard>();
        static PlayingCard playedCard;
        static PlayingCard p2PlayedCard;
        static List<PlayingCard> CardPool;




        static public void StartGame()
        {
            PlayingCardDeck cardDeck = new PlayingCardDeck();
            Random random = new Random();






            CardPool = new List<PlayingCard>();
            Shuffled = cardDeck.CardDeck
                .OrderBy(c => Guid.NewGuid())
                .ToList();
           
            for (int i = 0; i < 26; i++)
            {
                EnemyShuffled.Add(Shuffled[i]);
                Shuffled.Remove(Shuffled[i]);
            }
            p2PlayedCard = EnemyShuffled[random.Next(1, 26)];


            while (true)
            {
                PlayerTurn();
                EnemyTurn();
            }
            


        }
        static public void PlayerTurn()
        {

            Console.WriteLine("Player 1 turn:");
            Console.WriteLine($"Player 2's card: {p2PlayedCard.CardName}");
            PlayingCard[] playableCards = new PlayingCard[3];
            for (int i = 0; i < playableCards.Length; i++)
            {
                playableCards[i] = Shuffled[i];
            }
            foreach (var item in playableCards)
            {
                Console.WriteLine(item.CardName);
            }
            Console.WriteLine();
            Console.WriteLine("Choose a card from 1 - 3");
            Console.WriteLine($"CardPool amount: {CardPool.Count}");
            Console.WriteLine($"Player 1's amount: {Shuffled.Count}");


            var value = int.Parse(Console.ReadLine());
            if (value < 1 || value > 3)
            {
                throw new Exception();
            }
            playedCard = playableCards[value - 1];
            Console.WriteLine(playedCard.CardName);
            if (playedCard.CardNumber == CardNumber.tio || playedCard.CardNumber == CardNumber.två)
            {
                CardPool.Add(playedCard);
                CardPool.Clear();
                p2PlayedCard.CardNumber = CardNumber.två;
                p2PlayedCard.CardName = "";
                Shuffled.Remove(playedCard);

                Console.Clear();

                PlayerTurn();


            }
           else if (playedCard.CardNumber > p2PlayedCard.CardNumber)
            {
                CardPool.Add(playedCard);
                Shuffled.Remove(playedCard);
            }
            else if (playedCard.CardNumber <= p2PlayedCard.CardNumber)
            {
                CardPool.Add(playedCard);
                Shuffled.AddRange(CardPool);
                Shuffled.Remove(playedCard);
                playedCard.CardNumber = CardNumber.två;
                playedCard.CardName = "";
                EnemyShuffled.Remove(p2PlayedCard);
                CardPool.Clear();


            }
            Console.Clear();
            if (Shuffled == null)
            {
                Program.Won(1);
                
            }
            


        }
        static public void EnemyTurn()
        {
            Console.WriteLine("Player 2 turn:");
            Console.WriteLine($"Player 1's card: {playedCard.CardName}");

            PlayingCard[] playableCards = new PlayingCard[3];
            for (int i = 0; i < playableCards.Length; i++)
            {
                playableCards[i] = EnemyShuffled[i];
            }

            foreach (var item in playableCards)
            {
                Console.WriteLine(item.CardName);
            }
            Console.WriteLine();
            Console.WriteLine("Choose a card from 1 - 3");
            Console.WriteLine($"CardPool amount: {CardPool.Count}");
            Console.WriteLine($"Player 2's amount: {EnemyShuffled.Count}");

            var value = int.Parse(Console.ReadLine());
            if (value < 1 || value > 3)
            {
                throw new Exception();
            }
            p2PlayedCard = playableCards[value - 1];
            Console.WriteLine(playedCard.CardName);
            if (p2PlayedCard.CardNumber == CardNumber.tio || p2PlayedCard.CardNumber == CardNumber.två)
            {
                CardPool.Add(p2PlayedCard);
                CardPool.Clear();
                playedCard.CardNumber = CardNumber.två;
                playedCard.CardName = "";
                EnemyShuffled.Remove(p2PlayedCard);

                Console.Clear();
                EnemyTurn();
                
                
            }
            else if (p2PlayedCard.CardNumber > playedCard.CardNumber)
            {
                CardPool.Add(p2PlayedCard);
                EnemyShuffled.Remove(p2PlayedCard);
            }
            else if (p2PlayedCard.CardNumber <= playedCard.CardNumber)
            {
                CardPool.Add(p2PlayedCard);
                EnemyShuffled.AddRange(CardPool);
                EnemyShuffled.Remove(p2PlayedCard);
                p2PlayedCard.CardNumber = CardNumber.två;
                p2PlayedCard.CardName = "";
                EnemyShuffled.Remove(p2PlayedCard);
                CardPool.Clear();

            }

          
            Console.Clear();
            if (EnemyShuffled == null)
            {
                Program.Won(2);



            }


        }
        
       
    }
}
