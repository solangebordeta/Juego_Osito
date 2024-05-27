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
        private ObstacleMovement obstacleMovement;
        public Vector2 originalPosition;
        public Obstacle(Vector2 position) : base(position)
        {
            originalPosition = position;
            obstacleMovement = new ObstacleMovement(transform);
            CreateAnimations();
            //GameManager.Instance.LevelController.Player.OnDie += ResetPosition;
        }

        // PROBABLEMENTE LE AGREGUEMOS ANIMACION DE CAERSE NI BIEN COLISIONA AL ARBOL MAS ADELANTE
        
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
            obstacleMovement.MoveObstacle();
        }

        /*public void ResetPosition()
        {
            transform.SetPosition(originalPosition);
        }*/
    }
}
