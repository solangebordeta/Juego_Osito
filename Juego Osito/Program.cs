using System;
using System.Collections.Generic;
using Tao.Sdl;

namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Initialize();
            GameManager.Instance.Initialize();

            while (true)
            {

                GameManager.Instance.Update();
                GameManager.Instance.Render();

                Sdl.SDL_Delay(20);
            }
        }
    }
}
