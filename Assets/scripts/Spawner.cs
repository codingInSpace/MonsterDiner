using UnityEngine;

public class Spawner : MonoBehaviour
{

    private float spawnBaseRate = 0.15f;
    private float spawnRate;

    void spawnRandomMonster()
    {
        float chance = Random.Range(0.0f, 1.0f);
        Debug.Log("Polling spawn rate " + spawnRate + " with chance " + chance);

        if (chance < spawnRate)
        {
            Debug.Log("A mosnter would be spawned");
            SimpleManager.IncrementCustomerCount();
        }
    }

    void Start()
    {
        InvokeRepeating("spawnRandomMonster", 0, 5.0f);
    }

    void Update()
    {
        // Update the spawnrate based on smart factors
        spawnRate = spawnBaseRate;
    }

}