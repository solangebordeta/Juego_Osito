using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tao.Sdl;

namespace MyGame
{
    public class Character
    {
        private Transform transform;
        private Animation walk;
        private Animation lose;
        private Animation currentAnimation;
        private CharacterController controller;
        IntPtr image = Engine.LoadImage("assets/obstacle.png");


        public Character(Vector2 position)
        {
            transform = new Transform(position, new Vector2(100, 100));
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
            List<IntPtr> walkingTextures = new List<IntPtr>();
            for (int i = 0; i < 4; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Obstacle/Idle/{i}.png");
                walkingTextures.Add(frame);
            }
            walk = new Animation("Walk", walkingTextures, 0.2f, true);
            currentAnimation = walk;

            List<IntPtr> losingTextures = new List<IntPtr>();
            for (int i = 0; i < 8; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Obstacle/Explosion/{i}.png");
                losingTextures.Add(frame);
            }
            lose = new Animation("Lose", walkingTextures, 0.2f, true);
            currentAnimation = lose;
        }

        public void ChangeAnimation()
        {
            currentAnimation = lose;
        }

        //quiero hacer un delay para que cuando pierda, 
        //no aparezca al toque la pantalla de derrota
        //asi se aprecia la animacion

        /*private void DelayAfterLosing(int delay) 
        {
            timeDelay = 3;

            
        }*/

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
                    ChangeAnimation();
                    
                    GameManager.Instance.ChangeGameStatus(GameManager.GameStatus.lose);
                    

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
