using UnityEngine;

public class Spawner : MonoBehaviour
{

    private double spawnBaseRate = 0.25;
    private double spawnRate;

    void spawnRandomMonster()
    {
        Debug.Log("A mosnter would be spawned");
        // Poll this value every 5 sec
        spawnRate = spawnBaseRate;
    }

    void Start()
    {
        InvokeRepeating("spawnRandomMonster", 0, 5.0f);
    }

}