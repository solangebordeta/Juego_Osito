using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Fish : GameObject
    {
        private static IntPtr image = Engine.LoadImage("assets/pez.png");
        public Transform Transform => transform;
        //private FishMovement FishMovement; //Aqui era originalmente ObstacleMovement pero para adpatarlo a Fish a lo mejor deberia 
        //crear un FishMovement que haga lo mismo

        public Fish(Vector2 position) : base(position)
        {
            //FishMovement = new FishMovement(transform);
        }
        public override void Render()
        {
            Engine.Draw(image, transform.Position.x, transform.Position.y);
        }
        public override void Update()
        {
            base.Update();
            //ObstacleMovement.MoveObstacle(); //Esto por si quiero darle el mismo tipo de movimiento que los obstaculos.
        }
    }
}
