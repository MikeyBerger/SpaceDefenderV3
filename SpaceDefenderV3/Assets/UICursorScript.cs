using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class UICursorScript : MonoBehaviour
{
    Vector2 Movement;
    public float Speed;
    private Rigidbody2D RB;
    private MainMenuButtonScript MMBS;
    private ResumeButtonScript RBS;
    public bool ButtonIsPressed = false;
    public string MenuString;


    IEnumerator StopPress()
    {
        yield return new WaitForSeconds(1);
        ButtonIsPressed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        MMBS = GameObject.FindGameObjectWithTag("MainMenuButton").GetComponent<MainMenuButtonScript>();
        //RBS = GameObject.FindGameObjectWithTag("ResumeButton").GetComponent<ResumeButtonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector2(Movement.x, Movement.y) * Speed;

        if (MMBS.MenuIsPressed && ButtonIsPressed)
        {
            SceneManager.LoadScene(MenuString);
        }
    
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
    }

    public void OnPlayPress(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            ButtonIsPressed = true;
            //StartCoroutine(StopPress());
        }
    }
}
