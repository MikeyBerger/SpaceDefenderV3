using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemyGraphic : MonoBehaviour
{
    private SpriteRenderer SR;
    public Material Material;
    public Transform Parent;
    private EnemyCollision EC;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.enabled = true;
        EC = GetComponentInParent<EnemyCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EC.WasHit)
        {
            SR.sharedMaterial = Material;
        } 
    }
}
