using UnityEngine;

namespace Assets.scripts.monster
{
    public abstract class MonsterState
    {
        public Monster Monster { get; set; }

        private bool _hasSeat;
        public bool HasSeat
        {
            get { return _hasSeat; }
            set { _hasSeat = value; }
        }

        public Vector2 TargetSeat { get; set; }

        public abstract void Enter();
    }
}