

using System;
using System.Collections.Generic;
using Tao.Sdl;

namespace MyGame
{

    class Program
    {
                    
        static IntPtr image = Engine.LoadImage("assets/fondo.png");
        static public List<Obstacle> ObstacleList = new List<Obstacle>();
        static public List<Bullet> BulletList = new List<Bullet>();
        private static Time _time;

        static Character player = new Character(new Vector2(400,700));

        static void Main(string[] args)
        {
            Engine.Initialize();
            CreateEnemies();
            _time.Initialize();

            while (true)
            {

                Update();
                Render();

                Sdl.SDL_Delay(20);
            }
        }

        private static void Render()
        {
            Engine.Clear();

            Engine.Draw(image, 0, 0);

            player.Render();
            
            for (int i = 0; i < BulletList.Count; i++)
            {
                BulletList[i].Render();
            }
            
            for (int i = 0; i < ObstacleList.Count; i++)
            {
                ObstacleList[i].Render();
            }

            Engine.Show();
        }

        private static void Update()
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
            ObstacleList.Add(new Obstacle(new Vector2(0, 0)));
            ObstacleList.Add(new Obstacle(new Vector2(200, 0)));
            ObstacleList.Add(new Obstacle(new Vector2(400, 0)));
            ObstacleList.Add(new Obstacle(new Vector2(600, 0)));
            ObstacleList.Add(new Obstacle(new Vector2(800, 0)));
            ObstacleList.Add(new Obstacle(new Vector2(0, 200)));
            ObstacleList.Add(new Obstacle(new Vector2(200, 200)));
            ObstacleList.Add(new Obstacle(new Vector2(400, 200)));
            ObstacleList.Add(new Obstacle(new Vector2(600, 200)));
            ObstacleList.Add(new Obstacle(new Vector2(800, 200)));
        }



    }

}
