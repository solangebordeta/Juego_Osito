using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class GameManager
    {
        public enum GameStatus
        {
            menu, game, lose
        }

        private static GameManager instance;
        private GameStatus gameStart = GameStatus.menu;  
        private IntPtr menuScreen = Engine.LoadImage("assets/menu.png");
        private IntPtr defeatScreen = Engine.LoadImage("assets/pantalladerrota.png");

        private LevelController levelController = new LevelController();
        public LevelController LevelController => levelController;

        private ScoreManager scoreManager;
        public ScoreManager ScoreManager => scoreManager;

        public static GameManager Instance

        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        private GameManager()
        {
            scoreManager = new ScoreManager();
        }

        public void Initialize()
        {
            levelController = new LevelController();
            levelController.Initialize();
        }

        public void Update()
        {

            switch (gameStart)
            {
                case GameStatus.menu:

                    if (Engine.KeyPress(Engine.KEY_ESP))
                    {
                        gameStart = GameStatus.game;
                    }
                    break;

                case GameStatus.game:

                    levelController.Update();
                    break;

                case GameStatus.lose:

                    if(Engine.KeyPress(Engine.KEY_ESP))
                    { 
                        gameStart = GameStatus.game;
                    }

                    // lo de arriba pasaba que, cuando quiero volver a jugar apretando espacio
                    // la animacion cambia a la de perder y termina siendo mi current animation 
                    // esto pasa cuando arranco a jugar de vuelta desde la pantalla de derrota, 
                    // no volviendo al menu
                    // YA ESTA :), basicamente en check colision (en la clase character)
                    // despues del game instance cambie el estado de la animacion 

                    if (Engine.KeyPress(Engine.KEY_ESC))
                    {
                        gameStart = GameStatus.menu;
                    }
                    break;

                
                   
            }
        }
        public void Render()
        {
            switch (gameStart)
            {
                case GameStatus.menu:
                    Engine.Clear();
                    Engine.Draw(menuScreen, 0, 0);
                    Engine.Show();

                    break;

                case GameStatus.game:
                    levelController.Render();
                    break;

                case GameStatus.lose:
                    Engine.Clear();
                    Engine.Draw(defeatScreen, 0, 0);
                    Engine.Show();
                    break;
                
            }
        }

        public void ChangeGameStatus(GameStatus newStatus)
        {
            gameStart = newStatus;
        }

    }
}
    
