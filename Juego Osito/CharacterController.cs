using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class CharacterController
    {
        private int speed = 5;
        private Transform transform;
        private DateTime timeLastShoot;
        private float timeBetweenShoots = 1;

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

        public void Shoot()
        {
            DateTime currentTime = DateTime.Now;
            if ((currentTime - timeLastShoot).TotalSeconds >= timeBetweenShoots)
            {
                Program.BulletList.Add(new Bullet(new Vector2(transform.Position.x + 48, transform.Position.y)));
                timeLastShoot = currentTime;
            }
    ;
        }
    }
}
