using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CursorScript : MonoBehaviour
{
    Vector2 Movement;
    public float Speed;
    private PlayButtonScriptV3 PBSV3;
    private OptionButtonScript OBS;
    private Rigidbody2D RB;
    public string PlayScene;
    public string OptionScene;
    public bool ButtonIsPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        PBSV3 = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScriptV3>();
        OBS = GameObject.FindGameObjectWithTag("OptionButton").GetComponent<OptionButtonScript>();
        RB = GetComponent<Rigidbody2D>();
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
