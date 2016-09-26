using UnityEngine;

public class SimpleManager : MonoBehaviour
{
    private static SimpleManager _instance;
    public static SimpleManager Instance { get { return _instance; } }

    public Vector2[] monsterSeats;
    private bool monstersSpawning = false;
    private static float amountMonsterCustomers = 0;

    public static float GetAmountCustomers { get { return amountMonsterCustomers; } }

    public static void IncrementCustomerCount() { ++amountMonsterCustomers; }

    public static void DecrementCustomerCount() { --amountMonsterCustomers; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}