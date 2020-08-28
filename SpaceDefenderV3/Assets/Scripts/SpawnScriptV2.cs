using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScriptV2 : MonoBehaviour
{
    private int RandShip;
    public int MinShip;
    public int MaxShip;
    public float SpawnTimer;
    public float Limit;
    public Transform[] EnemyShips;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RandShip = Random.Range(MinShip, MaxShip);

        SpawnTimer += Time.deltaTime;

        if (SpawnTimer >= Limit)
        {
            Instantiate(EnemyShips[0], transform.position, transform.rotation);
            SpawnTimer = 0;
        }
    }
}
