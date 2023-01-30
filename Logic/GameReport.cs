namespace Othello_Logic
{
    public class GameReport
    {
        public static int s_PlayerOneWinGames { get; set; }
        public static int s_PlayerTwoWinGames { get; set; }
        public eGameStatuses m_GameStatus { get; internal set; }
        public eMoveStatuses m_MoveStatus { get; internal set; }
        public Player m_Winner { get; internal set; }
        public Player m_Loser { get; internal set; }
        public int m_WinnerPoints { get; internal set; }
        public int m_LoserPoints { get; internal set; }
        public string m_LastMovePlayerName { get; internal set; }
    }
}
