using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Enemy : Actor
    {
        private Actor _target;
        private Color _alertColor;
        private Sprite _sprite;
        private Laser _laser;
        private bool _alive = true;

        public Actor Target
        {
            get { return _target; }
            set { _target = value; }
        }
        public Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Magenta)
            : base(x, y, icon, color)
        {
            _sprite = new Sprite("Images/enemy.png");
        }

        public Enemy(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Magenta)
            : base(x, y, rayColor, icon, color)
        {
            _alertColor = Color.WHITE;
            _sprite = new Sprite("Images/enemy.png");
        }

        public void CreateProjectile(Laser laser)
        {
            _laser = laser;
            Scene scene = Game.GetScene(Game.CurrentSceneIndex);
            scene.AddActor(_laser);
            laser.Velocity = (Forward * _laser.Speed).Normalized * 3;
        }

        public bool CheckTargetInSight(float maxAngle, float maxDistance)
        {
            if (Target == null)
                return false;
            //Find the vector representing the distnace between the actor and its target
            Vector2 direction = Target.LocalPosition - LocalPosition;
            //Get the magnitude of the distance vector
            float distance = direction.Magnitude;
            //Use the inverse cosine to find the angle of the dot product in radians
            float angle = (float)Math.Acos(Vector2.DotProduct(Forward, direction.Normalized));

            if ( angle <= maxAngle && distance <= maxDistance)
                return true;

            return false;
        }

        public virtual void OnCollision(Actor other)
        {
            if (other is Actor)
            {
                Death(other);
            }
        }

        public bool RemoveActor(int index)
        {
            if (index < 0 || index >= _actors.Length)
            {
                return false;
            }
            bool actorRemoved = false;

            Actor[] tempArray = new Actor[_actors.Length - 1];

            int j = 0;
            for (int i = 0; i < _actors.Length; i++)
            {
                if (i != index)
                {
                    tempArray[i] = _actors[i];
                    j++;
                }
                else
                {
                    actorRemoved = true;
                    if (_actors[i].Started)
                    {
                        _actors[i].End();
                    }
                }
            }
            _actors = tempArray;

            return actorRemoved;
        }

        public override void Update(float deltaTime)
        {
            if(CheckTargetInSight(0.125f, 20))
            {
                _rayColor = Color.RED;

                //If the player is in the sights of the enemy then the enemy will shoot
                Laser bullet = new Laser(WorldPosition + Forward, Forward, Color.WHITE, '*', ConsoleColor.White);
                CreateProjectile(bullet);
            }
            else
            {
                _rayColor = Color.BLUE;
            }

            base.Update(deltaTime);
        }

        public override void Draw()
        {
            _sprite.Draw(_globalTransform);
            base.Draw();
        }
    }
}
