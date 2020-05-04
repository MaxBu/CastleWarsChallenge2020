using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireballCon : MonoBehaviour
{

    public GameObject enemyExplosion;
    public Transform enemyBoom;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-5, -5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ground"))
        {
            //area splash damage




            Destroy(gameObject, .5f);
            GameObject clone = (GameObject)Instantiate(enemyExplosion, enemyBoom.position, enemyBoom.rotation);
            Destroy(clone, 0.5f);

        }
    }
}