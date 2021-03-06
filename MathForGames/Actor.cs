﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{

    class Actor
    {
        protected char _icon = ' ';
        private Sprite _sprite;
        private Vector2 _velocity = new Vector2();
        protected Vector2 acceleration = new Vector2();
        protected Matrix3 _globalTransform = new Matrix3();
        protected Matrix3 _localTransform = new Matrix3();
        private Matrix3 _translation = new Matrix3();
        private Matrix3 _rotation = new Matrix3();
        private Matrix3 _scale = new Matrix3();
        protected ConsoleColor _color;
        protected Color _rayColor;
        public static Actor[] _actors;
        protected Actor _actor;
        protected Actor _parent;
        protected Actor[] _children = new Actor[0];
        private float _collisionRadius;
        private float _speed = 1;
        private float _maxSpeed = 5;
        private bool _alive = true;

        public bool Started { get; private set; }

        public Vector2 Forward
        {
            get 
            { 
                return new Vector2(_globalTransform.m11, _globalTransform.m21); 
            }
        }

        //defines the world position using the global transform.
        public Vector2 WorldPosition
        {
            get
            {
                return new Vector2(_globalTransform.m13, _globalTransform.m23);
            }
        }

        public Vector2 LocalPosition
        {
            get
            {
                return new Vector2(_localTransform.m13, _localTransform.m23);
            }
            set
            {
                _translation.m13 = value.X;
                _translation.m23 = value.Y;
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

        protected Vector2 Acceleration
        {
            get
            {
                return acceleration;
            }
            set
            {
                acceleration = value;
            }
        }

        public float MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
            set
            {
                _maxSpeed = value;
            }
        }

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

        public Actor(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _rayColor = Color.WHITE;
            _icon = icon;
            _localTransform = new Matrix3();
            LocalPosition = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
        }

        public Actor(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : this(x,y,icon,color)
        {
            _rayColor = rayColor;
        }

        public bool AddChild(Actor child)
        {
            if (child == null)
                return false;
            Actor[] tempArray = new Actor[_children.Length + 1];

            for (int i = 0; i < _children.Length; i++)
            {
                tempArray[i] = _children[i];
            }

            tempArray[_children.Length] = child;
            _children = tempArray;
            child._parent = this;
            return true;
        }

        public bool RemoveChild(Actor child)
        {
            bool childRemoved = false;

            if (child == null)
                return false;

            Actor[] tempArray = new Actor[_children.Length - 1];

            int j = 0;
            for (int i = 0; i < _children.Length; i++)
            {
                if (child != _children[i])
                {
                    tempArray[j] = _children[i];
                    j++;
                }
                else
                {
                    childRemoved = true;
                }
            }

            _children = tempArray;
            child._parent = null;
            return childRemoved;
        }

        public bool RemoveActor(Actor actor)
        {
            if (actor == null)
            {
                return false;
            }
            bool actorRemoved = false;

            Actor[] newArray = new Actor[_actors.Length - 1];

            int j = 0;

            for (int i = 0; i < _actors.Length; i++)
            {
                if (actor != _actors[i])
                {
                    newArray[j] = _actors[i];
                    j++;
                }
                else
                {
                    actorRemoved = true;
                    if (actor.Started)
                    {
                        actor.End();
                    }
                }
            }
            _actors = newArray;

            return actorRemoved;
        }

        public virtual void Start()
        {
            Started = true;
        }

        /// <summary>
        /// Checks to see if this actor overlaps another.
        /// </summary>
        /// <param name="other">The actor that this actor is checking collision against</param>
        /// <returns></returns>
        public bool CheckCollision(Actor other)
        {
            float distance = (other.WorldPosition - WorldPosition).Magnitude;
            if(distance <= other._collisionRadius + _collisionRadius)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Called whenever a collision occurs between the actor and another.
        /// use this to define game logic for this actors collision.
        /// </summary>
        /// <param name="other"></param>
        public virtual void OnCollision(Actor other)
        {
            if (other is Actor)
            {
                Death(other);
            }
        }

        public void Death(Actor actor)
        {
            RemoveActor(actor);
        }

        public void SetTranslate(Vector2 position)
        {
            _translation = Matrix3.CreateTranslation(position);
        }

        public void SetRotation(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);
        }

        public void Rotate(float radians)
        {
            _rotation *= Matrix3.CreateRotation(radians);
        }

        public void SetScale(float x, float y)
        {
            _scale = Matrix3.CreateScale(new Vector2(x, y));
        }

        private void UpdateTransforms()
        {
            _localTransform = _translation * _rotation * _scale;
            if (_parent == null)
            {
                _globalTransform = _localTransform * Game.GetCurrentScene().World;
            }
            else
            {
                _globalTransform = _parent._globalTransform * _localTransform; 
            }
        }


        public virtual void Update(float deltaTime)
        {
            UpdateTransforms();

            Velocity += acceleration;

            if (Velocity.Magnitude > MaxSpeed)
                Velocity = Velocity.Normalized * MaxSpeed;

            //Increase position by the current velocity
            LocalPosition += _velocity * deltaTime;

            if(_alive == false)
            {
                
            }

        }

        public virtual void Draw()
        {
            //
            Raylib.DrawText(_icon.ToString(), (int)(WorldPosition.X * 32), (int)(WorldPosition.Y * 32), 32, _rayColor);
            Raylib.DrawLine(
                (int)(WorldPosition.X * 32),
                (int)(WorldPosition.Y * 32),
                (int)((WorldPosition.X + Forward.X) * 32),
                (int)((WorldPosition.Y + Forward.Y) * 32),
                Color.WHITE
                );

            Console.ForegroundColor = _color;
            Console.ForegroundColor = Game.DefaultColor;
            
            //Checks to see if the game object is inside the bounds.
            if(WorldPosition.X >= 0 && WorldPosition.X < Console.WindowWidth 
                && WorldPosition.Y >=0 && WorldPosition.Y < Console.WindowHeight)
            {
                Console.SetCursorPosition((int)WorldPosition.X, (int)WorldPosition.Y);
                Console.Write(_icon);
            }


        }

        public virtual void End()
        {

        }

    }
}
