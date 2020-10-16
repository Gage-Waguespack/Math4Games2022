using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using MathForGames;

namespace MathForGames
{
    /// <summary>
    /// I want to make a game that has the player choose a difficulty, either easy, medium, or large.
    /// After that I'd want each difficulty to have different amounts of enemies and I want the player
    /// to be able to walk over an enemy and for that enemy to disappear. If there are multiple enemies
    /// in the same position and the player is there, I want the game to end (the player will lose) 
    /// and if the player walks over just one enemy, I want the enemy to disappear and if the player
    /// gets rid of the all, they win.
    /// Things I'm going to need:
    /// - An enemy class that hold the variables for the enemies (including their movements).
    /// - A way for the player to lose via multiple enemies.
    /// - A way for the player to win after there are no enemies being detected.
    /// </summary>
    class Game
    {
        private static bool _gameOver = false;
        private Scene _scene;

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.Magenta;

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        public static ConsoleKey GetNextKey()
        {
            //If the user hasn't pressed a key return
            if(!Console.KeyAvailable)
            {
                return 0;
            }
            //Return the key that was pressed
            return Console.ReadKey(true).Key;
        }

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            Console.CursorVisible = false;
            _scene = new Scene();
            Actor actor = new Actor(0,0, '■', ConsoleColor.Magenta);
            actor.Velocity.X = 1;
            Player player = new Player(10, 20, '@', ConsoleColor.Cyan);
            _scene.AddActor(actor);
            _scene.AddActor(player);
        }


        //Called every frame.
        public void Update()
        {
            _scene.Update();
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Console.Clear();
            _scene.Draw();
        }


        //Called when the game ends.
        public void End()
        {

        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while(!_gameOver)
            {
                Update();
                Draw();
                while (Console.KeyAvailable) 
                    Console.ReadKey(true);
                Thread.Sleep(250);
            }

            End();
        }
    }
}
