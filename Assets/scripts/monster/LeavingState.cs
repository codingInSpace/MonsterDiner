using UnityEngine;

namespace Assets.scripts.monster
{
    public class LeavingState : MonsterState
    {
        public LeavingState(MonsterState state)
            : this(state.Monster, state.HasSeat, state.SeatIndex)
        {}

        public LeavingState(Monster monster, bool hasSeat, int seatIndex)
        {
            this.Monster = monster;
            this.HasSeat = hasSeat; //necessary?
            this.SeatIndex = seatIndex;
        }

        public override void Initialize()
        {
            // Find seat and make available
            if (HasSeat)
            {
                SimpleManager.TakenSeats[SeatIndex] = false;
                this.SeatIndex = 0;
            }

            // No seat
            else
            {
                Monster.GetComponent<SpriteRenderer>().enabled = true;
            }

            this.TargetPos = new Vector2(Monster.getSpawnCoordinates().x, Monster.getSpawnCoordinates().y);
            Print();
        }

        public override void Update()
        {
            Vector3 currentPos = Monster.gameObject.transform.position;

            if (currentPos.x < TargetPos.x - 0.05f)
            {
                Monster.gameObject.GetComponent<Animator>().SetInteger("direction", 6);
                Monster.gameObject.transform.Translate(0.05f, 0.0f, 0.0f);
            }
            else if (currentPos.x > TargetPos.x + 0.05f)
            {
                Monster.gameObject.GetComponent<Animator>().SetInteger("direction", 4);
                Monster.gameObject.transform.Translate(-0.05f, 0.0f, 0.0f);
            }

            // Monster is at target
            else
            {
                UnityEngine.Object.Destroy(Monster.gameObject);
                Monster = null;
            }

        }

        public override void Print()
        {
            Debug.Log("Monster Leaving.");
        }
    }
}
