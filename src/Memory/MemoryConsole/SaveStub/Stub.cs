using MemoryLib.Managers;
using MemoryLib.Models;

namespace MemoryConsole.SaveStub;

public class Stub1 : ISaveManager, ILoadManager
{
    public Game LoadGame() 
    {
        Player player1 = new("Player 1");
        Player player2 = new("Player 2");
        Grid grid = new(4, 4);

        Game game = new(player1, player2, GridSize.Size1);
        game.SwitchPlayer();
        player1.Add1ToScore();
        player1.Add1ToScore();
        player1.Add1ToScore();
        player2.Add1ToScore();

        player1.Add1ToMovesCount();
        player2.Add1ToMovesCount();
        player1.Add1ToMovesCount();
        player2.Add1ToMovesCount();
        player1.Add1ToMovesCount();
        player2.Add1ToMovesCount();

        return game;
        
    }

    public void SaveGame(Game game)
    {
        return;
    }
}

public class Stub2 : ISaveManager, ILoadManager
{
    public Game LoadGame()
    {
        Player player1 = new("Player 1");
        Player player2 = new("Player 2");
        Grid grid = new(4, 4);
        Game game = new(player1, player2, GridSize.Size1);

        game.SwitchPlayer();
        player1.Add1ToScore();
        player2.Add1ToScore();
        player1.Add1ToScore();
        player2.Add1ToScore();

        player1.Add1ToMovesCount();
        player2.Add1ToMovesCount();
        player1.Add1ToMovesCount();
        player2.Add1ToMovesCount();
        player1.Add1ToMovesCount();
        player2.Add1ToMovesCount();

        return game;
    }

    public void SaveGame(Game game)
    {
        return;
    }
}
