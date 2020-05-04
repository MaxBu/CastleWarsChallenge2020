using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballConM : MonoBehaviour
{

    public GameObject explosion;
    public Transform boom;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(5, -5);
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ground"))
        {
            

            

            
            Destroy(gameObject, .5f);
            GameObject clone = PhotonNetwork.Instantiate(explosion.name, boom.position, boom.rotation);
            Destroy(clone, 0.5f);

        }

     
    }
}
