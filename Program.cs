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
            Player player1 = new Player(new Board(xSize, ySize), "Alex");
            Player player2 = new Player(new Board(xSize, ySize), "James");
            Game game = new Game(player1, player2);
            game.gameLoop();
        }
    }
}




