using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Car : Actor
    {
        private Sprite _sprite;

        public Car(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Magenta)
            : base(x, y, icon, color)
        {
            _sprite = new Sprite("Images/enemy.png");
        }

        public Car(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Magenta)
            : base(x, y, rayColor, icon, color)
        {
            _sprite = new Sprite("Images/enemy.png");
        }
    }
}
