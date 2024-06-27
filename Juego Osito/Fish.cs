using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyGame.Character;

namespace MyGame
{
    public class Fish : GameObject, IPickuppeable
    {
        private static IntPtr image = Engine.LoadImage("assets/pez.png");

        private VerticalMovement verticalMovement;
        private int scoreValue = 5;
        private DynamicPoolFish pool;

        public event Action<int> FishPickedUp;
        public Vector2 originalPosition;

        public Fish(Vector2 position, DynamicPoolFish pool) : base(position)
        {
            this.pool = pool;
            verticalMovement = new VerticalMovement(transform); // Para mover el pez
            FishPickedUp += GameManager.Instance.LevelController.OnFishPickedUp;
            GameManager.Instance.LevelController.Player.OnDie += ResetPosition;
            originalPosition = position;
        }

        public void ResetPosition()
        {
            transform.SetPosition(originalPosition);
        }

        public override void Render()
        {
            Engine.Draw(image, transform.Position.x, transform.Position.y);
        }

        public override void Update()
        {
            verticalMovement.MoveObstacle(); // Movimiento del pez

            // Verifica si el pez ha salido de la pantalla (supongamos que la pantalla tiene límite en y = 900)
            if (transform.Position.y > 650)
            {
                ResetPositionToRandom();
                pool.ReleaseFish(this); // Libera el pez de vuelta a la pool
            }
        }

        public void PickUp()
        {
            Engine.Debug("Se aumentó el score");
            FishPickedUp?.Invoke(scoreValue);
            pool.ReleaseFish(this); // Libera el pez de vuelta a la pool
        }

        public void ResetPositionToRandom()
        {
            // Generar una nueva posición aleatoria en la pantalla
            Random rand = new Random();
            float x = rand.Next(200, 700);
            float y = rand.Next(0, 0);
            transform.SetPosition(new Vector2((int)x, (int)y));
        }
    }
}
