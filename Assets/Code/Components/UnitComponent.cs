using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Game.Entity;

namespace Game.Components
{
    public class UnitComponent : MonoBehaviour
    {
        protected const float SNAP_DELTA = .05f;

        public Rigidbody2D Rigidbody2D;

        protected Vector3 _targetPosition;
        protected bool _moving;

        protected Unit _unit;

        // TODO: Replace with factory implementation
        public UnitComponent Construct(Unit unit)
        {
            _unit = unit;
            _unit.OnStartMovement += OnStartMove;
            return this;
        }

        private void FixedUpdate()
        {
            if (_moving)
            {
                var direction = (_targetPosition - gameObject.transform.position).normalized;
                Rigidbody2D.velocity = direction.normalized * _unit.Speed;

                _moving = Vector2.Distance(gameObject.transform.position, _targetPosition) > SNAP_DELTA;
                if (_moving == false)
                {
                    gameObject.transform.position = _targetPosition;
                    Rigidbody2D.velocity = Vector2.zero;
                    _unit.OnMovementDone();
                }
            }
        }

        public void OnStartMove(int x, int y)
        {
            _targetPosition = new Vector3(
                x,
                y,
                gameObject.transform.position.z
            );
            _moving = true;
        }
    }
}

