using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterScript : MonoBehaviour
{
    private Vector3 Scale;
    public float Size;
    public float MinSize;
    public float MaxSize;
    public float DestroyLimit;
    public float DestroyTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Size = Random.Range(MinSize, MaxSize);
        Scale = new Vector3(Size, Size, Size);
        transform.localScale = Scale;


        DestroyTimer += Time.deltaTime;

        if (DestroyTimer >= DestroyLimit)
        {
            Destroy(transform.gameObject);
        }
    }
}
