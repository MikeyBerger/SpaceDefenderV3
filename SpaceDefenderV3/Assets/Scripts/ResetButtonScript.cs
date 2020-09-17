using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButtonScript : MonoBehaviour
{

    private Vector3 Scale;
    public float DefaultSizeX;
    public float DefaultSizeY;
    public float ScaledSizeX;
    public float ScaleSizeY;
    public Text ResetText;
    public bool ResetIsPressed = false;

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
            ResetText.fontSize = 45;
            ResetIsPressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cursor")
        {
            Scale = new Vector3(DefaultSizeX, DefaultSizeY, 1);
            ResetText.fontSize = 40;
            ResetIsPressed = false;
        }
    }
}
