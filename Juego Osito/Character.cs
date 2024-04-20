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
        private Animation idleAnimation;
        private Animation currentAnimation;
        private CharacterController controller;
        IntPtr image = Engine.LoadImage("assets/player.png");


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

        private void CreateAnimations()
        {
            List<IntPtr> idleTextures = new List<IntPtr>();
            for (int i = 0; i < 4; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Ship/Idle/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true);
            currentAnimation = idleAnimation;
        }

        private void CheckCollisions()
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
