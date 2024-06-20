﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class CharacterController : ICharacterController
    {
        private int speed = 5;
        private Transform transform;

        public CharacterController(Transform transform)
        {
            this.transform = transform;
        }

        public void GetInputs()
        {
            if (Engine.KeyPress(Engine.KEY_LEFT))
            {
                transform.Translate(new Vector2(-1, 0), speed);
            }


            if (Engine.KeyPress(Engine.KEY_RIGHT))
            {
                transform.Translate(new Vector2(1, 0), speed);
            }

        }

       
    }
}
