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
        protected Map _map;
        protected TileFactory _tileFactory;

        public GameObject PelletPrefab;

        [Inject]
        public void Construct(TileFactory tileFactory)
        {
            _tileFactory = tileFactory;
        }

        private void Start()
        {
            var floor = _tileFactory.Tiles["floor"];
            var map = new Map(13, 7, floor);

            for (int x = 0; x < map.Width; x++)
            {
                var wall = _tileFactory.Tiles["wall"];
                var wallTop = _tileFactory.Tiles["wall-top"];

                map.SetTile(x, 6, wallTop);
                map.SetTile(x, 5, wall);
            }

            LoadMap(map);
        }

        public void LoadMap(Map map)
        {
            _map = map;
            map.ForEachTile((x, y, tile) =>
            {
                var tileObject = _tileFactory.Create(tile.ID);

                tileObject.transform.localScale = Vector3.one;
                tileObject.transform.localPosition = new Vector3(
                    x - (_map.Width / 2),
                    y - (_map.Height / 2),
                    gameObject.transform.position.z
                );

                if(tile.SpawnPellet)
                {
                    GameObject.Instantiate(PelletPrefab, tileObject.transform.position, Quaternion.identity);
                }
            });
        }
    }
}

