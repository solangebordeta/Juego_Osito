using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Character
    {
        private Transform transform;
        private Animation idleAnimation;
        private Animation currentAnimation;
        private CharacterController controller;
        IntPtr image = Engine.LoadImage("assets/player.png");


        public Character(Vector2 position) {
            transform = new Transform(position, new Vector2(100,100));
            controller = new CharacterController(transform);
            CreateAnimations();
        }

        public void Render()
        {
            transform.Position = new Vector2(200, 200);
            Engine.Draw(currentAnimation.CurrentFrame, transform.Position.x, transform.Position.y);
        }

        private void CreateAnimations()
        {
            List<IntPtr> idleTextures = new List<IntPtr>();
            for (int i = 0; i < 4; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Ship/Idle/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true);
            currentAnimation = idleAnimation;
        }
        public void Update()
        {
            controller.GetInputs();
            currentAnimation.Update();
        }


    }
}
