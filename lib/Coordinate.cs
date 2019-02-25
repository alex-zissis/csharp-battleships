namespace battleship.lib
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using battleship;
    //Coordinate class. Has the X,Y values, the ship in that spot and whether it's been guessed or not
    public class Coordinate
    {
        private int x;
        private int y;
        private Ship shipFilled;
        private bool guessed;
        private List<int> coords;
        public List<int> Coords { get => coords; }
        public int X { get => x; }
        public int Y { get => y; }
        public Ship ShipFilled { get => shipFilled; set => shipFilled = value; }
        public bool Guessed { get => guessed; set => guessed = value; }

        public Coordinate(int _x, int _y)
        {
            x = _x;
            y = _y;
            guessed = false;
            coords = new List<int>() { x, y };
        }
        //return X if a coordinate has a ship attached or - otherwise
        public string getShipLocations()
        {
            string outStr = "";
            if (this.shipFilled != null)
            {
                outStr = "X";
            }
            else
            {
                outStr = "-";
            }
            return " " + outStr + " ";
        }

        //overide two string to display status of spots
        public override string ToString()
        {
            string outStr = "";
            if (!this.guessed)
            {
                outStr = "-";
            }
            else if (this.shipFilled != null && this.guessed)
            {
                outStr = "X";
            }
            else if (this.guessed && this.shipFilled == null)
            {
                outStr = "0";
            }
            return " " + outStr + " ";
        }
    }
}