using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 MoveVector;
    public Vector2 RotateVector;
    private Rigidbody2D RB;
    public float Speed;
    public float JumpForce;
    public bool IsJumping = false;
    public bool IsShooting = false;
    public Transform PlayerArm;
    

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
        RB.velocity = new Vector2(MoveVector.x, 0) * Speed * Time.deltaTime;
        Jump();
        Arm();

    }

    void Jump()
    {
        if (IsJumping)
        {
            RB.AddForce(Vector2.up * JumpForce * Time.deltaTime);
            IsJumping = false;
        }
    }

    void Arm()
    {
        PlayerArm.transform.right = new Vector2(RotateVector.x, RotateVector.y);
    }




    #region InputActions
    public void OnMove(InputAction.CallbackContext ctx)
    {
        MoveVector = ctx.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if(ctx.phase == InputActionPhase.Performed)
        {
            IsJumping = true;
        }
    }

    public void OnShoot(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            IsShooting = true;
        }
    }

    public void OnRotateArm(InputAction.CallbackContext ctx)
    {
        RotateVector = ctx.ReadValue<Vector2>();
    }
    #endregion
}
