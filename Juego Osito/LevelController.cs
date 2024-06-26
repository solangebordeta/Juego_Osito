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
        private Fish fish;
        public IntPtr fontScore = Engine.LoadFont("assets/Font/ARCADE.TTF", 75);
        private List<Obstacle> obstacles = new List<Obstacle>();
        private const int maxObstacles = 15;
        public void Initialize()
        {
            fish = new Fish(new Vector2(480, 100));
            CreateInitialObstacles();
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
            CheckObstacles();
        }

        private void CreateInitialObstacles()
        {
            for (int i = 0; i < maxObstacles; i++)
            {
                Vector2 position = GetRandomOffscreenPosition();
                Obstacle obstacle = ObstacleFactory.CreateObstacles(position, Obstacles.arbol);
                obstacles.Add(obstacle);
                GameObjectList.Add(obstacle);
            }
        }

        public Vector2 GetRandomOffscreenPosition()
        {
            Random rand = new Random();
            int xOffset = rand.Next(200, 800);
            int yOffset = rand.Next(-600, -100);
            return new Vector2(xOffset, yOffset);
        }

        private void CheckObstacles()
        {
            foreach (var obstacle in obstacles)
            {
                if (obstacle.Transform.Position.y > 900)
                {
                    obstacle.Reposition(GetRandomOffscreenPosition());
                }
            }
        }
    }
}
