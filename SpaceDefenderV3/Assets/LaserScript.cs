using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private Rigidbody2D RB;
    public float Speed;
    //public Transform ShootPoint;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Vector2 Direction = new Vector2(ShootPoint.position.x - transform.position.x, ShootPoint.position.y - transform.position.y);

        //transform.Translate(Vector2.right * Speed * Time.deltaTime);

        RB.velocity = Vector3.right * Speed * Time.deltaTime;
    }
}
