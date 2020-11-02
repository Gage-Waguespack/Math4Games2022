using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{

    class Actor
    {
        protected char _icon = ' ';
        protected Vector2 _velocity;
        protected Matrix3 _transform = new Matrix3();
        private Matrix3 _tanslation = new Matrix3();
        private Matrix3 _rotation = new Matrix3();
        private Matrix3 _scale = new Matrix3();
        protected ConsoleColor _color;
        protected Color _rayColor;

        /// <summary>
        /// Create new matrices to transform the actors matrix. The user should be able
        /// to translate, rotate, and scale the actor.
        /// </summary>

        public bool Started { get; private set; }


        public Vector2 Forward
        {
            get 
            { 
                return new Vector2(_transform.m11, _transform.m21); 
            }
            set
            {
                _transform.m11 = value.X;
                _transform.m21 = value.Y;
            }
        }

        public Vector2 Position
        {
            get
            {
                return new Vector2(_transform.m13, _transform.m23);
            }
            set
            {
                _transform.m13 = value.X;
                _transform.m23 = value.Y;
            }
        }

        public Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }

        public Actor(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _rayColor = Color.WHITE;
            _icon = icon;
            _transform = new Matrix3();
            Position = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
            Forward = new Vector2(1, 0);
        }

        public Actor(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : this(x,y,icon,color)
        {
            _rayColor = rayColor;
        }

        //Updates the actors forward vector to be 
        //the last direction it moved in.
        private void UpdateFacing()
        {
            if (Velocity.Magnitude <= 0)
                return;

            Forward = Velocity.Normalized;
        }

        public virtual void Start()
        {
            Started = true;
        }

        public void SetTranslate(Vector2 position)
        {
            _tanslation.m13 = position.X;
            _tanslation.m23 = position.Y;
        }

        public void SetRotation(float radians)
        {
            _rotation.m11 = (float)Math.Cos(radians);
            _rotation.m12 = (float)Math.Sin(radians);
            _rotation.m21 = -(float)Math.Sin(radians);
            _rotation.m22 = (float)Math.Cos(radians);
        }

        public void SetScale(float x, float y)
        {
            _scale.m11 = x;
            _scale.m22 = y;
        }

        private void UpdateTransform()
        {

        }

        public virtual void Update(float deltaTime)
        {
            UpdateFacing();
            Position.X = Math.Clamp(Position.X, 0, Console.WindowWidth-1);
            Position.Y = Math.Clamp(Position.Y, 0, Console.WindowHeight-1);
            Position += _velocity * deltaTime;
        }

        public virtual void Draw()
        {
            Raylib.DrawText(_icon.ToString(), (int)(Position.X * 32), (int)(Position.Y * 32), 32, _rayColor);
            Raylib.DrawLine(
                (int)(Position.X * 32),
                (int)(Position.Y * 32),
                (int)((Position.X + Forward.X) * 32),
                (int)((Position.Y + Forward.Y) * 32),
                Color.WHITE
                );

            Console.ForegroundColor = _color;
            Console.ForegroundColor = Game.DefaultColor;
            
            //
            if(Position.X >= 0 && Position.X < Console.WindowWidth 
                && Position.Y >=0 && Position.Y < Console.WindowHeight)
            {
                Console.SetCursorPosition((int)Position.X, (int)Position.Y);
                Console.Write(_icon);
            }


        }

        public virtual void End()
        {

        }

    }
}
