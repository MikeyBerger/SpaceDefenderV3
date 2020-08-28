using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private Rigidbody2D RB;
    public float Speed;
    public float TurnSpeed;
    private Transform Arm;
    private PlayerController PC;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Arm = GameObject.FindGameObjectWithTag("Arm").GetComponent<Transform>();
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        /*
        //Vector2 Direction = new Vector2(ShootPoint.position.x - transform.position.x, ShootPoint.position.y - transform.position.y);

        //transform.Translate(Arm.position * Speed * Time.deltaTime);

        //transform.Translate(Vector3.right * Speed * Time.deltaTime);

        //RB.velocity = Vector3.right * Speed * Time.deltaTime;

        //RB.AddForce(new Vector2(Arm.rotation * Speed, Arm.rotation * Speed));

        // RB.velocity = new Vector2(PC.RotateVector.x, PC.RotateVector.y) * Speed * Time.deltaTime;

        //RB.velocity = new Vector2(Arm.position.x, Arm.position.y) * Speed;

        //RB.MovePosition(new Vector2(Speed, Speed) * Time.deltaTime);

        if (Arm.rotation.z == 90)
        {
            RB.velocity = Vector3.up * Speed * Time.deltaTime;
        }
        else if (Arm.rotation.y == -180)
        {
            RB.velocity = Vector3.left * Speed * Time.deltaTime;
        }
        else if (Arm.rotation.z == -90)
        {
            RB.velocity = Vector3.down * Speed * Time.deltaTime;
        }
        else if (Arm.rotation.y == 0)
        {
            RB.velocity = Vector3.right * Speed * Time.deltaTime;
        }
        */

        


    }
}
