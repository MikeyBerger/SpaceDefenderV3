using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterScriptV2 : MonoBehaviour
{
    public Transform ThrusterPrefab;
    public float Limit;
    public float SpawnTimer;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimer += Time.deltaTime;


        if(SpawnTimer >= Limit)
        {
            Instantiate(ThrusterPrefab, transform.position, transform.rotation);
            SpawnTimer = 0;
        }
    }
}
