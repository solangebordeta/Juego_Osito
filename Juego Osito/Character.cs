using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Security;
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
        private CharacterController controller;
        private bool isLosing;

        //transform.Position = new Vector2(200, 200);


        public Character(Vector2 position) : base(position)
        {
            controller = new CharacterController(transform);
            CreateAnimations();
            isLosing = false;
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

        public void NewAnimation()
        {
            List<IntPtr> losingTextures = new List<IntPtr>();
            for (int i = 0; i < 15; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/osito/lose/{i}.png");
                losingTextures.Add(frame);

            }
            lose = new Animation("Lose", losingTextures, 0.1f, true);
            currentAnimation = lose;

            if (losingTextures.Count <= 15)
            {
                isLosing = true;
            }
        }



        public void ChangeAnimation() //cuando pierdo se cambia la animacion
        {
            if (currentAnimation != walk) 
            {
               NewAnimation();   
            }
            isLosing = true;
            currentAnimation = lose;
        }



        //quiero hacer un delay para que cuando pierda, 
        //no aparezca al toque la pantalla de derrota
        //asi se aprecia la animacion

        /*public void DelayAfterLosing() 
        {
            int currentTime = 0;
            int delay = 3;

            if (currentAnimation  == lose)
            {
                CheckCollisions();
                ChangeAnimation();
                currentTime += delay;  
            }
         
        }*/

        public void CheckCollisions()
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
<<<<<<< Updated upstream
                    Console.WriteLine("Colisión detectada!");
                    LevelController.GameObjectList.Remove(gameObject); 
                    ChangeAnimation();
                    //DelayAfterLosing();
                    GameManager.Instance.ChangeGameStatus(GameManager.GameStatus.lose);
                    currentAnimation = walk; //aca hice q cuando pierdo, y quiero volver a jugar
                                             //mi current animation cambie de perder a caminar
                                             //puede q esto lo cambie mas adelante si genera conflicto con el delay
=======
                    

                    // toco el pez

                    if (gameObject is IPickuppeable pickupobj) // Verifica si el objeto es un pez
                    {
                        pickupobj.PickUp();
                        LevelController.GameObjectList.RemoveAt(i); //ESTO SE TENDRIA QUE MODIFICAR CUANDO SE HAGA EL FACTORY. 
                    }

                    // toco el arbol

                    if (gameObject is Obstacle)
                    {
                        Console.WriteLine("Colisión detectada con un obstaculo!");
                        LevelController.GameObjectList.Remove(gameObject);


                        ChangeAnimation();
                        NewAnimation();
                        isLosing = true;


                        



                        /*if (isLosing) 
                        {

                             GameManager.Instance.ChangeGameStatus(GameManager.GameStatus.lose);
                        
                        }*/


                        //currentAnimation = walk; //aca hice q cuando pierdo, y quiero volver a jugar
                        //mi current animation cambie de perder a caminar
                    }
>>>>>>> Stashed changes



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
