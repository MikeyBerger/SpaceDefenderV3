using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private LaserCollision LC;

    // Start is called before the first frame update
    void Start()
    {
        LC = GameObject.FindGameObjectWithTag("Laser").GetComponent<LaserCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LC.SpawnExplosion)
        {
            Instantiate(LC.Explosion, LC.gameObject.transform.position, LC.gameObject.transform.rotation);
            Destroy(LC.transform.gameObject);
        }
    }
}
