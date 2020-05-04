using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeConP1 : MonoBehaviour, IPunObservable
{
    public int playerMeleeHP = 10;
    public int meleeTakingDPS = 2;
    public int enemyArrowtakingDamage = 4;

    public bool isDeadP1 = false;

    private Rigidbody2D meleeRB;
    private Animator anim;
    private BoxCollider2D box2d;
    //private bool enemyKilled = false;
    private bool isSiege = false;


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(isDeadP1);
        }
        else
        {
            isDeadP1 = (bool)stream.ReceiveNext();
        }
    }

    void Start()
    {
        meleeRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box2d = GetComponent<BoxCollider2D>();
        move();
        
    }

    private void move()
    {
        meleeRB.velocity = new Vector2(3, 0);
        
    }

    private void stop()
    {
        meleeRB.velocity = new Vector2(0, 0);
    }

    
    void Update()
    {
        
        if (playerMeleeHP < 1)
        {
            stop();
            anim.SetTrigger("die");
            box2d.enabled = false;
            //PhotonNetwork.Destroy(gameObject);
            
        }
        

    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("enemyExplosion"))
        //{
        //    Destroy(gameObject);
        //}

        if (other.CompareTag("enemymelee"))
        {
            //Debug.Log("Enemy HIT!");
            stop();
            //enemyKilled = false;
            anim.SetTrigger("attack");
            StartCoroutine("receviedDamage");
        }

        if (other.CompareTag("enemyArcher"))
        {
            anim.SetTrigger("attack");
            stop();

        }

        if (other.CompareTag("enemycastle"))
        {
            isSiege = true;
            stop();
            anim.SetTrigger("attack");
            StartCoroutine("castleDamage");
            
        }

        if (other.CompareTag("enemyArrow"))
        {
            playerMeleeHP -= enemyArrowtakingDamage;
        }

    }

    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!isSiege)
        {
            if (other.CompareTag("enemymelee"))
            {
                StopCoroutine("receviedDamage");
                //enemyKilled = true;
                anim.ResetTrigger("attack");
                anim.SetTrigger("run");
                move();

            }

            if (other.CompareTag("enemyArcher"))
            {
                anim.SetTrigger("run");
                move();

            }
        }
        
       
    }


    IEnumerator castleDamage()
    {
        yield return new WaitForSeconds(1);
        //GameFlow.enemyCastleHP -= 5;
        StartCoroutine("castleDamage");
        
        //Debug.Log(GameFlow.enemyCastleHP);
    }

   

    IEnumerator receviedDamage()
    {

        yield return new WaitForSeconds(1);
        
        //if (enemyKilled == true)
        //{
        //    StopCoroutine(receviedDamage());
              
        //}
        
        playerMeleeHP -= meleeTakingDPS;
        StartCoroutine("receviedDamage");
        Debug.Log("PlayerHP: " + playerMeleeHP);
    }
}
