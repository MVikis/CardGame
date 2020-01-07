using System;
using System.IO;

namespace CardGame
{
    class Program
    {
       static int highscorePlayer1 = 0;
       static int highscorePlayer2 = 0;


        static void Main(string[] args)
        {
            Menu();
            Console.Clear();
            PlayingCardGame.StartGame();
            
        }

        static void Menu()
        {
            Console.WriteLine("The point of this game is to end with 0 cards before the second player.");
            Console.WriteLine();
            Console.WriteLine("In order to place down a card, your card needs to be higher than your opponents card.");
            Console.WriteLine("The cards two and ten can remove the whole card pool" +  Environment.NewLine + "and let you play any cards on your hand.");
            Console.WriteLine("If you cannot enter a higher card you need to pick up all cards in the card pool.");
            Console.WriteLine();
            Console.Write("Play Game?");
            Console.ReadKey(true);

        }
       public static void Won(int i)
        {
            Console.WriteLine($"player {i} won!");
            if (i == 1)
                highscorePlayer1++;
            else if (i == 2)
                highscorePlayer2++;

            

            Console.WriteLine();
            Console.WriteLine("Play again?");
            Console.WriteLine("Enter yes or no");
            string input = Console.ReadLine();
            if (input == "yes")
            {
                
            PlayingCardGame.StartGame();


            }
            else if (input == "no")
            {
                Environment.Exit(0);
                string pathPlayer1 = @"C:\Users\Martin\source\repos\Player1.txt";
                string pathPlayer2 = @"C:\Users\Martin\source\repos\Player2.txt";

                if (int.Parse(File.ReadAllText(pathPlayer1)) > highscorePlayer1 )
                File.WriteAllText(pathPlayer1, $"Highscore for Player 1: {highscorePlayer1}");
                if (int.Parse(File.ReadAllText(pathPlayer2)) > highscorePlayer2)
                File.WriteAllText(pathPlayer2, $"Highscore for Player 2:{highscorePlayer2}");



                



            }


        }
    }
}
