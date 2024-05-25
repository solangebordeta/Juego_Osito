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
        static public List<GameObject> GameObjectList = new List<GameObject>();
        private static Time _time;

        static Character player = new Character(new Vector2(480, 400));
        static Fish fish = new Fish(new Vector2(480, 400));

        public void Initialize()
        {
            System.Console.WriteLine("Hola MUNDO!!");
            CreateEnemies();
            _time.Initialize();
        }

        public void Render()
        {
            Engine.Clear();

            Engine.Draw(image, 0, 0);

            for (int i = 0; i < GameObjectList.Count; i++)
            {
                GameObjectList[i].Render();
            }

            player.Render();

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
                        GameObjectList.Add(new Obstacle(new Vector2(xOffset + j * cellSize, -100 - i * cellSize)));
                    }
                }
            }
        }


    }
}
