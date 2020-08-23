using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashSize : MonoBehaviour
{
    private Vector3 Scale;
    private float Size;
    public float MinSize;
    public float MaxSize;

    // Start is called before the first frame update
    void Start()
    {
        Size = Random.Range(MinSize, MaxSize);
        Scale = new Vector3(Size, Size, Size);
        transform.localScale = Scale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
