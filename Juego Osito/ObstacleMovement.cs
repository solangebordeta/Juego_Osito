using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class ObstacleMovement
    {
        private Transform transform;
        private int speed = 4;
        private Vector2 direccion = new Vector2(1, 0);
        public ObstacleMovement (Transform transform)
        {
            this.transform = transform;
        }

        public void MoveObstacle()
        {
            if (transform.Position.x > 1000 || transform.Position.x < 0)
            {
                direccion.x = direccion.x * -1;
            }
            transform.Translate(direccion,speed);
        }
    }
}
