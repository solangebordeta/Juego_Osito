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
        private ScoreManager scoreManager = new ScoreManager();

        private Character player = new Character(new Vector2(480, 400));
        public Character Player => player;

        public Obstacle Obstacle => Obstacle;

        private Fish fish;
        public Fish Fish => fish;

        public IntPtr fontScore = Engine.LoadFont("assets/Font/ARCADE.TTF", 100);

        public void Initialize()
        {
            fish = new Fish(new Vector2(480, 100));
            CreateEnemies();
            _time.Initialize();
            GameObjectList.Add(fish);
            GameObjectList.Add(player);
        }

        public void OnFishPickedUp(int scoreValue)
        {
            scoreManager.OnFishPickedUp(scoreValue);
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

            Engine.DrawText($"Score: {scoreManager.Score}", 10, 10, 200, 0, 0, fontScore);

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
