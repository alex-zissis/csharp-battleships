namespace battleship.lib
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using battleship;
    public class Player
    {
        private string name;
        private Board playerBoard;
        public Board PlayerBoard { get => playerBoard; }
        public String Name { get => name; }

        public Player(Board _board, string _name)
        {
            playerBoard = _board;
            name = _name;
        }

        public Player(Board _board)
        {
            playerBoard = _board;
            Console.WriteLine("\nEnter players name: ");
            name = Console.ReadLine();
        }
    }

}