using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmScript : MonoBehaviour
{
    private PlayerController PC;
    private Vector2 RotateVector;

    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PC.RotateVector.x == 0 && PC.RotateVector.y == 0)
        {
            transform.right = Vector2.zero;
            transform.up = Vector2.zero;
           
        }
    }

    public void OnRotateArm(InputAction.CallbackContext ctx)
    {
        RotateVector = ctx.ReadValue<Vector2>();
    }
}
