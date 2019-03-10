using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Game.Mapping;

namespace Game.Entity
{
    public class PlayerController : Controller
    {
        public int InputVertical;
        public int InputHorizontal;

        public override void OnUnitWaiting(Unit unit)
        {
            if(InputHorizontal != 0 || InputVertical != 0)
            {
                unit.MoveTo(unit.X + InputHorizontal, unit.Y + InputVertical);
            }
        }
    }
}
