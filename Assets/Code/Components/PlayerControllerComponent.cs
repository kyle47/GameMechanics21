using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Game.Entity;

namespace Game.Components
{
    public class PlayerControllerComponent : MonoBehaviour
    {
        protected PlayerController _playerController;

        public GameObject PlayerPrefab;

        private void Start()
        {
            // TODO: Move
            var unit = new Unit();
            var map = GameObject.FindObjectOfType<MapComponent>();
            var playerUnitObject = GameObject.Instantiate(PlayerPrefab, map.gameObject.transform);
            playerUnitObject.transform.localScale = Vector3.one;
            playerUnitObject.AddComponent<PlayerComponent>();

            var unitComponent = playerUnitObject.GetComponent<UnitComponent>().Construct(unit);

            var playerContoller = new PlayerController();
            playerContoller.AddUnit(unit);
            Construct(playerContoller);
        }

        public PlayerControllerComponent Construct(PlayerController playerController)
        {
            _playerController = playerController;
            return this;
        }

        private void Update()
        {
            _playerController.InputVertical = 0;
            _playerController.InputHorizontal = 0;

            if (Input.GetKey(KeyCode.A))
            {
                _playerController.InputHorizontal = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _playerController.InputHorizontal = 1;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                _playerController.InputVertical = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _playerController.InputVertical = -1;
            }

            _playerController.Tick();
        }
    }
}
