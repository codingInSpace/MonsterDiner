using System;
using UnityEngine;

namespace Assets.scripts.monster
{
    public class Monster : MonoBehaviour
    {
        private static Vector3 SpawnCoordinates { get { return new Vector3(-30.0f, 0.5f, 0.0f); } }

        // State variables
        [HideInInspector] public bool HasSeat;
        [HideInInspector] public int SeatIndex;
        [HideInInspector] public Vector2 TargetPos;

        [HideInInspector] public IMonsterState CurrentState;
        [HideInInspector] public EnteringState EnteringState;

        private void Awake()
        {
            EnteringState = new EnteringState(this);
        }

        void Start()
        {
            this.gameObject.transform.position = SpawnCoordinates;
            CurrentState = EnteringState;
            CurrentState.Initialize();
            CurrentState.Print();
        }
	
        void Update()
        {
            CurrentState.Update();
        }

        public Vector3 getSpawnCoordinates()
        {
            return SpawnCoordinates;
        }
    }
}
