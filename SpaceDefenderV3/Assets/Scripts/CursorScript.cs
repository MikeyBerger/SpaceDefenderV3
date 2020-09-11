using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CursorScript : MonoBehaviour
{
    Vector2 Movement;
    public float Speed;
    private ButtonScript BS;
    private Rigidbody2D RB;
    public string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        BS = GameObject.FindGameObjectWithTag("Button").GetComponent<ButtonScript>();
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (BS.IsPressed)
        {
            SceneManager.LoadScene(SceneName);
        }
        

        RB.velocity = new Vector2(Movement.x, Movement.y) * Speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
    }

    public void OnPress(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            BS.IsPressed = true;
        }
    }
}
