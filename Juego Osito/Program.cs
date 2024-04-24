using System;
using System.Collections.Generic;
using Tao.Sdl;

namespace MyGame
{

    class Program
    {
                    
        static IntPtr image = Engine.LoadImage("assets/background.png");
        static public List<Obstacle> ObstacleList = new List<Obstacle>();
        static public List<Bullet> BulletList = new List<Bullet>();
        private static Time _time;

        static Character player = new Character(new Vector2(480,400));

        static void Main(string[] args)
        {
            Engine.Initialize();
            CreateEnemies();
            _time.Initialize();

            while (true)
            {

                GameManager.Instance.Update();
                GameManager.Instance.Render();

                Sdl.SDL_Delay(20);
            }
        }

        public static void Render()
        {
            Engine.Clear();

            Engine.Draw(image, 0, 0);

            
            
            for (int i = 0; i < BulletList.Count; i++)
            {
                BulletList[i].Render();
            }
            
            for (int i = 0; i < ObstacleList.Count; i++)
            {
                ObstacleList[i].Render();
            }

            player.Render();

            Engine.Show();
        }

        public static void Update()
        {
            player.Update();
            
            for(int i = 0; i < BulletList.Count; i++)
            {
                BulletList[i].Update();
            }

            for (int i = 0; i < ObstacleList.Count; i++)
            {
                ObstacleList[i].Update();
            }

            _time.Update();
        }

        private static void CreateEnemies()
        {
            int cellSize = 250;

            int xOffset = 200;

            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((i + j) % 3 == 0 || (i + j) % 2 == 0)
                    {
                        ObstacleList.Add(new Obstacle(new Vector2(xOffset + j * cellSize, -100 - i * cellSize)));
                    }
                }
            }
        }

    }

}
