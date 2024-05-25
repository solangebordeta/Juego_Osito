using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Fish : GameObject
    {
        private Animation idle;
        //private FishMovement FishMovement; //Aqui era originalmente ObstacleMovement pero para adpatarlo a Fish a lo mejor deberia 
        //crear un FishMovement que haga lo mismo

        public Fish(Vector2 position) : base(position)
        {
            CreateAnimations();
            //FishMovement = new FishMovement(transform);
        }

        private void CreateAnimations()
        {
            List<IntPtr> idleTextures = new List<IntPtr>();
            for (int i = 0; i < 5; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/pez.png");
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
            //ObstacleMovement.MoveObstacle(); //Esto por si quiero darle el mismo tipo de movimiento que los obstaculos.
        }
    }
}
