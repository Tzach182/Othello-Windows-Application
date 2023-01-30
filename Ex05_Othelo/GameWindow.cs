using Othello_Logic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Othelo_UI
{
    public partial class GameWindow : Form
    {
        private readonly BoardButton[,] r_Buttons;
        private Panel m_Container = new Panel();
        private GameLogic m_GameLogic;
        public GameWindow(int boardSize, bool isComputer)
        {
            GameSettings gameSettings = new GameSettings(2)
            {
                m_MatrixSize = boardSize,
            };

            InitializeComponent();
            r_Buttons = new BoardButton[boardSize, boardSize];
            FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeButtons(boardSize);
            gameSettings.m_Players[0] = new Player("Red", false);
            gameSettings.m_Players[1] = new Player("Yellow", isComputer);
            m_GameLogic = new GameLogic(gameSettings);
            m_GameLogic.BoardChanged += GameLogic_BoardChanged;
            m_GameLogic.InitGame();
            PlayGame();
        }

        private void PlayGame()
        {
            this.Text = string.Format("Othello - {0}'s Turn", m_GameLogic.m_CurrentPlayer.m_Name);
            GameReport gameStatus = m_GameLogic.CheckHasAnyMove();
            if (gameStatus.m_GameStatus == eGameStatuses.GameOver)
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("{0} Won!! ({2}/{3}) ({4}/{5}){1}Would you like another round?",
                    gameStatus.m_Winner.m_Name, Environment.NewLine, gameStatus.m_WinnerPoints, gameStatus.m_LoserPoints, GameReport.s_PlayerOneWinGames, GameReport.s_PlayerTwoWinGames), "Othello", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.No)
                {
                    this.Close();
                    return;
                }

                m_GameLogic.InitGame();
                PlayGame();
            }
            else if (gameStatus.m_MoveStatus == eMoveStatuses.MoveSkipped)
            {
                MessageBox.Show(string.Format("No moves, turn skipped"));
                Update();
                PlayGame();
            }
            else if (m_GameLogic.m_CurrentPlayer.m_IsComputer)
            {
                Update();
                m_GameLogic.MakeMove(new Coordinate(0, 0));
                PlayGame();
            }
           
        }

        private void GameLogic_BoardChanged(int i_Row, int i_Col, eCellState newState)
        {
            r_Buttons[i_Row, i_Col].ButtonState = newState;
        }

        public void InitializeButtons(int i_BoardSize)
        {
            var size = i_BoardSize * 60;
            Size = new Size(size, size + 20);

            for (int i = 0; i < i_BoardSize; i++)
            {
                for (int j = 0; j < i_BoardSize; j++)
                {
                    r_Buttons[i, j] = new BoardButton(new Coordinate(i, j));
                    r_Buttons[i, j].Size = new Size(50, 50);
                    r_Buttons[i, j].Location = new Point(j * 60, i * 60);
                    r_Buttons[i, j].Click += new EventHandler(button_Click);
                    m_Container.Controls.Add(r_Buttons[i, j]);
                }
            }

            m_Container.Dock = DockStyle.Fill;
            Controls.Add(m_Container);
        }

        private void button_Click(object sender, EventArgs e)
        {
            BoardButton button = (BoardButton)sender;
            m_GameLogic.MakeMove(button.Coordinate);
            PlayGame();
        }
    }
}
