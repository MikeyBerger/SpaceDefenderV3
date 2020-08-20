using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmScript : MonoBehaviour
{

    private Vector2 RotateVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = new Vector2(RotateVector.y, RotateVector.x);
        //transform.LookAt(new Vector2(RotateVector.x, RotateVector.y));
    }

    public void OnRotateArm(InputAction.CallbackContext ctx)
    {
        RotateVector = ctx.ReadValue<Vector2>();
    }
}
