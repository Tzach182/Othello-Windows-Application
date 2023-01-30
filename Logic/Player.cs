namespace Othello_Logic
{
    public class Player
    {
        public Player(string i_Name, bool i_IsComputer)
        {
            m_Name = i_Name;
            m_IsComputer = i_IsComputer;
        }

        public string m_Name { get; set; }
        public bool m_IsComputer { get; set; }
    }
}
