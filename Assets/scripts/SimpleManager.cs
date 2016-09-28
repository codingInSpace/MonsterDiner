using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

public class SimpleManager : MonoBehaviour
{
    private static SimpleManager _instance;
    public static SimpleManager Instance { get { return _instance; } }

    public static Vector2[] MonsterSeats;
    public static Vector2 DoorPos;
    public static bool[] TakenSeats;

    public static int Gold = 0;

    private bool monstersSpawning = false;
    private static float _amountMonsterCustomers = 0;


    public static void PayForFood()
    {
        Gold += 5;
        GameObject.Find("GoldText").GetComponent<Text>().text = "Gold: " + Gold;
    }
    
    public static float GetAmountCustomers { get { return _amountMonsterCustomers; } }
    public static void IncrementCustomerCount() { ++_amountMonsterCustomers; }
    public static void DecrementCustomerCount() { --_amountMonsterCustomers; }

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

    private void Start()
    {
        // Initialize seats, door with coordinates of sprite in scene :(
        DoorPos = new Vector2(3.5f, 0.0f);
        MonsterSeats = new Vector2[3] {new Vector2(-3.0f, 0.0f), new Vector2(-1.4f, 0.0f), new Vector2(1.0f, 0.0f)};
        TakenSeats = new bool[MonsterSeats.Length];
        for (var i = 0; i < TakenSeats.Length; ++i)
        {
            TakenSeats[i] = false;
        }

        // Add spawner when ready
        monstersSpawning = true;
        this.gameObject.AddComponent<Spawner>();
    }
}