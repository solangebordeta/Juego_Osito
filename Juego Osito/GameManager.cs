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
            menu, game, pause, lose
        }

        private static GameManager instance;
        private GameStatus gameStart = GameStatus.menu;  
        private IntPtr menuScreen = Engine.LoadImage("assets/menu.png");
        private IntPtr defeatScreen = Engine.LoadImage("assets/pantalladerrota.png");
        private IntPtr pauseScreen = Engine.LoadImage("assets/pausa.png");

        private LevelController levelController = new LevelController();
        public LevelController LevelController => levelController;

        private ScoreManager scoreManager;
        //public ScoreManager ScoreManager => scoreManager;

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
            foreach (var gameObject in LevelController.GameObjectList)
            {
                if (gameObject is Fish fish)
                {
                    fish.FishPickedUp += scoreManager.OnFishPickedUp;
                }
            }
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

                    if (Engine.KeyPress(Engine.KEY_ESC))
                    {
                        gameStart = GameStatus.pause;
                    }
                    break;

                case GameStatus.pause:

                    if (Engine.KeyPress(Engine.KEY_ESC))
                    {
                        gameStart = GameStatus.game;
                    }
                    break;

                case GameStatus.lose:

                    if(Engine.KeyPress(Engine.KEY_ESP))
                    { 
                        gameStart = GameStatus.game;
                    }

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

                case GameStatus.pause:
                    Engine.Clear();
                    Engine.Draw(pauseScreen, 0, 0);
                    Engine.Show();
                    break;

                case GameStatus.lose:
                    Engine.Clear();
                    Engine.Draw(defeatScreen, 0, 0);
                    string scoreText = $"Puntaje: {scoreManager.Score}";
                    Engine.Debug(scoreText);
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
    
