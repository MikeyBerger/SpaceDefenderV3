using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public bool WasHit = false;
    //private Transform Graphic;
    //public Material Material;
    //private SpriteRenderer SR;
    public GameObject Child;
    public float Timer;
    private BoxCollider2D BC2D;
    public Transform Explosion;
    //private SaveSystemV2 SSV2;
    private GameMaster GM;
    private int PowerUpNumber;
    public Transform PowerUp1;
    public Transform PowerUp2;
    private int RandPowerUp;
    public bool SpawnPowerUp = false;

    IEnumerator DestroyShip()
    {
        yield return new WaitForSeconds(Timer);
        Destroy(transform.gameObject);
    }

    private void Start()
    {
        //Graphic.GetComponent<SpriteRenderer>();
        //SR = GetComponentInChildren<SpriteRenderer>();
        //SR.enabled = true;
        Child.transform.SetParent(transform);
        BC2D = GetComponent<BoxCollider2D>();
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>();

        PowerUpNumber = Random.Range(1, 2);

        if (PowerUpNumber == 1)
        {
            SpawnPowerUp = true;
        }
        else
        {
            SpawnPowerUp = false;
        }

        RandPowerUp = Random.Range(1, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Instantiate(Explosion, transform.position, transform.rotation);
        if (collision.gameObject.tag == "Laser")
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            if (SpawnPowerUp == true)
            {
                if (RandPowerUp == 1)
                {
                    Instantiate(PowerUp1, transform.position, Quaternion.identity);
                }
                else if (RandPowerUp == 2)
                {
                    Instantiate(PowerUp2, transform.position, Quaternion.identity);
                }
            }
            //Destroy(transform.gameObject);
            WasHit = true;
            GM.Score++;
            //SR.material = Material;
            Destroy(collision.gameObject);
            Destroy(Child.gameObject);
            BC2D.enabled = false;
            StartCoroutine(DestroyShip());
        }
        //Destroy(transform.gameObject);
        //Destroy(collision.gameObject);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(transform.gameObject);
    }
}
