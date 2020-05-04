using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowConP2 : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ourcastle"))
        {
            //GameFlow.enemyCastleHP -= castleDamage;
            Destroy(gameObject, .5f);

        }

        if (other.CompareTag("ourmelee") || other.CompareTag("ourarcher"))
        {

            Destroy(gameObject);

        }
    }
}

