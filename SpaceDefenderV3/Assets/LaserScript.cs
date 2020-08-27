using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private Rigidbody2D RB;
    public float Speed;
    private Transform Arm;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Arm = GameObject.FindGameObjectWithTag("Arm").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Vector2 Direction = new Vector2(ShootPoint.position.x - transform.position.x, ShootPoint.position.y - transform.position.y);

        //transform.Translate(Arm.position * Speed * Time.deltaTime);

        //transform.Translate(Vector3.right * Speed * Time.deltaTime);

        RB.velocity = Vector3.right * Speed * Time.deltaTime;

        //RB.AddForce(new Vector2(Arm.rotation * Speed, Arm.rotation * Speed));
    }
}
