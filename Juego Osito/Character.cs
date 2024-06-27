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


            if (currentAnimation.CurrentFrameIndex >= 11)
            {
                currentAnimation = lose;
            }

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

        private void CheckCollisions()
        {
            for (int i = 0; i < LevelController.GameObjectList.Count; i++)
            {
                GameObject gameObject = LevelController.GameObjectList[i];
                float distanceX = Math.Abs((gameObject.Transform.Position.x + (gameObject.Transform.Scale.x / 2)) - (transform.Position.x + (transform.Scale.x / 2)));
                float distanceY = Math.Abs((gameObject.Transform.Position.y + (gameObject.Transform.Scale.y / 2)) - (transform.Position.y + (transform.Scale.y / 2)));
                float sumHalfWidth = gameObject.Transform.Scale.x / 2 + transform.Scale.x / 2;
                float sumHalfHeight = gameObject.Transform.Scale.y / 2 + transform.Scale.y / 2;


                if (distanceX < sumHalfWidth && distanceY < sumHalfHeight)
                {

                    if (gameObject is IPickuppeable pickupobj) // Verifica si el objeto es un pez
                    {
                        pickupobj.PickUp();
                        objectsToRemove.Add(gameObject);
                    }

                    if (gameObject is Obstacle)
                    {
                        Console.WriteLine("Colisión detectada con un obstaculo!");
                        LevelController.GameObjectList.Remove(gameObject);

                        //DieAnimation(); 

                        GameManager.Instance.ChangeGameStatus(GameManager.GameStatus.lose);

                        OnDie();

                        ChangeAnimation();
                    }

                    foreach (var obj in objectsToRemove)
                    {
                        LevelController.GameObjectList.Remove(obj);
                    }
                    objectsToRemove.Clear();

                }


            }
        }

        public override void Update()
        {
            base.Update();
            controller.GetInputs();
            CheckCollisions();
        }


    }
}
