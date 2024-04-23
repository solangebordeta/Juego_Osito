﻿using System;
using System.Collections.Generic;
using Tao.Sdl;

namespace MyGame
{

    class Program
    {
<<<<<<< Updated upstream
                    
        static IntPtr image = Engine.LoadImage("assets/fondo.png");
=======
        
        static IntPtr image = Engine.LoadImage("assets/background.png");
>>>>>>> Stashed changes
        static public List<Obstacle> ObstacleList = new List<Obstacle>();
        static public List<Bullet> BulletList = new List<Bullet>();
        private static Time _time;

<<<<<<< Updated upstream
        static Character player = new Character(new Vector2(400,700));
=======
        static Character player = new Character(new Vector2(480, 400));
>>>>>>> Stashed changes

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
            int cellSize = 200;

            int xOffset = 270;

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
