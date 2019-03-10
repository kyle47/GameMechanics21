using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Game.Components
{
    public class PlayerComponent : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Pellet"))
            {
                GameObject.Destroy(other.gameObject);
            }
        }
    }
}
