using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Game.Mapping;

namespace Game.Entity
{
    public class Unit
    {
        public string ID;
        public string Name;

        public float Speed = 2.0f;

        public bool Moving { get; protected set; }

        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Action<int, int> OnStartMovement;

        public void MoveTo(int x, int y)
        {
            Moving = true;
            X = x;
            Y = y;
            OnStartMovement?.Invoke(x, y);
        }

        public bool CanEnter(Tile tile)
        {
            return tile.Walkable;
        }

        public void OnMovementDone()
        {
            Moving = false;
        }
    }
}
