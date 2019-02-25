namespace battleship.lib
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using battleship;
    //ship class
    public class Ship
    {
        private Area shipArea;
        public Area ShipArea { get => shipArea; }

        //the ship takes a start coordinate and an end coordinate as arguments. E.g if the ship is placed horizontall on A1 and has a length of 3, this arugment will be (0,0),(0,2) - NB A1 referes to 0,0 because arrays
        public Ship(Coordinate start, Coordinate end)
        {
            bool horizontal = new bool();
            //ensure the coordinates frm a straight line
            if (start.X == end.X)
            {
                horizontal = true;
            }
            else if (start.Y == end.Y)
            {
                horizontal = false;
            }
            else
            {
                throw new System.ArgumentException("The ships coordinates must be in a stright line. Ensure either the X or Y values of the start and end coordinates are equal", "Original");
            }

            //get the ints in the range. E.g. if startX is 2 and endX is 5 it will return [2,3,4,5]
            List<int> varCoord = !horizontal ? Helpers.getIntsInRange(start.X, end.X) : Helpers.getIntsInRange(start.Y, end.Y);
            //static coord is the axis that doesn't change
            int staticCoord = horizontal ? start.X : end.Y;

            //merge the static coords into the variable coords to get a coordinate object
            List<Coordinate> coordinates = Helpers.getAllCoordsInRange(staticCoord, varCoord, horizontal);
            if (horizontal)
            {
                shipArea = new Row(coordinates);
            }
            else
            {
                shipArea = new Column(coordinates);
            }
        }
    }
}