namespace Othello_Logic
{
    public class GameSettings
    {
        public GameSettings(int i_NumOfPlayers)
        {
            m_Players = new Player[i_NumOfPlayers];
        }

        public int m_MatrixSize { get; set; }
        public Player[] m_Players { get; set; }
    }
}
