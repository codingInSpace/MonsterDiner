using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const float SpawnBaseRate = 0.25f;
    private float _spawnRate;

    void SpawnRandomMonster()
    {
        float chance = Random.Range(0.0f, 1.0f);
        Debug.Log("Polling spawn rate " + _spawnRate + " with chance " + chance);

        if (chance < _spawnRate)
        {
            // Make random for multiple monsters
            const string monsterPath = "characters/monsters/pablo/pablo";
            GameObject monster = Instantiate(Resources.Load(monsterPath)) as GameObject;
        }
    }

    void Start()
    {
        InvokeRepeating("SpawnRandomMonster", 0, 5.0f);
    }

    void Update()
    {
        // Update the spawnrate based on smart factors
        _spawnRate = SpawnBaseRate;
    }

}