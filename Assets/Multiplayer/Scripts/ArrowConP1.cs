using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowConP1 : MonoBehaviour
{
    //public int arrowDamage = 5;
    //public int castleDamage = 5;
    
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemycastle"))
        {
            //GameFlow.enemyCastleHP -= castleDamage;
            Destroy(gameObject, .5f);
            
        }

        if (other.CompareTag("enemymelee"))
        {
            
            Destroy(gameObject);

        }

        if (other.CompareTag("enemymelee") || other.CompareTag("enemyArcher"))
        {

            Destroy(gameObject);

        }
    }
}
