namespace battleship.lib
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using battleship;
    //Contains the game logic
    public class Game
    {
        private Player player1;
        private Player player2;

        public Game(Player _player1, Player _player2)
        {
            player1 = _player1;
            player2 = _player2;
        }

        public void gameLoop()
        {
            bool quitGame = false;
            this.initialiseShips();
            while (!quitGame)
            {
                Player active = player1;
                Player opponent = player2;
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("\n" + active.Name + ", it's your turn \n");
                    Console.WriteLine("Opponent's board: \n");
                    Console.WriteLine(opponent.PlayerBoard);
                    Coordinate guess = null;
                    while (guess == null)
                    {
                        Console.WriteLine("\n Make a guess in the format \"A1\":");
                        string value = Console.ReadLine();
                        Coordinate tempCoord;
                        try
                        {
                            tempCoord = Helpers.getCoordsFromPoint(value, Program.XSize, Program.YSize);
                            if (opponent.PlayerBoard.isGuessed(tempCoord))
                            {
                                Console.WriteLine("That coordinate has already been guessed, try again");
                                continue;
                            }
                            bool isGuessGood = opponent.PlayerBoard.isGuessGood(tempCoord);
                            if (isGuessGood)
                            {
                                Console.WriteLine("HIT: A ship was hit at " + value);
                                Ship ship = opponent.PlayerBoard.getFilledShip(tempCoord);
                                Console.WriteLine(ship);
                                if (ship != null)
                                {
                                    Console.WriteLine(ship.isSunk());
                                    if (ship.isSunk())
                                    {
                                        Console.WriteLine("SUNK: You have sunk " + opponent.Name + "'s battleship!");
                                        opponent.PlayerBoard.ShipCount--;
                                        if (opponent.PlayerBoard.ShipCount == 0)
                                        {
                                            Console.WriteLine("VICTOR: You have sunk all of" + opponent.Name + "'s ships! You win!");

                                            Environment.Exit(0);
                                        }
                                        else
                                        {
                                            Console.WriteLine(opponent.Name + "Has " + opponent.PlayerBoard.ShipCount + " ships remaining.");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("MISS: No ship was hit at " + value);
                            }
                            guess = tempCoord;
                        }
                        catch (System.ArgumentException e)
                        {
                            Console.WriteLine(e);
                            continue;
                        }
                    }
                    Player temp = active;
                    active = opponent;
                    opponent = temp;
                }
            }
        }

        //Loop through each user and have them select where to place their ships
        private void initialiseShips()
        {
            foreach (var player in new List<Player>() { player1, player2 })
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
                            Coordinate tempPosition = Helpers.getCoordsFromPoint(Console.ReadLine().ToUpper(), Program.XSize, Program.YSize);
                            if (tempPosition.X == Program.XSize)
                            {
                                Console.WriteLine("A ship can not start in the last column of the board.");
                            }
                            else if (tempPosition.Y == Program.YSize)
                            {
                                Console.WriteLine("A ship can not start in the row column of the board.");
                            }

                            startingPosition = tempPosition;
                        }
                        catch (System.ArgumentException e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    //calculate the max length of the ship by finding the available points in the direction chosen
                    int maxAxisLength = orientation == 'H' ? Program.XSize : Program.YSize;
                    int axisPosition = orientation == 'H' ? startingPosition.X : startingPosition.Y;
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

                        if (tempLength > 1 && tempLength <= maxLength)
                        {
                            length = tempLength;
                        }
                        else if (tempLength <= 1)
                        {
                            Console.WriteLine("Enter a length above 1");
                        }
                        else if (tempLength > maxLength)
                        {
                            Console.WriteLine("Your length was above the max length of " + maxLength);
                        }
                    }

                    //calculate the end coordinates of the ship by adding the length to the start value on the relevant axis
                    Coordinate endPosition = orientation == 'H' ? new Coordinate(startingPosition.X + length - 1, startingPosition.Y) : new Coordinate(startingPosition.X, startingPosition.Y + length - 1);
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
        }
    }
}