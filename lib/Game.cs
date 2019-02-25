namespace battleship.lib
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using battleship;
    //Contains the game logic
    public class Game
    {
        private List<Player> players;

        public Game(List<Player> _players)
        {
            players = _players;
        }

        public void gameLoop()
        {
            bool quitGame = false;
            this.initialiseShips();
            while (!quitGame)
            {
                //Console.WriteLine();
            }
        }

        //Loop through each user and have them select where to place their ships
        private void initialiseShips()
        {
            foreach (var player in this.players)
            {
                bool done = false;
                int shipCount = 0;
                bool initial = true;
                Console.WriteLine("\nWelcome " + player.Name + ". Here you will set up your ships. Use the prompts below to configure your ships");
                while (!done)
                {
                    char answer = new char();
                    //ask player if they want to place another ship
                    while (answer != 'N' && answer != 'Y')
                    {
                        if (!initial)
                        {
                            Console.WriteLine(player.Name + ", you have " + shipCount + " ships currently placed. Place another? (Y/N)");
                            answer = Console.ReadLine().ToUpper()[0];
                        }
                        else
                        {
                            initial = false;
                            answer = 'Y';
                        }
                    }

                    //if the player is done go on to the next player
                    if (answer == 'N')
                    {
                        done = true;
                        initial = true;
                        continue;
                    }

                    char orientation = new char();
                    Coordinate startingPosition = null;
                    int length = 0;

                    //get the orientation of the ship
                    while (orientation != 'H' && orientation != 'V')
                    {
                        Console.WriteLine("Choose an orientation for your ship (h = hoirzontal, v = vertical): (H/V)");
                        orientation = Console.ReadLine().ToUpper()[0];
                    }

                    //get the starting coords
                    while (startingPosition == null)
                    {
                        Console.WriteLine("Choose a starting position for your ship in the format A1 (Row Letter, Column Number):");
                        try
                        {
                            startingPosition = Helpers.getCoordsFromPoint(Console.ReadLine().ToUpper(), Program.XSize, Program.YSize);
                        }
                        catch (System.ArgumentException e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    //calculate the max length of the ship by finding the available points in the direction chosen
                    int maxAxisLength = orientation == 'H' ? Program.YSize : Program.XSize;
                    int axisPosition = orientation == 'H' ? startingPosition.Y : startingPosition.X;
                    int maxLength = maxAxisLength - axisPosition;

                    while (length == 0)
                    {
                        Console.WriteLine("Length for your ship. Based on the value you choose earlier your max length is " + maxLength + ":");
                        int tempLength = new int();
                        try
                        {
                            tempLength = Int32.Parse(Console.ReadLine());
                        }
                        catch (System.FormatException)
                        {
                            Console.WriteLine("Please enter a number");
                            continue;
                        }

                        if (tempLength > 0 && tempLength <= maxLength)
                        {
                            length = tempLength;
                        }
                        else if (tempLength <= 0)
                        {
                            Console.WriteLine("Enter a length above 0");
                        }
                        else if (tempLength > maxLength)
                        {
                            Console.WriteLine("Your length was above the max length of " + maxLength);
                        }
                    }

                    //calculate the end coordinates of the ship by adding the length to the start value on the relevant axis
                    Coordinate endPosition = orientation == 'H' ? new Coordinate(startingPosition.X, startingPosition.Y + length) : new Coordinate(startingPosition.X + length, startingPosition.Y);
                    Ship ship = new Ship(startingPosition, endPosition);
                    try
                    {
                        player.PlayerBoard.assignShip(ship);
                        shipCount++;
                        player.PlayerBoard.ShipCount = shipCount;
                    }
                    catch (System.ArgumentException e)
                    {
                        //this will be thrown if the ship is trying to be put into a square that is already filled
                        Console.WriteLine(e);
                        Console.WriteLine("The ship was not added");
                    }
                    Console.WriteLine("\n" + player.Name + "'s board\n");
                    Console.WriteLine(player.PlayerBoard.getShipLocations());
                }
            }
            Console.WriteLine(players[0].PlayerBoard);
            Console.WriteLine(players[1].PlayerBoard);
        }
    }
}