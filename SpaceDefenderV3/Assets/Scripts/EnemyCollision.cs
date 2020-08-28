using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(transform.gameObject);
        Destroy(collision.gameObject);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(transform.gameObject);
    }
}
