using UnityEngine;

namespace Assets.scripts.monster
{
    public class VisitingState : MonsterState
    {
        private bool _timeToLeave = false;

        public VisitingState(MonsterState state)
            : this(state.Monster, state.HasSeat, state.TargetPos, state.SeatIndex)
        {}

        public VisitingState(Monster monster, bool hasSeat, Vector2 targetPos, int seatIndex)
        {
            this.Monster = monster;
            this.HasSeat = hasSeat;
            this.TargetPos = targetPos;
            this.SeatIndex = seatIndex;
        }

        public override void Initialize()
        {
            // Eat or something
            // ...
            Print();

            // Randomize visiting time
            float visitingTime = Random.Range(10.0f, 20.0f);
            Invoke("SetTimeToLeave", visitingTime);
        }

        private void SetTimeToLeave()
        {
            _timeToLeave = true;
        }

        public override void Update()
        {
            // Give money or something
            // ...

            if (_timeToLeave)
            {
                UpdateState();
            }
        }

        private void UpdateState()
        {
            Monster.State = new LeavingState(this);
        }

        public override void Print()
        {
            Debug.Log("Monster visiting. " + ((HasSeat) ? "has seat " + HasSeat + ", " : "Is inside"));
        }
    }
}