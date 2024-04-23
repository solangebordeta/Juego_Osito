using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Character
    {
        private Transform transform;
        private Animation run;
        private Animation lose;
        private Animation currentAnimation;
        private CharacterController controller;
        IntPtr image = Engine.LoadImage("assets/bear.png");
        

        public Character(Vector2 position) {
            transform = new Transform(position, new Vector2(100,100));
            controller = new CharacterController(transform);
            CreateAnimations();
        }

        public void Render()
        {
            transform.Position = new Vector2(200, 200);
            Engine.Draw(currentAnimation.CurrentFrame, transform.Position.x, transform.Position.y);
        }

        public void CreateAnimations()
        {
            List<IntPtr> runningTextures = new List<IntPtr>();
            for (int i = 0; i < 2; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Bear/walking/{i}.png");
                runningTextures.Add(frame);
            }
            run = new Animation("run", runningTextures, 0.2f, true);
            currentAnimation = run;

            List<IntPtr> losingTextures = new List<IntPtr>();
            for (int i = 0; i < 15; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Bear/loser/{i}.png");
                losingTextures.Add(frame);
            }
            lose = new Animation("lose", losingTextures, 0.2f, true);
            
        }

        public void CheckCollisions()
        {
            for (int i = 0; i < Program.ObstacleList.Count; i++)
            {
                Obstacle obstacle = Program.ObstacleList[i];
                float distanceX = Math.Abs((obstacle.Transform.Position.x + (obstacle.Transform.Scale.x / 2)) - (transform.Position.x + (transform.Scale.x / 2)));
                float distanceY = Math.Abs((obstacle.Transform.Position.y + (obstacle.Transform.Scale.y / 2)) - (transform.Position.y + (transform.Scale.y / 2)));
                float sumHalfWidth = obstacle.Transform.Scale.x / 2 + transform.Scale.x / 2;
                float sumHalfHeight = obstacle.Transform.Scale.y / 2 + transform.Scale.y / 2;

                if (distanceX < sumHalfWidth && distanceY < sumHalfHeight)
                {
                    Console.WriteLine("Colisión detectada!");
                    Program.ObstacleList.Remove(obstacle);
                }
            }
        }
        public void Update()
        {
            controller.GetInputs();
            currentAnimation.Update();
            CheckCollisions();

            
        }


    }
}
