using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Enemy : Actor
    {
        private string _name;
        public Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Magenta)
            : base(x, y, icon, color)
        {

        }



    }
}
