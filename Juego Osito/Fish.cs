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
        private ObstacleMovement obstacleMovement; //Aqui era originalmente ObstacleMovement pero para adpatarlo a Fish a lo mejor deberia 
        //crear un FishMovement que haga lo mismo

        public Fish(Vector2 position) : base(position)
        {
            obstacleMovement = new ObstacleMovement(transform);//Para mover el pez
        }
        public override void Render()
        {
            Engine.Draw(image, transform.Position.x, transform.Position.y);
        }
        public override void Update()
        {
            obstacleMovement.MoveObstacle(); //Esto por si quiero darle el mismo tipo de movimiento que los obstaculos.
        }
    }
}
