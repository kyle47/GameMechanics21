using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Game.Entity;

namespace Game.Mapping
{
    public class Map
    {
        protected int _width;
        protected int _height;

        protected Tile[,] _tiles = new Tile[0, 0];
        protected Dictionary<string, Unit> _units = new Dictionary<string, Unit>();

        public bool IsOnMap(int x, int y) => (x >= 0) && (y >= 0) && (x < _width) && (y < _height);

        public int Width => _tiles.GetLength(0);
        public int Height => _tiles.GetLength(1);

        public Action<int, int, Tile> OnTileChanged;

        public Map(int width, int height, Tile fill)
        {
            _width = Math.Max(width, 1);
            _height = Math.Max(height, 1);

            _tiles = new Tile[_width, _height];

            Fill(fill);
        }

        protected void Fill(Tile tile)
        {
            var width = Width;
            var height = Height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _tiles[x, y] = tile;
                    OnTileChanged?.Invoke(x, y, tile);
                }
            }
        }

        public void SetTile(int x, int y, Tile tile)
        {
            if(IsOnMap(x, y))
            {
                _tiles[x, y] = tile;
            }
        }

        public void ForEachTile(Action<int, int, Tile> callback)
        {
            var width = Width;
            var height = Height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    callback?.Invoke(x, y, _tiles[x, y]);
                }
            }
        }

    }
}
