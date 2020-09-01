using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public bool WasHit = false;
    //private Transform Graphic;
    //public Material Material;
    //private SpriteRenderer SR;

    private void Start()
    {
        //Graphic.GetComponent<SpriteRenderer>();
        //SR = GetComponentInChildren<SpriteRenderer>();
        //SR.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Instantiate(Explosion, transform.position, transform.rotation);
        if (collision.gameObject.tag == "Laser")
        {
            Destroy(transform.gameObject);
            WasHit = true;
            //SR.material = Material;
            Destroy(collision.gameObject);
        }
        //Destroy(transform.gameObject);
        //Destroy(collision.gameObject);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(transform.gameObject);
    }
}
