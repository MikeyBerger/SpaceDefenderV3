using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : MonoBehaviour
{
    private Animator Anim;
    public float HitTime;

    IEnumerator NotHit()
    {
        yield return new WaitForSeconds(HitTime);
        Anim.SetBool("WasHit", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
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
            Anim.SetBool("WasHit", true);
            StartCoroutine(NotHit());
        }
    }
}
