using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using MathForGames;
using Raylib_cs;

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
        private static Scene[] _scenes;
        private static int _currentSceneIndex;

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.Magenta;

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        public static Scene GetScenes(int index)
        {
            return _scenes[index];
        }

        public static int AddScene(Scene scene)
        {
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            for(int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            int index = _scenes.Length;
            tempArray[index] = scene;
            _scenes = tempArray;

            return _scenes.Length - 1;
        }

        public static bool RemoveScene(Scene scene)
        {
            if(scene == null)
            {
                return false;
            }

            bool sceneRemoved = false;

            Scene[] tempArray = new Scene[_scenes.Length - 1];

            int j = 0;
            for(int i = 0; i < _scenes.Length; i++)
            {
                if (tempArray[i] != scene)
                {
                    tempArray[j] = _scenes[i];
                    j++;
                }
                else
                {
                    sceneRemoved = true;
                }
            }

            if(sceneRemoved)
            {
                _scenes = tempArray;
            }

            return sceneRemoved;
        }

        public static void setCurrentScene(int index)
        {
            if (index < 0 || index >= _scenes.Length)
                return;

            _scenes[_currentSceneIndex].End();

            _currentSceneIndex = index;

            _scenes[_currentSceneIndex].Start();
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

        public Game()
        {
            _scenes = new Scene[0];
        }

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            //Creates a new window for raylib
            Raylib.InitWindow(1024, 760, "Math For Games");
            Raylib.SetTargetFPS(60);

            //Set up the console window
            Console.CursorVisible = false;
            Console.Title = "Math For Games";

            //Creates a new scene
            Scene scene1 = new Scene();
            Scene scene2 = new Scene();

            //Creates Enemies in the game that the player should dodge
            Enemy enemy = new Enemy(2, 0, Color.RED, '■', ConsoleColor.Magenta);
            enemy.Velocity.Y = 1;
            Enemy enemy1 = new Enemy(4, 0, Color.RED, '■', ConsoleColor.Magenta);
            enemy1.Velocity.Y = 1;
            Enemy enemy2 = new Enemy(6, 0, Color.RED, '■', ConsoleColor.Magenta);
            enemy2.Velocity.Y = 1;
            Player player = new Player(10, 20, Color.BLUE, '@', ConsoleColor.Cyan);
            scene1.AddActor(enemy);
            scene1.AddActor(enemy1);
            scene1.AddActor(enemy2);
            scene1.AddActor(player);

            scene2.AddActor(player);

            int startingSceneIndex = 0;

            startingSceneIndex = AddScene(scene1);
            AddScene(scene2);

            setCurrentScene(startingSceneIndex);


        }


        //Called every frame.
        public void Update()
        {
            _scenes[_currentSceneIndex].Update();
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);
            Console.Clear();
            _scenes[_currentSceneIndex].Draw();

            Raylib.EndDrawing();
        }


        //Called when the game ends.
        public void End()
        {
            _scenes[_currentSceneIndex].End();
        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while(!_gameOver && !Raylib.WindowShouldClose())
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
