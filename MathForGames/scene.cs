﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Scene
    {
        private Actor[] _actors;

        public Scene()
        {
            _actors = new Actor[0];
        }

        public void AddActor(Actor actor)
        {
            //Creating a new array with a size one greater than our old array
            Actor[] appendedArray = new Actor[_actors.Length + 1];
            //Copy the values from the old array to the new array
            for(int i = 0; i < _actors.Length; i++)
            {
                appendedArray[i] = _actors[i];
            }
            //Set the last value in the new array to be the actor we want to add
            appendedArray[_actors.Length] = actor;
            //Set old arrat to hold values of the new array
            _actors = appendedArray;
        }

        public bool RemoveActor(int index)
        {
            //Check to see if index is outside the bounds of our array
            if(index < 0 || index >= _actors.Length)
            {
                return false;
            }

            bool actorRemoved = false;

            //Create a new array smaller with a size one less than out old array
            Actor[] newArray = new Actor[_actors.Length - 1];
            //Create variable to access tempArray index
            int j = 0;
            //Copy values from the old array to the new array
            for(int i = 0; i < _actors.Length; i++)
            {
                //If the current index is not the index that needs to be removed,
                //add the value into the old array and increment j
                if(i != index)
                {
                    newArray[j] = _actors[i];
                    j++;
                }
                else
                {
                    actorRemoved = true;
                }
            }
            //Set the old array to be the tempArray
            _actors = newArray;
            return actorRemoved;
        }

        public bool RemoveActor(Actor actor)
        {
            //Checks to see if the actor was null
            if(actor == null)
            {
                return false;
            }
            //This is a flag
            bool actorRemoved = false;
            //Create a new array smaller with a size one less than out old array
            Actor[] newArray = new Actor[_actors.Length - 1];
            //Create variable to access tempArray index
            int j = 0;
            //Copy values from the old array to the new array
            for (int i = 0; i < _actors.Length; i++)
            {
                if(actor != _actors[i])
                {
                    newArray[j] = _actors[i];
                    j++;
                }
                else
                {
                    //This is where I used the flag
                    actorRemoved = true;
                }
            }

            //Set the old array to the new array
            _actors = newArray;
            //Return whether or not the removal was successful
            return actorRemoved;
        }

        public virtual void Start()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Start();
            }
        }

        public virtual void Update()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Update();
            }
        }

        public virtual void Draw()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Draw();
            }
        }

        public virtual void End()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].End();
            }
        }
    }
}
