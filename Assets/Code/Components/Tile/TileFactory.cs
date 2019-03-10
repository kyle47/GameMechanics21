using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Zenject;
using Newtonsoft.Json;

using Game.Mapping;
using Game.Components;


namespace Game.Factory
{
    public class TileFactory
    {
        protected const string TILE_PREFAB_PATH     = "prefabs/base-tile";
        protected const string TILE_JSON_PATH       = "json/tiles";
        protected const string TILE_IMAGE_PATH      = "sprites/tiles";

        public Dictionary<string, Tile> Tiles { get; protected set; } = new Dictionary<string, Tile>();

        protected Dictionary<string, Sprite> _tileImages = new Dictionary<string, Sprite>();
        protected DiContainer _container;
        protected GameObject _tilePrefab;
        protected Tile _defaultTile;

        [Inject]
        public TileFactory(DiContainer container)
        {
            _container = container;
            _tileImages = Resources.LoadAll<Sprite>(TILE_IMAGE_PATH)
                .ToDictionary(sprite => sprite.name);

            _tilePrefab = Resources.Load<GameObject>(TILE_PREFAB_PATH);

            Tiles = Resources.LoadAll<TextAsset>(TILE_JSON_PATH)
               .ToList()
               .Select(file =>JsonConvert.DeserializeObject<Tile>(file.text))
               .ToDictionary(tile => tile.ID);

            _defaultTile = Tiles[Tiles.Keys.First()];
        }

        public TileComponent Create(string id)
        {
            var tileObject = _container.InstantiatePrefab(_tilePrefab);
            var tileComponent = tileObject.GetComponent<TileComponent>()
                .Construct(_tileImages);
            var tile = Tiles.ContainsKey(id) ? Tiles[id] : _defaultTile;
            tileComponent.SetTile(tile);
            return tileComponent;
        }
    }
}
