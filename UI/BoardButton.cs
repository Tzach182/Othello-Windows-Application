using Othello_Logic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Othelo_UI
{
    public class BoardButton : Button
    {
        private eCellState m_ButtonState = eCellState.Free;
        private Coordinate m_Coordinate;
        
        public BoardButton(Coordinate i_Location)
        {
            m_Coordinate = i_Location;
            ButtonState = eCellState.Disabled;
        }
        public Coordinate Coordinate => m_Coordinate;
        public eCellState ButtonState { get { return m_ButtonState; } set { SetState(value); } }

        protected override void OnClick(EventArgs e)
        {

            if (ButtonState != eCellState.Free)
                return; 

            base.OnClick(e);
        }

        private void SetState(eCellState i_State)
        {

            m_ButtonState = i_State;
            switch(m_ButtonState)
            {
                case eCellState.Disabled:
                    {
                        Enabled = false;
                        this.BackgroundImage = null;
                        this.BackColor = default(Color);
                    }
                    break;
                case eCellState.Free:
                    {
                        Enabled = true;
                        this.BackgroundImage = null;
                        this.BackColor = Color.Green;
                    }
                    break;
                case eCellState.Black:
                    {
                        Enabled = true;
                        this.BackgroundImage = Image.FromFile(Environment.CurrentDirectory+"\\CoinRed.png");
                        this.BackgroundImageLayout = ImageLayout.Stretch;
                        this.BackColor = Color.Gray;
                    }
                    break;
                case eCellState.White:
                    {
                        Enabled = true;
                        this.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\CoinYellow.png");
                        this.BackgroundImageLayout = ImageLayout.Stretch;
                        this.BackColor = Color.Gray;
                    }
                    break;
            }
        }
    }
}
