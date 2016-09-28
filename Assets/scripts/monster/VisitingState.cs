using UnityEngine;

namespace Assets.scripts.monster
{
    public class VisitingState : IMonsterState
    {
        private readonly Monster _monster;
        private bool _timeToLeave = false;

        public VisitingState(Monster monster)
        {
            this._monster = monster;
            _monster.HasSeat = monster.HasSeat;
            _monster.TargetPos = monster.TargetPos;
            _monster.SeatIndex = monster.SeatIndex;
            Initialize();
        }

        public void Initialize()
        {
            // Eat or something
            // ...
            Print();

            // Randomize visiting time
            //float visitingTime = Random.Range(10.0f, 20.0f);
            //Invoke("SetTimeToLeave", visitingTime);
        }

        private void SetTimeToLeave()
        {
            Debug.Log("Time to leave for a monster");
            _timeToLeave = true;
        }

        public void Update()
        {
            // Give money or something
            // ...

            if (_timeToLeave)
            {
                UpdateState();
            }


            float chance = Random.Range(0.0f, 1.0f);

            if (chance < 0.00003f)
            {
                SetTimeToLeave();
            }
        }

        public void UpdateState()
        {
            LeavingState leavingState = new LeavingState(_monster);
            _monster.CurrentState = leavingState;
        }

        public void Print()
        {
            Debug.Log("Monster visiting. " + ((_monster.HasSeat) ? "has seat " + _monster.HasSeat + ", " : "Is inside"));
        }
    }
}