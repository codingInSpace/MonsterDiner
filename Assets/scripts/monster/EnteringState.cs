using UnityEngine;

namespace Assets.scripts.monster
{
    public class EnteringState : MonsterState
    {
        public EnteringState(MonsterState state)
            : this(state.Monster)
        {

        }

        public EnteringState(Monster monster)
        {
            this.Monster = monster;
            this.HasSeat = false;
            this.TargetSeat = new Vector2();
        }

        public override void Enter()
        {
            bool noSeatAvailable = true;

            // Check available seats
            for (var i = 0; i < SimpleManager.TakenSeats.Length; ++i)
            {
                if (SimpleManager.TakenSeats[i] != false) continue;
                this.TargetSeat = SimpleManager.MonsterSeats[i];
                this.HasSeat = true;
                SimpleManager.TakenSeats[i] = true;
                noSeatAvailable = false;
            }

            if (noSeatAvailable)
            {
                this.HasSeat = false;
            }

            // Update State to visiting
        }

        void Update()
        {
            Debug.Log("testing");
        }
    }
}