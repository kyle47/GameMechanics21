using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Game.Mapping;

namespace Game.Entity
{
    public class Controller
    {
        protected List<Unit> _units = new List<Unit>();

        public void AddUnit(Unit unit)
        {
            _units.Add(unit);
        }

        public virtual void Tick()
        {
            _units.ForEach(unit =>
            {
                if(unit.Moving == false)
                {
                    OnUnitWaiting(unit);
                }
            });
        }

        public virtual void OnUnitWaiting(Unit unit)
        {
            
        }
    }
}
