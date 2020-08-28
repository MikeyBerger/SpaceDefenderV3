using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Transform[] EnemyShips;
    public float Timer;
    public int RandShip;

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(Timer);
        Instantiate(EnemyShips[RandShip], transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnEnemy());
    }
}
