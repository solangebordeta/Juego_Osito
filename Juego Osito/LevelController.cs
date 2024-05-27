using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class LevelController
    {
        private static IntPtr image = Engine.LoadImage("assets/background.png");
        public static List<GameObject> GameObjectList = new List<GameObject>();
        private static Time _time;

        private Character player = new Character(new Vector2(480, 400));
        public Character Player => player;
        private Fish fish = new Fish(new Vector2(480, 100));
        public Fish Fish => fish;

        public void Initialize()
        {
            CreateEnemies();
            _time.Initialize();
            GameObjectList.Add(fish);
            GameObjectList.Add(player);
        }

        public void Render()
        {
            Engine.Clear();

            Engine.Draw(image, 0, 0);

            player.Render();

            for (int i = 0; i < GameObjectList.Count; i++)
            {
                GameObjectList[i].Render();
            }

            Engine.Show();
        }

        public void Update()
        {
            player.Update();
            for (int i = 0; i < GameObjectList.Count; i++)
            {
                GameObjectList[i].Update();
            }
            _time.Update();
        }

        private void CreateEnemies()
        {
            int cellSize = 250;

            int xOffset = 200;

            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((i + j) % 3 == 0 || (i + j) % 2 == 0)
                    {
                        GameObjectList.Add(ObstacleFactory.CreateObstacles(new Vector2(xOffset + j * cellSize, -100 - i * cellSize), Obstacles.arbol));
                    }
                }
            }
        }


    }
}
