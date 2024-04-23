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
        
        public Transform Transform => transform;
        private ObstacleMovement ObstacleMovement;

        IntPtr image = Engine.LoadImage("assets/arbol.png");

        public Obstacle(Vector2 pos)
        {
            transform = new Transform(pos,new Vector2(100, 100));
            ObstacleMovement = new ObstacleMovement(transform);
            
        }

        

        public void Render()
        {
            Engine.Draw(image, transform.Position.x, transform.Position.y);
        }

        public void Update()
        {
            
            ObstacleMovement.MoveObstacle();
        }
    }
}
