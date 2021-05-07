using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    class GameModel
    {
        private IGameBattlefieldView GameView { get; set; }
        private List<GameObject> AllGameObjects = new List<GameObject>();
        private Random Random = new Random();

        public GameModel(IGameBattlefieldView gameView)
        {
            GameView = gameView;
            InitializeGameObjects();

            // To do: сделать обновление экрана отдельным таймером
            Timer timer = new Timer();
            timer.Interval = 60;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        private void Update()
        {
            foreach (var gameObject in AllGameObjects)
            {
                gameObject.Update();

                // To do: вынести логику перенаправления полёта в отдельное место
                if (gameObject.Position.X < 0 || gameObject.Position.X > GameView.Width)
                    gameObject.Direction = new Point(-gameObject.Direction.X, gameObject.Direction.Y);

                if (gameObject.Position.Y < 0 || gameObject.Position.Y > GameView.Height)
                    gameObject.Direction = new Point(gameObject.Direction.X, -gameObject.Direction.Y);
            }
        }

        public void Draw()
        {
            GameView.BufferedGraphics.Graphics.Clear(Color.Black);            

            foreach(var gameObject in AllGameObjects)
            {
                gameObject.Draw(GameView.BufferedGraphics.Graphics);
            }

            GameView.BufferedGraphics.Render();
        }

        private void InitializeGameObjects()
        {
            // To do: Разбить всё на отдельные методы.
            
            GameObject gameObject = new GameBackground(new Point(), new Point(), new Size(GameView.Width, GameView.Height))
            {
                Image = Resources.background
            };

            AllGameObjects.Add(gameObject);

            gameObject = new GameBackground(new Point(100, 100), new Point(), new Size(200, 200))
            {
                Image = Resources.planet
            };

            AllGameObjects.Add(gameObject);

            for (int i = 0; i < 15; i++)
            {
                var size = Random.Next(10, 50);
                gameObject = new Asteroid(new Point(600, i * 20 + 10), new Point(-i - 1, -i - 1), new Size(size, size))
                {
                    Image = Resources.meteorBrown_big1
                };

                AllGameObjects.Add(gameObject);

                gameObject = new Star(new Point(600, i * 40 + 10), new Point(-i - 1, -i - 1), new Size(5, 5))
                {
                    Image = Resources.star1
                };

                AllGameObjects.Add(gameObject);

                gameObject = new Bullet(new Point(0, GameView.Height / 2), new Point(25, 0), new Size(54, 9))
                {
                    Image = Resources.laserRed011
                };

                AllGameObjects.Add(gameObject);
            }            
        }


    }
}
