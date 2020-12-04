using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Player : Actor
    {
        private float _speed = 1;
        private Sprite _sprite;
        private Laser _laser;

        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        public Player(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Magenta)
            : base(x, y, icon, color)
        {
            _sprite = new Sprite("Images/player.png");
        }

        public Player(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Magenta)
            : base(x, y, rayColor, icon, color)
        {
            _sprite = new Sprite("Images/player.png");
        }

        public void CreateProjectile(Laser laser)
        {
            _laser = laser;
            Scene scene = Game.GetScene(Game.CurrentSceneIndex);
            scene.AddActor(_laser);
            laser.Velocity = (Forward * _laser.Speed).Normalized * 3;
        }

        public override void Update(float deltaTime)
        {

            int xVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_A))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_D));

            int yVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_W))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_S));

            if (Game.GetKeyDown((int)KeyboardKey.KEY_UP))
            {
                Laser bullet = new Laser(WorldPosition + Forward, Forward, Color.WHITE, '@', ConsoleColor.White);
                CreateProjectile(bullet);
            }

            Acceleration = new Vector2(xVelocity, yVelocity);
            //Velocity = Velocity.Normalized * Speed;

            base.Update(deltaTime);
        }

        public override void Draw()
        {
            _sprite.Draw(_globalTransform);
            base.Draw();
        }
    }
}


