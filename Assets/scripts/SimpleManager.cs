using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleManager : MonoBehaviour {
    private static SimpleManager _instance;

    public static SimpleManager Instance { get { return _instance; } }

    public Vector2[] monsterSeats;
    private float amountMonsterCustomers;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
}
