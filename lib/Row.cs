namespace battleship.lib
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using battleship;
    //row implementation of area
    public class Row : Area
    {
        public Row(List<Coordinate> _coords) : base(_coords) { } //call the init on the super using _coords

        //loop through the x to make sure all values are the same. Otherwise it is not a valid row
        public override bool validateCoords(List<Coordinate> _coords)
        {
            int refX = _coords[0].X;
            foreach (var item in _coords)
            {
                if (item.X != refX)
                {
                    return false;
                }
            }
            return true;
        }
    }
}