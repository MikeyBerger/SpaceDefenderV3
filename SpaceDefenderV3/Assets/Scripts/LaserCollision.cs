using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour
{
    public Transform Explosion;
    public bool SpawnExplosion = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            SpawnExplosion = true;
            Instantiate(Explosion, transform.position, transform.rotation);
        }
        //Instantiate(Explosion, transform.position, transform.rotation);

        //Destroy(transform.gameObject);
    }
}
