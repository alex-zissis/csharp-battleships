namespace battleship.lib
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using battleship;
    //area is an abstract class that forms the basis for rows or columns of coordinates
    public abstract class Area
    {
        private List<Coordinate> coords;
        public List<Coordinate> Coords { get => coords; }

        public Area(List<Coordinate> _coords)
        {
            //ensure the coordinates draw a straight line
            if (!this.validateCoords(_coords))
            {
                throw new System.ArgumentException("The coordinates provided were not in the same area", "original");
            }
            coords = _coords;
        }

        //print the coordinates in the area
        public string getShipLocations()
        {
            String outstr = "";
            foreach (var item in this.coords)
            {
                outstr += item.getShipLocations();
            }
            return outstr;
        }

        //print the coordinates in the area
        public override string ToString()
        {
            String outstr = "";
            foreach (var item in this.coords)
            {
                outstr += item.ToString();
            }
            return outstr;
        }

        //abstract validation class. Different for rows and columns
        public abstract bool validateCoords(List<Coordinate> _coords);
    }

}