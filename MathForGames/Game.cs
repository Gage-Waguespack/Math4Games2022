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
    /// Making a crossyroad type game where the player has to survive on the road for as long as possible
    /// </summary>
    class Game
    {
        private static bool _gameOver = false;
        private static Scene[] _scenes;
        private static int _currentSceneIndex;

        public static int CurrentSceneIndex
        {
            get
            {
                return _currentSceneIndex;
            }
        }
        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.Magenta;

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        public static Scene GetScene(int index)
        {
            return _scenes[index];
        }

        public static Scene GetCurrentScene()
        {
            return _scenes[_currentSceneIndex];
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

        public static void SetCurrentScene(int index)
        {
            if (index < 0 || index >= _scenes.Length)
                return;

            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();

            _currentSceneIndex = index;
        }

        public static bool GetKeyDown(int key)
        {
            return Raylib.IsKeyDown((KeyboardKey)key);
        }

        public static bool GetKeyPressed(int key)
        {
            return Raylib.IsKeyPressed((KeyboardKey)key);
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

            Space background = new Space(16, 12, ' ', ConsoleColor.White);

            background.SetScale(35f, 30f);

            //Creates Enemies in the game that the player should dodge
            Enemy enemy = new Enemy(15, 4, Color.RED, '■', ConsoleColor.Magenta);
            Enemy enemy1 = new Enemy(5, 4, Color.RED, '■', ConsoleColor.Magenta);
            Enemy enemy2 = new Enemy(10, 4, Color.RED, '■', ConsoleColor.Magenta);
            Enemy enemy3 = new Enemy(20, 4, Color.RED, '■', ConsoleColor.Magenta);
            Enemy enemy4 = new Enemy(25, 4, Color.RED, '■', ConsoleColor.Magenta);
            Enemy enemy5 = new Enemy(12, 6, Color.RED, '■', ConsoleColor.Magenta);
            Enemy enemy6 = new Enemy(13, 6, Color.RED, '■', ConsoleColor.Magenta);
            Enemy enemy7 = new Enemy(17, 6, Color.RED, '■', ConsoleColor.Magenta);
            Enemy enemy8 = new Enemy(18, 6, Color.RED, '■', ConsoleColor.Magenta);
            Enemy enemy9 = new Enemy(8, 6, Color.RED, '■', ConsoleColor.Magenta);
            Enemy enemy10 = new Enemy(7, 6, Color.RED, '■', ConsoleColor.Magenta);
            Enemy enemy11 = new Enemy(22, 6, Color.RED, '■', ConsoleColor.Magenta);
            Enemy enemy12 = new Enemy(23, 6, Color.RED, '■', ConsoleColor.Magenta);
            Enemy enemy13 = new Enemy(3, 6, Color.RED, '■', ConsoleColor.Magenta);
            Enemy enemy14 = new Enemy(27, 6, Color.RED, '■', ConsoleColor.Magenta);
            Player player = new Player(15, 22, Color.BLUE, '@', ConsoleColor.Cyan);

            player.SetScale(1f, 1f);
            enemy.SetScale(1f, 1f);

            //gives the actor a specified target
            enemy.Target = player;
            enemy1.Target = player;
            enemy2.Target = player;
            enemy3.Target = player;
            enemy4.Target = player;
            enemy5.Target = player;
            enemy6.Target = player;
            enemy7.Target = player;
            enemy8.Target = player;
            enemy9.Target = player;
            enemy10.Target = player;
            enemy11.Target = player;
            enemy12.Target = player;
            enemy13.Target = player;
            enemy14.Target = player;

            //sets the rotation of an actor in radians
            player.SetRotation(1.5707f);
            enemy.SetRotation(-1.5707f);
            enemy1.SetRotation(-1.5707f);
            enemy2.SetRotation(-1.5707f);
            enemy3.SetRotation(-1.5707f);
            enemy4.SetRotation(-1.5707f);
            enemy5.SetRotation(-1.5707f);
            enemy6.SetRotation(-1.5707f);
            enemy7.SetRotation(-1.5707f);
            enemy8.SetRotation(-1.5707f);
            enemy9.SetRotation(-1.5707f);
            enemy10.SetRotation(-1.5707f);
            enemy11.SetRotation(-1.5707f);
            enemy12.SetRotation(-1.5707f);
            enemy13.SetRotation(-1.5707f);
            enemy14.SetRotation(-1.5707f);

            //player.AddChild(enemy);

            //Adds the actors to the specified scene
            scene1.AddActor(background);
            scene1.AddActor(player);
            scene1.AddActor(enemy);
            scene1.AddActor(enemy1);
            scene1.AddActor(enemy2);
            scene1.AddActor(enemy3);
            scene1.AddActor(enemy4);
            scene1.AddActor(enemy5);
            scene1.AddActor(enemy6);
            scene1.AddActor(enemy7);
            scene1.AddActor(enemy8);
            scene1.AddActor(enemy9);
            scene1.AddActor(enemy10);
            scene1.AddActor(enemy11);
            scene1.AddActor(enemy12);
            scene1.AddActor(enemy13);
            scene1.AddActor(enemy14);

            player.Speed = 5;

            int startingSceneIndex = 0;

            startingSceneIndex = AddScene(scene1);
            AddScene(scene2);

            SetCurrentScene(startingSceneIndex);


        }


        //Called every frame.
        public void Update(float deltaTime)
        {
            if (!_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();

            _scenes[_currentSceneIndex].Update(deltaTime);
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
            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();
        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while(!_gameOver && !Raylib.WindowShouldClose())
            {
                float deltaTime = Raylib.GetFrameTime();
                Update(deltaTime);
                Draw();
                while (Console.KeyAvailable) 
                    Console.ReadKey(true);
            }

            End();
        }
    }
}
