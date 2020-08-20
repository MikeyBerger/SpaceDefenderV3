using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 MoveVector;
    public Vector2 RotateVector;
    private Rigidbody2D RB;
    private Animator Anim;
    public float Speed;
    public float JumpForce;
    public bool IsJumping = false;
    public bool IsShooting = false;
    public bool FacingRight = true;
    public Transform PlayerArm;
    public Transform PlayerBody;
    

    

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
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
        Flip();
        AnimatePlayer();


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
        if(RotateVector.x != 0 || RotateVector.y != 0)
        {
            PlayerArm.transform.right = new Vector2(RotateVector.x, RotateVector.y);
        }
    }

    void Flip()
    {
        Vector3 Scale;
        Scale = PlayerBody.localScale;

        if (MoveVector.x > 0)
        {
            Scale.x = 3;
            FacingRight = true;
        }
        else if (MoveVector.x < 1)
        {
            Scale.x = -3;
            FacingRight = false;
        }

        if (FacingRight)
        {
            Scale.x = 3;
        }
        PlayerBody.localScale = Scale;
    }

    void AnimatePlayer()
    {
        if (MoveVector.x > 0 || MoveVector.x < 0)
        {
            Anim.SetBool("IsWalking", true);
        }
        else if (MoveVector.x == 0)
        {
            Anim.SetBool("IsWalking", false);
        }
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
