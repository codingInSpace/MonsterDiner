﻿using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const float spawnBaseRate = 0.5f;
    private float spawnRate;

    void spawnRandomMonster()
    {
        float chance = Random.Range(0.0f, 1.0f);
        Debug.Log("Polling spawn rate " + spawnRate + " with chance " + chance);

        if (chance < spawnRate)
        {
            Debug.Log("A mosnter would be spawned");
            SimpleManager.IncrementCustomerCount();
            const string monsterPath = "characters/monsters/pablo/pablo";
            GameObject monster = Instantiate(Resources.Load(monsterPath)) as GameObject;
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