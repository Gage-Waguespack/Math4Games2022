using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace MathForGames
{
    class Enemy : Actor
    {
        public Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Magenta)
            : base(x, y, icon, color)
        {

        }

        public Enemy(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Magenta)
            : base(x, y, rayColor, icon, color)
        {

        }

    }
}
