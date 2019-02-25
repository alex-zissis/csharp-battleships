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

        public void assignShip(Ship _ship)
        {
            string shipType = _ship.ShipArea.GetType().ToString();
            Area _shipArea = _ship.ShipArea;
            if (shipType == "Row")
            {
                for (int i = _shipArea.Coords[0].Y; i < _shipArea.Coords[0].Y + _shipArea.Coords.Count - 1; i++)
                {
                    if (this.rows[_shipArea.Coords[0].X].Coords[i].ShipFilled != null)
                    {
                        throw new System.ArgumentException("The area you selected already has a ship at " + this.rows[_shipArea.Coords[0].X].Coords[i]);
                    }
                }

                for (int i = _shipArea.Coords[0].Y; i < _shipArea.Coords[0].Y + _shipArea.Coords.Count - 1; i++)
                {
                    this.rows[_shipArea.Coords[0].X].Coords[i].ShipFilled = _ship;
                }
            }
            else
            {
                for (int i = _shipArea.Coords[0].X; i < _shipArea.Coords[0].X + _shipArea.Coords.Count - 1; i++)
                {
                    if (this.rows[_shipArea.Coords[0].Y].Coords[i].ShipFilled != null)
                    {
                        throw new System.ArgumentException("The area you selected already has a ship at " + this.rows[_shipArea.Coords[0].Y].Coords[i]);
                    }
                }

                for (int i = _shipArea.Coords[0].X; i < _shipArea.Coords[0].X + _shipArea.Coords.Count - 1; i++)
                {
                    this.rows[_shipArea.Coords[0].Y].Coords[i].ShipFilled = _ship;
                }
            }
        }


        private List<Row> genRows(int _xSize, int _ySize)
        {
            List<Row> outRows = new List<Row>();
            for (int i = 0; i < _xSize; i++)
            {
                List<Coordinate> listCoords = new List<Coordinate>();
                for (int k = 0; k < _ySize; k++)
                {
                    listCoords.Add(new Coordinate(i, k));
                }
                outRows.Add(new Row(listCoords));
            }
            return outRows;
        }

        public string getShipLocations()
        {
            string outStr = this.formatColumnHeaders(rows[0]);
            int ctr = 0;
            foreach (var row in this.rows)
            {
                outStr += ctr + " | " + row.getShipLocations() + "\n";
                ctr++;
            }
            return outStr;
        }

        public override string ToString()
        {
            string outStr = this.formatColumnHeaders(rows[0]);
            int ctr = 0;
            foreach (var row in this.rows)
            {
                outStr += ctr + " | " + row.ToString() + "\n";
                ctr++;
            }
            return outStr;
        }

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