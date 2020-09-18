using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Vector2 MoveVector;
    public Vector2 RotateVector;
    private Rigidbody2D RB;
    private Animator Anim;
    public float Speed;
    public float JumpForce;
    public float Reload;
    public float BulletForce;
    public bool IsJumping = false;
    public bool IsShooting = false;
    public bool FacingRight = false;
    public bool AirBorn = false;
    public static bool GameIsPaused = false;
    public Transform PlayerArm;
    public Transform PlayerBody;
    public Transform MuzzleFlash;
    public Transform MuzzleFlashPoint;
    public Transform Bullet;
    public Transform ShootPoint;
    public Transform AudioClip;
    public GameObject PauseMenuUI;
    Quaternion Rotation;
    public LayerMask WhatToHit;
    
    
    
    IEnumerator StopShooting()
    {
        yield return new WaitForSeconds(0);
        IsShooting = false;
    }

    IEnumerator StartShooting()
    {
        yield return new WaitForSeconds(0);
        Instantiate(MuzzleFlash, MuzzleFlashPoint.position, MuzzleFlashPoint.rotation);
        Transform BulletPrefab = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        Instantiate(AudioClip, ShootPoint.position, ShootPoint.rotation);

        Rigidbody2D BulletRB = BulletPrefab.GetComponent<Rigidbody2D>();
        BulletRB.AddForce(ShootPoint.up * BulletForce, ForceMode2D.Impulse);
    }



    

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        FacingRight = true;

        Rotation = ShootPoint.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RB.velocity = new Vector2(MoveVector.x, 0) * Speed * Time.deltaTime;
        //Jump();
        Arm();
        //Flip();
        Flip2();
        AnimatePlayer();
        Shoot();
        //ShootV2();


    }

    #region Methods
    void Jump()
    {
        if (IsJumping && !AirBorn)
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
    }// Not in use

    void Flip2()
    {
        if(MoveVector.x > 0 && !FacingRight || MoveVector.x < 0 && FacingRight)
        {
            FacingRight = !FacingRight;

            Vector3 Scale;
            Scale = PlayerBody.localScale;

            Scale.x *= -1;

            PlayerBody.localScale = Scale;
        }
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

    void Shoot()
    {
        if (IsShooting)
        {
            StartCoroutine(StartShooting());
            IsShooting = false;
        }
        else if (!IsShooting)
        {
            StopAllCoroutines();
        }
    }

    void ShootV2()
    {
        if (IsShooting)
        {
            Vector2 StickPos = new Vector2(RotateVector.x, RotateVector.y);
            Vector2 ShootPos = new Vector2(ShootPoint.position.x, ShootPoint.position.y);
            RaycastHit2D Hit = Physics2D.Raycast(ShootPos, StickPos - ShootPos, 100, WhatToHit);
            Debug.DrawLine(ShootPos, StickPos * 100);

            if (Hit.transform.gameObject.tag == "Enemy")
            {
                Destroy(Hit.transform.gameObject);
            }

            if (Hit.collider != null)
            {
                Debug.DrawLine(ShootPos, Hit.point, Color.red);
            }
        }
        else
        {
            Vector2 StickPos = new Vector2(RotateVector.x, RotateVector.y);
            Vector2 ShootPos = new Vector2(ShootPoint.position.x, ShootPoint.position.y);
            RaycastHit2D Hit = Physics2D.Raycast(ShootPos, StickPos - ShootPos, 0);
            Debug.DrawLine(ShootPos, StickPos * 0);
        }



    }

    void PauseGame()
    {

    }
    #endregion

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
            //StartCoroutine(StopShooting());
        }
    }

    public void OnRotateArm(InputAction.CallbackContext ctx)
    {
        RotateVector = ctx.ReadValue<Vector2>();
    }

    public void OnPause(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed && !GameIsPaused)
        {
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0;
            GameIsPaused = true;
        }
        else if (ctx.phase == InputActionPhase.Performed && GameIsPaused)
        {
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1;
            GameIsPaused = false;
        }
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AirBorn = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        AirBorn = true;
    }
}
