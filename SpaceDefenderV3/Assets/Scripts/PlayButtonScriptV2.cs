using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonScriptV2 : MonoBehaviour
{

    private Vector3 Scale;
    public float DefaultSizeX;
    public float DefaultSizeY;
    public float ScaledSizeX;
    public float ScaleSizeY;
    public Text PlayText;
    public bool IsPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        Scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cursor")
        {
            Scale = new Vector3(ScaledSizeX, ScaleSizeY, 1);
            PlayText.fontSize = 45;
            IsPressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cursor")
        {
            Scale = new Vector3(DefaultSizeX, DefaultSizeY, 1);
            PlayText.fontSize = 40;
            IsPressed = false;
        }
    }
}
