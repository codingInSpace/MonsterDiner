using UnityEngine;

namespace Assets.scripts.monster
{
    public interface IMonsterState
    {
        void Initialize();
        void Update();
        void Print();
        void UpdateState();
    }
}