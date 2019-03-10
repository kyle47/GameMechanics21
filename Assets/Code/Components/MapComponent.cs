using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Zenject;

using Game.Factory;
using Game.Mapping;
using Game.State;


namespace Game.Components
{
    public class MapComponent : MonoBehaviour
    {
        protected const int MAP_WIDTH = 7;
        protected const int MAP_HEIGHT = 5;

        protected Map _map;
        protected TileFactory _tileFactory;

        // TEMPORARY: Load from Resources
        public GameObject PelletPrefab;

        // TEMPORARY: Load correct map from Resources
        public GameObject MapPrefab;

        [Inject]
        public void Construct(TileFactory tileFactory)
        {
            _tileFactory = tileFactory;
        }

        private void Start()
        {
            var mapObject = GameObject.Instantiate(MapPrefab, Vector3.zero, Quaternion.identity);
            var tileHolder = mapObject.transform.Find("tiles");

            var locationToGameObject = new Dictionary<string, GameObject>();

            foreach(Transform tileTransform in tileHolder)
            {
                var x = (int)Mathf.Round(tileTransform.localPosition.x) + (MAP_WIDTH / 2);
                var z = (int)Mathf.Round(tileTransform.localPosition.z) + (MAP_HEIGHT / 2);

                locationToGameObject.Add($"{x}:{z}", tileTransform.gameObject);
            }

            var map = new Map(MAP_WIDTH, MAP_HEIGHT, null);

            LoadMap(map, locationToGameObject);
        }

        public void LoadMap(Map map, Dictionary<string, GameObject> locationToGameObject)
        {
            _map = map;
            map.ForEachTile((x, z, tile) =>
            {
                var tileObject = locationToGameObject[$"{x}:{z}"];
                var newTile = _tileFactory.Tiles[tileObject.name];
                _map.SetTile(x, z, newTile);

                if (newTile.SpawnPellet)
                {
                    var pelletObject = GameObject.Instantiate(PelletPrefab, tileObject.transform.position, Quaternion.identity);
                }
            });
        }
    }
}

