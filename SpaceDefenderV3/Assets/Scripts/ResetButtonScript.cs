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
    private Renderer SR;
    private Color ColorWhite = Color.white;
    private Color ColorGreen = Color.green;

    //public Material[] Materials;

    // Start is called before the first frame update
    void Start()
    {
        Scale = transform.localScale;
        SR = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SR.enabled = true;

        if (ResetIsPressed)
        {
            SR.material.color = ColorGreen;
        }
        else
        {
            SR.material.color = ColorWhite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "Cursor")
        {
            //Scale = new Vector3(ScaledSizeX, ScaleSizeY, 1);
            //ResetText.fontSize = 45;
            ResetIsPressed = true;
            //SR.material.color = ColorGreen;
            //SR.color = Materials[1];
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "Cursor")
        {
            //Scale = new Vector3(DefaultSizeX, DefaultSizeY, 1);
            //ResetText.fontSize = 40;
            ResetIsPressed = false;
            //SR.material.color = ColorWhite;
            //SR.color = Materials[0];
        }
    }
}
