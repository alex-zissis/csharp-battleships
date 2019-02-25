namespace battleship.lib
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using battleship;
    public static class Helpers
    {
        public static List<int> getIntsInRange(int _startNum, int _endNum)
        {
            List<int> numList = new List<int>();
            for (int i = _startNum; i <= _endNum; i++)
            {
                numList.Add(i);
            }

            return numList;
        }

        public static List<Coordinate> getAllCoordsInRange(int coordStatic, List<int> coordVar, bool horizontal)
        {
            List<Coordinate> outList = new List<Coordinate>();
            foreach (var item in coordVar)
            {
                Coordinate coord = horizontal ? new Coordinate(coordStatic, item) : new Coordinate(item, coordStatic);
                outList.Add(coord);
            }
            return outList;
        }

        public static Coordinate getCoordsFromPoint(string point, int xSize, int ySize)
        {
            point = point.ToUpper();
            if (point.Length != 2)
            {
                throw new System.ArgumentException("Invalid length. Ensure you enter the position in the format \"A1\"");
            }

            int x = Encoding.ASCII.GetBytes(point)[0] - 65;

            if (x > 25 || x < 0)
            {
                throw new System.ArgumentException("Ensure the first charecter is a letter, e.g. F1");
            }
            int y = new int();
            try
            {
                y = Int32.Parse(point[1].ToString()) - 1;
            }
            catch (System.FormatException)
            {
                throw new System.ArgumentException("Ensure the second charecter is a number, e.g. A1");
            }
            if (x >= xSize - 1)
            {
                throw new System.ArgumentException("Your X coordinate was too big. Remeber the size of the board is " + xSize + " (and you can't start on postion " + (xSize - 1));
            }

            if (y >= ySize - 1)
            {
                throw new System.ArgumentException("Your Y coordinate was too big. Remeber the size of the board is " + ySize + " (and you can't start on postion " + (ySize - 1));
            }

            return new Coordinate(x, y);
        }

        public static char[] getColumnHeadings(int amount)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return alphabet.Take(amount).ToArray();
        }
    }
}