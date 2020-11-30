using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Space : Actor
    {
        private Sprite _sprite;

        public Space(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {
            _sprite = new Sprite("Images/space.png");
        }

        public Space(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Magenta)
            : base(x, y, rayColor, icon, color)
        {
            _sprite = new Sprite("Images/space.png");
        }

        public override void Draw()
        {
            _sprite.Draw(_globalTransform);
            base.Draw();
        }
    }
}
