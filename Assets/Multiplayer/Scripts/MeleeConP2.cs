using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeConP2 : MonoBehaviour//, IPunObservable
{
    public int enemyMeleeHP = 10;
    //public int currentEnemyMeleeHP;
    public int enemyMeleeTakingDPS = 2;
    public int enemyArrowtakingDamage = 4;

    public bool isDeadP2 = false;

    public static Transform meleeSoldier;
    private Rigidbody2D enemyMeleeRB;
    private Animator anim;
    private BoxCollider2D box2d;
    //public HealthBar healthBarMelee;

    //private bool enemyKilled = false;
    private bool isSiege = false;

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        stream.SendNext(isDeadP2);
    //    }
    //    else
    //    {
    //       isDeadP2 = (bool) stream.ReceiveNext();
    //    }
    //}


    void Start()
    {
        //currentEnemyMeleeHP = enemyMeleeHP;
        //healthBarMelee.SetMaxHealth(enemyMeleeHP);
        //healthBar.SetMaxHealth(100);

        enemyMeleeRB = GetComponent<Rigidbody2D>();
        anim  = GetComponent<Animator>();
        box2d = GetComponent<BoxCollider2D>();
        
        move();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemyMeleeHP < 1)
        {
            isDeadP2 = true;
            stop();
            anim.SetTrigger("die");
            box2d.enabled = false;
            this.GetComponent<PhotonView>().RPC("Destroy", RpcTarget.AllBuffered);
            //PhotonNetwork.Destroy(gameObject);
        }
    }

    


    private void move()
    {
        enemyMeleeRB.velocity = new Vector2(-3, 0);
        //anim.SetTrigger("run");
        
    }

    private void stop()
    {
        enemyMeleeRB.velocity = new Vector2(0, 0);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("playerExplosion"))
        {
            enemyMeleeHP = 0;
        }

        if (other.CompareTag("ourmelee"))
        {
            Debug.Log("Player HIT!");
            stop();
            anim.SetTrigger("attack");

            //Debug.Log("EnemyHP: " + enemyHP);
            StartCoroutine("receviedDamage");
       
        }

        //if (other.CompareTag("ourcastle"))
        //{
        //    stop();
        //    anim.SetTrigger("attack");
        //    //StartCoroutine(castleDamage());
        //    isSiege = true;
        //}

        if (other.CompareTag("siegepoint"))
        {
            stop();
            anim.SetTrigger("attack");
            //StartCoroutine(castleDamage());
            isSiege = true;
        }





        if (other.CompareTag("ourarcher"))
        {
            anim.SetTrigger("attack");
            stop();
   
        }
        

        if (other.CompareTag("ourarrow"))
        {
            enemyMeleeHP -= enemyArrowtakingDamage;
            //Debug.Log("EnemyHP: " + enemyMeleeHP);
        }
        
    }

    

    

    private void OnTriggerExit2D(Collider2D other)
    {

        if (!isSiege)
        {
            if (other.CompareTag("ourmelee"))
            {
                //Debug.Log("OUT FROM TRIGGER!");
                
                StopCoroutine("receviedDamage");
                
                anim.ResetTrigger("attack");
                anim.SetTrigger("run");
                move();
            }

            if (other.CompareTag("ourarcher"))
            {
                anim.SetTrigger("run");
                move();
            }
        }
        
    }

    





    IEnumerator receviedDamage()
    {
        yield return new WaitForSeconds(1);
        
        enemyMeleeHP -= enemyMeleeTakingDPS;
       
        StartCoroutine("receviedDamage");

        //Debug.Log("EnemyHP: " + enemyMeleeHP);
    }
}
