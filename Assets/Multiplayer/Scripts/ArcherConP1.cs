using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherConP1 : MonoBehaviour
{
    public float playerArcherHP = 10;
    public float fireDelay = 3f;
    public int enemyArrowtakingDamage = 4;

    public Transform arrowObj;

    private Rigidbody2D arherRB;
    private Animator anim;
    private BoxCollider2D box2d;

    void Start()
    {
        arherRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box2d = GetComponent<BoxCollider2D>();

        move();


    }

    private void move()
    {
        arherRB.velocity = new Vector2(2, 0);
    }

    private void stop()
    {
        arherRB.velocity = new Vector2(0, 0);
    }


    void Update()
    {
        if (playerArcherHP < 1)
        {
            stop();
            anim.SetTrigger("archerDie");
            box2d.enabled = false;
            PhotonNetwork.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemyExplosion"))
        {
            playerArcherHP = 0;
        }
        if (other.CompareTag("archerstop"))
        {
            stop();
            anim.SetTrigger("archerIdle");
            StartCoroutine("rangeAtackRate");
        }

        if (other.CompareTag("enemymelee"))
        {
            stop();
            Debug.Log("Why this happen?");
            //StartCoroutine(rangeAtackRate());
            StartCoroutine("receviedDamage");
        }

        if (other.CompareTag("enemyArrow"))
        {
            playerArcherHP -= enemyArrowtakingDamage;
        }

        //if (other.CompareTag("enemysword"))
        //{

        //    StartCoroutine("receviedDamage");
        //}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("enemymelee"))
        {
            Debug.Log("Why this happen?");
            StopCoroutine("receviedDamage");
        }
    }

    IEnumerator rangeAtackRate()
    {
        yield return new WaitForSeconds(fireDelay);
        //anim.ResetTrigger("archerShoot");
        Instantiate(arrowObj, transform.position, arrowObj.rotation);
        anim.SetTrigger("archerShoot");
        
        
        
        StartCoroutine("rangeAtackRate");
    }

    IEnumerator receviedDamage()
    {
        yield return new WaitForSeconds(1);
        playerArcherHP -= 5;
        StartCoroutine("receviedDamage");
        
    }
}
