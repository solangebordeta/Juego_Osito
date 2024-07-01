using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Collisions
    {
        public ScoreManager scoreManager = new ScoreManager();
        public ScoreManager ScoreManager => scoreManager;
        public static void CheckCollisions(Character character, List<GameObject> gameObjects)
        {
            List<GameObject> objectsToRemove = new List<GameObject>();

            List<GameObject> gameObjectsCopy = new List<GameObject>(gameObjects);

            foreach (var gameObject in gameObjectsCopy)
            {
                float distanceX = Math.Abs((gameObject.Transform.Position.x + (gameObject.Transform.Scale.x / 2)) - (character.Transform.Position.x + (character.Transform.Scale.x / 2)));
                float distanceY = Math.Abs((gameObject.Transform.Position.y + (gameObject.Transform.Scale.y / 2)) - (character.Transform.Position.y + (character.Transform.Scale.y / 2)));
                float sumHalfWidth = gameObject.Transform.Scale.x / 2 + character.Transform.Scale.x / 2;
                float sumHalfHeight = gameObject.Transform.Scale.y / 2 + character.Transform.Scale.y / 2;

                if (distanceX < sumHalfWidth && distanceY < sumHalfHeight)
                {
                    if (gameObject is IPickuppeable pickupobj)
                    {
                        pickupobj.PickUp();
                        objectsToRemove.Add(gameObject);
                    }

                    if (gameObject is Obstacle)
                    {
                        Console.WriteLine("Colisión detectada con un obstaculo!");
                        objectsToRemove.Add(gameObject);

                        GameManager.Instance.ChangeGameStatus(GameManager.GameStatus.lose);

                        character.TriggerOnDie();

                        character.ChangeAnimation();

                        GameManager.Instance.LevelController.ScoreManager.ResetScore();
                    }
                }
            }

            foreach (var obj in objectsToRemove)
            {
                gameObjects.Remove(obj);
            }
        }
    }
}
