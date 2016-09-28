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

            // Translate down from sitting place
            Vector3 currentPos = _monster.gameObject.transform.position;
            _monster.gameObject.transform.position = new Vector3(currentPos.x, _monster.GetSpawnCoordinates().y, currentPos.z);

            this._leaveTarget = new Vector2(_monster.GetSpawnCoordinates().x, _monster.GetSpawnCoordinates().y);

            SimpleManager.PayForFood();
            SimpleManager.DecrementCustomerCount();
        }

        public void Update()
        {
            Vector3 currentPos = _monster.gameObject.transform.position;

            if (_leaveTarget == Vector2.zero) return;
            float target = _leaveTarget.x;

            if (currentPos.x < target - 0.005f)
            {
                if (_monster.NeedsInvertedDirection)
                {
                    _monster.GetComponent<SpriteRenderer>().flipX = false;
                }

                _monster.gameObject.GetComponent<Animator>().StopPlayback();
                _monster.gameObject.GetComponent<Animator>().SetInteger("direction", 6);
                _monster.gameObject.transform.Translate(0.05f, 0.0f, 0.0f);
            }

            else if (currentPos.x > target + 0.005f)
            {
                if (_monster.NeedsInvertedDirection)
                {
                    _monster.GetComponent<SpriteRenderer>().flipX = true;
                }

                _monster.gameObject.GetComponent<Animator>().StopPlayback();
                _monster.gameObject.GetComponent<Animator>().SetInteger("direction", 4);
                _monster.gameObject.transform.Translate(-0.05f, 0.0f, 0.0f);
            }

            // Monster is at target
            else
            {
                UnityEngine.Object.Destroy(_monster.gameObject);
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
