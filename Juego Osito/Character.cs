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
    public class Character : GameObject
    {
        
        private Animation walk;
        private Animation lose;   
        private CharacterController controller;
        

        //transform.Position = new Vector2(200, 200);


        public Character(Vector2 position) : base(position)
        {
            controller = new CharacterController(transform);
            CreateAnimations();
        }

  
        private void CreateAnimations()
        {
            List<IntPtr> walkingTextures = new List<IntPtr>();
            for (int i = 0; i < 2; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/osito/walk/{i}.png");
                walkingTextures.Add(frame);
            }
            walk = new Animation("Walk", walkingTextures, 0.2f, true);
            currentAnimation = walk;

            List<IntPtr> losingTextures = new List<IntPtr>();
            for (int i = 0; i < 15; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/osito/lose/{i}.png");
                losingTextures.Add(frame);
            }
            lose = new Animation("Lose", walkingTextures, 0.2f, true);
            
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

        public override void Update()
        {
            base.Update();
            controller.GetInputs();
            CheckCollisions();

        }


    }
}
