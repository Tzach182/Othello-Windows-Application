namespace Othello_Logic
{
    public class Coordinate
    {
        public Coordinate(int i_Row, int i_Column)
        {
            Row = i_Row;
            Column = i_Column;
        }

        public int Row { get; set; }
        public int Column { get; set; }
    }
}
