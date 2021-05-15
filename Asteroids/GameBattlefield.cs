using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    class GameBattlefield : Form, IGameBattlefieldView
    {
        int IGameBattlefieldView.Width => ClientSize.Width;
        int IGameBattlefieldView.Height => ClientSize.Height;

        private GameModel GameModel { get; set; }
        public BufferedGraphics BufferedGraphics { get; private set; }

        public GameBattlefield(int width, int height)
        {
            ClientSize = new Size(width, height);
            Initialize();

            GameModel = new GameModel(this);

            
        }

        private void Initialize()
        {
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(800, 600);
            MaximumSize = new System.Drawing.Size(800, 600);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Asteroids";

            var bufferedGraphicsContext = BufferedGraphicsManager.Current;
            var battleFieldRectangle = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
            BufferedGraphics = bufferedGraphicsContext.Allocate(CreateGraphics(), battleFieldRectangle);            
        }





    }
}
