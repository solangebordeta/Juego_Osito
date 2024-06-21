using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Obstacle : GameObject
    {
        
        private Animation idle;
        private VerticalMovement verticalMovement;
        public Vector2 originalPosition;
        public Obstacle(Vector2 position) : base(position)
        {
            originalPosition = position;
            verticalMovement = new VerticalMovement(transform);
            CreateAnimations();
            GameManager.Instance.LevelController.Player.OnDie += ResetPosition;
        }

        public void ResetPosition()
        {
            transform.SetPosition(originalPosition);
        }

        public void Reposition(Vector2 newPosition)
        {
            transform.SetPosition(newPosition);
        }
        private void CreateAnimations()
        {
            List<IntPtr> idleTextures = new List<IntPtr>();
            for (int i = 0; i < 5; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Arbol/Idle/{i}.png");
                idleTextures.Add(frame);
            }
            idle = new Animation("Idle", idleTextures, 0.1f, true);
            currentAnimation = idle;
        }

        public override void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.Position.x, transform.Position.y);
        }

        public override void Update()
        {
            base.Update();
            verticalMovement.MoveObstacle();
        }
    }
}
