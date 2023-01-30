using System;
using System.Windows.Forms;

namespace Othelo_UI
{
    public partial class GameSettingsWindow : Form
    {
        private GameWindow m_GameWindow;
        private static int s_BoardSize = 6;
        private static string s_BoardSizeStringFormat { get => "Board Size: {0}x{0} (Click to increase)"; }
        private static string s_BoardSizeMsg { get; set; }
        private static string s_BoardSizeText
        {
            set
            {
                s_BoardSizeMsg = string.Format(s_BoardSizeStringFormat, value);
            }
            get 
            {
                return s_BoardSizeMsg;
            }
        }

        public GameSettingsWindow()
        {
            InitializeComponent();
        }

        private void boardSizeButton_Click(object sender, EventArgs e)
        {
            Button boardSizeBtn = sender as Button;
            s_BoardSize += 2;
            s_BoardSize = s_BoardSize > 12 ? 6 : s_BoardSize;
            s_BoardSizeText = s_BoardSize.ToString();
            boardSizeBtn.Text = s_BoardSizeText; 
        }

        private void playComputerButton_Click(object sender, EventArgs e)
        {
            bool isComputer = true;
            StartNewGame(isComputer);
        }

        private void playHumanButton_Click(object sender, EventArgs e)
        {
            bool isComputer = false;
            StartNewGame(isComputer);
        }

        private void StartNewGame(bool i_IsComputer)
        {
            Hide();
            m_GameWindow = new GameWindow(s_BoardSize,i_IsComputer);
            m_GameWindow.ShowDialog();
            Close();
        }
    }
}
