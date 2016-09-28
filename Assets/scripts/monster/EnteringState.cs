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
                Debug.Log("Monster received seat " + TargetSeat.x);
                break;
            }

            if (noSeatAvailable)
            {
                this.HasSeat = false;
                this.TargetSeat = SimpleManager.doorPos;
            }

            // Update State to visiting
        }

        public override void Update()
        {
            Vector3 currentPos = Monster.gameObject.transform.position;

            if (currentPos.x < TargetSeat.x - 0.05f)
            {
                Monster.gameObject.GetComponent<Animator>().SetInteger("direction", 6);
                Monster.gameObject.transform.Translate(0.05f, 0.0f, 0.0f);
            }
            else if (currentPos.x > TargetSeat.x + 0.05f)
            {
                Monster.gameObject.GetComponent<Animator>().SetInteger("direction", 4);
                Monster.gameObject.transform.Translate(-0.05f, 0.0f, 0.0f);
            }

            // Monster is at target
            else
            {
                if (HasSeat)
                {
                    Monster.gameObject.GetComponent<Animator>().SetInteger("direction", 5);
                    Monster.gameObject.transform.position = new Vector3(currentPos.x, Monster.getSpawnCoordinates().y + 0.5f, currentPos.z);
                }
                else
                {
                    Monster.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
            }


        }

        public override void Print()
        {
            Debug.Log("Monster: " + "hasSeat = " + HasSeat + ", targetSeat = " + TargetSeat.x);
        }
    }
}