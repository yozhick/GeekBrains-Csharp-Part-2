﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        static Asteroid[] _asteroids;
        static Asteroid[] _stars;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static void Init(Form form)
        {
            Graphics g = form.CreateGraphics();
            _context = BufferedGraphicsManager.Current;
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer();
            timer.Interval = 60;
            timer.Tick += OnTime;
            timer.Start();
        }

        private static void OnTime(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 200, 200));

            foreach (Asteroid asteroid in _asteroids)
                asteroid.Draw();

            foreach (Asteroid star in _stars)
                star.Draw();


            Buffer.Render();
        }

        public static void Load()
        {
            var random = new Random();

            _asteroids = new Asteroid[15];
            for (int i = 0; i < _asteroids.Length; i++)
            {
                var size = random.Next(10, 50);
                _asteroids[i] = new Asteroid(new Point(600, i * 20 + 10), new Point(-i - 1, -i - 1), new Size(size, size));
            }

            _stars = new Asteroid[20];
            for (int i = 0; i < _stars.Length; i++)
            {
                _stars[i] = new Star(new Point(600, i * 40 + 10), new Point(-i - 1, -i - 1), new Size(5, 5));
            }
        }

        public static void Update()
        {
            foreach (Asteroid asteroid in _asteroids)
                asteroid.Update();

            foreach (Asteroid star in _stars)
                star.Update();
        }

    }
}
