using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGraphic : MonoBehaviour
{
    private EnemyCollision EC;
    private SpriteRenderer SR;
    public Material DestroyMat;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
