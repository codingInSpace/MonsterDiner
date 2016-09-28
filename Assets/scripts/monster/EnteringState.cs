using UnityEngine;

namespace Assets.scripts.monster
{
    public class EnteringState : IMonsterState
    {
        private readonly Monster _monster;

        public EnteringState(Monster monster)
        {
            this._monster = monster;
            _monster.HasSeat = false;
            _monster.TargetPos = new Vector2();
            _monster.SeatIndex = -1;
        }

        public void Initialize()
        {
            bool noSeatAvailable = true;

            // Check available seats
            for (var i = 0; i < SimpleManager.TakenSeats.Length; ++i)
            {
                if (SimpleManager.TakenSeats[i] != false) continue;
                _monster.TargetPos = SimpleManager.MonsterSeats[i];
                _monster.HasSeat = true;
                SimpleManager.TakenSeats[i] = true;
                _monster.SeatIndex = i;
                noSeatAvailable = false;
                break;
            }

            if (noSeatAvailable)
            {
                _monster.HasSeat = false;
                _monster.TargetPos = SimpleManager.DoorPos;
            }
        }

        public void Update()
        {
            Vector3 currentPos = _monster.gameObject.transform.position;
            float target = _monster.TargetPos.x;

            if (currentPos.x < target - 0.05f)
            {
                _monster.gameObject.GetComponent<Animator>().SetInteger("direction", 6);
                _monster.gameObject.transform.Translate(0.05f, 0.0f, 0.0f);
            }
            else if (currentPos.x > target + 0.05f)
            {
                _monster.gameObject.GetComponent<Animator>().SetInteger("direction", 4);
                _monster.gameObject.transform.Translate(-0.05f, 0.0f, 0.0f);
            }

            // Monster is at target
            else
            {
                if (_monster.HasSeat)
                {
                    _monster.gameObject.GetComponent<Animator>().SetInteger("direction", 5);
                    _monster.gameObject.transform.position = new Vector3(currentPos.x, _monster.GetSpawnCoordinates().y + 0.5f, currentPos.z);
                    UpdateState();
                }
                else
                {
                    _monster.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    UpdateState();
                }
            }
        }

        public void UpdateState()
        {
            VisitingState visitingState = new VisitingState(_monster);
            _monster.CurrentState = visitingState;
        }
        public void Print()
        {
            Debug.Log("Monster Entering: " + ((_monster.HasSeat) ? "has seat " + _monster.HasSeat + ", ": "") + "targetPos = " + _monster.TargetPos.x);
        }
    }
}