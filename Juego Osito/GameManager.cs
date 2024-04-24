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
        private IntPtr defeatScreen = Engine.LoadImage("assets/perdiste.png");

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
                    Program.Update();
                    break;

                case GameStatus.lose:
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
                    Program.Render();
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
    
