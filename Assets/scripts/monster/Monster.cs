using System;
using UnityEngine;

namespace Assets.scripts.monster
{
    public class Monster : MonoBehaviour
    {
        public MonsterState State = null;
        private static Vector3 SpawnCoordinates { get { return new Vector3(-30.0f, 0.5f, 0.0f); } }
        protected Animator animator;

        void Start ()
        {
            animator = this.GetComponent<Animator>();
            this.gameObject.transform.position = SpawnCoordinates;
            State = new EnteringState(this);
            State.Enter();
            State.Print();
        }
	
        void Update ()
        {
            State.Update();
        }

        public Vector3 getSpawnCoordinates()
        {
            return SpawnCoordinates;
        }
    }
}
