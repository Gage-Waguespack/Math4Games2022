﻿using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    /// <summary>
    /// I want to press space and spawn a bullet
    /// after that I want to make that bullet go straight in the direction it was shot.
    /// </summary>
    class Laser : Actor
    {
        private Vector2 _position = new Vector2();
        private Vector2 _direction = new Vector2();

        public Laser(Vector2 position, Vector2 direction, Color raycolor, char icon = '@', ConsoleColor color = ConsoleColor.White)
            : base(position.X, position.Y, icon, color)
        {
            Velocity = new Vector2(position.X, position.Y);
            _position = position;
            _direction = direction;
        }

        public virtual void OnCollision(Actor other)
        {
            if (other is Actor)
            {
                Death(other);
            }
        }
    }
}