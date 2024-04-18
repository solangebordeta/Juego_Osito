using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class Bullet
    {
        private Transform transform;
        private IntPtr image = Engine.LoadImage("assets/bullet.png");
        private Animation idleAnimation;
        private Animation currentAnimation;
        public Bullet(Vector2 pos)
        {
            transform = new Transform(pos,new Vector2(5, 5));
            CreateAnimations();
        }

        private void CreateAnimations()
        {
            List<IntPtr> idleTextures = new List<IntPtr>();
            for (int i = 0; i < 4; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Bullet/Idle/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true);
            currentAnimation = idleAnimation;
        }

        private void CheckCollisions()
        {

            for (int i = 0; i < Program.ObstacleList.Count; i++)
            {
                Obstacle Obstacle = Program.ObstacleList[i];
                float distanceX = Math.Abs((Obstacle.Transform.Position.x + (Obstacle.Transform.Scale.x / 2)) - (transform.Position.x + (transform.Scale.x / 2)));
                float distanceY = Math.Abs((Obstacle.Transform.Position.y + (Obstacle.Transform.Scale.y / 2)) - (transform.Position.y + (transform.Scale.y / 2)));

                float sumHalfWidth = Obstacle.Transform.Scale.x / 2 + transform.Scale.x / 2;
                float sumHalfH = Obstacle.Transform.Scale.y / 2 + transform.Scale.y / 2;

                if (distanceX < sumHalfWidth && distanceY < sumHalfH) // hay colision
                {
                    Program.BulletList.Remove(this);
                    Program.ObstacleList.Remove(Obstacle);
                }
            }
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.Position.x, transform.Position.y);
        }

        public void Update()
        {
            currentAnimation.Update();
            CheckCollisions();
            transform.Translate(new Vector2(0,-1),10);
        }
    }
}
