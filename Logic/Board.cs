namespace Othello_Logic
{
    public class Board
    {
        private CellState[,] m_Matrix;
        public int m_Size => m_Matrix.GetLength(0);
        public bool m_IsFull => GetIsFull();

        public event BoardChangedEventHandler BoardChanged;

        public Board(int i_MatrixSize)
        {
            m_Matrix = new CellState[i_MatrixSize, i_MatrixSize];
        }

        public void InitializeBoard()
        {
            int matrixSize = m_Matrix.GetLength(0);
            int middleLocation = matrixSize / 2 - 1;

            for (int rows = 0; rows < matrixSize; rows++)
            {
                for (int cols = 0; cols < matrixSize; cols++)
                {
                    m_Matrix[rows, cols] = new CellState(new Coordinate(rows, cols));
                    m_Matrix[rows, cols].StateChanged += Cell_StateChanged;
                    m_Matrix[rows, cols].StateChanged += Cell_StateChanged;
                    m_Matrix[rows, cols].State = eCellState.Disabled;
                }
            }

            m_Matrix[middleLocation, middleLocation].State = eCellState.White;
            m_Matrix[middleLocation + 1, middleLocation].State = eCellState.Black;
            m_Matrix[middleLocation, middleLocation + 1].State = eCellState.Black;
            m_Matrix[middleLocation + 1, middleLocation + 1].State = eCellState.White;

        }

        private void Cell_StateChanged(Coordinate coordinate, eCellState newState)
        {
            BoardChanged?.Invoke(coordinate.Row, coordinate.Column, newState);
        }

        private bool GetIsFull()
        {
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    if (IsCellEmpty(i,j))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        internal void SetCellValue(eCellState newValue, int i_Row, int i_Column)
        {
            m_Matrix[i_Row, i_Column].State = newValue;
        }

        public eCellState GetCellValue(int i_Row, int i_Column)
        {
            return m_Matrix[i_Row, i_Column].State;
        }

        public bool IsCellEmpty(int i_Row, int i_Column)
        {
            return m_Matrix[i_Row, i_Column].State == eCellState.Free
                || m_Matrix[i_Row, i_Column].State == eCellState.Disabled;
        }

        internal void EmptyCell()
        {
            for (int rows = 0; rows < m_Matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < m_Matrix.GetLength(0); cols++)
                {
                    if(m_Matrix[rows,cols].State == eCellState.Free)
                    {
                        SetCellValue(eCellState.Disabled, rows, cols);
                    }
                }
            }
        }
    }
}
