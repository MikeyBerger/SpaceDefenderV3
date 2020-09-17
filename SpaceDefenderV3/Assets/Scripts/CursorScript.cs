using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CursorScript : MonoBehaviour
{
    Vector2 Movement;
    public float Speed;
    private MainMenuButtonScript MMBS;
    private PlayButtonScriptV3 PBSV3;
    private OptionButtonScript OBS;
    private ResetButtonScript RBS;
    private SaveSystemV2 SSV2;
    private Rigidbody2D RB;
    public string PlayScene;
    public string OptionScene;
    public string MainMenu;
    public bool ButtonIsPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        //MMBS = GameObject.FindGameObjectWithTag("MainMenuButton").GetComponent<MainMenuButtonScript>();
        SSV2 = new SaveSystemV2();
        PBSV3 = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScriptV3>();
        OBS = GameObject.FindGameObjectWithTag("OptionButton").GetComponent<OptionButtonScript>();
        //RBS = GameObject.FindGameObjectWithTag("ResetButton").GetComponent<ResetButtonScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PBSV3.PlayIsPressed && ButtonIsPressed)
        {
            SceneManager.LoadScene(PlayScene);
        }

        if (OBS.OptionIsPressed && ButtonIsPressed)
        {
            SceneManager.LoadScene(OptionScene);
        }
        /*
        if (RBS.ResetIsPressed && ButtonIsPressed)
        {
            PlayerPrefs.DeleteKey("HiScore");

            SSV2.HiScore = 0;
        }

        if (MMBS.MenuIsPressed && ButtonIsPressed)
        {
            SceneManager.LoadScene(MainMenu);
        }
        */

        RB.velocity = new Vector2(Movement.x, Movement.y) * Speed * Time.deltaTime;
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
