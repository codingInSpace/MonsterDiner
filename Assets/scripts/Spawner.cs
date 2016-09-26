using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    private double spawnBaseRate = 0.25;
    private double spawnRate;

    void Update () {
        // Poll this value every 5 sec
        spawnRate = spawnBaseRate;
    }
}