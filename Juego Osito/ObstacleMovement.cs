﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class ObstacleMovement
    {
        private Transform transform;
        private int speed = 3;
        private Vector2 direccion = new Vector2(0, 1);
        public ObstacleMovement (Transform transform)
        {
            this.transform = transform;
        }

        public void MoveObstacle()
        {

            transform.Translate(direccion,speed);
        }
    }
}
