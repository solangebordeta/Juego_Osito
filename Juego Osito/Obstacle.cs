using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Obstacle
    {
        private Transform transform;
        private Animation idleAnimation;
        private Animation currentAnimation;
        public Transform Transform => transform;
        private ObstacleMovement ObstacleMovement;

        IntPtr image = Engine.LoadImage("assets/obstacle.png");

        public Obstacle(Vector2 pos)
        {
            transform = new Transform(pos,new Vector2(100, 100));
            ObstacleMovement = new ObstacleMovement(transform);
            CreateAnimations();
        }

        private void CreateAnimations()
        {
            List<IntPtr> idleTextures = new List<IntPtr>();
            for (int i = 0; i < 4; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/obstacle/Idle/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true);
            currentAnimation = idleAnimation;
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.Position.x, transform.Position.y);
        }

        public void Update()
        {
            currentAnimation.Update();
            ObstacleMovement.MoveObstacle();
        }
    }
}
