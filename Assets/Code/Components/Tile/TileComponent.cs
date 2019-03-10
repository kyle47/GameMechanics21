using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Game.Mapping;

namespace Game.Components
{
    public class TileComponent : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;

        protected Dictionary<string, Sprite> _tileImages;
        protected Tile _tile;

        public TileComponent Construct(Dictionary<string, Sprite> tileImages)
        {
            _tileImages = tileImages;
            return this;
        }

        public void SetTile(Tile tile)
        {
            _tile = tile;
            UpdateDisplay();
        }

        protected void UpdateDisplay()
        {
            var tileImage = _tileImages[_tile.Image];
            SpriteRenderer.sprite = tileImage;
        }
    }
}
