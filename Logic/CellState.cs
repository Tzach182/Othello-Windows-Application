namespace Othello_Logic
{
    public enum eCellState
    {
        Free,
        Disabled,
        Black,
        White
    }

    public delegate void CellStateChangedEventHandler(Coordinate coordinate, eCellState newState);

    public class CellState
    {
        private eCellState _state;
        public event CellStateChangedEventHandler StateChanged;
        public Coordinate Coordinate { get; }

        public CellState(Coordinate coordinate)
        {
            _state = eCellState.Disabled;
            Coordinate = coordinate;
        }

        public eCellState State
        {
            get => _state;
            set { _state = value; StateChanged?.Invoke(Coordinate, _state); }
        }
    }
}
