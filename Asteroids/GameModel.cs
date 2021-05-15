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
        private List<GameObject> AllGameObjects { get; set; } = new List<GameObject>();
        private Random Random { get; set; } = new Random();
        private Rectangle BattleField;
        private BattleShip BattleShip { get; set; }

        public GameModel(IGameBattlefieldView gameView)
        {
            GameView = gameView;
            BattleField = new Rectangle(0, 0, gameView.Width, gameView.Height);
            GameView.KeyDown += GameView_KeyDown;

            InitializeGameObjects();

            // To do: сделать обновление экрана отдельным таймером
            Timer timer = new Timer();
            timer.Interval = 60;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void GameView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    Up();
                    break;
                case Keys.S:
                case Keys.Down:
                    Down();
                    break;
                case Keys.Space:
                    Shot();
                    break;
            }
        }

        private void Up()
        {
            var battleShipRectangle = BattleShip.Rectangle;
            battleShipRectangle.Y -= 10;
            var outOfBounds = OutOfBounds.Calculate(battleShipRectangle, BattleField);
            if (outOfBounds == 0)
            {
                BattleShip.SetPosition(battleShipRectangle.Location); 
            }
        }

        private void Down()
        {
            var battleShipRectangle = BattleShip.Rectangle;
            battleShipRectangle.Y += 10;
            var outOfBounds = OutOfBounds.Calculate(battleShipRectangle, BattleField);
            if (outOfBounds == 0)
            {
                BattleShip.SetPosition(battleShipRectangle.Location);
            }
        }

        private void Shot()
        {

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
                var outOfBounds = OutOfBounds.Calculate(gameObject.Rectangle, BattleField);
                gameObject.Redirect(outOfBounds);                
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
            InitializeGameBackground(Resources.background);
            InitializePlanet();
            InitializeAsteroids(15);
            InitializeStars(25);
            InitializeBattleShip();
        }

        private void InitializeGameBackground(Image background)
        {
            var gameObject = new GameBackground(new Point(), new Point(), new Size(GameView.Width, GameView.Height))
            {
                Image = background
            };

            AllGameObjects.Add(gameObject);
        }

        private void InitializePlanet()
        {
            var planet = new GameBackground(new Point(100, 100), new Point(), new Size(200, 200))
            {
                Image = Resources.planet
            };

            AllGameObjects.Add(planet);
        }

        private void InitializeAsteroids(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var size = Random.Next(10, 50);
                var asteroid = new Asteroid(new Point(600, i * 20 + 10), new Point(-i - 1, -i - 1), new Size(size, size))
                {
                    Image = Resources.meteorBrown_big1
                };

                AllGameObjects.Add(asteroid);
            }
        }
        private void InitializeStars(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var size = Random.Next(10, 20);
                var asteroid = new Star(new Point(600, i * 20 + 10),
                                        new Point(Random.Next(-1, 1), Random.Next(-1, 1)),
                                        new Size(size, size))
                {
                    Image = Resources.star2
                };

                AllGameObjects.Add(asteroid);
            }
        }

        private void InitializeBattleShip()
        {
            var position = new Point(60, GameView.Height / 2);
            BattleShip = new BattleShip(position, new Point(0, 0), new Size(37, 50))
            {
                Image = Resources.ship
            };

            AllGameObjects.Add(BattleShip);
        }

    }
}
