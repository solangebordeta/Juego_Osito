using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class GameObject
    {
        protected Transform transform;
        protected Animation currentAnimation;

        public GameObject(Vector2 position) 
        {
            transform = new Transform(position, new Vector2(100, 100));
            //CreateAnimations(); --> lo agrego mas tarde
        }

        
        public virtual void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.Position.x, transform.Position.y);
        }

        public virtual void Update()
        {

            currentAnimation.Update();
            //CheckCollisions();

        }
    }



    
}
