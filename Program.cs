namespace battleship
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using battleship.lib;
    public class Program
    {
        //definitions for size of game board
        private static int xSize = 10;
        private static int ySize = 10;
        public static int XSize { get => xSize; }
        public static int YSize { get => ySize; }

        //generate two players and then start the GameLoop
        public static void Main()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player(new Board(xSize, ySize), "Alex"));
            players.Add(new Player(new Board(xSize, ySize), "James"));
            Game game = new Game(players);
            game.gameLoop();
        }
    }
}




