namespace battleship.lib
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using battleship;
    //the board class. Contains a list of rows
    public class Board
    {
        private List<Row> rows;
        private int shipCount;
        public List<Row> Rows { get => rows; }

        public int ShipCount { get => shipCount; set => shipCount = value; }

        public Board(int _xSize, int _ySize)
        {
            rows = this.genRows(_xSize, _ySize);
        }
        //assigns coordinates on board to a ship
        public void assignShip(Ship _ship)
        {
            string shipType = _ship.ShipArea.GetType().ToString();
            Area _shipArea = _ship.ShipArea;
            if (shipType == "battleship.lib.Row")
            {
                //loop through the column to ensure its empty
                int row = _shipArea.Coords[0].Y;
                int firstX = _shipArea.Coords[0].X;
                for (int i = firstX; i < firstX + _shipArea.Coords.Count; i++)
                {
                    if (this.rows[row].Coords[i].ShipFilled != null)
                    {
                        throw new System.ArgumentException("The area you selected already has a ship at " + this.rows[row].Coords[i]);
                    }
                }

                for (int i = firstX; i < firstX + _shipArea.Coords.Count; i++)
                {
                    this.rows[row].Coords[i].ShipFilled = _ship;
                }
            }
            else
            {
                //loop through the column to ensure its empty
                int column = _shipArea.Coords[0].X;
                int firstY = _shipArea.Coords[0].Y;

                for (int i = firstY; i < firstY + _shipArea.Coords.Count; i++)
                {
                    if (this.rows[i].Coords[column].ShipFilled != null)
                    {
                        throw new System.ArgumentException("The area you selected already has a ship at " + this.rows[i].Coords[column]);
                    }
                }

                for (int i = firstY; i < firstY + _shipArea.Coords.Count; i++)
                {
                    this.rows[i].Coords[column].ShipFilled = _ship;
                }
            }
        }

        //generate starting rows
        private List<Row> genRows(int _xSize, int _ySize)
        {
            List<Row> outRows = new List<Row>();
            for (int i = 0; i < _xSize; i++)
            {
                List<Coordinate> listCoords = new List<Coordinate>();
                for (int k = 0; k < _ySize; k++)
                {
                    listCoords.Add(new Coordinate(k, i));
                }
                outRows.Add(new Row(listCoords));
            }
            return outRows;
        }
        //get a display of all the coordinates that have a ship attached
        public string getShipLocations()
        {
            string outStr = this.formatColumnHeaders(rows[0]);
            int ctr = 1;
            foreach (var row in this.rows)
            {
                String startstr = "";
                if (ctr < 10)
                {
                    startstr = ctr + " ";
                }
                else
                {
                    startstr = ctr.ToString();
                }
                outStr += startstr + "| " + row.getShipLocations() + "\n";
                ctr++;
            }
            return outStr;
        }
        //returns where or not the coordinate has been guessed
        public bool isGuessed(Coordinate coord)
        {
            return this.rows[coord.Y].Coords[coord.X].Guessed;
        }

        //returns whether a coordinate has been filled by a ship
        public Ship getFilledShip(Coordinate coord)
        {
            return this.rows[coord.Y].Coords[coord.X].ShipFilled;
        }
        //returns whether a guess hit a ship
        public bool isGuessGood(Coordinate coord)
        {
            this.rows[coord.Y].Coords[coord.X].Guessed = true;
            Ship ship = this.getFilledShip(coord);
            if (ship != null)
            {
                ship.setGuessed(coord);
                return true;
            }
            else
            {
                return false;
            }
        }
        //overides to string to print all the rows
        public override string ToString()
        {
            string outStr = this.formatColumnHeaders(rows[0]);
            int ctr = 1;
            foreach (var row in this.rows)
            {
                String startstr = "";
                if (ctr < 10)
                {
                    startstr = ctr + " ";
                }
                else
                {
                    startstr = ctr.ToString();
                }
                outStr += startstr + "| " + row.ToString() + "\n";
                ctr++;
            }
            return outStr;
        }
        //formats rows headers from a char array into the ouput format.
        private String formatColumnHeaders(Row row)
        {
            char[] colHeaders = Helpers.getColumnHeadings(row.Coords.Count);
            string outStr = "  | ";
            foreach (var c in colHeaders)
            {
                outStr += " " + c + " ";
            }
            return outStr += "\n";
        }
    }
}