using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class OptionCursorScript : MonoBehaviour
{

    Vector2 Movement;
    public float Speed;
    private MainMenuButtonScript MMBS;
    private ResetButtonScript RBS;
    private SaveSystemV2 SSV2;
    private Rigidbody2D RB;
    public string MainMenu;
    public bool ButtonIsPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        MMBS = GameObject.FindGameObjectWithTag("MainMenuButton").GetComponent<MainMenuButtonScript>();
        RBS = GameObject.FindGameObjectWithTag("ResetButton").GetComponent<ResetButtonScript>();
        SSV2 = new SaveSystemV2();
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector2(Movement.x, Movement.y) * Speed * Time.deltaTime;

        if (RBS.ResetIsPressed && ButtonIsPressed)
        {
            PlayerPrefs.DeleteKey("HiScore");

            SSV2.HiScore = 0;
        }

        if (MMBS.MenuIsPressed && ButtonIsPressed)
        {
            SceneManager.LoadScene(MainMenu);
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
        }
    }
}
