using static System.Console;
using MemoryLib.Managers;
using MemoryLib.Models;
using System.Xml.Linq;

namespace MemoryConsole
{
    public class ConsoleAsking
    {
        public ConsoleAsking() { }

        public void AskOnePlayerName(out string playerName) 
        {
            Write("Enter your name :    ");
            playerName = ReadLine();
            while (string.IsNullOrWhiteSpace(playerName))
            {
                Write("Please enter a valid name.\nEnter your name :   ");
                playerName = ReadLine();
            }
        }

        public void AskTwoPlayersNames(out string? P1Name, out string? P2Name)
        {
            Write("Player 1 :   ");
            P1Name = ReadLine();
            while (string.IsNullOrWhiteSpace(P1Name))
            {
                Write("Please enter a valid name.\nPlayer 1 :   ");
                P1Name = ReadLine();
            }

            Write("Player 2 :   ");
            P2Name = ReadLine();

            if (P2Name == P1Name)
            {
                WriteLine("The two players cannot have the same name.\n");
                P2Name = null;
            }

            while (string.IsNullOrWhiteSpace(P2Name))
            {
                Write("Please enter a valid name.\nPlayer 2 :   ");
                P2Name = ReadLine();
            }
        }
    }
}
