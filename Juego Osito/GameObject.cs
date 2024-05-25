using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public abstract class GameObject
    {
        protected Transform transform;
        protected Animation currentAnimation;
        public Transform Transform => transform;
        public GameObject(Vector2 position) 
        {
            transform = new Transform(position, new Vector2(100, 100));
            //CreateAnimations(); --> lo agrego mas tarde
        }

        
        public virtual void Render()
        {
            
        }

        public virtual void Update()
        {

            
            //CheckCollisions();

        }
    }



    
}
