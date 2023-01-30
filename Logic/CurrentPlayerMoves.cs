using System.Collections.Generic;

namespace Othello_Logic
{
    class CurrentPlayerMoves
    {
        private Dictionary<string, List<Coordinate>> m_AvailablePlayerMoves;
        private Board m_Board;
        public bool HasAnyMove => m_AvailablePlayerMoves.Count > 0;

        public CurrentPlayerMoves(Board i_Board)
        {
            m_Board = i_Board;
        }

        private string CreateKey(int i_Row, int i_Column)
        {
            return $"{i_Row}_{i_Column}";
        }

        private bool isInsideBoard(int i_Row, int i_Column)
        {
            return i_Row >= 0 && i_Row < m_Board.m_Size && i_Column >= 0 && i_Column < m_Board.m_Size;
        }

        private List<Coordinate> MoveInDirection(Coordinate i_Location, eCellState i_OpponentValue, int i_RowDirection, int i_ColumnDirection)
        {
            List<Coordinate> movesInDirection = new List<Coordinate>();
            int row = i_Location.Row + i_RowDirection;
            int column = i_Location.Column + i_ColumnDirection;

            while (isInsideBoard(row, column) && !m_Board.IsCellEmpty(row,column))
            {
                if (m_Board.GetCellValue(row, column) == i_OpponentValue)
                {
                    movesInDirection.Add(new Coordinate(row, column));
                    row += i_RowDirection;
                    column += i_ColumnDirection;
                }
                else
                {
                    return movesInDirection;
                }
            }

            return new List<Coordinate>();
        }

        private List<Coordinate> AllCoordinatesForFlipping(Coordinate i_Location, eCellState i_OpponentValue)
        {
            List<Coordinate> AllCoordinates = new List<Coordinate>();

            for (int rowDirection = -1; rowDirection <= 1; rowDirection++)
            {
                for (int colDirection = -1; colDirection <= 1; colDirection++)
                {
                    if (rowDirection == 0 && colDirection == 0)
                    {
                        continue;
                    }

                    AllCoordinates.AddRange(MoveInDirection(i_Location, i_OpponentValue, rowDirection, colDirection));
                }
            }

            return AllCoordinates;
        }

        public Dictionary<string, List<Coordinate>> AllCurrentPlayerMoves(eCellState i_OpponentValue)
        {
            m_AvailablePlayerMoves = new Dictionary<string, List<Coordinate>>();

            for (int row = 0; row < m_Board.m_Size; row++)
            {
                for (int column = 0; column < m_Board.m_Size; column++)
                {
                    Coordinate location = new Coordinate(row, column);

                    if (m_Board.IsCellEmpty(location.Row, location.Column))
                    {
                        List<Coordinate> locationMoves = AllCoordinatesForFlipping(location, i_OpponentValue);

                        if (locationMoves.Count > 0)
                        {
                            m_Board.SetCellValue(eCellState.Free, row, column);
                            string key = CreateKey(location.Row, location.Column);
                            locationMoves.Add(location);
                            m_AvailablePlayerMoves[key] = locationMoves;
                        }
                    }
                }
            }

            return m_AvailablePlayerMoves;
        }

        public List<Coordinate> GetFlippableList(Coordinate i_Location)
        {
            string key = CreateKey(i_Location.Row, i_Location.Column);
            return m_AvailablePlayerMoves.ContainsKey(key) ? m_AvailablePlayerMoves[key] : new List<Coordinate>();
        }

        public List<Coordinate> GetAvailableComputerMoves()
        {
            List<Coordinate> moves = new List<Coordinate>();

            foreach (var key in m_AvailablePlayerMoves.Keys)
            {
                int row, column;
                string[] rowAndCol = key.Split('_');
                row = int.Parse(rowAndCol[0]);
                column = int.Parse(rowAndCol[1]);
                moves.Add(new Coordinate(row, column));
            }

            return moves;
        }
    }
}
