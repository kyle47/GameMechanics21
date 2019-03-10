using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Game.Mapping
{
    public class Tile
    {
        public string ID;
        public string Name;
        public string Image;
        public bool Walkable = true;
        public bool SpawnPellet = true;
    }
}
