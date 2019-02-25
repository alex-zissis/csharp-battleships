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

        //loop through the Y to make sure all values are the same. Otherwise it is not a valid row
        public override bool validateCoords(List<Coordinate> _coords)
        {
            int refY = _coords[0].Y;
            foreach (var item in _coords)
            {
                if (item.Y != refY)
                {
                    return false;
                }
            }
            return true;
        }
    }
}