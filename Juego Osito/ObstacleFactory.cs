using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{

    public enum Obstacles
    {
        arbol 
    }


    public class ObstacleFactory
    {
        public static Obstacle CreateObstacles(Vector2 position, Obstacles obstacle)
        {
            switch (obstacle)
            {
                case Obstacles.arbol:
                    return new Obstacle(position);
            }
            return null;
        }
    }
}
