using UnityEngine;

namespace Assets.scripts.monster
{
    public class LeavingState : IMonsterState
    {

        private readonly Monster _monster;
        private Vector2 _leaveTarget;

        public LeavingState(Monster monster)
        {
            this._monster = monster;
            _monster.HasSeat = monster.HasSeat; //necessary?
            _monster.SeatIndex = monster.SeatIndex;

            this._leaveTarget = Vector2.zero;
            Initialize();
        }

        public void Initialize()
        {
            // Find seat and make available
            if (_monster.HasSeat)
            {
                SimpleManager.TakenSeats[_monster.SeatIndex] = false;
                _monster.SeatIndex = 0;
            }

            // No seat
            else
            {
                _monster.GetComponent<SpriteRenderer>().enabled = true;
            }

            this._leaveTarget = new Vector2(_monster.GetSpawnCoordinates().x, _monster.GetSpawnCoordinates().y);
        }

        public void Update()
        {
            Vector3 currentPos = _monster.gameObject.transform.position;

            if (_leaveTarget == Vector2.zero) return;
            float target = _leaveTarget.x;

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
                UnityEngine.Object.Destroy(_monster.gameObject);
                //_monster = null; //read-only
            }
        }

        public void UpdateState()
        {
            // No more
        }

        public void Print()
        {
            Debug.Log("Monster Leaving.");
        }
    }
}
