using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Tao.Sdl;

namespace MyGame
{
    public class Character : GameObject
    {

        private Animation walk;
        private Animation lose;
        private ICharacterController controller;
        private Vector2 originalPosition;
        private List<GameObject> objectsToRemove = new List<GameObject>();

        public delegate void Evento();
        public event Evento OnDie = null;

        public Character(Vector2 position) : base(position)
        {
            originalPosition = position;
            controller = new CharacterController(transform);
            CreateAnimations();
            OnDie += ResetPosition;
        }

        private void CreateAnimations()
        {
            List<IntPtr> walkingTextures = new List<IntPtr>();
            for (int i = 0; i < 2; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/osito/walk/{i}.png");
                walkingTextures.Add(frame);
            }
            walk = new Animation("Walk", walkingTextures, 0.2f, true);
            currentAnimation = walk;
        }

        public void DieAnimation()
        {
            List<IntPtr> losingTextures = new List<IntPtr>();
            for (int i = 0; i < 12; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/osito/lose/{i}.png");
                losingTextures.Add(frame);
            }
            lose = new Animation("Lose", losingTextures, 0.2f, true);
            currentAnimation = lose;
        }

        public void ChangeAnimation() //cambio la animacion de perder a caminar cuando vuelve a jugar
        {
            if (currentAnimation != lose)
            {
                currentAnimation = walk;
            }
        }

        public void ResetPosition()
        {
            transform.SetPosition(originalPosition);
        }

        public void TriggerOnDie()
        {
            OnDie?.Invoke();
        }

        public override void Update()
        {
            base.Update();
            controller.GetInputs();
            Collisions.CheckCollisions(this, LevelController.GameObjectList);
        }
    }
}
